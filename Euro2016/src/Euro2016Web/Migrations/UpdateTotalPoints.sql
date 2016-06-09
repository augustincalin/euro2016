USE [EURO2016DB]
GO

/****** Object:  StoredProcedure [dbo].[UpdateTotalPoints]    Script Date: 09.06.2016 11:06:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateTotalPoints]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateTotalPoints]
GO

/****** Object:  StoredProcedure [dbo].[UpdateTotalPoints]    Script Date: 09.06.2016 11:06:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateTotalPoints]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateTotalPoints] AS' 
END
GO


ALTER PROCEDURE [dbo].[UpdateTotalPoints] 
AS
BEGIN
	SET NOCOUNT ON;

	-- foreach User U
	--		U.TP = 0
	--		foreach Bet B in U.Bet
	--			B.PG = 0
	--			if B.Match is in past & B.S1 != null & B.S2 != null
	--				if (M.S1 > M.S2 & B.S1 > B.S2) | (M.S1 < M.S2 & B.S1 < B.S2) | (M.S1 == M.S2 & B.S1 == B.S2)
	--					B.PG += 3
	--				if (M.S1 == B.S1 | M.S2 == B.S2)
	--					B.PG += 1
	--			U.TP += B.PG

	DECLARE @userId int
		,@betId int
		,@betS1 int
		,@betS2 int
		,@matchS1 int
		,@matchS2 int
		,@totalPoints int = 0
		,@pointsGained int = 0


	DECLARE user_cursor CURSOR FOR SELECT Id FROM [User]

	OPEN user_cursor
	FETCH NEXT FROM user_cursor INTO @userId
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT 'Processing USERID ' + cast(@userId as varchar)

		DECLARE bet_cursor CURSOR FOR
			SELECT B.Id
				,B.Score1
				,B.Score2
				,M.Score1
				,M.Score2
			FROM Bet B INNER JOIN Match M ON B.MatchId = M.Id WHERE UserId = @userId
		OPEN bet_cursor
		FETCH NEXT FROM bet_cursor INTO @betId, @betS1, @betS2, @matchS1, @matchS2
		WHILE @@FETCH_STATUS = 0
		BEGIN
			PRINT '      processing BETID ' + cast(@betId as varchar)

			IF (@betS1 > @betS2 AND @matchS1 > @matchS2) OR (@betS1 < @betS2 AND @matchS1 < @matchS2) OR (@betS1 = @betS2 AND @matchS1 = @matchS2)
				SELECT @pointsGained = @pointsGained + 3
			IF (@betS1 = @matchS1)
				SELECT @pointsGained = @pointsGained + 1
			IF (@betS2 = @matchS2)
				SELECT @pointsGained = @pointsGained + 1
			UPDATE Bet SET PointsGained = @pointsGained WHERE Id = @betId
			SET @totalPoints = @totalPoints + @pointsGained
			SET @pointsGained = 0
			PRINT '           @pointsGained ' + cast(@pointsGained as varchar)
			FETCH NEXT FROM bet_cursor INTO @betId, @betS1, @betS2, @matchS1, @matchS2
		END
		CLOSE bet_cursor
		DEALLOCATE bet_cursor

		UPDATE [User] SET TotalPoints = @totalPoints WHERE Id = @userId
		SET @totalPoints = 0
		FETCH NEXT FROM user_cursor INTO @userId
	END
	CLOSE user_cursor
	DEALLOCATE user_cursor
END

GO


