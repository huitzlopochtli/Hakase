CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `AspNetRoles` (
    `Id` varchar(255) NOT NULL,
    `Name` varchar(256) NULL,
    `NormalizedName` varchar(256) NULL,
    `ConcurrencyStamp` longtext NULL,
    CONSTRAINT `PK_AspNetRoles` PRIMARY KEY (`Id`)
);

CREATE TABLE `AspNetUsers` (
    `Id` varchar(255) NOT NULL,
    `UserName` varchar(256) NULL,
    `NormalizedUserName` varchar(256) NULL,
    `Email` varchar(256) NULL,
    `NormalizedEmail` varchar(256) NULL,
    `EmailConfirmed` bit NOT NULL,
    `PasswordHash` longtext NULL,
    `SecurityStamp` longtext NULL,
    `ConcurrencyStamp` longtext NULL,
    `PhoneNumber` longtext NULL,
    `PhoneNumberConfirmed` bit NOT NULL,
    `TwoFactorEnabled` bit NOT NULL,
    `LockoutEnd` datetime(6) NULL,
    `LockoutEnabled` bit NOT NULL,
    `AccessFailedCount` int NOT NULL,
    CONSTRAINT `PK_AspNetUsers` PRIMARY KEY (`Id`)
);

CREATE TABLE `AspNetRoleClaims` (
    `Id` int NOT NULL,
    `RoleId` varchar(255) NOT NULL,
    `ClaimType` longtext NULL,
    `ClaimValue` longtext NULL,
    CONSTRAINT `PK_AspNetRoleClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserClaims` (
    `Id` int NOT NULL,
    `UserId` varchar(255) NOT NULL,
    `ClaimType` longtext NULL,
    `ClaimValue` longtext NULL,
    CONSTRAINT `PK_AspNetUserClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserLogins` (
    `LoginProvider` varchar(128) NOT NULL,
    `ProviderKey` varchar(128) NOT NULL,
    `ProviderDisplayName` longtext NULL,
    `UserId` varchar(255) NOT NULL,
    CONSTRAINT `PK_AspNetUserLogins` PRIMARY KEY (`LoginProvider`, `ProviderKey`),
    CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserRoles` (
    `UserId` varchar(255) NOT NULL,
    `RoleId` varchar(255) NOT NULL,
    CONSTRAINT `PK_AspNetUserRoles` PRIMARY KEY (`UserId`, `RoleId`),
    CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserTokens` (
    `UserId` varchar(255) NOT NULL,
    `LoginProvider` varchar(128) NOT NULL,
    `Name` varchar(128) NOT NULL,
    `Value` longtext NULL,
    CONSTRAINT `PK_AspNetUserTokens` PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
    CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IX_AspNetRoleClaims_RoleId` ON `AspNetRoleClaims` (`RoleId`);

CREATE UNIQUE INDEX `RoleNameIndex` ON `AspNetRoles` (`NormalizedName`);

CREATE INDEX `IX_AspNetUserClaims_UserId` ON `AspNetUserClaims` (`UserId`);

CREATE INDEX `IX_AspNetUserLogins_UserId` ON `AspNetUserLogins` (`UserId`);

CREATE INDEX `IX_AspNetUserRoles_RoleId` ON `AspNetUserRoles` (`RoleId`);

CREATE INDEX `EmailIndex` ON `AspNetUsers` (`NormalizedEmail`);

CREATE UNIQUE INDEX `UserNameIndex` ON `AspNetUsers` (`NormalizedUserName`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('00000000000000_CreateIdentitySchema', '2.1.14-servicing-32113');

ALTER TABLE `AspNetUsers` DROP INDEX `UserNameIndex`;

ALTER TABLE `AspNetRoles` DROP INDEX `RoleNameIndex`;

ALTER TABLE `AspNetUserTokens` MODIFY COLUMN `Name` varchar(255) NOT NULL;

ALTER TABLE `AspNetUserTokens` MODIFY COLUMN `LoginProvider` varchar(255) NOT NULL;

ALTER TABLE `AspNetUserLogins` MODIFY COLUMN `ProviderKey` varchar(255) NOT NULL;

ALTER TABLE `AspNetUserLogins` MODIFY COLUMN `LoginProvider` varchar(255) NOT NULL;

CREATE TABLE `Customers` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `DateCreated` datetime(6) NULL,
    `UserCreated` longtext NULL,
    `DateModified` datetime(6) NULL,
    `UserModified` longtext NULL,
    `NameHira` longtext NOT NULL,
    `NameKata` longtext NOT NULL,
    `CompanyNameHira` longtext NOT NULL,
    `CompanyNameKata` longtext NOT NULL,
    `CompanyEmail` longtext NOT NULL,
    `Phone` longtext NULL,
    `PhoneMobile` longtext NULL,
    `DateOfBirth` datetime(6) NULL,
    `Address` longtext NULL,
    `UserId` varchar(255) NULL,
    CONSTRAINT `PK_Customers` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Customers_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Materials` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `DateCreated` datetime(6) NULL,
    `UserCreated` longtext NULL,
    `DateModified` datetime(6) NULL,
    `UserModified` longtext NULL,
    `Name` longtext NOT NULL,
    `ImageUrl` longtext NOT NULL,
    `UserId` varchar(255) NULL,
    CONSTRAINT `PK_Materials` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Materials_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `UploadedImages` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `DateCreated` datetime(6) NULL,
    `UserCreated` longtext NULL,
    `DateModified` datetime(6) NULL,
    `UserModified` longtext NULL,
    `ImageUrl` longtext NULL,
    `UserId` varchar(255) NULL,
    CONSTRAINT `PK_UploadedImages` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_UploadedImages_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `ReformedImages` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `DateCreated` datetime(6) NULL,
    `UserCreated` longtext NULL,
    `DateModified` datetime(6) NULL,
    `UserModified` longtext NULL,
    `Name` longtext NULL,
    `ImageUrl` longtext NULL,
    `UploadedImageId` int NOT NULL,
    CONSTRAINT `PK_ReformedImages` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ReformedImages_UploadedImages_UploadedImageId` FOREIGN KEY (`UploadedImageId`) REFERENCES `UploadedImages` (`Id`) ON DELETE CASCADE
);

CREATE UNIQUE INDEX `UserNameIndex` ON `AspNetUsers` (`NormalizedUserName`);

CREATE UNIQUE INDEX `RoleNameIndex` ON `AspNetRoles` (`NormalizedName`);

CREATE INDEX `IX_Customers_UserId` ON `Customers` (`UserId`);

CREATE INDEX `IX_Materials_UserId` ON `Materials` (`UserId`);

CREATE INDEX `IX_ReformedImages_UploadedImageId` ON `ReformedImages` (`UploadedImageId`);

CREATE INDEX `IX_UploadedImages_UserId` ON `UploadedImages` (`UserId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20191122100655_asf', '2.1.14-servicing-32113');

ALTER TABLE `Materials` ADD `Precedence` int NOT NULL DEFAULT 0;

ALTER TABLE `Materials` ADD `Type` int NOT NULL DEFAULT 0;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20191125100258_MaterialPrecedence', '2.1.14-servicing-32113');

