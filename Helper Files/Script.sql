IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [LocationPoints] (
    [Latitude] DECIMAL(9,6) NOT NULL,
    [Longitude] DECIMAL(9,6) NOT NULL,
    [DateAdded] datetime2 NOT NULL,
    CONSTRAINT [PK_LocationPoints] PRIMARY KEY ([Latitude], [Longitude])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201006190650_InitialModel', N'3.1.8');

GO


