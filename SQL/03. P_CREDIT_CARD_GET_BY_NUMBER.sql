USE [ServiceDB]
GO
/****** Object:  StoredProcedure [dbo].[P_CREDIT_CARD_GET_BY_NUMBER]    Script Date: 10/07/2018 03:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Change Revision
--------------------------------------------------------------------------------------------
Date        Author      Remark
--------------------------------------------------------------------------------------------


*/
CREATE PROCEDURE [dbo].[P_CREDIT_CARD_GET_BY_NUMBER]
@p_creditCardNo bigInt
AS
BEGIN

	SELECT [ID]
      ,[CardNumber]
      ,[ExpiryDate]
  FROM [CreditCard] where CardNumber=@p_creditCardNo

END
