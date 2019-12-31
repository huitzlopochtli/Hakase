-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 31, 2019 at 07:05 PM
-- Server version: 10.4.8-MariaDB
-- PHP Version: 7.1.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hakase`
--

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroleclaims`
--

CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroles`
--

CREATE TABLE `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `aspnetroles`
--

INSERT INTO `aspnetroles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
('aa05b16b-5684-4607-866d-e4c4cf37bd68', 'Customer', 'CUSTOMER', '2d6bdfb3-20e1-4d01-b6c9-6f3bcc69a6d9'),
('c3f3a0f4-8a90-45d1-872e-cf7b9433a154', 'Admin', 'ADMIN', '31aa332b-d826-467f-8d5e-25b092b79bd1');

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `aspnetuserroles`
--

INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
('27eca728-9bcc-4398-9738-631e060d684a', 'aa05b16b-5684-4607-866d-e4c4cf37bd68'),
('6137a378-21cd-4d58-8a8c-0ea0c51dabff', 'aa05b16b-5684-4607-866d-e4c4cf37bd68'),
('78b241a1-590a-4d73-9bff-6b2665304aee', 'aa05b16b-5684-4607-866d-e4c4cf37bd68'),
('99d783fb-b0b9-4995-bb0d-ddefc99a8180', 'c3f3a0f4-8a90-45d1-872e-cf7b9433a154'),
('b1c49790-82e4-40e8-8b70-41a930e49461', 'aa05b16b-5684-4607-866d-e4c4cf37bd68'),
('ba332d4b-4770-4838-8592-b9ac3de8d829', 'aa05b16b-5684-4607-866d-e4c4cf37bd68'),
('f240fca1-1a3e-4600-8589-a91da0f8b2ef', 'aa05b16b-5684-4607-866d-e4c4cf37bd68');

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('27eca728-9bcc-4398-9738-631e060d684a', 'customer4@hakase.com', 'CUSTOMER4@HAKASE.COM', 'customer4@hakase.com', 'CUSTOMER4@HAKASE.COM', b'0', 'AQAAAAEAACcQAAAAEDzl8adsYOl+jlXOChuGdJAAu/cS7nfHGVLN4wRRzqshmSzvqw06sBEUMZthfSMq4g==', 'MMI5MLB7ALUL3JD523GFD4LFW6AAOAMV', '7f57d37c-bbf2-4a2e-9e6f-0c707bf74578', NULL, b'0', b'0', NULL, b'1', 0),
('6137a378-21cd-4d58-8a8c-0ea0c51dabff', 'customer5@hakase.com', 'CUSTOMER5@HAKASE.COM', 'customer5@hakase.com', 'CUSTOMER5@HAKASE.COM', b'0', 'AQAAAAEAACcQAAAAEOd3HpRwSS1qv+JvS07uoHug/U+DVowMebJIa1xaLBBj+GIpZUepdjOp/2ZATj5qRw==', '3M7F5HUH6IXKNPGOFYUXTFYLNWWIM6RP', '2e5ef4ac-32d3-440f-b71d-7c7e73cdb54f', NULL, b'0', b'0', NULL, b'1', 0),
('78b241a1-590a-4d73-9bff-6b2665304aee', 'customer1@hakase.com', 'CUSTOMER1@HAKASE.COM', 'customer1@hakase.com', 'CUSTOMER1@HAKASE.COM', b'0', 'AQAAAAEAACcQAAAAELMrocEWDyVdT/ZAKsJ5gAqw0M92bDN88rDDV7Rti+Hp+o1sW5rcDdtI6+I0S4VXGg==AQAAAAEAACcQAAAAELMrocEWDyVdT/ZAKsJ5gAqw0M92bDN88rDDV7Rti+Hp+o1sW5rcDdtI6+I0S4VXGg==', 'BNCOVUPCM2FGE6V422USWX537XO32JZ6', '20b8bb0a-b23e-4e31-bd84-74e074fc5979', NULL, b'0', b'0', NULL, b'1', 2),
('99d783fb-b0b9-4995-bb0d-ddefc99a8180', 'admin@hakase.com', 'ADMIN@HAKASE.COM', 'admin@hakase.com', 'ADMIN@HAKASE.COM', b'0', 'AQAAAAEAACcQAAAAEJxO9mGvwhgxS6f/pA8qhDfMTCfWH8w0KIUgktZ4npGDmcft/IDUaWzTvZt7KHWvFw==', '3ZM7ASLCFDLCWG7J3IHX5NQAIETGUGD2', '66f5333b-8960-4ab4-81f3-9df3834e58cc', NULL, b'0', b'0', NULL, b'1', 0),
('b1c49790-82e4-40e8-8b70-41a930e49461', 'customer2@hakase.com', 'CUSTOMER2@HAKASE.COM', 'customer2@hakase.com', 'CUSTOMER2@HAKASE.COM', b'0', 'AQAAAAEAACcQAAAAEKksy1hGSU8YNCj2W1jQh+nbI3gXKXRSf+IcWRizn15xXSMdJKWBwNZ24sJc2/rSlQ==', 'XEQQTRWJVZTYB6Q5QU62DRRG5QXOPKBQ', '7dee2cba-db6f-49fb-94dc-6d79c17abcfd', NULL, b'0', b'0', NULL, b'1', 0),
('ba332d4b-4770-4838-8592-b9ac3de8d829', 'customer6@hakase.com', 'CUSTOMER6@HAKASE.COM', 'customer6@hakase.com', 'CUSTOMER6@HAKASE.COM', b'0', 'AQAAAAEAACcQAAAAECuq0+kT8ujFNWRrWHjEOtZZ2o+19Nq0E4E2Uj5SecvcOOaITUDuPQEhdjgdHcZe+A==', 'IKCLY42EDYTPNDFYOFB7WWWMVM6FID6Q', '61bd86ec-aed1-47a1-b086-40757f75ce95', NULL, b'0', b'0', NULL, b'1', 0),
('f240fca1-1a3e-4600-8589-a91da0f8b2ef', 'customer7@hakase.com', 'CUSTOMER7@HAKASE.COM', 'customer7@hakase.com', 'CUSTOMER7@HAKASE.COM', b'0', 'AQAAAAEAACcQAAAAEE91a8YpGWdMBlCtcB0cottTMSRwN+dNyOtuwndDSmezqCx+y3596vQbVIqJOYayXg==', 'VCE6H3IO67HSQ6TDC2UMSKHLHJ5YCNMS', 'd92ba823-2cec-42e5-ab43-b97994519830', NULL, b'0', b'0', NULL, b'1', 0);

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusertokens`
--

CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `Id` int(11) NOT NULL,
  `DateCreated` datetime(6) DEFAULT NULL,
  `UserCreated` longtext DEFAULT NULL,
  `DateModified` datetime(6) DEFAULT NULL,
  `UserModified` longtext DEFAULT NULL,
  `NameHira` longtext DEFAULT NULL,
  `NameKata` longtext DEFAULT NULL,
  `CompanyNameHira` longtext NOT NULL,
  `CompanyNameKata` longtext NOT NULL,
  `CompanyEmail` longtext DEFAULT NULL,
  `Phone` longtext DEFAULT NULL,
  `PhoneMobile` longtext DEFAULT NULL,
  `DateOfBirth` datetime(6) DEFAULT NULL,
  `Address` longtext DEFAULT NULL,
  `UserId` varchar(255) DEFAULT NULL,
  `Pass` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`Id`, `DateCreated`, `UserCreated`, `DateModified`, `UserModified`, `NameHira`, `NameKata`, `CompanyNameHira`, `CompanyNameKata`, `CompanyEmail`, `Phone`, `PhoneMobile`, `DateOfBirth`, `Address`, `UserId`, `Pass`) VALUES
(1, '2019-11-28 02:31:51.000000', NULL, '2019-12-30 08:27:46.254334', 'admin@hakase.com', NULL, NULL, '木の葉', 'コノハ', NULL, '093847893', NULL, NULL, '〒103-0011 東京都中央区日本橋大伝馬町１１−８ ＨＡＴビル 3F ERAS株式会社', '78b241a1-590a-4d73-9bff-6b2665304aee', NULL),
(2, '2019-11-28 02:31:51.932518', NULL, '2019-11-28 02:31:51.932518', NULL, '鳴門 うじゅ巻き', 'ナルト ウジュマキ', '木の葉', 'コノハ', 'cccc@hakase.com', '093847893', NULL, '2019-11-28 11:31:51.931585', '〒103-0011 東京都中央区日本橋大伝馬町１１−８ ＨＡＴビル 3F ERAS株式会社', 'b1c49790-82e4-40e8-8b70-41a930e49461', NULL),
(3, '2019-11-29 03:11:54.174973', 'admin@hakase.com', '2019-11-29 03:11:54.175155', 'admin@hakase.com', 'Test', 'Test', 'test', 'Test Com', 'test', '54345', '443434', NULL, '32453erfdfggr4frtf', '27eca728-9bcc-4398-9738-631e060d684a', NULL),
(4, '2019-11-29 03:21:42.266854', 'admin@hakase.com', '2019-11-29 03:21:42.266998', 'admin@hakase.com', 'Test', 'Test', 'test', 'test', 'test', 'test', 'test', NULL, 'test', '6137a378-21cd-4d58-8a8c-0ea0c51dabff', NULL),
(5, '2019-11-29 04:48:42.262493', 'admin@hakase.com', '2019-11-29 04:48:42.262721', 'admin@hakase.com', 'Test', 'Test', 'test', 'test', 'test', 'test', '443434', NULL, '32453erfdfggr4frtf', 'ba332d4b-4770-4838-8592-b9ac3de8d829', NULL),
(6, '2019-12-30 04:40:19.000000', 'admin@hakase.com', '2019-12-30 07:52:23.986347', 'admin@hakase.com', NULL, NULL, 'test', 'test', NULL, 'test', NULL, NULL, '32453erfdfggr4frtf', 'f240fca1-1a3e-4600-8589-a91da0f8b2ef', 'abcdd');

