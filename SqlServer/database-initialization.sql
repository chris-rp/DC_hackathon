CREATE DATABASE Hackathon;


GO
USE Hackathon;


GO
CREATE SCHEMA [hack];


GO
CREATE TABLE [hack].[BusinessControlling_ConsolidatedRealised] (
    [TradeID] [nvarchar] (50) COLLATE Danish_Norwegian_CI_AS NOT NULL,
    [PositionID] [nvarchar] (50) COLLATE Danish_Norwegian_CI_AS NOT NULL,
    [DeliveryDate] [date] NOT NULL,
    [TradeType] [nvarchar] (100) COLLATE Danish_Norwegian_CI_AS NOT NULL,
    [PositionType] [nvarchar] (30) COLLATE Danish_Norwegian_CI_AS NOT NULL,
    [Currency] [nvarchar] (10) COLLATE Danish_Norwegian_CI_AS NOT NULL,
    [VolumeMWh] [decimal] (24, 6) NOT NULL,
    [Realised_Currency] [decimal] (24, 6) NOT NULL,
    [Realised_EUR] [decimal] (24, 6) NOT NULL,
    [Source] [nvarchar] (50) COLLATE Danish_Norwegian_CI_AS NOT NULL,
    [InsertedTime] [datetimeoffset] (2) NOT NULL,
    [MarketAreaName] [nvarchar] (50) COLLATE Danish_Norwegian_CI_AS NOT NULL,
    [DW_AuditGlobalKey_Insert] [bigint] NULL,
    [DW_AuditGlobalKey_Update] [bigint] NULL
)
GO
ALTER TABLE [hack].[BusinessControlling_ConsolidatedRealised] ADD CONSTRAINT [PK_BusinessControlling_ConsolidatedRealised] PRIMARY KEY CLUSTERED ([TradeID], [PositionID], [DeliveryDate], [Source], [MarketAreaName])
GO