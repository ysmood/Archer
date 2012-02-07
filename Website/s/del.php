<?php	
	$mysql = new SaeMysql();
	
	$sql = 
		"select `Super` from `User` ".
		"where `UserName` = '".$mysql->escape($_POST['UserName'])."' ".
		"and `Password` = '".$mysql->escape($_POST['Password'])."' limit 1"
	;
	$data = $mysql->getData($sql);
	$has_authority = count($data) == 1;
	
	if($has_authority)
	{
		$super_user = $data[0]['Super'] == 1;
		if($super_user)
		{
			$sql = "select count(*) from `Arrow` where ".
					"`GUID` = '".$mysql->escape($_POST['GUID'])."' and ".
					"`DateTime` = '".$mysql->escape($_POST['DateTime'])."' ";
		}
		else
		{
			$sql = "select count(*) from `Arrow` where ".
					"`UserName` = '".$mysql->escape($_POST['UserName'])."' and ".
					"`GUID` = '".$mysql->escape($_POST['GUID'])."' and ".
					"`DateTime` = '".$mysql->escape($_POST['DateTime'])."' ";
		}
		
		$data = $mysql->getData($sql);
		$exists = $data[0]['count(*)'] == 1;
		if($exists)
		{
			$sql = "delete from `Arrow` where ".
				"`GUID` = '".$mysql->escape($_POST['GUID'])."' and ".
				"`DateTime` = '".$mysql->escape($_POST['DateTime'])."' ";
			$mysql->runSql($sql);
			
			if($mysql->errno() != 0)
			{	
				$return = 'server_failed';
			}	
			else
				$return = 'server_done';
		}
		else
		{
			$return = "Item doesn't exist. Or you don't have the authority to delete: normal user can't delete other user's sharing.";
		}
	}
	else
	{
		$return = 'auth_error';
	}
	
	echo $return;
?>