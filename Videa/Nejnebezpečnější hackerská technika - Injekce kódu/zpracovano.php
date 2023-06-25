<!DOCTYPE html>
<html>
<head>
    <title>Zpracováno</title>
    <meta charset="utf-8">
</head>
<body>
    <?php
    error_reporting(E_ALL & ~E_NOTICE);

    $vstup = $_GET['input'];
    eval("\$promenna = $vstup;");
    echo $promenna;
    ?>
</body>
</html>