<?php
/* PHP Doc y.s.
*/
	$mysql = new SaeMysql();
	$return = '';
	
	$sql = 
		"select count(*) from `User` ".
		"where `UserName` = '".$mysql->escape($_POST['UserName'])."' ".
		"and `Password` = '".$mysql->escape($_POST['Password'])."' limit 1";
	$data = $mysql->getData($sql);
	
	$has_authority = $data[0]['count(*)'] == 1;
	
	if($has_authority)
	{
		// Remove the same item first.
		$sql = "delete from `Arrow` where ".
			"`GUID` = '".$mysql->escape($_POST['GUID'])."' and ".
			"`UserName` = '".$mysql->escape($_POST['UserName'])."';";
		$mysql->runSql($sql);
		
		// Insert new item.
		$sql =
			"insert into `Arrow` (`Name`,`Cmd`,`Arg`,`Tag`,`HotKey`,`Enabled`,`Timestamp`,`GUID`,`UserName`,`DateTime`,`DownloadCount`) ".
			"value(".
				"'".$mysql->escape($_POST['Name'])."',".
				"'".$mysql->escape($_POST['Cmd'])."',".
				"'".$mysql->escape($_POST['Arg'])."',".
				"'".$mysql->escape($_POST['Tag'])."',".
				"'".$mysql->escape($_POST['HotKey'])."',".
				"'".$mysql->escape($_POST['Enabled'])."',".
				"'".$mysql->escape($_POST['Timestamp'])."',".
				"'".$mysql->escape($_POST['GUID'])."',".
				"'".$mysql->escape($_POST['UserName'])."',".
				"now(),".
				"0);"
		;
		$mysql->runSql($sql);	
		if($mysql->errno() != 0)
		{	
			$return .= 'server_failed';
		}	
		else
			$return .= 'server_done';
	}
	else
		$return .= 'auth_error';
	
	echo $return;
	
	$mysql->closeDb();
	
?>