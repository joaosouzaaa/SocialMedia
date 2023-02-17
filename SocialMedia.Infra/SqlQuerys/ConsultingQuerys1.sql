SELECT *
FROM Users;

SELECT *
FROM Addresses;

SELECT *
FROM Posts;

SELECT *
FROM Tags;

SELECT * 
FROM TagsPosts;

SELECT *
FROM Posts P
INNER JOIN TagsPosts TP
ON TP.Post_Id = P.Id
INNER JOIN Tags T
ON TP.Tag_Id = T.Id;

SELECT *
FROM Posts P
INNER JOIN TagsPosts TP
ON TP.Post_Id = P.Id
INNER JOIN Tags T
ON TP.Tag_Id = T.Id
WHERE P.User_Id = 1;
