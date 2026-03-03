<!DOCTYPE html>
<html>
<head>
    <title>jQuery Alert App</title>

  
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <script>
        $(document).ready(function() {
            $("#alertBtn").click(function() {
                alert("Hello! Button was clicked successfully.");
            });
        });
    </script>
</head>

<body>

    <h2>jQuery Alert Example</h2>
    <button id="alertBtn">Click Me</button>

</body>
</html>
