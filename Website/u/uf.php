<?php
	// Upload User File
	
 	$mysql = new SaeMysql();
	
	$sql = sprintf(
		"select count(*) from `User` where `UserName` = '%s' and `Password` = '%s'",
		$mysql->escape($_SERVER['HTTP_USERNAME']),
		$mysql->escape($_SERVER['HTTP_PASSWORD'])
	);
	$data = $mysql->getData($sql);
	
	$exists = $data[0]['count(*)'] == 1;
	
	if($mysql->errno() != 0)
	{
		$return .= 'server_failed';
	}
	else if($exists)
	{			
		$has_auth = true;
	}
	else
	{
		$return = 'auth_error';
	}

	if($has_auth && array_key_exists('file',$_FILES))
	{
		$return = '';
		if ($_FILES['file']['error'] > 0)
		{
			$return .= $_FILES['file']['error'];
		}
		else
		{
			$s = new SaeStorage();
			
			$sql = sprintf(
				"select * from `File` where `UserName` = '%s' and `GUID` = '%s'",
				$mysql->escape($_SERVER['HTTP_USERNAME']),
				$mysql->escape($_SERVER['HTTP_GUID'])
			);
			$data = $mysql->getData($sql);
			
			if($data != null)
				foreach($data as $f)
				{
					$s->delete('uf', $f['SaeStoragePath']);
				}
			
			$file_name = hash_file('md5', $_FILES['file']['tmp_name']).'.'.pathinfo($_FILES['file']['name'], PATHINFO_EXTENSION);
			$s->upload('uf', $file_name, $_FILES['file']['tmp_name']);
			
			$return .= $s->getUrl('uf', $file_name);
			
			$sql = sprintf(
				"delete from `File` where `UserName` = '%s' and `GUID` = '%s'",
				$mysql->escape($_SERVER['HTTP_USERNAME']),
				$mysql->escape($_SERVER['HTTP_GUID'])
			);
			$mysql->runsql($sql);
			$sql = sprintf(
				"insert into `File` (`SaeStoragePath`, `UserName`, `GUID`) value ('%s', '%s', '%s')",
				$mysql->escape($file_name),
				$mysql->escape($_SERVER['HTTP_USERNAME']),
				$mysql->escape($_SERVER['HTTP_GUID'])
			);
			$mysql->runsql($sql);
		}
	}
	
	echo $return;
	
	$mysql->closeDb();
?>