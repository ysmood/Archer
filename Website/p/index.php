<?php
/* PHP Doc 0.1 y.s.
*/	
	session_start();
	
 	$mysql = new SaeMysql();
	
	if(!array_key_exists('r', $_GET) || $_GET['r'] == '')
	{
		include('room_entrance.php');
		return;
	}
	else
	{
		$room = $_GET['r'];
		$sql_room = $mysql->escape($room);
	}
		
	if(array_key_exists('i', $_GET))
		$interval = (int)$_GET['i'] < 1000 ? 1000 : (int)$_GET['i'];
	else
		$interval = 1000;
	
	if(array_key_exists('o', $_GET))
		$offset = $_GET['o'];
	else
		$offset = 0;
	
	$sql = sprintf("select * from `Pebble` where `Room` = '%s' order by `ID` desc limit %s,30",
		$sql_room,
		(int)$offset
	);
	$msg_data = $mysql->getData($sql);
	
	if($msg_data == null)
	{
		$msg_data = array(
			0 => array(
				'ID' => '0',
				'UserName_MD5' => 'a8ec4208d0b7ef9a6c2d1f3a1bcb80b1',
				'UserName' => 'archer_server@sina.com',
				'DateTime' => date("Y-m-d H:i:s"),
				'HTTP_USER_AGENT' => '',
				'Body' => '<h4>Welcome to Pebble.</h4>'
			)
		);
		
		// Create a new room.
		if($mysql->getVar("select count(*) from `Pebble_Manager` where `Room` = '$sql_room'") == 0)
			$mysql->runSql("insert into `Pebble_Manager` (`Room`) value ('$sql_room')");
	}
	
	$mysql->closeDb();
?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<link rel="icon" href="../favicon.ico" />
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	
	<link rel="stylesheet" href="css/main.css" type="text/css" />
	
	<link rel="stylesheet" href="../js/code-prettify/prettify.css" type="text/css"/>
	<script type="text/javascript" src="../js/code-prettify/prettify.js"></script>
	
	<script type="text/JavaScript" src="../js/jquery.js"></script>

	<script type="text/javascript" src="../js/markitup/jquery.markitup.js"></script>
	<script type="text/javascript" src="../js/markitup/sets/default/set.js"></script>
	<link rel="stylesheet" type="text/css" href="../js/markitup/skins/markitup/style.css" />
	<link rel="stylesheet" type="text/css" href="../js/markitup/sets/default/style.css" />
	
	<link type="text/css" href="../css/smoothness/jquery-ui.css" rel="stylesheet" />	
	<script type="text/javascript" src="../js/jquery-ui.js"></script>
	
	<link rel="stylesheet" href="../css/jquery.bubblePopup.css" type="text/css" />
	<script type="text/JavaScript" src="../js/jquery.bubblePopup.js"></script>
	
	<script type="text/JavaScript" src="../js/jquery.highlight.js"></script>
	
	<script type="text/JavaScript" src="../js/y.s.fx.js"></script>

	<script type="text/JavaScript" src="js/main.js"></script>
	
	<title>Archer Pebble - <?= $room ?></title>
</head>
<body login="<?php if(isset($_SESSION['UserName'])) echo 'true'; else echo 'false'; ?>">
	<div id="main">
		<div id="top">
			<a href="../">Archer Home</a> &gt;&gt; <a href="./">Pebble</a> &gt;&gt; 
			<?= "Room : <a href=\"#\">$room</a>" ?>
			<span class="tool_strip">
				<input id="show_hide_msgbox" type="checkbox"/><label for="show_hide_msgbox">Message Box</label>
				<input id="upload_file" type="button" value="Upload File" onclick="window.open('../u/')" title="Max file size is 10M"/>
				<input id="room_manager" type="button" value="Manager"/>
				<?php if(isset($_SESSION['UserName'])) echo '<span class="UserName">'.$_SESSION['UserName'].'</span> <a id="logout" href="../login.php?url='.urlencode($_SERVER['REQUEST_URI']).'">Logout</a>'; ?>
			</span>
		</div>
		<div id="center">
			<form id="msg_form" onsubmit="return false;">
				<input class="UserName" type="text" value="E-mail here, supports Gravatar" title="E-mail here, supports Gravatar"/>
				<input type="checkbox" id="msg_float_check" /><label for="msg_float_check">Float</label>
				<input type="checkbox" id="msg_float_lock" /><label for="msg_float_lock">Lock</label>
				<input type="submit" value="Send"/><br/>
				<textarea id="markItUp" cols="40" rows="10">Any html content is allowed. Have fun here.</textarea>
			</form>
			<div id="msg_list" offset="<?= $offset;?>" interval="<?= $interval;?>" room="<?= $room ?>">
			<?php foreach($msg_data as $msg): ?>
				<div class="msg" msg_id="<?= $msg['ID']?>">
					<img class="avatar" src="<?= 'http://www.gravatar.com/avatar/'.$msg['UserName_MD5'].'?s=32'?>"/>
					<div class="UserName"><?= $msg['UserName']?></div>
					<div class="DateTime"><?= $msg['DateTime'].' IP:'.$msg['IP'].' '.$msg['HTTP_USER_AGENT']?></div>
					<div class="Body"><?= $msg['Body']?></div>
				</div>
				<div class="hr"></div>
			<?php endforeach; ?>
			</div>
		</div>
		<div id="bottom">
			<div class="footer">
				<div class="copyright">May 2011 - y.s.</div>
			</div>
		</div>
	</div>
	
	<form id="manager_form" onsubmit="return false;" title="Manager">
		<table>
			<tr>
				<td>
					<label for="Locked">Locked</label>
					<input id="Locked" type="checkbox" checked="true"/>
				</td>
				<td>
					<label for="Delete">Delete</label>
					<input id="Delete" type="checkbox"/>
					<input type="submit" value="Submit"/>
				</td>
			</tr>
		</table>
	</form>
	
	<form id="login_form" onsubmit="return false;" title="Login">
		<table>
			<tr>
				<td>User Name : </td>
				<td><input id="UserName" type="text"/></td>
			</tr>
			<tr>
				<td>Password : </td>
				<td><input id="Password" type="password"/></td>
			</tr>
			<tr>
				<td></td>
				<td>
					<input type="submit" value="Login"/>
				</td>
			</tr>
		</table>
	</form>
	<!--[if IE 6]>
	<script type="text/javascript" src="http://letskillie6.googlecode.com/svn/trunk/letskillie6.pack.js"></script>
	<![endif]-->
</body>
</html>