API Documentation
Register Request

Request
Method: POST
Endpoint: /register
Content-Type: application/json
Body:
{
  "FirstName": "string",
  "LastName": "string",
  "Email": "string",
  "Password": "string"
}

Parameters

FirstName (string): The first name of the user.
LastName (string): The last name of the user.
Email (string): The email address of the user.
Password (string): The password chosen by the user.

Response
Status Code: 200 OK

Content-Type: application/json
Body:
{
  "success": true,
  "message": "User registered successfully."
}

Login Request
This API endpoint allows you to authenticate a user and generate an access token.

Request
Method: POST
Endpoint: /login
Content-Type: application/json
Body:
json
Copy
{
  "Email": "string",
  "Password": "string"
}
Parameters
Email (string): The email address of the user.
Password (string): The password of the user.
Response
Status Code: 200 OK
Content-Type: application/json
Body:
json
Copy
{
  "Id": "string",
  "FirstName": "string",
  "LastName": "string",
  "Email": "string",
  "Token": "string"
}
Authentication Response
This API response contains the user information and an access token.

Properties
Id (string): The unique identifier of the user.
FirstName (string): The first name of the user.
LastName (string): The last name of the user.
Email (string): The email address of the user.
Token (string): The access token generated for the user.