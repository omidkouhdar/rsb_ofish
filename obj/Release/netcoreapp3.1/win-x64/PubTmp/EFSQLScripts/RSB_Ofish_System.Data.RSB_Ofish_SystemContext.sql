IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220521081842_init')
BEGIN
    CREATE TABLE [Office] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Office] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220521081842_init')
BEGIN
    CREATE TABLE [Ofish] (
        [Id] bigint NOT NULL IDENTITY,
        [UserId] nvarchar(max) NULL,
        [FullName] nvarchar(max) NULL,
        [Staff] nvarchar(max) NULL,
        [OfficeId] int NOT NULL,
        [NationCode] nvarchar(max) NULL,
        [PicPath] nvarchar(max) NULL,
        [OffishTime] datetime2 NOT NULL,
        [ExitTime] datetime2 NOT NULL,
        [Created] datetime2 NOT NULL,
        [LastModified] datetime2 NOT NULL,
        CONSTRAINT [PK_Ofish] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Ofish_Office_OfficeId] FOREIGN KEY ([OfficeId]) REFERENCES [Office] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220521081842_init')
BEGIN
    CREATE TABLE [Staffs] (
        [Id] int NOT NULL IDENTITY,
        [firstName] nvarchar(max) NULL,
        [sureName] nvarchar(max) NULL,
        [sexual] int NOT NULL,
        [OfficeId] int NOT NULL,
        CONSTRAINT [PK_Staffs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Staffs_Office_OfficeId] FOREIGN KEY ([OfficeId]) REFERENCES [Office] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220521081842_init')
BEGIN
    CREATE INDEX [IX_Ofish_OfficeId] ON [Ofish] ([OfficeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220521081842_init')
BEGIN
    CREATE INDEX [IX_Staffs_OfficeId] ON [Staffs] ([OfficeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220521081842_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220521081842_init', N'3.1.25');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220523093637_add2colsToOfish')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ofish]') AND [c].[name] = N'ExitTime');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Ofish] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Ofish] ALTER COLUMN [ExitTime] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220523093637_add2colsToOfish')
BEGIN
    ALTER TABLE [Ofish] ADD [OnExitRegister] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220523093637_add2colsToOfish')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220523093637_add2colsToOfish', N'3.1.25');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220622075443_addPlate')
BEGIN
    ALTER TABLE [Ofish] ADD [ViheclePlate] nvarchar(10) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220622075443_addPlate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220622075443_addPlate', N'3.1.25');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220622080439_editPlatelength')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ofish]') AND [c].[name] = N'ViheclePlate');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Ofish] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Ofish] ALTER COLUMN [ViheclePlate] nvarchar(14) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220622080439_editPlatelength')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220622080439_editPlatelength', N'3.1.25');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220626041520_addviheclePic')
BEGIN
    ALTER TABLE [Ofish] ADD [ViheclePic] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220626041520_addviheclePic')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220626041520_addviheclePic', N'3.1.25');
END;

GO

