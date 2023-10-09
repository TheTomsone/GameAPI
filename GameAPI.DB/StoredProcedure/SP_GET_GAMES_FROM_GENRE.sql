CREATE PROCEDURE [dbo].[SP_GET_GAMES_FROM_GENRE]
	@genreId INT
AS
BEGIN

	SELECT G.[g_id], G.[g_title], G.[g_resume]
	FROM [dbo].[G_GAME] G
	JOIN [dbo].[GG_GAME_GENRE] GG ON G.[g_id] = GG.[gg_game_id]
	JOIN [dbo].[G_GENRE] Ge ON GG.[gg_genre_id] = Ge.[g_id]
	WHERE Ge.[g_id] = @genreId

END
