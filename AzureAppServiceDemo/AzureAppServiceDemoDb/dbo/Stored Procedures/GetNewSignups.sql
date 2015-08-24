CREATE PROCEDURE [dbo].[GetNewSignups]
AS
	SELECT Id, FirstName, LastName, Email, Phone, [Status]
	FROM [dbo].[Customers]
	WHERE [status] = 0

	UPDATE [dbo].[Customers]
	SET [status] = 1
	WHERE [status] = 0
