CREATE PROCEDURE [dbo].[GetCustomers]
AS
	SELECT Id, FirstName, LastName, Email, Phone, [Status]
	FROM [dbo].[Customers]


