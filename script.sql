/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [id]
      ,[fName]
      ,[lName]
      ,[email]
      ,[password]
      ,[phone]
  FROM [projectDB].[dbo].[Customer]