<?php

	require_once('recaptchalib.php');
	
	$privatekey = "6LekDMcSAAAAACzUvzUySeIXKJAfCxi8MRbXQ7mt";
	$resp = recaptcha_check_answer ($privatekey,
			$_SERVER["REMOTE_ADDR"],
			$_POST["recaptcha_challenge_field"],
			$_POST["recaptcha_response_field"]);
	if (!$resp->is_valid)
	{
		echo 'recaptcha_fail';
	}
	else
	{
		switch($_POST['Type'])
		{
			case 'Register':
				echo Register();
				break;
			case 'Reset':
				echo ResetPassword();
				break;
		}
		
	} 

/****** Subfunction ******/

function Register()
{
	$mysql = new SaeMysql();
	
	$sql = 
		"select `UserName` from `User` ".
		"where `UserName` = '".$mysql->escape($_POST['UserName'])."' limit 1";
	$data = $mysql->getData($sql);
	
	if(count($data) == 1)
	{
		$return = 'user_exists';
	}
	else
	{
		$sql = 
		"insert into `User` (`UserName`,`Password`) values ('".$mysql->escape($_POST['UserName'])."','".md5($_POST['Password'])."')";
		$data = $mysql->runSql($sql);
		
		if($mysql->errno() != 0)
		{	
			$return = 'server_failed';
		}	
		else
		{
			$title = "Archer Service";
			$content = "Thank you for registering Archer account.";
			SendMail($title, $content);
			$return = 'server_done';
		}
	}
	
	$mysql->closeDb();
	
	return $return;
}

function ResetPassword()
{
	$newPassword =  generate_password();

	$mysql = new SaeMysql();
	
	$sql =
		"update `User` set `Password` = '".md5($newPassword).
		"' where `UserName` = '".$mysql->escape($_POST['UserName'])."' limit 1"
	;
	$mysql->runSql($sql);
	if($mysql->errno() != 0)
	{
		$return = 'server_failed';
	}	
	else
	{
		$return = 'server_done';
		SendMail('Archer Reset Password', 'Your password has been reset to : '.$newPassword);
	}

	$mysql->closeDb();
	
	return $return;
}

function SendMail($title, $content)
{
	$mail = new SaeMail();
	$ret = $mail->quickSend(
		$_POST['UserName'],
		$title,
		$content,
		"archer_server@sina.com",
		"y.s.@archer"
	);
	if ($ret === false)
		echo var_dump($mail->errno(), $mail->errmsg());
}

function generate_password( $length = 32 )
{
	// 密码字符集，可任意添加你需要的字符
	$chars = 'abcSTUVWX`YZ01234*()-_defghopqrstu1$$v56sdf789!@#$%^&wxyzABCDEFGHIJKijklmnLMNOPQR[]{}<>~`+=,.;:/?|';
	$password = '';
	for ( $i = 0; $i < $length; $i++ ) 
	{
		// 这里提供两种字符获取方式
		// 第一种是使用 substr 截取$chars中的任意一位字符；
		// 第二种是取字符数组 $chars 的任意元素
		// $password .= substr($chars, mt_rand(0, strlen($chars) - 1), 1);
		$password .= $chars[ mt_rand(0, strlen($chars) - 1) ];
	}
	return $password;
}


?>