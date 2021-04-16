<?php
$hostname = 'localhost:3306';
$username = 'Crash-Fight';
$password = '4hxNYJfpHoMpm3VM';
$database = 'Crash-Fight';

$conn = new mysqli($hostname, $username, $password, $database);
//Vérifier la connexion
if ($conn->connect_errno) {
   printf("Échec de la connexion à la base de données");
   exit();
}
//Récupérer les lignes de la table users
$res = $conn->query("SELECT * FROM user ");
//Initialiser un tableau
$data = array();
//Récupérer les lignes
while ( $row = $res->fetch_assoc())  {
   $data[] = $row;
}
//Afficher le tableau au format JSON
echo json_encode($data);
