IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [migration_id] nvarchar(150) NOT NULL,
        [product_version] nvarchar(32) NOT NULL,
        CONSTRAINT [pk___ef_migrations_history] PRIMARY KEY ([migration_id])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251103050224_InitialMigration'
)
BEGIN
    CREATE TABLE [book] (
        [id] uniqueidentifier NOT NULL,
        [isbn] nvarchar(13) NOT NULL,
        [title] nvarchar(200) NOT NULL,
        [author] nvarchar(150) NOT NULL,
        [publication_year] int NOT NULL,
        [created_at] datetime2 NOT NULL,
        CONSTRAINT [pk_book] PRIMARY KEY ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251103050224_InitialMigration'
)
BEGIN
    CREATE TABLE [library] (
        [id] uniqueidentifier NOT NULL,
        [name] nvarchar(200) NOT NULL,
        CONSTRAINT [pk_library] PRIMARY KEY ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251103050224_InitialMigration'
)
BEGIN
    CREATE TABLE [member] (
        [id] uniqueidentifier NOT NULL,
        [name] nvarchar(100) NOT NULL,
        [email] nvarchar(150) NOT NULL,
        CONSTRAINT [pk_member] PRIMARY KEY ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251103050224_InitialMigration'
)
BEGIN
    CREATE TABLE [users] (
        [id] uniqueidentifier NOT NULL,
        [first_name] nvarchar(50) NOT NULL,
        [second_name] nvarchar(50) NULL,
        [last_name] nvarchar(50) NOT NULL,
        [second_last_name] nvarchar(50) NULL,
        [email] nvarchar(100) NOT NULL,
        CONSTRAINT [pk_users] PRIMARY KEY ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251103050224_InitialMigration'
)
BEGIN
    CREATE TABLE [library_book] (
        [id] uniqueidentifier NOT NULL,
        [library_id] uniqueidentifier NOT NULL,
        [book_id] uniqueidentifier NOT NULL,
        [total_copies] int NOT NULL,
        [available_copies] int NOT NULL,
        CONSTRAINT [pk_library_book] PRIMARY KEY ([id]),
        CONSTRAINT [fk_library_book_book_book_id] FOREIGN KEY ([book_id]) REFERENCES [book] ([id]) ON DELETE CASCADE,
        CONSTRAINT [fk_library_book_library_library_id] FOREIGN KEY ([library_id]) REFERENCES [library] ([id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251103050224_InitialMigration'
)
BEGIN
    CREATE TABLE [library_member] (
        [libraries_id] uniqueidentifier NOT NULL,
        [members_id] uniqueidentifier NOT NULL,
        CONSTRAINT [pk_library_member] PRIMARY KEY ([libraries_id], [members_id]),
        CONSTRAINT [fk_library_member_library_libraries_id] FOREIGN KEY ([libraries_id]) REFERENCES [library] ([id]) ON DELETE CASCADE,
        CONSTRAINT [fk_library_member_member_members_id] FOREIGN KEY ([members_id]) REFERENCES [member] ([id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251103050224_InitialMigration'
)
BEGIN
    CREATE TABLE [loan] (
        [id] uniqueidentifier NOT NULL,
        [library_book_id] uniqueidentifier NOT NULL,
        [member_id] uniqueidentifier NOT NULL,
        [loan_date] datetime2 NOT NULL,
        [expected_return_date] datetime2 NOT NULL,
        [return_date] datetime2 NULL,
        [status] int NOT NULL,
        [created_at] datetime2 NOT NULL,
        CONSTRAINT [pk_loan] PRIMARY KEY ([id]),
        CONSTRAINT [fk_loan_library_book_library_book_id] FOREIGN KEY ([library_book_id]) REFERENCES [library_book] ([id]) ON DELETE CASCADE,
        CONSTRAINT [fk_loan_member_member_id] FOREIGN KEY ([member_id]) REFERENCES [member] ([id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251103050224_InitialMigration'
)
BEGIN
    CREATE UNIQUE INDEX [ix_book_isbn] ON [book] ([isbn]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251103050224_InitialMigration'
)
BEGIN
    CREATE INDEX [ix_library_book_book_id] ON [library_book] ([book_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251103050224_InitialMigration'
)
BEGIN
    CREATE INDEX [ix_library_book_library_id] ON [library_book] ([library_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251103050224_InitialMigration'
)
BEGIN
    CREATE INDEX [ix_library_member_members_id] ON [library_member] ([members_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251103050224_InitialMigration'
)
BEGIN
    CREATE INDEX [ix_loan_library_book_id] ON [loan] ([library_book_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251103050224_InitialMigration'
)
BEGIN
    CREATE INDEX [ix_loan_member_id] ON [loan] ([member_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251103050224_InitialMigration'
)
BEGIN
    CREATE UNIQUE INDEX [ix_users_email] ON [users] ([email]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251103050224_InitialMigration'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([migration_id], [product_version])
    VALUES (N'20251103050224_InitialMigration', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251104005637_LibraryBookFKIndex'
)
BEGIN
    DROP INDEX [ix_library_book_library_id] ON [library_book];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251104005637_LibraryBookFKIndex'
)
BEGIN
    CREATE UNIQUE INDEX [ix_library_book_library_id_book_id] ON [library_book] ([library_id], [book_id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251104005637_LibraryBookFKIndex'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([migration_id], [product_version])
    VALUES (N'20251104005637_LibraryBookFKIndex', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251104013235_MemberEmailUQ_DroppedUsers'
)
BEGIN
    DROP TABLE [users];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251104013235_MemberEmailUQ_DroppedUsers'
)
BEGIN
    CREATE UNIQUE INDEX [ix_member_email] ON [member] ([email]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251104013235_MemberEmailUQ_DroppedUsers'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([migration_id], [product_version])
    VALUES (N'20251104013235_MemberEmailUQ_DroppedUsers', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251104024714_Loan_LoanedAmountColumn'
)
BEGIN
    ALTER TABLE [loan] ADD [loaned_amount] int NOT NULL DEFAULT 0;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [migration_id] = N'20251104024714_Loan_LoanedAmountColumn'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([migration_id], [product_version])
    VALUES (N'20251104024714_Loan_LoanedAmountColumn', N'9.0.10');
END;

COMMIT;
GO