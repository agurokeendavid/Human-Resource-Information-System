-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 17, 2020 at 03:16 PM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hriscapsu`
--

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE `employees` (
  `employee_id` int(11) NOT NULL,
  `employee_no` varchar(50) NOT NULL,
  `first_name` varchar(100) NOT NULL,
  `middle_name` varchar(100) NOT NULL,
  `last_name` varchar(100) NOT NULL,
  `address` varchar(100) NOT NULL,
  `gender` varchar(20) NOT NULL,
  `date_of_birth` date NOT NULL,
  `place_of_birth` varchar(100) NOT NULL,
  `contact_no` varchar(20) NOT NULL,
  `civil_status` varchar(20) NOT NULL,
  `highest_degree` varchar(30) NOT NULL,
  `bs_course` varchar(30) NOT NULL,
  `bs_year_graduated` int(11) NOT NULL,
  `bs_school` varchar(30) NOT NULL,
  `masteral_course` varchar(30) NOT NULL,
  `masteral_year_graduated` int(11) NOT NULL,
  `masteral_school` varchar(30) NOT NULL,
  `doctoral_course` varchar(30) NOT NULL,
  `doctoral_year_graduated` int(11) NOT NULL,
  `doctoral_school` varchar(30) NOT NULL,
  `eligibility` varchar(30) NOT NULL,
  `employee_type` varchar(15) NOT NULL,
  `position` varchar(50) NOT NULL,
  `unique_item_no` varchar(50) NOT NULL,
  `salary_grade` int(11) NOT NULL,
  `step` int(11) NOT NULL,
  `department` varchar(50) NOT NULL,
  `work_status` varchar(20) NOT NULL,
  `employee_photo` blob NOT NULL,
  `documentpath` varchar(300) NOT NULL,
  `hired_date` date NOT NULL,
  `end_of_contract` date DEFAULT NULL,
  `is_deleted` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `ports`
--

CREATE TABLE `ports` (
  `port_id` int(11) NOT NULL,
  `port_name` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `ports`
--

INSERT INTO `ports` (`port_id`, `port_name`) VALUES
(1, 'COM1');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_leave`
--

CREATE TABLE `tbl_leave` (
  `id` int(11) NOT NULL,
  `employee_no` varchar(50) NOT NULL,
  `leave_credits` int(5) NOT NULL,
  `remaining_leave` int(5) NOT NULL,
  `type` varchar(20) DEFAULT NULL,
  `from_date` date NOT NULL,
  `to_date` date NOT NULL,
  `reason` varchar(150) NOT NULL,
  `is_deleted` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_list_of_seminars`
--

CREATE TABLE `tbl_list_of_seminars` (
  `id` int(11) NOT NULL,
  `employee_no` varchar(50) NOT NULL,
  `local_seminar_name` varchar(50) DEFAULT NULL,
  `local_seminar_type` varchar(50) DEFAULT NULL,
  `local_from` date DEFAULT NULL,
  `local_to` date DEFAULT NULL,
  `regional_seminar_name` varchar(50) DEFAULT NULL,
  `regional_seminar_type` varchar(50) DEFAULT NULL,
  `regional_from` date DEFAULT NULL,
  `regional_to` date DEFAULT NULL,
  `national_seminar_name` varchar(50) DEFAULT NULL,
  `national_seminar_type` varchar(50) DEFAULT NULL,
  `national_from` date DEFAULT NULL,
  `national_to` date DEFAULT NULL,
  `international_seminar_name` varchar(50) DEFAULT NULL,
  `international_seminar_type` varchar(50) DEFAULT NULL,
  `international_from` date DEFAULT NULL,
  `international_to` date DEFAULT NULL,
  `number_of_seminars` int(11) DEFAULT NULL,
  `is_deleted` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_positions`
--

CREATE TABLE `tbl_positions` (
  `id` int(11) NOT NULL,
  `position_name` varchar(50) NOT NULL,
  `position_type` varchar(30) NOT NULL,
  `salary_grade_level` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_positions`
--

INSERT INTO `tbl_positions` (`id`, `position_name`, `position_type`, `salary_grade_level`) VALUES
(1, 'Instructor I', 'Academic', 12),
(2, 'Instructor II', 'Academic', 13),
(3, 'Professor II', 'Non - Academic', 24);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `userID` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`userID`, `username`, `password`) VALUES
(1, 'admin', '356a192b7913b04c54574d18c28d46e6395428ab');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`employee_id`),
  ADD UNIQUE KEY `employee_no` (`employee_no`);

--
-- Indexes for table `ports`
--
ALTER TABLE `ports`
  ADD PRIMARY KEY (`port_id`);

--
-- Indexes for table `tbl_leave`
--
ALTER TABLE `tbl_leave`
  ADD PRIMARY KEY (`id`),
  ADD KEY `employee_no_fk` (`employee_no`);

--
-- Indexes for table `tbl_list_of_seminars`
--
ALTER TABLE `tbl_list_of_seminars`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `employee_no` (`employee_no`);

--
-- Indexes for table `tbl_positions`
--
ALTER TABLE `tbl_positions`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `position_name` (`position_name`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`userID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `employees`
--
ALTER TABLE `employees`
  MODIFY `employee_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT for table `ports`
--
ALTER TABLE `ports`
  MODIFY `port_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tbl_leave`
--
ALTER TABLE `tbl_leave`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `tbl_list_of_seminars`
--
ALTER TABLE `tbl_list_of_seminars`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `tbl_positions`
--
ALTER TABLE `tbl_positions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `userID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
