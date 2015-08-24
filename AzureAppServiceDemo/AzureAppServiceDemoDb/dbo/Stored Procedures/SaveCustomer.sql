CREATE PROCEDURE [dbo].[SaveCustomer]
	@FirstName	nvarchar(100),
	@LastName	nvarchar(100),
	@Email		nvarchar(100),
	@Phone		nvarchar(100)
AS
	DECLARE @Id		INT

	INSERT INTO [dbo].Customers
	(FirstName, LastName, Email, Phone)
	VALUES(@FirstName, @LastName, @Email, @Phone)

	SET @Id = SCOPE_IDENTITY()

	SELECT Id, FirstName, LastName, Email, Phone, [Status]
	FROM [dbo].Customers
	WHERE Id = @Id
