<?php
	session_start();
	
	if(array_key_exists('file',$_FILES))
	{
		$return = '';
		if ($_FILES['file']['error'] > 0)
		{
			$return .= 'Error: ' . $_FILES['file']['error'] . '<br />';
		}
		else
		{
			$s = new SaeStorage();

			$hash = hash_file('md5', $_FILES['file']['tmp_name']);
			$file_name = $hash.'.'.pathinfo($_FILES['file']['name'], PATHINFO_EXTENSION);
			$s->upload('dict', $file_name, $_FILES['file']['tmp_name']);
			
			$return .= $s->getUrl('dict', $file_name);
			
			$return = "<a id=\"file_url\" href=\"$return\">$return</a><br /><input type=\"text\" value=\"$return\" />";
		}
	}
?>

<!DOCTYPE html>
<html>
	<head>
		<link type="text/css" href="../css/smoothness/jquery-ui.css" rel="stylesheet" />	
		<script type="text/javascript" src="../js/jquery.js"></script>
		<script type="text/javascript" src="../js/jquery-ui.js"></script>
		
		<style>
			body				{ font-family: Arial, SimSun; background-color: #eee; margin: 0; padding: 0; }
			a					{ text-decoration: none; margin: 0 2px; border-bottom: 2px solid #ddd; color: #297DB5; vertical-align: middle; cursor: pointer; }
			a:hover				{ border-bottom: 2px solid #297DB5; }
			label				{ font-size: 14px; color: #666; }
			input[type=submit]	{ font-size: 14px; margin: 5px; }
			input[type=file]	{ color: #666; font-size: 14px; width: 260px; border: 1px solid #ccc; border-radius: 4px; background-color: #fafafa; padding: 5px; }
			input[type=text]	{ color: #333; font-size: 12px; width: 360px; border: 1px solid #ccc; border-radius: 4px; background-color: #fafafa; padding: 5px; margin-top: 10px; }
			form				{ margin: 10px auto; width: 400px; padding: 20px; background-color: #fff; border-radius: 8px; box-shadow: 0px 4px 10px -1px rgba(200,200,200,0.7); text-align: left; }
			#main_title			{ margin-top: 30px; font-size: 24px; color: #333; font-family: Georgia; }
			#top
			{
				padding: 10px;
				background: url(../img/bg_navibar.png) repeat-x 0 0;
				border-bottom: 1px solid #aaa;
				width: 100%;
				height: 100%;
				font-family: Georgia;
				font-size: 14px;
				color: #333;
			}
			#top span.tool_strip
			{
				margin-left: 30px;
			}
			#top span.tool_strip *
			{
				font-size: 10px;
			}
			#center
			{
				text-align: center;
			}
			#file_url
			{
				font-size: 12px;
			}
		</style>
		
		<script type="text/javascript">
			$(function()
				{
					$('input:submit, button, input:button').button();
					$('input:text').focus(function(){ $(this).select(); });
					$('input:text').focus();
				}
			);
			
			function uploading()
			{
				$('form').prepend("<h5>Uploading...</h5>");
			}
		</script>
		<title>Archer Upload File</title>
	</head>
<body>
	<div id="top">
		<a href="../">Archer Home</a> &gt;&gt; <a href="./">Upload File</a>
		<span class="tool_strip">
			<?php if(isset($_SESSION['UserName'])) echo '<span class="UserName">'.$_SESSION['UserName'].'</span> <a id="logout" href="../login.php?url='.urlencode($_SERVER['REQUEST_URI']).'">Logout</a>'; ?>
		<span>
	</div>
	<div id="center">
		<form action="./" method="post" enctype="multipart/form-data" onsubmit="uploading();">
			<?= $return ?>
			<div>
				<label for="file">File : </label>
				<input type="file" name="file" id="file" />
				<input type="submit" name="submit" value="Upload"/>
			</div>
		</form>
	</div>
</body>
</html>
