<?php
/* PHP Doc y.s.
*/

// ***** Main *****

	session_start();
	
	if($_POST['Room'] != ''
		&& $_SESSION['UserName'] != ''
		&& $_POST['Room'] != '')
	{
		echo SetRoomState();
	}
	else
		echo 'empty_error';

// ***** Subfunction *****

function SetRoomState()
{
	$mysql = new SaeMysql();
	
	$sql = sprintf(
		"select count(*) from `User` where `UserName` = '%s' and `Authenticated` = 1",
		$mysql->escape($_SESSION['UserName'])
	);
	$data = $mysql->getData($sql);
	$has_authority = $data[0]['count(*)'] == 1;
	
	if($has_authority)
	{
		if($_POST['Delete'] == 'true')
		{
			$sql = sprintf(
				"delete from `Pebble` where `Room` = '%s'",
				$mysql->escape($_POST['Room'])
			);
			$mysql->runSql($sql);
			
			$sql = sprintf(
				"delete from `Pebble_Manager` where `Room` = '%s'",
				$mysql->escape($_POST['Room'])
			);
		}
		else
		{
			$sql = sprintf(
				"update `Pebble_Manager` set `Locked` = %s where `Room` = '%s'",
				$_POST['Locked'],
				$mysql->escape($_POST['Room'])
			);
		}
	
		
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
		$return .= "auth_error";
	}
	
	$mysql->closeDb();
	
	return $return;
}

?>