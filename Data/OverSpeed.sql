USE [IBA_Test]
GO

/****** Object:  StoredProcedure [dbo].[Overspeed]    Script Date: 02.10.2020 22:08:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Overspeed]
	@date DATETIME,
	@speed DECIMAL
	
AS
	SELECT Records.[Date], Records.RegistrationNumber, Records.Speed
	FROM Records
	WHERE convert(date,[Date]) = convert(date, @date) AND Speed > @speed
GO

