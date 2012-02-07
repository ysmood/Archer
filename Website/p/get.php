<?php
/* PHP Doc y.s.
*/
	$mysql = new SaeMysql();
	$return = '';
	
	$sql = sprintf(
		"select * from `Pebble` where `Room` = '%s' and `ID` > %s order by `ID` limit 0,10",
		$mysql->escape($_GET['Room']),
		(int)$_GET['ID']
	);
	$return = $mysql->getData($sql);
	if($mysql->errno() != 0)
	{	
		$return .= 'server_failed';
	}	
	echo json_encode($return);
	
	$mysql->closeDb();
	
?>