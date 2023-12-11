-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 11, 2023 at 01:15 PM
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
-- Database: `dbpos`
--

-- --------------------------------------------------------

--
-- Table structure for table `orders_list`
--

CREATE TABLE `orders_list` (
  `purchased_id` int(11) NOT NULL,
  `transact_id` text DEFAULT NULL,
  `product_id` varchar(30) DEFAULT NULL,
  `unit_price` float DEFAULT NULL,
  `qty` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `orders_list`
--

INSERT INTO `orders_list` (`purchased_id`, `transact_id`, `product_id`, `unit_price`, `qty`) VALUES
(13, '915020952432', 'P002', 60.25, 5),
(14, '915020952432', 'P003', 69.75, 5),
(15, '915020952432', 'P005', 55, 10);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_added_product`
--

CREATE TABLE `tbl_added_product` (
  `prod_id` int(11) NOT NULL,
  `prod_code` varchar(25) DEFAULT NULL,
  `prod_desc` varchar(125) DEFAULT NULL,
  `prod_category` varchar(125) DEFAULT NULL,
  `prod_unit_price` float DEFAULT NULL,
  `prod_qty` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_category`
--

CREATE TABLE `tbl_category` (
  `cat_id` int(11) NOT NULL,
  `product_desc` varchar(125) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `tbl_category`
--

INSERT INTO `tbl_category` (`cat_id`, `product_desc`) VALUES
(1, 'Beverages'),
(2, 'Biscuits'),
(4, 'Health & Beauty'),
(7, 'Liquor'),
(8, 'Dairy');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_products`
--

CREATE TABLE `tbl_products` (
  `prod_id` int(11) NOT NULL,
  `prod_code` varchar(25) DEFAULT NULL,
  `prod_desc` varchar(125) DEFAULT NULL,
  `prod_category` int(30) DEFAULT NULL,
  `prod_unit_price` text DEFAULT NULL,
  `prod_qty` int(11) DEFAULT 0,
  `prod_reorder_level` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `tbl_products`
--

INSERT INTO `tbl_products` (`prod_id`, `prod_code`, `prod_desc`, `prod_category`, `prod_unit_price`, `prod_qty`, `prod_reorder_level`) VALUES
(1, 'P001', 'Nestle All-Purpose Cream', 8, '55.5', 25, 10),
(2, 'P002', 'Fudgee Bar', 2, '60.25', 50, 15),
(3, 'P003', 'Quake Overload', 2, '69.75', 350, 10),
(4, 'P004', '80 grams', 2, '65', 180, 10),
(15, 'P005', 'San Mig Light', 1, '55', 25, 10);

-- --------------------------------------------------------

--
-- Table structure for table `transactions_list`
--

CREATE TABLE `transactions_list` (
  `transact_id` int(30) NOT NULL,
  `transact_no` bigint(30) DEFAULT NULL,
  `discount_amount` varchar(25) DEFAULT NULL,
  `tax_amount` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `transactions_list`
--

INSERT INTO `transactions_list` (`transact_id`, `transact_no`, `discount_amount`, `tax_amount`) VALUES
(11, 454673098228, '48.75', '117.00'),
(12, 915020952432, '60.00', '144.00');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(25) DEFAULT NULL,
  `password` varchar(25) DEFAULT NULL,
  `last_name` varchar(25) DEFAULT NULL,
  `first_name` varchar(25) DEFAULT NULL,
  `middle_name` varchar(25) DEFAULT NULL,
  `birthdate` text DEFAULT NULL,
  `address` varchar(125) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `contact_no` text DEFAULT NULL,
  `status` varchar(25) DEFAULT NULL,
  `user_level` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `last_name`, `first_name`, `middle_name`, `birthdate`, `address`, `age`, `contact_no`, `status`, `user_level`) VALUES
(1, 'admin', 'admin12345', 'Dela Cruz', 'Juan', 'Santos', '1996-12-25', 'Bulacan', 26, '2147483647', 'Active', 'Administrator'),
(6, 'juandelacruz', 'juandelacruz', 'Dela Cruz', 'Juan', 'Smith', '12/26/1996', 'Cebu', 26, '09678755116', '0', 'Cashier');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `orders_list`
--
ALTER TABLE `orders_list`
  ADD PRIMARY KEY (`purchased_id`);

--
-- Indexes for table `tbl_added_product`
--
ALTER TABLE `tbl_added_product`
  ADD PRIMARY KEY (`prod_id`);

--
-- Indexes for table `tbl_category`
--
ALTER TABLE `tbl_category`
  ADD PRIMARY KEY (`cat_id`);

--
-- Indexes for table `tbl_products`
--
ALTER TABLE `tbl_products`
  ADD PRIMARY KEY (`prod_id`);

--
-- Indexes for table `transactions_list`
--
ALTER TABLE `transactions_list`
  ADD PRIMARY KEY (`transact_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `orders_list`
--
ALTER TABLE `orders_list`
  MODIFY `purchased_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `tbl_added_product`
--
ALTER TABLE `tbl_added_product`
  MODIFY `prod_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `tbl_category`
--
ALTER TABLE `tbl_category`
  MODIFY `cat_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `tbl_products`
--
ALTER TABLE `tbl_products`
  MODIFY `prod_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `transactions_list`
--
ALTER TABLE `transactions_list`
  MODIFY `transact_id` int(30) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
