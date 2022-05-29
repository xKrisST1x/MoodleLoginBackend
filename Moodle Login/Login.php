<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unitybackendlogin";

// variables submitted by user
$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  // "die" means exit, meaning php will stop working/stop running the code, after printing "Connection failed: ".
  die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully.<br><br>";

// gets the password from the table "users" where the username inside my database is equal to the 
// user that was submitted by the unity application.
$sql = "SELECT password FROM users WHERE username = '" . $loginUser . "'";

// makes a result with a connection from the query
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    if($row["password"] == $loginPass) {
        echo "Login completed.";
        // get users data here.

        // get user info.

        // modify user data.

        // update user data.
        
    }

    else{
        echo "Login failed.";
    }
  }
} else {
  echo "Username does not exist.";
}
$conn->close();

?>