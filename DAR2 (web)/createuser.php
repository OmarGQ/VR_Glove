<?php
	include "conection.php";
	$user = $_GET['user'];
	$email =$_GET['email'];
	$pass = hash("sha256", $_GET['pass']);

	if(!$conexion){
		echo "Fallo la conexion";
	}else{
		$sql = "SELECT userName FROM user WHERE userName = '$user'";
		$resultado = mysqli_query($conexion, $sql);
		if(mysqli_num_rows($resultado) > 0)
		{
			echo "usuario";
			exit();
		}else{
			$sql = "SELECT email FROM user WHERE email = '$email'";
			$resultado = mysqli_query($conexion, $sql);
			if(mysqli_num_rows($resultado) > 0)
			{
				echo "email";
				exit();
			}else{
				$sql = "INSERT INTO user SET userName = '$user', email = '$email', password = '$pass'";
				$resultado = mysqli_query($conexion, $sql);
				echo "registrado";
				exit();
			}
		}
	}
?>