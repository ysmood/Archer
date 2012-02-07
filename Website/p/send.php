<?php
/* PHP Doc y.s.
*/
	session_start();

	$return = '';

 	$mysql = new SaeMysql();
	
	// Check room state
	$sql = sprintf(
		"select count(*) from `Pebble_Manager` where `Room` = '%s' and `Locked` = 1",
		$mysql->escape($_POST['Room'])
	);
	$locked = $mysql->getData($sql);
	
	if($locked[0]['count(*)'] != 1)
	{
		if($_POST['ID'] == '')
		{
			// Insert new item.
			$sql = sprintf(
				"insert into `Pebble` (`Room`, `UserName`, `UserName_MD5`, `Body`, `IP`, `HTTP_USER_AGENT`) value ('%s', '%s', '%s', '%s', '%s', '%s')",
				$mysql->escape($_POST['Room']),
				$mysql->escape($_POST['UserName']),
				md5(strtolower(trim($_POST['UserName']))),
				$mysql->escape($_POST['Body']),
				$mysql->escape($_SERVER['REMOTE_ADDR']),
				$mysql->escape($_SERVER['HTTP_USER_AGENT'])
			);
			$mysql->runSql($sql);
			if($mysql->errno() != 0)
			{	
				$return .= 'server_failed';
			}	
			else
				$return .= 'server_done';
		}
		else
		{			
			if(isset($_SESSION['UserName']))
			{
				// Change specified message.
				$sql = sprintf(
					"update `Pebble` set `Body` = '%s' where `ID` = '%s' and `UserName` = '%s'",
					$mysql->escape($_POST['Body']),
					(int)$_POST['ID'],
					$mysql->escape($_POST['UserName'])
				);
				$mysql->runSql($sql);
				if($mysql->errno() != 0)
				{	
					$return .= 'server_failed';
				}	
				else if($mysql->affectedRows() == 0)
				{
					$return .= 'auth_error';
				}
				else
					$return .= 'msg_changed';
			}
			else
			{
				$return .= 'auth_error';
			}
		}
	}
	else
	{
		$return .= 'room_locked';
	}
	
	$mysql->closeDb();
	
	echo json_encode($return);
?>