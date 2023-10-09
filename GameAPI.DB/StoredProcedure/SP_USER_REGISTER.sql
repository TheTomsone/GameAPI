CREATE PROCEDURE [dbo].[SP_USER_REGISTER]
	@email VARCHAR(100),
	@pwd VARCHAR(100),
	@username VARCHAR(100)
AS
BEGIN

	DECLARE @salt VARCHAR(100)
	SET @salt = CONCAT(NEWID(), NEWID(), NEWID())

	DECLARE @pwdHash VARBINARY(64)
	SET @pwdHash = HASHBYTES('SHA2_512', CONCAT(@salt, @pwd, @email, [dbo].[F_GET_SECRET_KEY]()))

	INSERT INTO [dbo].[U_USER] ([u_email], [u_pwd_hash], [u_name], [u_salt]) VALUES
	(@email, @pwdHash, @username, @salt)

END
