CREATE PROCEDURE [dbo].[UpdateCustomerStatus]
AS
	UPDATE [dbo].[Customers]
	SET [Status] = 1
	WHERE [Status] = 0

