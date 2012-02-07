<?php
/* PHP Doc y.s.
*/

    $mysql_host     = 'localhost:3306';
    $mysql_user     = 'admin';
    $mysql_password = '123456';
    $mysql_db       = 'plus_game';

    // $mysql_host     = SAE_MYSQL_HOST_M.':'.SAE_MYSQL_PORT;
    // $mysql_user     = SAE_MYSQL_USER;
    // $mysql_password = SAE_MYSQL_PASS;
    // $mysql_db       = SAE_MYSQL_DB;
    
// ***** Main *****

    $link = mysql_connect($mysql_host, $mysql_user, $mysql_password);
    
    $sql = sprintf("select * from ".$mysql_db.".game where id = '%s'",
            mysql_escape_string('test')
        );
    
    $re = mysql_query($sql);
    
    $data = mysql_fetch_array($re, MYSQL_ASSOC);
    
    if(array_key_exists('p', $_GET))
    {
        $sql = sprintf("update ".$mysql_db.".game set p = %s, num_0 = %s, num_1 = %s, num_2 = %s, num_3 = %s",
                (int)$_GET['p'],
                (int)$_GET['num_0'],
                (int)$_GET['num_1'],
                (int)$_GET['num_2'],
                (int)$_GET['num_3']
            );
        mysql_query($sql);
    }
    
    mysql_close($link);

    echo json_encode($data);
    
?>