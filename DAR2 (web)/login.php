<?php
	include "conection.php";
	$user = $_GET['user'];
	$pass = hash("sha256", $_GET['pass']);


	if(!$conexion){
		echo "fallo";
	}else{
		$sql = "SELECT * FROM user WHERE userName = '$user' AND password = '$pass'";
		$resultado = mysqli_query($conexion, $sql);
		if (mysqli_num_rows($resultado)>0) {
			echo "sirve";
		}else{
			echo "nop";
		}
	}
?>