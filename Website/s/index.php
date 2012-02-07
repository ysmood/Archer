<?php
/* PHP Doc y.s.
*/
	include_once('get.php');
	
	$num_perpage = 10;
	$page = 1;
	$search_keyword = '';
	
	if(array_key_exists('search', $_GET) && $_GET['search'] != '')
	{
		$total = (int)count_row(urldecode($_GET['search']));
		$total_page = (int)(($total - 1) / $num_perpage + 1);
		
		if(array_key_exists('page', $_GET))
			$page = (int)$_GET['page'];
		else
			 $page = 1;
		$offset = $num_perpage * ($page - 1);
		$offset = $offset > $total ? $total : $offset;
		
		$search_keyword = urldecode($_GET['search']);
		$data = get_page($offset, $num_perpage, $search_keyword);
		
		$page_indicator = 
			'<a href="?page='.($page - 1 > 0 ? $page - 1 : 1).'&search='.$_GET['search'].'">Previous</a> '.
			$page.'/'.$total_page.
			' <a href="?page='.($page + 1 < $total_page ? $page + 1 : $total_page).'&search='.$_GET['search'].'">Next</a> '
		;
	}
	else if(array_key_exists('page', $_GET))
	{
		$total = (int)count_row();
		$total_page = (int)(($total - 1) / $num_perpage + 1);
		
		$page = (int)$_GET['page'];
		$offset = $num_perpage * ($page - 1);
		$offset = $offset > $total ? $total : $offset;
		$data = get_page($offset, $num_perpage);
		
		$page_indicator = 
			'<a href="?page='.($page - 1 > 0 ? $page - 1 : 1).'">Previous</a> '.
			$page.'/'.$total_page.
			' <a href="?page='.($page + 1 < $total_page ? $page + 1 : $total_page).'">Next</a> '
		;
	}
	else
	{
		$total = (int)count_row();
		$total_page = (int)(($total - 1) / $num_perpage + 1);
		$data = get_page(0, $num_perpage);
		
		$page_indicator = 
			'<a href="?page=1">Previous</a> '.
			'1/'.$total_page.
			' <a href="?page=2">Next</a> '
		;
	}
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Archer Script Store</title>
	<link rel="icon" href="../favicon.ico" />
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	
	<link rel="stylesheet" href="../js/code-prettify/prettify.css" type="text/css"/>
	<script type="text/javascript" src="../js/code-prettify/prettify.js"></script>
	
	<script type="text/JavaScript" src="../js/jquery.js"></script>
	
	<link rel="stylesheet" href="../css/jquery.bubblePopup.css" type="text/css" />
	<script type="text/JavaScript" src="../js/jquery.bubblePopup.js"></script>
	
	<script type="text/JavaScript" src="../js/jquery.corner.js"></script>
	<script type="text/JavaScript" src="../js/jquery.corner.js"></script>
	
	<script type="text/JavaScript" src="../js/jquery.highlight.js"></script>
	
	<link rel="stylesheet" href="css/main.css" type="text/css" />
	<script type="text/JavaScript" src="js/main.js"></script>
</head>
<body onload="prettyPrint()">
	<div id="main">
		<div id="top">
			<div class="navigator">
				<a href="http://archer.sinaapp.com/">Archer Home</a> &gt;&gt; <a href="index.php">Script Store</a> &gt;&gt; 
				<?php echo " $total arrows &gt;&gt; Page: $page_indicator"; ?> 
				<span class="goto_page"> <input value="1"/> <a href="?page=1&search=<?php echo $search_keyword; ?>">Go</a></span>
				<span class="search">
					<input value="<?php echo $search_keyword; ?>"/> <a href="#">Search</a>
				</span>
			</div>
		</div>
		<div id="center">
		<?php
			if($data == null)
			{
				echo '<p style="margin: 30px; font-size: 20px;">No more items</p>';
			}
			else
			{
				function get_row($name, $Name, $value)
				{
					if($value != '')
					{
						if($name == 'cmd')
						{
							return
								'<div class="row '.$name.'">
									<div class="name float_left">'.$Name.': </div>
									<div class="value"><pre class="prettyprint linenums">'.$value.'</pre></div>
								</div>';
						}
						else
						{
							return
								'<div class="row '.$name.'">
									<div class="name float_left">'.$Name.': </div>
									<div class="value">'.$value.'</div>
								</div>';
						}
					}
					else
						return '';
				}
				
				foreach ($data as $arrow)
				{
					foreach ($arrow as $key => &$value)
					{
						if($key == 'Cmd')
							$value = htmlspecialchars($value);
						else if($key != 'GUID')
							$value = nl2br(htmlspecialchars($value));
					}
					
					echo
					'<div class="arrow" guid="'.$arrow['GUID'].'">
						<div class="btn_add float_right"><img src="img/add.png"/></div>
						<div class="btn_delete float_right"><img src="img/delete.png"/></div>'.
						get_row('name', 'Name', $arrow['Name']).
						get_row('tag', 'Tag', $arrow['Tag']).
						get_row('user', 'User', $arrow['UserName']).
						get_row('arg', 'Arg', $arrow['Arg']).
						get_row('hotkey', 'HotKey', $arrow['HotKey']).
						get_row('count', 'Count', $arrow['DownloadCount']).
						get_row('upload_date', 'Date', $arrow['DateTime']).
						get_row('cmd', 'Cmd', $arrow['Cmd']).
					'</div>';
				}
			}
		?>
		</div>
		<div id="bottom">
			<div class="footer">
				<div class="copyright">May 2011 - y.s.</div>
			</div>
		</div>
	</div>
</body>
</html>