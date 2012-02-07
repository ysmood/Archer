<?php
/* PHP Doc y.s.
*/

// ***** Main *****

	session_start();
	
	$return = '';
	
	if(isset($_POST['Password']))
	{
		$mysql = new SaeMysql();
		
		$sql = sprintf(
			"select count(*) from `User` where `UserName` = '%s' and `Password` = '%s'",
			$mysql->escape($_POST['UserName']),
			md5($_POST['Password'])
		);
		$data = $mysql->getData($sql);
		
		$exists = $data[0]['count(*)'] == 1;
		
		if($mysql->errno() != 0)
		{
			$return .= 'server_failed';
		}
		else if($exists)
		{			
			$_SESSION['UserName'] = $_POST['UserName'];
			
			$return = 'server_done';
		}
		else
		{
			$return = 'auth_error';
		}
		$mysql->closeDb();
	}
	else
	{
		session_destroy();
		header('location:'.$_GET['url']);
	}
	
	echo $return;
	
// ***** Subfunction *****
	
?>