<?php
$hostname = 'localhost:3306';
$username = 'root';
$password = '';
$database = 'crashfight';

try {
    $connectionQQM = new PDO('mysql:host=' . $hostname . '; dbname=' . $database, $username, $password);
} catch (PDOException $e) {
    echo '<h1>Une erreur s\'est produite<h1><pre>', $e->getMessage(), '</pre>';
}

$data = json_decode($_POST['new_stats']);

$statement = $connectionQQM->prepare("UPDATE stat SET `life`=".$data->life.",`round`=".$data->round);
$statement->execute();