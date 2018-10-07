USE [ServiceDB]

SET IDENTITY_INSERT [dbo].[CreditCard] ON
INSERT [dbo].[CreditCard] ([ID], [CardNumber], [ExpiryDate]) VALUES (1, 4444333322221111, CAST(0x0000AC8500000000 AS DateTime))
INSERT [dbo].[CreditCard] ([ID], [CardNumber], [ExpiryDate]) VALUES (3, 378282246310005, CAST(0x0000ACA300000000 AS DateTime))
INSERT [dbo].[CreditCard] ([ID], [CardNumber], [ExpiryDate]) VALUES (4, 5105105105105100, CAST(0x0000B53200000000 AS DateTime))
INSERT [dbo].[CreditCard] ([ID], [CardNumber], [ExpiryDate]) VALUES (5, 3530111333300000, CAST(0x0000A9C800000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[CreditCard] OFF
