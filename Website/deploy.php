<?php

// ***** Main *****

	if(array_key_exists('r', $_GET))
	{
		switch($_GET['r'])
		{
			case 'a':
				$mysql = new SaeMysql();			
				$sql = "insert into `Deploy_Statistics` (`REMOTE_HOST`,`REQUEST_TIME`,`REMOTE_ADDR`,`HTTP_USER_AGENT`,`\$_SERVER`) values ('".
					$mysql->escape($_SERVER['REMOTE_HOST'])."','".
					date("Y-m-d H:i:s", $_SERVER['REQUEST_TIME'])."','".
					$mysql->escape($_SERVER['REMOTE_ADDR'])."','".
					$mysql->escape($_SERVER['HTTP_USER_AGENT'])."','".
					$mysql->escape(print_r($_SERVER, true))."')";
				$mysql->runSql($sql);
				$mysql->closeDb();
								
				$info = get_latest_version_info('d/', '/Archer.*\.zip/');
				echo json_encode($info);
				break;
				
			case 'd':
				$info = get_latest_version_info("d/", "/Archer.*\.zip/");
				$url = $info['url'];
				echo "<html><body><meta http-equiv=\"refresh\" content=\"0; url=$url\"/><body/><html/>";
				break;
				
			case 'l':
				$files = array();
				$d = dir('d/');
				while(($f = $d->read()) !== false && !is_dir($f))
				{
					array_push($files, $f);
				}
				sort($files, SORT_STRING);
				
				$output = '';
				foreach($files as $f)
				{
					$output .= "<li><a href=\"http://archer.sinaapp.com/d/$f\">$f</a></li>";
				}
				
				echo "<html><body><ol>$output</ol></body></html>";
				break;

			case 's': // show deploy statistics
				$mysql = new SaeMysql();
				$sql =
					"select `REMOTE_HOST`,`REQUEST_TIME`,`REMOTE_ADDR`,`HTTP_USER_AGENT` from `Deploy_Statistics` ".
					"limit ".(int)$_GET['offset'].", 20"
				;
				$data = $mysql->getData($sql);
				$mysql->closeDb();
				
				echo nl2br(htmlspecialchars(print_r($data, true)));
				break;
				
			default:
				echo "Unknown Request.";
				break;
		}
	}

// ***** Subfunction *****

	function get_latest_version_info($path, $preg)
	{
		$files = array();
		$d = dir($path);
		while(($f = $d->read()) !== false)
		{
			if(preg_match($preg, $f))
			{
				array_push($files, $f);
			}
		}
		sort($files, SORT_STRING);
		
		preg_match("/\d\.\d\.\d\.\d/",$files[count($files) - 1],$version);
		
		$info = array(
			"name" => $files[count($files) - 1],
			"size" => " [".number_format(filesize($path.$files[count($files) - 1]) / (1024 * 1024), 2)." MB]",
			"version" => $version[0],
			"url" => 'http://archer.sinaapp.com/d/'.$files[count($files) - 1],
			"info" => ''	// Reserve
		);
		
		return $info;
	}

?>
