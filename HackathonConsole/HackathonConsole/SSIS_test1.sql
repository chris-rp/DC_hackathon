DECLARE @StageValueLast datetimeoffset = (
 
SELECT  stm.StageValue_Last FROM molder.etl.StagingTableMap stm
INNER JOIN molder.etl.StagingTable st ON st.DW_StagingTableKey = stm.DW_StagingTableKey
WHERE st.StagingTableName = 'ConsolidatedRealised'
)
 
 
;WITH CTE AS (
		SELECT	
			   CAST(rcr.[TradeID] AS NVARCHAR(50)) AS [TradeID]
			  ,CAST(rcr.[PositionID] AS NVARCHAR(50)) AS [PositionID]
		      ,rcr.[DeliveryDate]
		      ,CAST(rcr.[TradeType] AS NVARCHAR(100)) AS [TradeType]
		      ,CAST(rcr.[PositionType] AS NVARCHAR(30)) AS [PositionType]
		      ,CAST(rcr.[Currency] AS NVARCHAR(10)) AS [Currency]
		      ,rcr.[VolumeMWh]
		      ,rcr.[Realised_Currency]
		      ,rcr.[Realised_EUR]
		      ,CAST(rcr.[Source] AS NVARCHAR(50)) AS [Source]
		      ,CAST(rcr.[InsertedTime] AS DATETIMEOFFSET(2)) AS [InsertedTime]
			  ,CAST(rcr.[MarketAreaName] AS NVARCHAR(50)) AS MarketAreaName
			  ,ROW_NUMBER() OVER (PARTITION BY rcr.[TradeID], rcr.[PositionID], rcr.[DeliveryDate], rcr.[Source], rcr.[MarketAreaName] ORDER BY rcr.[InsertedTime] DESC) AS RowNum
		FROM BusinessControlling.[Resultsheet].[ConsolidatedRealised] rcr
	    WHERE CAST(rcr.[InsertedTime] AS DATETIMEOFFSET(2)) > CONVERT(DATETIMEOFFSET(2), @StageValueLast, 121)
		AND CAST(rcr.[InsertedTime] AS DATETIMEOFFSET(2)) < SYSDATETIMEOFFSET()
)
 
SELECT 
	   cte.[TradeID]
	  ,cte.[PositionID]
      ,cte.[DeliveryDate]
      ,cte.[TradeType]
      ,cte.[PositionType]
      ,cte.[Currency]
      ,cte.[VolumeMWh]
      ,cte.[Realised_Currency]
      ,cte.[Realised_EUR]
      ,cte.[Source]
      ,cte.[InsertedTime]
	  ,cte.[MarketAreaName]
FROM CTE cte
WHERE cte.RowNum = 1