create table dbo.__EFMigrationsHistory
(
    MigrationId    nvarchar(150) not null
        constraint PK___EFMigrationsHistory
            primary key,
    ProductVersion nvarchar(32)  not null
)
go

INSERT INTO SecureEmployeeManagementDb.dbo.__EFMigrationsHistory (MigrationId, ProductVersion) VALUES (N'20260608190128_InitialCreate', N'10.0.8');
