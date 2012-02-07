<?

    if(!array_key_exists('p', $_GET))
    {
        header('location:enter.php');
    }
    
    if($_GET['p'] == '0')
    {
        $player = 'Blue';
    }
    else
    {
        $player = 'Red';
        $_GET['p'] = 1;
    }
?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<link rel="stylesheet" href="css/default.css" type="text/css"/>
	<script type="text/JavaScript" src="js/jquery.js"></script>
	<script type="text/JavaScript" src="js/main.js"></script>
	<title>Plus Game</title>
</head>
<body>
    <div id="display" player="<?= $_GET['p'] ?>">
        Player <?= $player ?> : 
        <span id="state">your turn</span>
    </div>
	<div id="main">
		<div id="num_0" class="num" mark="0"><div class="clicked"></div></div>
		<div id="num_1" class="num" mark="0"><div class="clicked"></div></div>
		<div id="num_2" class="num" mark="1"><div class="clicked"></div></div>
		<div id="num_3" class="num" mark="1"><div class="clicked"></div></div>
		<div id="selected"></div>
	</div>
	<!--[if IE 6]>
	<script type="text/javascript" src="http://letskillie6.googlecode.com/svn/trunk/letskillie6.pack.js"></script>
	<![endif]-->
</body>
</html>