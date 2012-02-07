<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Archer Reset Password</title>
	<link rel="icon" href="../favicon.ico" />
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<link rel="stylesheet" href="css/main.css" type="text/css" />
	<link rel="stylesheet" href="css/reset.css" type="text/css" />
	<link rel="stylesheet" href="../css/bubblepopup.css" type="text/css" />
	<script type="text/JavaScript" src="../js/jquery.js"></script>
	<script type="text/JavaScript" src="../js/bubblePopup.js"></script>
	<script type="text/JavaScript">
		$(window).ready(
			function()
			{
				bg_animation();
				
				$("#email").change(checkEmail);
				
				$('#submit').click(Reset);
			}
		);
		
		function bg_animation()
		{
			var backgroundPositionX = 0;
			setInterval(function()
				{
					$('#main').css({ backgroundPosition:backgroundPositionX++ + 'px 0' });
				},
				50
			);
			$('#main').fadeIn('slow');
		}
		
		function checkEmail()
		{
			var email = $('#email').val();
			var r;
			var lb = $('#email').next();
			lb.css('color', 'red');			
			
			var emailRegExp = new RegExp("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
			if (!emailRegExp.test(email)||email.indexOf('.')==-1)
				r = 'X';
			else
			{
				r = 'O';
				lb.css('color', '#36EB2A');
			}
			
			lb.text(r);
			
			return r;
		}
		
		function Reset()
		{
			if(checkEmail() == 'O')
			{
				$('#submit').prop('disabled', true);
				$.post(
					'register.php',
					{
						'recaptcha_challenge_field': $('#recaptcha_challenge_field').val(),
						'recaptcha_response_field': $('#recaptcha_response_field').val(),
						'Type': 'Reset',
						'UserName': $('#email').val()
					},
					function(data)
					{
						switch(data)
						{
							case 'server_done':
								$('#reset_form').fadeOut('slow',
									function()
									{
										$('#reset_form').empty().css('background', 'none');
										$('#reset_form').append('<img src="img/reset-mail-sended.png"/>');
										$('#reset_form').fadeIn('slow');
									}
								);
								break;
								
							case 'server_failed':
								alert('Server Error, please try again.');
								$('#submit').prop('disabled', false);
								break;
								
							case 'recaptcha_fail':
								alert("The reCAPTCHA wasn't entered correctly. Go back and try it again.");
								$('#submit').prop('disabled', false);
								break;
								
							default:
								alert(data);
								$('#submit').prop('disabled', false);
								break;
						}
					}
				);
			}
		}
	</script>
</head>
<body>
	<div id="main">
		<div id="top">
			<a class="home" href="../">Archer Home</a>
		</div>
		<div id="center">
			<div id="reset_form">
				<div class="row">
					<div class="label">Email:</div>
					<input id="email" type="text" value=""/>
					<div class="state"></div>
					<script type="text/JavaScript">SetPopup("#email","A reset mail will be send to you.");</script>
				</div>
				<script type="text/javascript">
					var RecaptchaOptions = { theme : 'white' };
				</script>
				<?php
					require_once('recaptchalib.php');
					$publickey = "6LekDMcSAAAAAOI5sTT_qx3R7Qurm6dwt_rovG8A"; // you got this from the signup page
					echo recaptcha_get_html($publickey);
				?>
				<div>
					<button id="submit">Reset</button>
				</div>
			</div>
		</div>
		<div id="bottom">
			<div class="footer">
				<div class="copyright">May 2011 - y.s.</div>
			</div>
		</div>
		<div id="outerFrame">
		</div>
	</div>
	<!--[if IE 6]>
	<script type="text/javascript" src="http://letskillie6.googlecode.com/svn/trunk/letskillie6.pack.js"></script>
	<![endif]-->
</body>
</html>