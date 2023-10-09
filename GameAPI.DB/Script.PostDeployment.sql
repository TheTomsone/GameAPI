/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [dbo].[G_GAME] ([g_title], [g_resume])
VALUES  ('Counter-Strike 2','The largest technical leap forward in Counter-Strike''s history, ensuring new features and updates for years to come.'),
        ('Baldur''s Gate 3','Role-playing video game developed and published by Larian Studios. It is the third main installment in the Baldur''s Gate series, based on the tabletop role-playing system of Dungeons & Dragons.'),
        ('Star Citizen','In-development multiplayer, space trading and combat simulation game. The game is being developed and published by Cloud Imperium Games');


INSERT INTO [dbo].[G_GENRE] ([g_label])
VALUES  ('Action'),
        ('Adventure'),
        ('Cooperation'),
        ('Early Access'),
        ('FPS'),
        ('Free to Play'),
        ('MMO'),
        ('Management'),
        ('Multiplayer'),
        ('RPG'),
        ('Racing'),
        ('Simulation'),
        ('Singleplayer');


INSERT INTO [dbo].[GG_GAME_GENRE] ([gg_game_id], [gg_genre_id])
VALUES  (1,1),
        (1,3),
        (1,5),
        (1,6),
        (1,9),
        (2,2),
        (2,3),
        (2,10),
        (2,13),
        (3,1),
        (3,2),
        (3,3),
        (3,4),
        (3,5),
        (3,7),
        (3,9),
        (3,12);


EXEC [dbo].[SP_USER_REGISTER] 'admin@mail.com', '123456q.', 'Admin'
EXEC [dbo].[SP_USER_REGISTER] 'user@mail.com', '123456q.', 'User'

UPDATE [dbo].[U_USER] SET [u_role_id] = 3 WHERE [u_id] = 1

INSERT INTO [dbo].[UG_USER_GAME] ([ug_user_id], [ug_game_id])
VALUES  (1,1), (1,2), (1,3), (2,1);