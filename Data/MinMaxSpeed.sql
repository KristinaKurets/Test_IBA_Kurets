USE [IBA_Test]
GO

/****** Object:  StoredProcedure [dbo].[Minmaxspeed]    Script Date: 02.10.2020 22:07:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Minmaxspeed]
	@date DATETIME

AS	
BEGIN
	WITH a AS (
		SELECT TOP 1 Records.[Date], Records.RegistrationNumber, Records.Speed
		FROM Records
		WHERE convert(date,[Date]) = convert(date, @date)
		GROUP BY Records.[Date], Records.RegistrationNumber, Records.Speed
		ORDER BY Speed DESC),

		b AS (
		SELECT TOP 1 Records.[Date], Records.RegistrationNumber, Records.Speed
		FROM Records
		WHERE convert(date,[Date]) = convert(date, @date)
		GROUP BY Records.[Date], Records.RegistrationNumber, Records.Speed
		ORDER BY Speed ASC)
		
	SELECT * from a 
	union
	SELECT * from b
	END
GO

