-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th12 12, 2023 lúc 04:45 AM
-- Phiên bản máy phục vụ: 10.4.32-MariaDB
-- Phiên bản PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `quanlyquancf`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `account`
--

CREATE TABLE `account` (
  `id` int(11) NOT NULL,
  `DisplayName` varchar(100) NOT NULL,
  `UserName` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `Type` int(11) NOT NULL DEFAULT 0 COMMENT '0: Staff\r\n1: Admin'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `account`
--

INSERT INTO `account` (`id`, `DisplayName`, `UserName`, `Password`, `Type`) VALUES
(1, 'Nguyen Duc Huy', 'duchuy', '123', 0),
(2, 'Admin ne', 'admin', '123', 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `bill`
--

CREATE TABLE `bill` (
  `id` int(11) NOT NULL,
  `dateCheckIn` date NOT NULL,
  `dateCheckOut` date DEFAULT NULL,
  `idTable` int(11) NOT NULL,
  `status` int(11) NOT NULL COMMENT '0: chưa thanh toán \r\n1: đã thanh toán'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `bill`
--

INSERT INTO `bill` (`id`, `dateCheckIn`, `dateCheckOut`, `idTable`, `status`) VALUES
(50, '2023-12-07', '2023-12-07', 3, 1),
(51, '2023-12-07', '2023-12-07', 6, 1),
(52, '2023-12-07', '2023-12-08', 6, 1),
(53, '2023-12-08', '2023-12-11', 3, 1),
(54, '2023-12-08', NULL, 7, 0),
(55, '2023-12-08', NULL, 5, 0),
(56, '2023-12-11', '2023-12-12', 4, 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `billinfo`
--

CREATE TABLE `billinfo` (
  `id` int(11) NOT NULL,
  `idBill` int(11) NOT NULL,
  `idFood` int(11) NOT NULL,
  `count` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `billinfo`
--

INSERT INTO `billinfo` (`id`, `idBill`, `idFood`, `count`) VALUES
(59, 50, 1, 2),
(60, 50, 2, 1),
(61, 50, 4, 1),
(62, 51, 2, 1),
(63, 51, 12, 4),
(64, 52, 1, 3),
(65, 52, 2, 12),
(66, 53, 1, 1),
(67, 54, 3, 1),
(68, 54, 1, 1),
(69, 54, 2, 11),
(70, 55, 2, 7),
(71, 55, 10, 1),
(72, 55, 5, 1),
(73, 56, 1, 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `food`
--

CREATE TABLE `food` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `idCategory` int(11) NOT NULL,
  `price` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `food`
--

INSERT INTO `food` (`id`, `name`, `idCategory`, `price`) VALUES
(1, 'Cafe sữa đá', 1, 15000),
(2, 'Cafe đen', 1, 12000),
(3, 'Bạc xỉu', 1, 17000),
(4, 'Cappuccino', 1, 21000),
(5, 'Xúc xích chiêng', 2, 8000),
(6, 'Khoai tây chiêng', 2, 6000),
(7, 'Phô mai chiêng', 2, 7000),
(8, 'Mì tôm trứng', 2, 15000),
(10, 'Cam ép', 3, 21000),
(11, 'Dưa hấu ép', 3, 22000),
(12, 'Chanh dây', 3, 23000),
(13, 'Sinh tố ổi', 3, 24000);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `foodcategory`
--

CREATE TABLE `foodcategory` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `foodcategory`
--

INSERT INTO `foodcategory` (`id`, `name`) VALUES
(1, 'Cafe'),
(2, 'Đồ ăn'),
(3, 'Nước ép');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tablefood`
--

CREATE TABLE `tablefood` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `status` varchar(100) NOT NULL COMMENT 'trống || có người'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `tablefood`
--

INSERT INTO `tablefood` (`id`, `name`, `status`) VALUES
(1, 'Bàn 1', 'Trống'),
(2, 'Bàn 2', 'Trống'),
(3, 'Bàn 3', 'Trống'),
(4, 'Bàn 4', 'Trống'),
(5, 'Bàn 5', 'Có người'),
(6, 'Bàn 6', 'Trống'),
(7, 'Bàn 7', 'Có người'),
(8, 'Bàn 8', 'Trống'),
(9, 'Bàn 9', 'Trống');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `bill`
--
ALTER TABLE `bill`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_bill_tableFood` (`idTable`);

--
-- Chỉ mục cho bảng `billinfo`
--
ALTER TABLE `billinfo`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_bill_billInfo` (`idBill`),
  ADD KEY `fk_billinfo_food` (`idFood`);

--
-- Chỉ mục cho bảng `food`
--
ALTER TABLE `food`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_food_foodcategory` (`idCategory`);

--
-- Chỉ mục cho bảng `foodcategory`
--
ALTER TABLE `foodcategory`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `tablefood`
--
ALTER TABLE `tablefood`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `account`
--
ALTER TABLE `account`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT cho bảng `bill`
--
ALTER TABLE `bill`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=57;

--
-- AUTO_INCREMENT cho bảng `billinfo`
--
ALTER TABLE `billinfo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=74;

--
-- AUTO_INCREMENT cho bảng `food`
--
ALTER TABLE `food`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT cho bảng `foodcategory`
--
ALTER TABLE `foodcategory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT cho bảng `tablefood`
--
ALTER TABLE `tablefood`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `bill`
--
ALTER TABLE `bill`
  ADD CONSTRAINT `fk_bill_tableFood` FOREIGN KEY (`idTable`) REFERENCES `tablefood` (`id`);

--
-- Các ràng buộc cho bảng `billinfo`
--
ALTER TABLE `billinfo`
  ADD CONSTRAINT `fk_bill_billInfo` FOREIGN KEY (`idBill`) REFERENCES `bill` (`id`),
  ADD CONSTRAINT `fk_billinfo_food` FOREIGN KEY (`idFood`) REFERENCES `food` (`id`);

--
-- Các ràng buộc cho bảng `food`
--
ALTER TABLE `food`
  ADD CONSTRAINT `fk_food_foodcategory` FOREIGN KEY (`idCategory`) REFERENCES `foodcategory` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
