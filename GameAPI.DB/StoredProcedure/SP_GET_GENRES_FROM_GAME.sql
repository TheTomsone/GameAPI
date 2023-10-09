CREATE PROCEDURE [dbo].[SP_GET_GENRES_FROM_GAME]
	@gameId INT
AS
BEGIN

	SELECT Ge.[g_id], Ge.[g_label]
	FROM [dbo].[G_GENRE] Ge
	JOIN [dbo].[GG_GAME_GENRE] GG ON Ge.[g_id] = GG.[gg_genre_id]
	JOIN [dbo].[G_GAME] G ON GG.[gg_game_id] = G.[g_id]
	WHERE G.[g_id] = @gameId

END
