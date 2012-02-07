<?php
/* PHP Doc y.s.
*/

/*
	Response Type:
		server_failed
		server_done
		bad_request
		auth_error
*/

	$mysql = new SaeMysql();
	
	$sql = 
		"select count(*) from `User` ".
		"where `UserName` = '".$mysql->escape($_POST['UserName'])."' ".
		"and `Password` = '".$mysql->escape($_POST['Password'])."' limit 1"
	;
	$data = $mysql->getData($sql);
	
	$has_authority = $data[0]['count(*)'] == 1;
	
	if($has_authority)
	{
		switch($_POST['Type'])
		{
			case 'Backup':
				$sql =
					"update `User` set `UserData` = '".$mysql->escape($_POST['UserData']).
					"' where `UserName` = '".$mysql->escape($_POST['UserName'])."' limit 1"
				;
				$mysql->runSql($sql);	
				if($mysql->errno() != 0)
				{
					$return = 'server_failed';
				}	
				else
					$return = 'server_done';
				break;
				
			case 'Recovery':
				$sql =
					"select `UserData` from `User` where `UserName` = '".$mysql->escape($_POST['UserName'])."'"
				;
				$userData = $mysql->getData($sql);
				if($mysql->errno() != 0)
				{
					$return = 'server_failed';
				}	
				else
					$return = $userData[0]['UserData'];
				break;
				
			case 'ChangePassword':
				$sql =
					"update `User` set `Password` = '".$mysql->escape($_POST['NewPassword']).
					"' where `UserName` = '".$mysql->escape($_POST['UserName'])."' limit 1"
				;
				$mysql->runSql($sql);
				if($mysql->errno() != 0)
				{
					$return = 'server_failed';
				}	
				else
					$return = 'Password Changed';
				break;
			
			default:
				$return = 'bad_request';
				break;
		}
	}
	else
		$return = 'auth_error';
	
	echo $return;
	
	$mysql->closeDb();
?>