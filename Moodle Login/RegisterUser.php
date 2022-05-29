<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unitybackendlogin";

// variables submitted by user
$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];
//$loginEmail = $_POST["loginEmail"];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  // "die" means exit, meaning php will stop working/stop running the code, after printing "Connection failed: ".
  die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully.<br><br>";

// gets the password from the table "users" where the username inside my database is equal to the user that was submitted by the unity application.
$sql = "SELECT username FROM users WHERE username = '" . $loginUser . "'";

// makes a result with a connection from the query
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // tells user that, that name is taken.
    echo "Username is already taken.";

  } else {
    echo "Creating user...";
    // insert the user and the password into the database
    $sql2 = "INSERT INTO users (username, password) VALUES ('" . $loginUser . "', '" . $loginPass . "')";
    if ($conn->query($sql2) === TRUE) {
        echo "New record created successfully";
      } else {
        echo "Error: " . $sql2 . "<br>" . $conn->error;
      }
}
$conn->close();

?>