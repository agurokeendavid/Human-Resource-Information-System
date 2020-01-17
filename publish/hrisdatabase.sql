-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 16, 2020 at 04:49 AM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.1

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
-- Table structure for table `departments`
--

CREATE TABLE `departments` (
  `department_id` int(11) NOT NULL,
  `department_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
  `position_id` int(11) NOT NULL,
  `department_id` int(11) NOT NULL,
  `work_status` varchar(20) NOT NULL,
  `hired_date` date NOT NULL,
  `end_of_contract` date DEFAULT NULL,
  `status` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `employee_seminars`
--

CREATE TABLE `employee_seminars` (
  `id` int(11) NOT NULL,
  `seminar_id` int(11) NOT NULL,
  `employee_no` varchar(50) NOT NULL,
  `employee_position_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `ports`
--

CREATE TABLE `ports` (
  `port_id` int(11) NOT NULL,
  `port_name` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `positions`
--

CREATE TABLE `positions` (
  `position_id` int(11) NOT NULL,
  `position_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `seminars`
--

CREATE TABLE `seminars` (
  `seminar_id` int(11) NOT NULL,
  `seminar_name` varchar(50) NOT NULL,
  `seminar_location` varchar(50) NOT NULL,
  `seminar_date` date NOT NULL,
  `seminar_status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
(1, '1', '356a192b7913b04c54574d18c28d46e6395428ab');

-- --------------------------------------------------------

--
-- Stand-in structure for view `view_contractual_employees`
-- (See below for the actual view)
--
CREATE TABLE `view_contractual_employees` (
`employee_no` varchar(50)
,`first_name` varchar(100)
,`middle_name` varchar(100)
,`last_name` varchar(100)
,`address` varchar(100)
,`gender` varchar(20)
,`date_of_birth` date
,`place_of_birth` varchar(100)
,`contact_no` varchar(20)
,`civil_status` varchar(20)
,`position_name` varchar(50)
,`department_name` varchar(50)
,`work_status` varchar(20)
,`hired_date` date
,`end_of_contract` date
,`status` varchar(20)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `view_employees`
-- (See below for the actual view)
--
CREATE TABLE `view_employees` (
`employee_no` varchar(50)
,`first_name` varchar(100)
,`middle_name` varchar(100)
,`last_name` varchar(100)
,`address` varchar(100)
,`gender` varchar(20)
,`date_of_birth` date
,`place_of_birth` varchar(100)
,`contact_no` varchar(20)
,`civil_status` varchar(20)
,`position_name` varchar(50)
,`department_name` varchar(50)
,`work_status` varchar(20)
,`hired_date` date
,`end_of_contract` date
,`status` varchar(20)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `view_regular_employees`
-- (See below for the actual view)
--
CREATE TABLE `view_regular_employees` (
`employee_no` varchar(50)
,`first_name` varchar(100)
,`middle_name` varchar(100)
,`last_name` varchar(100)
,`address` varchar(100)
,`gender` varchar(20)
,`date_of_birth` date
,`place_of_birth` varchar(100)
,`contact_no` varchar(20)
,`civil_status` varchar(20)
,`position_name` varchar(50)
,`department_name` varchar(50)
,`work_status` varchar(20)
,`hired_date` date
,`end_of_contract` date
,`status` varchar(20)
);

-- --------------------------------------------------------

--
-- Structure for view `view_contractual_employees`
--
DROP TABLE IF EXISTS `view_contractual_employees`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_contractual_employees`  AS  select `emp`.`employee_no` AS `employee_no`,`emp`.`first_name` AS `first_name`,`emp`.`middle_name` AS `middle_name`,`emp`.`last_name` AS `last_name`,`emp`.`address` AS `address`,`emp`.`gender` AS `gender`,`emp`.`date_of_birth` AS `date_of_birth`,`emp`.`place_of_birth` AS `place_of_birth`,`emp`.`contact_no` AS `contact_no`,`emp`.`civil_status` AS `civil_status`,`pos`.`position_name` AS `position_name`,`dept`.`department_name` AS `department_name`,`emp`.`work_status` AS `work_status`,`emp`.`hired_date` AS `hired_date`,`emp`.`end_of_contract` AS `end_of_contract`,`emp`.`status` AS `status` from ((`employees` `emp` join `positions` `pos` on(`emp`.`position_id` = `pos`.`position_id`)) join `departments` `dept` on(`emp`.`department_id` = `dept`.`department_id`)) where `emp`.`work_status` = 'Contractual' and `emp`.`status` = 'Active' ;

-- --------------------------------------------------------

--
-- Structure for view `view_employees`
--
DROP TABLE IF EXISTS `view_employees`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_employees`  AS  select `emp`.`employee_no` AS `employee_no`,`emp`.`first_name` AS `first_name`,`emp`.`middle_name` AS `middle_name`,`emp`.`last_name` AS `last_name`,`emp`.`address` AS `address`,`emp`.`gender` AS `gender`,`emp`.`date_of_birth` AS `date_of_birth`,`emp`.`place_of_birth` AS `place_of_birth`,`emp`.`contact_no` AS `contact_no`,`emp`.`civil_status` AS `civil_status`,`pos`.`position_name` AS `position_name`,`dept`.`department_name` AS `department_name`,`emp`.`work_status` AS `work_status`,`emp`.`hired_date` AS `hired_date`,`emp`.`end_of_contract` AS `end_of_contract`,`emp`.`status` AS `status` from ((`employees` `emp` join `positions` `pos` on(`emp`.`position_id` = `pos`.`position_id`)) join `departments` `dept` on(`emp`.`department_id` = `dept`.`department_id`)) where `emp`.`status` = 'Active' ;

-- --------------------------------------------------------

--
-- Structure for view `view_regular_employees`
--
DROP TABLE IF EXISTS `view_regular_employees`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_regular_employees`  AS  select `emp`.`employee_no` AS `employee_no`,`emp`.`first_name` AS `first_name`,`emp`.`middle_name` AS `middle_name`,`emp`.`last_name` AS `last_name`,`emp`.`address` AS `address`,`emp`.`gender` AS `gender`,`emp`.`date_of_birth` AS `date_of_birth`,`emp`.`place_of_birth` AS `place_of_birth`,`emp`.`contact_no` AS `contact_no`,`emp`.`civil_status` AS `civil_status`,`pos`.`position_name` AS `position_name`,`dept`.`department_name` AS `department_name`,`emp`.`work_status` AS `work_status`,`emp`.`hired_date` AS `hired_date`,`emp`.`end_of_contract` AS `end_of_contract`,`emp`.`status` AS `status` from ((`employees` `emp` join `positions` `pos` on(`emp`.`position_id` = `pos`.`position_id`)) join `departments` `dept` on(`emp`.`department_id` = `dept`.`department_id`)) where `emp`.`work_status` = 'Regular' and `emp`.`status` = 'Active' ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `departments`
--
ALTER TABLE `departments`
  ADD PRIMARY KEY (`department_id`);

--
-- Indexes for table `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`employee_id`),
  ADD UNIQUE KEY `employee_no` (`employee_no`),
  ADD UNIQUE KEY `position_id` (`position_id`),
  ADD UNIQUE KEY `department_id` (`department_id`);

--
-- Indexes for table `employee_seminars`
--
ALTER TABLE `employee_seminars`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `seminar_id` (`seminar_id`);

--
-- Indexes for table `ports`
--
ALTER TABLE `ports`
  ADD PRIMARY KEY (`port_id`);

--
-- Indexes for table `positions`
--
ALTER TABLE `positions`
  ADD PRIMARY KEY (`position_id`);

--
-- Indexes for table `seminars`
--
ALTER TABLE `seminars`
  ADD PRIMARY KEY (`seminar_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`userID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `departments`
--
ALTER TABLE `departments`
  MODIFY `department_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employees`
--
ALTER TABLE `employees`
  MODIFY `employee_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employee_seminars`
--
ALTER TABLE `employee_seminars`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `ports`
--
ALTER TABLE `ports`
  MODIFY `port_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `positions`
--
ALTER TABLE `positions`
  MODIFY `position_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `seminars`
--
ALTER TABLE `seminars`
  MODIFY `seminar_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `userID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `employees`
--
ALTER TABLE `employees`
  ADD CONSTRAINT `department_id_fk` FOREIGN KEY (`department_id`) REFERENCES `departments` (`department_id`),
  ADD CONSTRAINT `position_id_fk` FOREIGN KEY (`position_id`) REFERENCES `positions` (`position_id`);

--
-- Constraints for table `employee_seminars`
--
ALTER TABLE `employee_seminars`
  ADD CONSTRAINT `seminar_id_fk` FOREIGN KEY (`seminar_id`) REFERENCES `seminars` (`seminar_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
