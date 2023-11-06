<?php
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
		echo $resultado[0]["userName"]." ".$resultado[0]["points"]." ".$resultado[1]["userName"]." ".$resultado[1]["points"]." ".$resultado[2]["userName"]." ".$resultado[2]["points"]." ".$resultado[3]["userName"]." ".$resultado[3]["points"]." ".$resultado[4]["userName"]." ".$resultado[4]["points"];
	}
	$conn = mysqli_connect("localhost", "dova", "Danielcot#1234", "game");
	if (!$conn) {
	    die("Connection failed: " . mysqli_connect_error());
	}
	$sql="select count(points) from puntajes";
	$resultado = $conn->query($sql);
	$valor = $resultado->fetch_assoc();
	if($valor["count(points)"] >= 7){
		$cont = $valor["count(points)"] - 6;
		$sql="DELETE FROM puntajes order by points ASC limit ".$cont."";
		$conn->query($sql);
	}
	mysqli_close($conn);
?>	