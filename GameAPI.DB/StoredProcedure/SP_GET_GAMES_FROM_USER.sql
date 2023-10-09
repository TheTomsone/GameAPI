CREATE PROCEDURE [dbo].[SP_GET_GAMES_FROM_USER]
	@userId INT
AS
BEGIN

	SELECT G.[g_id], G.[g_title], G.[g_resume]
	FROM [dbo].[G_GAME] G
	JOIN [dbo].[UG_USER_GAME] UG ON G.[g_id] = UG.[ug_game_id]
	JOIN [dbo].[U_USER] U ON UG.[ug_user_id] = U.[u_id]
	WHERE U.[u_id] = @userId

END