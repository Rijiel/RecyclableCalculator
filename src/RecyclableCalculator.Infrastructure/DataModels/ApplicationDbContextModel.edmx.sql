
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/14/2024 09:58:17
-- Generated from EDMX file: C:\Users\Administrator\source\repos\RecyclableCalculator\src\RecyclableCalculator.Infrastructure\DataModels\ApplicationDbContextModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RecyclableCalculatorDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RecyclableItemRecyclableType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecyclableItems] DROP CONSTRAINT [FK_RecyclableItemRecyclableType];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[RecyclableTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecyclableTypes];
GO
IF OBJECT_ID(N'[dbo].[RecyclableItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecyclableItems];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RecyclableTypes'
CREATE TABLE [dbo].[RecyclableTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] varchar(100)  NULL,
    [Rate] decimal(18,2)  NOT NULL,
    [MinKg] decimal(18,2)  NOT NULL,
    [MaxKg] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'RecyclableItems'
CREATE TABLE [dbo].[RecyclableItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ItemDescription] varchar(100)  NOT NULL,
    [RecyclableTypeId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'RecyclableTypes'
ALTER TABLE [dbo].[RecyclableTypes]
ADD CONSTRAINT [PK_RecyclableTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RecyclableItems'
ALTER TABLE [dbo].[RecyclableItems]
ADD CONSTRAINT [PK_RecyclableItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RecyclableTypeId] in table 'RecyclableItems'
ALTER TABLE [dbo].[RecyclableItems]
ADD CONSTRAINT [FK_RecyclableItemRecyclableType]
    FOREIGN KEY ([RecyclableTypeId])
    REFERENCES [dbo].[RecyclableTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RecyclableItemRecyclableType'
CREATE INDEX [IX_FK_RecyclableItemRecyclableType]
ON [dbo].[RecyclableItems]
    ([RecyclableTypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------