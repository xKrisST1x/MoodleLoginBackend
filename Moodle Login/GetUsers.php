<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unitybackendlogin";


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  // "die" means exit, meaning php will stop working/stop running the code, after printing "Connection failed: ".
  die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully.<br><br>";

// what do we want to show:
$sql = "SELECT username, email FROM users";

// makes a result with a connection from the query
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {

    // "<br>" is a break, it creates a new line
    echo "username: " . $row["username"]. " - email: " . $row["email"]. "<br>";
  }
} else {
  echo "0 results";
}
$conn->close();

?>