-- --------------------------------------------------------

--
-- Table structure for table `materials`
--

CREATE TABLE `materials` (
  `Id` int(11) NOT NULL,
  `DateCreated` datetime(6) DEFAULT NULL,
  `UserCreated` longtext DEFAULT NULL,
  `DateModified` datetime(6) DEFAULT NULL,
  `UserModified` longtext DEFAULT NULL,
  `Name` longtext NOT NULL,
  `ImageUrl` longtext NOT NULL,
  `UserId` varchar(255) DEFAULT NULL,
  `Precedence` int(11) NOT NULL DEFAULT 0,
  `Type` int(11) NOT NULL DEFAULT 0,
  `ImageThumbnailUrl1` longtext DEFAULT NULL,
  `ImageThumbnailUrl2` longtext DEFAULT NULL,
  `ImageThumbnailUrl3` longtext DEFAULT NULL,
  `ImageThumbnailUrl4` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `materials`
--

INSERT INTO `materials` (`Id`, `DateCreated`, `UserCreated`, `DateModified`, `UserModified`, `Name`, `ImageUrl`, `UserId`, `Precedence`, `Type`, `ImageThumbnailUrl1`, `ImageThumbnailUrl2`, `ImageThumbnailUrl3`, `ImageThumbnailUrl4`) VALUES
(9, '2019-11-29 04:08:02.537319', 'admin@hakase.com', '2019-11-29 04:08:02.537684', 'admin@hakase.com', 'Hakase Example 1', '/images/materials/Hakase Example 1.jpg', '99d783fb-b0b9-4995-bb0d-ddefc99a8180', 0, 1, '/images/materials/thumbnailUrl1Hakase Example 1.jpg', '/images/materials/thumbnailUrl2Hakase Example 1.jpg', '/images/materials/thumbnailUrl3Hakase Example 1.jpg', '/images/materials/thumbnailUrl4Hakase Example 1.jpg'),
(10, '2019-11-29 04:08:03.055860', 'admin@hakase.com', '2019-11-29 04:08:03.055866', 'admin@hakase.com', 'Hakase Example 2', '/images/materials/Hakase Example 2.jpg', '99d783fb-b0b9-4995-bb0d-ddefc99a8180', 0, 1, '/images/materials/thumbnailUrl1Hakase Example 2.jpg', '/images/materials/thumbnailUrl2Hakase Example 2.jpg', '/images/materials/thumbnailUrl3Hakase Example 2.jpg', '/images/materials/thumbnailUrl4Hakase Example 2.jpg'),
(11, '2019-11-29 04:08:03.476583', 'admin@hakase.com', '2019-11-29 04:08:03.476587', 'admin@hakase.com', 'Hakase Example 3', '/images/materials/Hakase Example 3.jpg', '99d783fb-b0b9-4995-bb0d-ddefc99a8180', 0, 1, '/images/materials/thumbnailUrl1Hakase Example 3.jpg', '/images/materials/thumbnailUrl2Hakase Example 3.jpg', '/images/materials/thumbnailUrl3Hakase Example 3.jpg', '/images/materials/thumbnailUrl4Hakase Example 3.jpg'),
(12, '2019-11-29 04:08:04.142767', 'admin@hakase.com', '2019-11-29 04:08:04.142768', 'admin@hakase.com', 'Hakase Example 4', '/images/materials/Hakase Example 4.jpg', '99d783fb-b0b9-4995-bb0d-ddefc99a8180', 0, 1, '/images/materials/thumbnailUrl1Hakase Example 4.jpg', '/images/materials/thumbnailUrl2Hakase Example 4.jpg', '/images/materials/thumbnailUrl3Hakase Example 4.jpg', '/images/materials/thumbnailUrl4Hakase Example 4.jpg'),
(13, '2019-11-29 04:15:36.264977', 'admin@hakase.com', '2019-11-29 04:15:36.265836', 'admin@hakase.com', 'Hakase Example 1', '/images/materials/Hakase Example 1.jpg', '99d783fb-b0b9-4995-bb0d-ddefc99a8180', 0, 1, '/images/materials/thumbnailUrl1Hakase Example 1.jpg', '/images/materials/thumbnailUrl2Hakase Example 1.jpg', '/images/materials/thumbnailUrl3Hakase Example 1.jpg', '/images/materials/thumbnailUrl4Hakase Example 1.jpg'),
(14, '2019-11-29 04:15:36.683766', 'admin@hakase.com', '2019-11-29 04:15:36.683770', 'admin@hakase.com', 'Hakase Example 2', '/images/materials/Hakase Example 2.jpg', '99d783fb-b0b9-4995-bb0d-ddefc99a8180', 0, 1, '/images/materials/thumbnailUrl1Hakase Example 2.jpg', '/images/materials/thumbnailUrl2Hakase Example 2.jpg', '/images/materials/thumbnailUrl3Hakase Example 2.jpg', '/images/materials/thumbnailUrl4Hakase Example 2.jpg'),
(15, '2019-11-29 04:15:37.067146', 'admin@hakase.com', '2019-11-29 04:15:37.067146', 'admin@hakase.com', 'Hakase Example 3', '/images/materials/Hakase Example 3.jpg', '99d783fb-b0b9-4995-bb0d-ddefc99a8180', 0, 1, '/images/materials/thumbnailUrl1Hakase Example 3.jpg', '/images/materials/thumbnailUrl2Hakase Example 3.jpg', '/images/materials/thumbnailUrl3Hakase Example 3.jpg', '/images/materials/thumbnailUrl4Hakase Example 3.jpg'),
(16, '2019-11-29 04:15:37.670918', 'admin@hakase.com', '2019-11-29 04:15:37.670918', 'admin@hakase.com', 'Hakase Example 4', '/images/materials/Hakase Example 4.jpg', '99d783fb-b0b9-4995-bb0d-ddefc99a8180', 0, 1, '/images/materials/thumbnailUrl1Hakase Example 4.jpg', '/images/materials/thumbnailUrl2Hakase Example 4.jpg', '/images/materials/thumbnailUrl3Hakase Example 4.jpg', '/images/materials/thumbnailUrl4Hakase Example 4.jpg'),
(17, '2019-11-29 04:15:49.848356', 'admin@hakase.com', '2019-11-29 04:15:49.848357', 'admin@hakase.com', 'Hakase Example 1', '/images/materials/Hakase Example 1.jpg', '99d783fb-b0b9-4995-bb0d-ddefc99a8180', 0, 1, '/images/materials/thumbnailUrl1Hakase Example 1.jpg', '/images/materials/thumbnailUrl2Hakase Example 1.jpg', '/images/materials/thumbnailUrl3Hakase Example 1.jpg', '/images/materials/thumbnailUrl4Hakase Example 1.jpg'),
(18, '2019-11-29 04:15:50.130787', 'admin@hakase.com', '2019-11-29 04:15:50.130787', 'admin@hakase.com', 'Hakase Example 2', '/images/materials/Hakase Example 2.jpg', '99d783fb-b0b9-4995-bb0d-ddefc99a8180', 0, 1, '/images/materials/thumbnailUrl1Hakase Example 2.jpg', '/images/materials/thumbnailUrl2Hakase Example 2.jpg', '/images/materials/thumbnailUrl3Hakase Example 2.jpg', '/images/materials/thumbnailUrl4Hakase Example 2.jpg'),
(19, '2019-11-29 04:15:50.517731', 'admin@hakase.com', '2019-11-29 04:15:50.517732', 'admin@hakase.com', 'Hakase Example 3', '/images/materials/Hakase Example 3.jpg', '99d783fb-b0b9-4995-bb0d-ddefc99a8180', 0, 1, '/images/materials/thumbnailUrl1Hakase Example 3.jpg', '/images/materials/thumbnailUrl2Hakase Example 3.jpg', '/images/materials/thumbnailUrl3Hakase Example 3.jpg', '/images/materials/thumbnailUrl4Hakase Example 3.jpg'),
(20, '2019-11-29 04:15:51.181568', 'admin@hakase.com', '2019-11-29 04:15:51.181569', 'admin@hakase.com', 'Hakase Example 4', '/images/materials/Hakase Example 4.jpg', '99d783fb-b0b9-4995-bb0d-ddefc99a8180', 0, 1, '/images/materials/thumbnailUrl1Hakase Example 4.jpg', '/images/materials/thumbnailUrl2Hakase Example 4.jpg', '/images/materials/thumbnailUrl3Hakase Example 4.jpg', '/images/materials/thumbnailUrl4Hakase Example 4.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `reformedimages`
--

CREATE TABLE `reformedimages` (
  `Id` int(11) NOT NULL,
  `DateCreated` datetime(6) DEFAULT NULL,
  `UserCreated` longtext DEFAULT NULL,
  `DateModified` datetime(6) DEFAULT NULL,
  `UserModified` longtext DEFAULT NULL,
  `Name` longtext DEFAULT NULL,
  `ImageUrl` longtext DEFAULT NULL,
  `UploadedImageId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `uploadedimages`
--

CREATE TABLE `uploadedimages` (
  `Id` int(11) NOT NULL,
  `DateCreated` datetime(6) DEFAULT NULL,
  `UserCreated` longtext DEFAULT NULL,
  `DateModified` datetime(6) DEFAULT NULL,
  `UserModified` longtext DEFAULT NULL,
  `ImageUrl` longtext DEFAULT NULL,
  `UserId` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `uploadedimages`
--

INSERT INTO `uploadedimages` (`Id`, `DateCreated`, `UserCreated`, `DateModified`, `UserModified`, `ImageUrl`, `UserId`) VALUES
(2, '2019-11-28 04:16:01.706124', 'admin@hakase.com', '2019-11-28 04:16:01.706370', 'admin@hakase.com', '\\images\\user\\admin@hakase.com\\wallpapers.jpg', '99d783fb-b0b9-4995-bb0d-ddefc99a8180'),
(4, '2019-11-28 06:50:52.458919', 'admin@hakase.com', '2019-11-28 06:50:52.459922', 'admin@hakase.com', '\\images\\user\\admin@hakase.com\\IMG_20191128_154213.jpg', '99d783fb-b0b9-4995-bb0d-ddefc99a8180'),
(7, '2019-11-29 04:16:51.922343', 'admin@hakase.com', '2019-11-29 04:16:51.922344', 'admin@hakase.com', '\\images\\user\\admin@hakase.com\\wallpapers.jpg', '99d783fb-b0b9-4995-bb0d-ddefc99a8180'),
(8, '2019-11-29 04:19:37.842604', 'admin@hakase.com', '2019-11-29 04:19:37.842605', 'admin@hakase.com', '\\images\\user\\admin@hakase.com\\hakase (2).png', '99d783fb-b0b9-4995-bb0d-ddefc99a8180');

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('00000000000000_CreateIdentitySchema', '2.1.14-servicing-32113'),
('20191122100655_asf', '2.1.14-servicing-32113'),
('20191125100258_MaterialPrecedence', '2.1.14-servicing-32113'),
('20191126092519_addedThumbnailToMaterials', '2.1.14-servicing-32113'),
('20191230032108_CustomerTableChanged', '2.1.14-servicing-32113'),
('20191230032938_changedCustomerRegistrationCustomerNameHira', '2.1.14-servicing-32113'),
('20191230053956_addedVisiblePasswordToCustomer', '2.1.14-servicing-32113');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indexes for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Indexes for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Customers_UserId` (`UserId`);

--
-- Indexes for table `materials`
--
ALTER TABLE `materials`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Materials_UserId` (`UserId`);

--
-- Indexes for table `reformedimages`
--
ALTER TABLE `reformedimages`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_ReformedImages_UploadedImageId` (`UploadedImageId`);

--
-- Indexes for table `uploadedimages`
--
ALTER TABLE `uploadedimages`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_UploadedImages_UserId` (`UserId`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `materials`
--
ALTER TABLE `materials`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `reformedimages`
--
ALTER TABLE `reformedimages`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `uploadedimages`
--
ALTER TABLE `uploadedimages`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `customers`
--
ALTER TABLE `customers`
  ADD CONSTRAINT `FK_Customers_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`);

--
-- Constraints for table `materials`
--
ALTER TABLE `materials`
  ADD CONSTRAINT `FK_Materials_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`);

--
-- Constraints for table `reformedimages`
--
ALTER TABLE `reformedimages`
  ADD CONSTRAINT `FK_ReformedImages_UploadedImages_UploadedImageId` FOREIGN KEY (`UploadedImageId`) REFERENCES `uploadedimages` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `uploadedimages`
--
ALTER TABLE `uploadedimages`
  ADD CONSTRAINT `FK_UploadedImages_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
