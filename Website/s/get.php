<?php
/* PHP Doc y.s.
*/

	if(array_key_exists('r', $_GET))
	{
		switch($_GET['r'])
		{
			case 'page':
				echo json_encode(get_page($_GET['offset'], $_GET['rows']));
				break;
				
			case 'arrow':
				echo json_encode(get_arrow($_GET['guid']));
				break;
			
			case 'count':
				echo count_row();
				break;
		}
	}

/************ Sub function **************/

	function get_page($offset = 0, $rows = 10, $keyword = null)
	{
		$mysql = new SaeMysql();
		
		if($keyword == null)
		{
			$sql = sprintf("select * from `Arrow` order by `DateTime` desc limit %s, %s",
				(int)$offset,
				(int)$rows
			);
		}
		else
		{
			$keyword = '%'.$mysql->escape($keyword).'%';
			
			// Search Tag first.
			$sql = sprintf("select * from `Arrow` where `Tag` like '%s' or `Name` like '%s' or `Cmd` like '%s' or `Arg` like '%s' or `HotKey` like '%s' or `Enabled` like '%s' or `Timestamp` like '%s' or `GUID` like '%s' or `UserName` like '%s' or `DateTime` like '%s' or `DownloadCount` like '%s' order by `DateTime` desc limit %s, %s",
				$keyword,
				$keyword,
				$keyword,
				$keyword,
				$keyword,
				$keyword,
				$keyword,
				$keyword,
				$keyword,
				$keyword,
				$keyword,
				(int)$offset,
				(int)$rows
			);
		}
		$data = $mysql->getData($sql);
		$mysql->closeDb();
		return $data;
	}
		
	function count_row($keyword = null)
	{
		$mysql = new SaeMysql();
		if($keyword == null)
		{
			$sql = "select count(*) from `Arrow`";
		}
		else
		{
			$keyword = '%'.$mysql->escape($keyword).'%';
			$sql = sprintf("select count(*) from `Arrow` where `Name` like '%s' or `Cmd` like '%s' or `Arg` like '%s' or `Tag` like '%s' or `HotKey` like '%s' or `Enabled` like '%s' or `Timestamp` like '%s' or `GUID` like '%s' or `UserName` like '%s' or `DateTime` like '%s' or `DownloadCount` like '%s'",
				$keyword,
				$keyword,
				$keyword,
				$keyword,
				$keyword,
				$keyword,
				$keyword,
				$keyword,
				$keyword,
				$keyword,
				$keyword
			);
		}
		$n = $mysql->getData($sql);
		$mysql->closeDb();
		return $n[0]['count(*)'];
	}
	
	function get_arrow($guid)
	{
		$mysql = new SaeMysql();
		$sql = "select * from `Arrow` where `GUID` = '".$mysql->escape($guid)."'";
		$data = $mysql->getData($sql);
		
		$sql = "update `Arrow` set `DownloadCount` = ".++$data[0]['DownloadCount']." where `GUID` = '".$data[0]['GUID']."'";
		$mysql->runSql($sql);
		
		$mysql->closeDb();
		return $data;
	}

?>