 <?php

if ($argc != 3) {
    die(PHP_EOL . 'Use: php lab1.php first_file second_file' . PHP_EOL);
}

$file = $argv[1];
$newfile = $argv[2];

if (!copy($file, $newfile)) {
    echo "не удалось скопировать $file...\n";
    die();
}
$mode = fileperms($file);
chmod($newfile, $mode);
?>
