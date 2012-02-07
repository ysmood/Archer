<!DOCTYPE html>
<html>
	<head>
		<link type="text/css" href="../css/smoothness/jquery-ui.css" rel="stylesheet" />	
		<script type="text/javascript" src="../js/jquery.js"></script>
		<script type="text/javascript" src="../js/jquery-ui.js"></script>
	
		<script type="text/JavaScript" src="../js/y.s.fx.js"></script>
		
		<style>
			body				{ font-family: Arial, SimSun; background-color: #eee; margin: 0; padding: 0; }
			a					{ text-decoration: none; margin: 0 2px; border-bottom: 2px solid #ddd; color: #297DB5; vertical-align: middle; cursor: pointer; }
			a:hover				{ border-bottom: 2px solid #297DB5; }
			label				{ font-size: 14px; color: #666; }
			input[type=submit]	{ font-size: 15px; margin-left: 200px; }
			input[type=text]	{ color: #666; font-size:18px; width: 260px; border: 1px solid #ccc; border-radius: 3px; background-color: #fafafa; padding: 5px; }
			form				{ margin: 10px auto; width: 300px; padding: 10px; background-color: #fff; border-radius: 8px; box-shadow: 0px 4px 10px -1px rgba(200,200,200,0.7); text-align: left; }
			#main_title			{ margin-top: 30px; font-size: 24px; color: #333; font-family: Georgia; }
			div.row				{ padding: 8px; }
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
			#center
			{
				text-align: center;
			}
		</style>
		
		<script type="text/javascript">
			$(function()
				{
					var Room = ys.cookier.get('Room');
					var Interval = ys.cookier.get('Interval');
					var Offset = ys.cookier.get('Offset');
					if(Room != null)
						$('input[name="r"]').val(Room);
					if(Interval != null)
						$('input[name="i"]').val(Interval);
					if(Offset != null)
						$('input[name="o"]').val(Offset);
					
					if(!($.browser.msie && $.browser.version < 8))
					{
						$('input:submit').button();
					}
					$('input[name="r"]').select().focus();
				}
			);
		</script>
		<title>Archer Pebble</title>
	</head>
<body>
	<div id="top">
		<a href="../">Archer Home</a> &gt;&gt; <a href="./">Pebble</a>
	</div>
	<div id="center">
		<div id="main_title">Pebble</div>
		<form action="./" method="get">
			<div class="row">
				<label>Room Name</label><br>
				<input name="r" type="text" value="help"/>
			</div>
			<div class="row">
				<label>Update Interval (millisecond)</label><br>
				<input name="i" type="text" value="1000"/>
			</div>
			<div class="row">
				<label>Thread Offset</label><br>
				<input name="o" type="text" value="0"/>
			</div>
			<input type="submit" value="Enter"/>
		</form>
	</div>
</body>
</html>


