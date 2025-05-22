-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 22, 2025 at 04:30 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `codpkv2`
--

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `id` int(30) NOT NULL,
  `kiosk_name` varchar(200) NOT NULL,
  `printer_name` varchar(200) DEFAULT NULL,
  `location` varchar(100) NOT NULL,
  `max_paper_load` int(50) NOT NULL,
  `date` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`id`, `kiosk_name`, `printer_name`, `location`, `max_paper_load`, `date`) VALUES
(36, 'CODPK V2', 'Epson L120', 'Department', 60, '2025-01-16');

-- --------------------------------------------------------

--
-- Table structure for table `insertedcoins`
--

CREATE TABLE `insertedcoins` (
  `ID` int(11) NOT NULL,
  `CoinAmount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `insertedcoins`
--

INSERT INTO `insertedcoins` (`ID`, `CoinAmount`) VALUES
(1, 10);

-- --------------------------------------------------------

--
-- Table structure for table `paperprice`
--

CREATE TABLE `paperprice` (
  `Kiosk_ID` int(11) NOT NULL,
  `PriceShortG` decimal(10,2) DEFAULT NULL,
  `PriceLongG` decimal(10,2) DEFAULT NULL,
  `PriceShortC` decimal(10,2) DEFAULT NULL,
  `PriceLongC` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `paperprice`
--

INSERT INTO `paperprice` (`Kiosk_ID`, `PriceShortG`, `PriceLongG`, `PriceShortC`, `PriceLongC`) VALUES
(1, 2.00, 3.00, 5.00, 7.00);

-- --------------------------------------------------------

--
-- Table structure for table `payments`
--

CREATE TABLE `payments` (
  `id` int(30) NOT NULL,
  `tenant_id` int(30) NOT NULL,
  `amount` float NOT NULL,
  `invoice` varchar(50) NOT NULL,
  `date_created` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `payments`
--

INSERT INTO `payments` (`id`, `tenant_id`, `amount`, `invoice`, `date_created`) VALUES
(1, 1, 1500, 'INV001', '2024-05-02 00:00:00'),
(3, 3, 1600, 'INV003', '2024-05-06 00:00:00'),
(4, 4, 1800, 'INV004', '2024-05-08 00:00:00'),
(5, 5, 1400, 'INV005', '2024-05-10 00:00:00'),
(6, 6, 1700, 'INV006', '2024-05-12 00:00:00'),
(7, 7, 1300, 'INV007', '2024-05-14 00:00:00'),
(8, 8, 1900, 'INV008', '2024-05-16 00:00:00'),
(9, 9, 1550, 'INV009', '2024-05-18 00:00:00'),
(10, 10, 1250, 'INV010', '2024-05-20 00:00:00'),
(11, 11, 1650, 'INV011', '2024-05-22 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `system_settings`
--

CREATE TABLE `system_settings` (
  `id` int(30) NOT NULL,
  `name` text NOT NULL,
  `email` varchar(200) NOT NULL,
  `contact` varchar(20) NOT NULL,
  `cover_img` text NOT NULL,
  `about_content` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `system_settings`
--

INSERT INTO `system_settings` (`id`, `name`, `email`, `contact`, `cover_img`, `about_content`) VALUES
(1, 'CODPK V2 Admin', 'info@sample.comm', '+6948 8542 623', '1603344720_1602738120_pngtree-purple-hd-business-banner-image_5493.jpg', '&lt;p style=&quot;text-align: center; background: transparent; position: relative;&quot;&gt;&lt;span style=&quot;color: rgb(0, 0, 0); font-family: &amp;quot;Open Sans&amp;quot;, Arial, sans-serif; font-weight: 400; text-align: justify;&quot;&gt;&amp;nbsp;is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&rsquo;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.&lt;/span&gt;&lt;br&gt;&lt;/p&gt;&lt;p style=&quot;text-align: center; background: transparent; position: relative;&quot;&gt;&lt;br&gt;&lt;/p&gt;&lt;p style=&quot;text-align: center; background: transparent; position: relative;&quot;&gt;&lt;br&gt;&lt;/p&gt;&lt;p&gt;&lt;/p&gt;');

-- --------------------------------------------------------

--
-- Table structure for table `tblavailablefunds`
--

CREATE TABLE `tblavailablefunds` (
  `Kiosk_ID` varchar(50) NOT NULL,
  `AvailableCoins` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tblavailablefunds`
--

INSERT INTO `tblavailablefunds` (`Kiosk_ID`, `AvailableCoins`) VALUES
('1', 22);

-- --------------------------------------------------------

--
-- Table structure for table `tblavailablepapers`
--

CREATE TABLE `tblavailablepapers` (
  `Kiosk_ID` varchar(50) NOT NULL,
  `AvailableShort` int(11) NOT NULL DEFAULT 0,
  `AvailableLong` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tblavailablepapers`
--

INSERT INTO `tblavailablepapers` (`Kiosk_ID`, `AvailableShort`, `AvailableLong`) VALUES
('1', 4, 11);

-- --------------------------------------------------------

--
-- Table structure for table `tblcoinfunds`
--

CREATE TABLE `tblcoinfunds` (
  `fund_id` int(11) NOT NULL,
  `kiosk_id` int(45) DEFAULT NULL,
  `Date` datetime DEFAULT NULL,
  `Coinsfund` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `tblcoinfunds`
--

INSERT INTO `tblcoinfunds` (`fund_id`, `kiosk_id`, `Date`, `Coinsfund`) VALUES
(1, 1, '2025-01-18 19:53:58', '100'),
(4, 1, '2025-02-12 21:36:58', '1'),
(5, 1, '2025-02-12 21:41:32', '12'),
(6, 1, '2025-02-12 21:55:28', '4'),
(7, 1, '2025-02-12 21:58:20', '11'),
(8, 1, '2025-02-12 22:05:57', '1'),
(9, 1, '2025-02-17 09:58:07', '12'),
(10, 1, '2025-02-17 18:58:37', '6'),
(11, 1, '2025-02-17 22:30:08', '1'),
(12, 1, '2025-02-17 22:55:57', '1');

-- --------------------------------------------------------

--
-- Table structure for table `tblhistory`
--

CREATE TABLE `tblhistory` (
  `log_id` int(11) NOT NULL,
  `admin_name` varchar(100) NOT NULL,
  `action` varchar(255) NOT NULL,
  `timestamp` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tblhistory`
--

INSERT INTO `tblhistory` (`log_id`, `admin_name`, `action`, `timestamp`) VALUES
(14, 'Administrator', 'Logged in', '2025-02-17 19:38:37'),
(15, 'Administrator', 'Logged in', '2025-02-17 19:41:44'),
(16, 'Administrator', 'Logged in', '2025-02-17 19:49:34'),
(17, 'Administrator', 'Logged in', '2025-02-17 19:56:06'),
(18, 'Administrator', 'Logged in', '2025-02-17 20:02:01'),
(19, 'Administrator', 'Logged in', '2025-02-17 20:03:56'),
(20, 'Administrator', 'Logged in', '2025-02-17 20:07:02'),
(21, 'Administrator', 'Logged in', '2025-02-17 20:07:49'),
(22, 'Administrator', 'Logged in', '2025-02-17 20:09:12'),
(23, 'Administrator', 'Logged in', '2025-02-17 20:10:58'),
(24, 'Administrator', 'Logged in', '2025-02-17 20:12:15'),
(25, 'Administrator', 'Logged in', '2025-02-17 20:14:15'),
(26, 'Administrator', 'Logged in', '2025-02-17 21:54:34'),
(27, 'Administrator', 'Logged in', '2025-02-17 22:06:08'),
(28, 'Administrator', 'Logged in', '2025-02-17 22:21:24'),
(29, 'Administrator', 'Logged in', '2025-02-17 22:23:53'),
(30, 'Jaspher', 'Logged in', '2025-02-17 22:26:16'),
(31, 'Administrator', 'Logged in', '2025-02-17 22:28:23'),
(32, 'Administrator', 'Logged in', '2025-02-17 22:29:31'),
(33, 'Administrator', 'Added funds: 1 PHP', '2025-02-17 22:30:09'),
(34, 'Administrator', 'Logged in', '2025-02-17 22:43:58'),
(35, 'Administrator', 'Logged in', '2025-02-17 22:47:26'),
(36, 'Administrator', 'Logged in', '2025-02-17 22:51:46'),
(37, 'Administrator', 'Added 1 sheets of Short paper', '2025-02-17 22:55:40'),
(38, 'Administrator', 'Added funds: 1 PHP', '2025-02-17 22:55:57'),
(39, 'Jaspher', 'Logged in', '2025-02-17 22:57:18'),
(40, 'Administrator', 'Logged in', '2025-02-17 22:57:29'),
(41, 'Administrator', 'Logged in', '2025-02-17 23:52:28'),
(42, 'Administrator', 'Logged in', '2025-02-17 23:56:58'),
(43, 'Administrator', 'Logged in', '2025-02-19 12:38:11'),
(44, 'Administrator', 'Logged in', '2025-02-19 12:44:57'),
(45, 'Administrator', 'Logged in', '2025-02-19 12:50:01'),
(46, 'Administrator', 'Logged in', '2025-02-19 12:54:27'),
(47, 'Administrator', 'Logged in', '2025-02-19 12:56:02'),
(48, 'Administrator', 'Logged in', '2025-02-19 12:59:49'),
(49, 'Jaspher', 'Logged in', '2025-02-19 13:03:29'),
(50, 'Administrator', 'Logged in', '2025-02-19 13:04:43'),
(51, 'Administrator', 'Logged in', '2025-02-19 13:14:29'),
(52, 'Administrator', 'Logged in', '2025-02-19 13:25:45'),
(53, 'Administrator', 'Logged in', '2025-02-19 13:41:26'),
(54, 'Administrator', 'Logged in', '2025-02-19 13:45:27'),
(55, 'Administrator', 'Logged in', '2025-02-19 20:17:51'),
(56, 'Administrator', 'Logged in', '2025-02-19 20:24:18'),
(57, 'Administrator', 'Logged in', '2025-02-19 20:36:37'),
(58, 'Administrator', 'Logged in', '2025-02-19 20:41:27'),
(59, 'Administrator', 'Logged in', '2025-02-19 20:47:11'),
(60, 'Administrator', 'Logged in', '2025-02-19 20:49:09'),
(61, 'Administrator', 'Logged in', '2025-02-19 20:49:47'),
(62, 'Jaspher', 'Logged in', '2025-02-19 20:50:57'),
(63, 'Administrator', 'Logged in', '2025-02-19 21:10:59'),
(64, 'Administrator', 'Logged in', '2025-02-19 21:12:17'),
(65, 'Administrator', 'Logged in', '2025-02-19 21:14:10'),
(66, 'Administrator', 'Logged in', '2025-02-19 21:19:36'),
(67, 'Administrator', 'Logged in', '2025-02-19 21:21:25'),
(68, 'Administrator', 'Logged in', '2025-02-19 21:27:25'),
(69, 'Administrator', 'Logged in', '2025-02-19 21:28:11'),
(70, 'Administrator', 'Logged in', '2025-02-19 21:31:21'),
(71, 'Jaspher', 'Logged in', '2025-02-19 21:34:57'),
(72, 'Jaspher', 'Logged in', '2025-02-19 21:39:27'),
(73, 'Administrator', 'Logged in', '2025-02-19 21:43:31'),
(74, 'Administrator', 'Logged in', '2025-02-19 21:50:14'),
(75, 'Administrator', 'Logged in', '2025-02-19 22:02:19'),
(76, 'Administrator', 'Logged in', '2025-02-19 22:06:31'),
(77, 'Administrator', 'Logged in', '2025-02-19 22:08:52'),
(78, 'Administrator', 'Logged in', '2025-02-19 22:10:43'),
(79, 'Administrator', 'Logged in', '2025-02-19 22:11:47'),
(80, 'Administrator', 'Logged in', '2025-02-19 22:12:51'),
(81, 'Administrator', 'Logged in', '2025-02-21 18:55:14'),
(82, 'Administrator', 'Logged in', '2025-02-21 18:58:19'),
(83, 'Administrator', 'Logged in', '2025-02-21 19:04:16'),
(84, 'Administrator', 'Logged in', '2025-02-21 19:07:36'),
(85, 'Administrator', 'Logged in', '2025-02-22 08:15:07'),
(86, 'Administrator', 'Logged in', '2025-02-22 08:16:33'),
(87, 'Administrator', 'Logged in', '2025-02-22 08:19:41'),
(88, 'Administrator', 'Logged in', '2025-02-22 08:22:50'),
(89, 'Administrator', 'Logged in', '2025-02-22 08:24:00'),
(90, 'Administrator', 'Logged in', '2025-02-22 08:33:03'),
(91, 'Administrator', 'Logged in', '2025-02-22 08:35:04'),
(92, 'Administrator', 'Logged in', '2025-02-22 08:40:26'),
(93, 'Administrator', 'Logged in', '2025-02-22 08:41:24'),
(94, 'Administrator', 'Logged in', '2025-02-22 08:42:09'),
(95, 'Administrator', 'Logged in', '2025-02-22 08:42:41'),
(96, 'Administrator', 'Logged in', '2025-02-22 08:45:08'),
(97, 'Administrator', 'Logged in', '2025-02-22 08:46:35'),
(98, 'Administrator', 'Logged in', '2025-02-22 08:51:16'),
(99, 'Administrator', 'Logged in', '2025-02-22 08:52:01'),
(100, 'Administrator', 'Logged in', '2025-02-22 08:52:28'),
(101, 'Administrator', 'Logged in', '2025-02-22 08:55:40'),
(102, 'Jaspher', 'Logged in', '2025-02-22 09:07:36'),
(103, 'Administrator', 'Logged in', '2025-02-22 09:11:57'),
(104, 'Administrator', 'Logged in', '2025-02-22 09:15:02'),
(105, 'Administrator', 'Logged in', '2025-02-22 09:16:48'),
(106, 'Administrator', 'Logged in', '2025-02-22 09:17:39'),
(107, 'Administrator', 'Logged in', '2025-02-22 09:20:00'),
(108, 'Administrator', 'Logged in', '2025-02-22 09:21:07'),
(109, 'Administrator', 'Logged in', '2025-02-22 09:35:47'),
(110, 'Administrator', 'Logged in', '2025-02-22 09:59:46'),
(111, 'Administrator', 'Logged in', '2025-02-22 10:03:25'),
(112, 'Administrator', 'Logged in', '2025-02-22 10:09:45'),
(113, 'Administrator', 'Logged in', '2025-02-22 10:13:53'),
(114, 'Administrator', 'Logged in', '2025-02-22 10:20:53'),
(115, 'Administrator', 'Logged in', '2025-02-22 10:21:20'),
(116, 'Administrator', 'Logged in', '2025-02-22 10:21:29'),
(117, 'Jaspher', 'Logged in', '2025-02-22 10:24:48'),
(118, 'Administrator', 'Logged in', '2025-02-22 10:29:37'),
(119, 'Administrator', 'Logged in', '2025-02-22 10:31:06'),
(120, 'Jaspher', 'Logged in', '2025-02-22 10:32:58'),
(121, 'Administrator', 'Logged in', '2025-02-22 10:41:04'),
(122, 'Administrator', 'Logged in', '2025-02-22 10:43:15'),
(123, 'Administrator', 'Logged in', '2025-02-22 10:44:05'),
(124, 'Administrator', 'Logged in', '2025-02-22 10:46:51'),
(125, 'Administrator', 'Logged in', '2025-02-22 10:51:02'),
(126, 'Administrator', 'Logged in', '2025-02-22 11:03:25'),
(127, 'Administrator', 'Logged in', '2025-02-22 11:04:20'),
(128, 'Administrator', 'Logged in', '2025-02-22 11:08:09'),
(129, 'Administrator', 'Updated price for LetterG to 2', '2025-02-22 11:08:14'),
(130, 'Administrator', 'Updated price for LetterC to 5', '2025-02-22 11:08:14'),
(131, 'Administrator', 'Updated price for LegalG to 3', '2025-02-22 11:08:14'),
(132, 'Administrator', 'Updated price for LegalC to 7', '2025-02-22 11:08:14'),
(133, 'Administrator', 'Logged in', '2025-02-22 11:12:11'),
(134, 'Administrator', 'Logged in', '2025-02-22 11:12:43'),
(135, 'Administrator', 'Logged in', '2025-02-22 11:14:00'),
(136, 'Administrator', 'Updated PriceShortG to 3', '2025-02-22 11:14:16'),
(137, 'Administrator', 'Updated PriceShortG to 2', '2025-02-22 11:14:33'),
(138, 'Administrator', 'Logged in', '2025-02-22 11:16:39'),
(139, 'Administrator', 'Logged in', '2025-02-22 11:22:32'),
(140, 'Administrator', 'Logged in', '2025-02-22 11:25:03'),
(141, 'Administrator', 'Logged in', '2025-02-22 11:27:44');

-- --------------------------------------------------------

--
-- Table structure for table `tblincome`
--

CREATE TABLE `tblincome` (
  `trans_id` int(11) NOT NULL,
  `kiosk_id` varchar(45) DEFAULT NULL,
  `DateTrans` datetime DEFAULT NULL,
  `Filename` varchar(255) DEFAULT NULL,
  `PaperSize` text NOT NULL,
  `PageCount` varchar(45) DEFAULT NULL,
  `Pagefrom` varchar(45) DEFAULT NULL,
  `Pageto` varchar(45) DEFAULT NULL,
  `Pageprint` varchar(45) DEFAULT NULL,
  `NumberOfcopies` varchar(45) DEFAULT NULL,
  `Coins` varchar(45) DEFAULT NULL,
  `change` int(45) DEFAULT NULL,
  `remarks` int(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `tblincome`
--

INSERT INTO `tblincome` (`trans_id`, `kiosk_id`, `DateTrans`, `Filename`, `PaperSize`, `PageCount`, `Pagefrom`, `Pageto`, `Pageprint`, `NumberOfcopies`, `Coins`, `change`, `remarks`) VALUES
(1, '1', '2025-01-18 20:19:12', 'qwer.docx', 'Long Bondpaper', '10', '10', '10', '10', '10', '50', 0, 0),
(2, '2', '2025-01-21 15:42:59', 'asd.docx', 'Letter', '10', '10', '10', '10', '10', '50', 30, 0);

-- --------------------------------------------------------

--
-- Table structure for table `tblpaperload`
--

CREATE TABLE `tblpaperload` (
  `paper_id` int(11) NOT NULL,
  `kiosk_id` int(45) DEFAULT NULL,
  `Date` datetime DEFAULT NULL,
  `papersize` text NOT NULL,
  `NumberOfPaper` varchar(45) DEFAULT NULL,
  `total` int(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `tblpaperload`
--

INSERT INTO `tblpaperload` (`paper_id`, `kiosk_id`, `Date`, `papersize`, `NumberOfPaper`, `total`) VALUES
(1, 1, '2025-01-18 19:53:58', 'Long', '60', 0),
(6, NULL, '2025-02-03 15:56:26', 'Long', '60', 0),
(7, NULL, '2025-02-03 15:57:48', 'Short', '15', 0),
(12, NULL, '2025-02-12 19:41:49', 'Short', '15', 0),
(13, NULL, '2025-02-12 19:44:31', 'Short', '1', 0),
(14, NULL, '2025-02-12 19:49:11', 'Short', '11', 0),
(15, NULL, '2025-02-12 19:49:11', 'Long', '1', 0),
(16, NULL, '2025-02-12 19:49:58', 'Short', '1', 0),
(17, NULL, '2025-02-12 19:51:14', 'Long', '1', 0),
(18, NULL, '2025-02-12 21:41:43', 'Short', '1', 0),
(19, NULL, '2025-02-12 21:41:43', 'Long', '1', 0),
(20, NULL, '2025-02-12 22:10:38', 'Long', '1', 0),
(21, NULL, '2025-02-12 22:10:54', 'Short', '1', 0),
(22, 1, '2025-02-12 22:18:57', 'Short', '33', 0),
(23, 1, '2025-02-13 19:50:22', 'Short', '1', 0),
(24, 1, '2025-02-13 19:50:22', 'Long', '1', 0),
(25, 1, '2025-02-13 19:50:47', 'Short', '1', 0),
(26, 1, '2025-02-13 19:50:47', 'Long', '1', 0),
(27, 1, '2025-02-13 19:55:29', 'Short', '1', 0),
(28, 1, '2025-02-13 19:55:29', 'Long', '1', 0),
(29, 1, '2025-02-13 20:38:48', 'Short', '11', 0),
(30, 1, '2025-02-13 20:50:00', 'Short', '1', 0),
(31, 1, '2025-02-13 21:28:05', 'Short', '1', 0),
(32, 1, '2025-02-13 21:28:05', 'Long', '1', 0),
(33, 1, '2025-02-13 21:30:03', 'Short', '11', 0),
(34, 1, '2025-02-16 19:08:56', 'Short', '9', 0),
(35, 1, '2025-02-16 19:08:56', 'Long', '11', 0),
(36, 1, '2025-02-17 10:21:41', 'Short', '11', 0),
(37, 1, '2025-02-17 19:01:26', 'Short', '1', 0),
(38, 1, '2025-02-17 22:55:38', 'Short', '1', 0);

-- --------------------------------------------------------

--
-- Table structure for table `tblregisterkiosk`
--

CREATE TABLE `tblregisterkiosk` (
  `kiosk_id` int(11) DEFAULT NULL,
  `TypeofPrinter` varchar(100) DEFAULT NULL,
  `Placedeploy` varchar(100) NOT NULL,
  `Paperload` int(11) NOT NULL,
  `date` datetime NOT NULL,
  `active` int(11) NOT NULL,
  `status_w` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `tblregisterkiosk`
--

INSERT INTO `tblregisterkiosk` (`kiosk_id`, `TypeofPrinter`, `Placedeploy`, `Paperload`, `date`, `active`, `status_w`) VALUES
(1, 'Epson L120 Series', 'It Departments', 60, '2017-10-03 07:12:23', 0, 1);

-- --------------------------------------------------------

--
-- Table structure for table `tblupadateploadpapercoins`
--

CREATE TABLE `tblupadateploadpapercoins` (
  `id` int(11) NOT NULL,
  `Code` varchar(50) NOT NULL,
  `Count` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `tblupadateploadpapercoins`
--

INSERT INTO `tblupadateploadpapercoins` (`id`, `Code`, `Count`) VALUES
(1, 'Paper', '60'),
(2, 'Coins', '1');

-- --------------------------------------------------------

--
-- Table structure for table `tbluser`
--

CREATE TABLE `tbluser` (
  `user_id` int(11) NOT NULL,
  `firstname` varchar(100) NOT NULL,
  `middlename` varchar(100) NOT NULL,
  `lastname` varchar(100) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `user_added` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `tbluser`
--

INSERT INTO `tbluser` (`user_id`, `firstname`, `middlename`, `lastname`, `username`, `password`, `user_added`) VALUES
(1, 'juel', 'd', 'coper', 'admin', 'admin', '2017-10-02 16:27:06'),
(2, 'Mara', 'L', 'Langomez', 'mara', 'mara', '2017-11-16 15:18:32'),
(3, 'Mark Ajae', 'Caraan', 'Fallago', 'mark ajae', 'caraanpogi', '2018-01-05 10:33:50'),
(4, 'mariel angelica', 'E', 'buyo', 'mariel', 'buyo', '2018-01-05 10:34:57'),
(5, 'Kevin', 'V', 'Vidamo', 'Kevin', 'kevin', '2018-01-05 10:36:50');

-- --------------------------------------------------------

--
-- Table structure for table `transactions`
--

CREATE TABLE `transactions` (
  `Transaction_ID` int(11) NOT NULL,
  `Kiosk_ID` int(11) NOT NULL,
  `Transaction_DateTime` timestamp NULL DEFAULT current_timestamp(),
  `File_Name` varchar(255) NOT NULL,
  `Number_Of_Pages` int(11) NOT NULL,
  `Print_Type` varchar(50) DEFAULT NULL,
  `Payment` decimal(10,2) NOT NULL,
  `Change_Amount` decimal(10,2) DEFAULT 0.00,
  `Print_Status` varchar(255) DEFAULT 'Pending'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transactions`
--

INSERT INTO `transactions` (`Transaction_ID`, `Kiosk_ID`, `Transaction_DateTime`, `File_Name`, `Number_Of_Pages`, `Print_Type`, `Payment`, `Change_Amount`, `Print_Status`) VALUES
(37, 1, '2024-02-22 04:30:00', 'TestFile.pdf', 5, 'Color', 100.00, 10.00, 'Completed'),
(38, 1, '2025-02-22 02:05:42', 'JOSEPH JOPIA - Copy (2).pdf', 1, 'Grayscale', 2.00, 8.00, 'Error'),
(39, 1, '2025-02-22 02:06:20', 'JOSEPH JOPIA - Copy (2).pdf', 1, 'Grayscale', 2.00, 8.00, 'Error'),
(40, 1, '2025-02-22 02:07:04', 'JOSEPH JOPIA - Copy (2).pdf', 1, 'Grayscale', 2.00, 8.00, 'Error'),
(41, 1, '2025-02-22 02:09:33', 'JOSEPH JOPIA - Copy (3).pdf', 1, 'Grayscale', 2.00, 8.00, 'Error'),
(42, 1, '2025-02-22 02:21:16', 'CCT 4th Year Individual Inventory - 262 (1).pdf', 1, 'Grayscale', 2.00, 8.00, 'Error');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `username` varchar(200) NOT NULL,
  `password` text NOT NULL,
  `Kiosk_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`, `username`, `password`, `Kiosk_ID`) VALUES
(1, 'Administrator', 'admin', 'admin', 1),
(3, 'Jaspher', 'titenus', 'titenus', 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `insertedcoins`
--
ALTER TABLE `insertedcoins`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `paperprice`
--
ALTER TABLE `paperprice`
  ADD PRIMARY KEY (`Kiosk_ID`);

--
-- Indexes for table `payments`
--
ALTER TABLE `payments`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `system_settings`
--
ALTER TABLE `system_settings`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tblavailablefunds`
--
ALTER TABLE `tblavailablefunds`
  ADD PRIMARY KEY (`Kiosk_ID`);

--
-- Indexes for table `tblavailablepapers`
--
ALTER TABLE `tblavailablepapers`
  ADD PRIMARY KEY (`Kiosk_ID`);

--
-- Indexes for table `tblcoinfunds`
--
ALTER TABLE `tblcoinfunds`
  ADD PRIMARY KEY (`fund_id`);

--
-- Indexes for table `tblhistory`
--
ALTER TABLE `tblhistory`
  ADD PRIMARY KEY (`log_id`);

--
-- Indexes for table `tblincome`
--
ALTER TABLE `tblincome`
  ADD PRIMARY KEY (`trans_id`);

--
-- Indexes for table `tblpaperload`
--
ALTER TABLE `tblpaperload`
  ADD PRIMARY KEY (`paper_id`);

--
-- Indexes for table `tblupadateploadpapercoins`
--
ALTER TABLE `tblupadateploadpapercoins`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbluser`
--
ALTER TABLE `tbluser`
  ADD PRIMARY KEY (`user_id`);

--
-- Indexes for table `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`Transaction_ID`),
  ADD KEY `Kiosk_ID` (`Kiosk_ID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `id` int(30) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- AUTO_INCREMENT for table `insertedcoins`
--
ALTER TABLE `insertedcoins`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `payments`
--
ALTER TABLE `payments`
  MODIFY `id` int(30) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `system_settings`
--
ALTER TABLE `system_settings`
  MODIFY `id` int(30) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tblcoinfunds`
--
ALTER TABLE `tblcoinfunds`
  MODIFY `fund_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `tblhistory`
--
ALTER TABLE `tblhistory`
  MODIFY `log_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=142;

--
-- AUTO_INCREMENT for table `tblincome`
--
ALTER TABLE `tblincome`
  MODIFY `trans_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tblpaperload`
--
ALTER TABLE `tblpaperload`
  MODIFY `paper_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- AUTO_INCREMENT for table `tblupadateploadpapercoins`
--
ALTER TABLE `tblupadateploadpapercoins`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tbluser`
--
ALTER TABLE `tbluser`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `transactions`
--
ALTER TABLE `transactions`
  MODIFY `Transaction_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `transactions`
--
ALTER TABLE `transactions`
  ADD CONSTRAINT `transactions_ibfk_1` FOREIGN KEY (`Kiosk_ID`) REFERENCES `paperprice` (`Kiosk_ID`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
