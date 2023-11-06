<?php
	$user = $_GET['user'];
	$points =$_GET['points'];
	$ban = false;
	if ($user != "" && $points > 0) {
		$resultado = array();
		$dbh = new PDO('mysql:host=localhost;dbname=game', "dova", "Danielcot#1234");
		if (!$dbh) {
			echo "Fallo la conexion";
		}else{
			$dbh->query("SET NAMES 'utf8'");
			$sql="select * from puntajes order by points DESC limit 5";
			foreach ($dbh->query($sql) as $res)
			{
				$resultado[]=$res;
			}
			for ($i=0; $i < count($resultado); $i++) { 
				if ($points > $resultado[$i]["points"]) {
					$ban = true;
				}
			}
			if ($ban) {
				$sql="INSERT INTO puntajes SET userName = '$user', points = '$points'";
				$dbh->query($sql);
				echo "registrado";
			}else{
				echo "nop";
			}
		}
	}
?>