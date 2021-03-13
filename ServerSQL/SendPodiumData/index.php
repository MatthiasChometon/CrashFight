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

echo 'SELECT * FROM user where Pseudo = ' . $_GET['Pseudo'];
$statement = $connectionQQM->prepare("SELECT * FROM user");
$statement->execute();
$allResults = $statement->fetchAll(\PDO::FETCH_ASSOC);
?>

<!DOCTYPE html>

<body>
    <p>
        <?php
        foreach ($allResults[0] as $key => $value) {
            if (empty($_GET[$key]) == false && $key != 'Pseudo') {
                echo "UPDATE user SET " . $key . " = " . $_GET[$key];
                $statement = $connectionQQM->prepare("UPDATE user SET " . $key . " = " . "'" . $_GET[$key] . "'" . "WHERE Pseudo = " . "'" . $_GET['Pseudo'] . "'");
                $statement->execute();
            }
        }
        ?>
    </p>
</body>