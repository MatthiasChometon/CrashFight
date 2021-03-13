<?php
$hostname = 'localhost:3306';
$username = 'Crash-Fight';
$password = '4hxNYJfpHoMpm3VM';
$database = 'Crash-Fight';

try {
    $connectionQQM = new PDO('mysql:host=' . $hostname . '; dbname=' . $database, $username, $password);
} catch (PDOException $e) {
    echo '<h1>Une erreur s\'est produite<h1><pre>', $e->getMessage(), '</pre>';
}

$statement = $connectionQQM->prepare("SELECT * FROM user WHERE Pseudo = " . "'" . $_GET['Pseudo'] . "'");
$statement->execute();
$users = $statement->fetchAll(\PDO::FETCH_ASSOC);
?>

<?php
foreach ($users as $user) {

    echo $user['Id']; 
    echo $user['Pseudo'];
    echo $user['Score'];
}
?>