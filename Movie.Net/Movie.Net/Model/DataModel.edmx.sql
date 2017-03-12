
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/27/2017 12:39:10
-- Generated from EDMX file: C:\Users\mchua\Dev\random\visualStudio\Git\Movie.Net\Movie.Net\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MovieNetDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_GenresMovies_Genres]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GenresMovies] DROP CONSTRAINT [FK_GenresMovies_Genres];
GO
IF OBJECT_ID(N'[dbo].[FK_GenresMovies_Movies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GenresMovies] DROP CONSTRAINT [FK_GenresMovies_Movies];
GO
IF OBJECT_ID(N'[dbo].[FK_CommentsMovies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_CommentsMovies];
GO
IF OBJECT_ID(N'[dbo].[FK_CommentsUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_CommentsUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Movies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movies];
GO
IF OBJECT_ID(N'[dbo].[Genres]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Genres];
GO
IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO
IF OBJECT_ID(N'[dbo].[GenresMovies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GenresMovies];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Movies'
CREATE TABLE [dbo].[Movies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Plot] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Genres'
CREATE TABLE [dbo].[Genres] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Rating] nvarchar(max)  NOT NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [MoviesId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'GenresMovies'
CREATE TABLE [dbo].[GenresMovies] (
    [Genres_Id] int  NOT NULL,
    [Movies_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Movies'
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT [PK_Movies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Genres'
ALTER TABLE [dbo].[Genres]
ADD CONSTRAINT [PK_Genres]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Genres_Id], [Movies_Id] in table 'GenresMovies'
ALTER TABLE [dbo].[GenresMovies]
ADD CONSTRAINT [PK_GenresMovies]
    PRIMARY KEY CLUSTERED ([Genres_Id], [Movies_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Genres_Id] in table 'GenresMovies'
ALTER TABLE [dbo].[GenresMovies]
ADD CONSTRAINT [FK_GenresMovies_Genres]
    FOREIGN KEY ([Genres_Id])
    REFERENCES [dbo].[Genres]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Movies_Id] in table 'GenresMovies'
ALTER TABLE [dbo].[GenresMovies]
ADD CONSTRAINT [FK_GenresMovies_Movies]
    FOREIGN KEY ([Movies_Id])
    REFERENCES [dbo].[Movies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GenresMovies_Movies'
CREATE INDEX [IX_FK_GenresMovies_Movies]
ON [dbo].[GenresMovies]
    ([Movies_Id]);
GO

-- Creating foreign key on [MoviesId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_MoviesComments]
    FOREIGN KEY ([MoviesId])
    REFERENCES [dbo].[Movies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MoviesComments'
CREATE INDEX [IX_FK_MoviesComments]
ON [dbo].[Comments]
    ([MoviesId]);
GO

-- Creating foreign key on [UserId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_UserComments]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserComments'
CREATE INDEX [IX_FK_UserComments]
ON [dbo].[Comments]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------