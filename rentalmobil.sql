-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 25, 2021 at 09:22 AM
-- Server version: 10.4.17-MariaDB
-- PHP Version: 8.0.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `rentalmobil`
--

-- --------------------------------------------------------

--
-- Table structure for table `jenis_mobil`
--

CREATE TABLE `jenis_mobil` (
  `idjenis` int(11) NOT NULL,
  `jenis` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `jenis_mobil`
--

INSERT INTO `jenis_mobil` (`idjenis`, `jenis`) VALUES
(1, 'MPV'),
(2, 'City Car'),
(6, 'SUV'),
(10, 'Pick Up'),
(11, 'Truck'),
(16, 'Bus'),
(17, 'Mini Bus'),
(18, 'Sedan');

-- --------------------------------------------------------

--
-- Table structure for table `merk`
--

CREATE TABLE `merk` (
  `idmerk` int(11) NOT NULL,
  `merk` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `merk`
--

INSERT INTO `merk` (`idmerk`, `merk`) VALUES
(1, 'Honda'),
(2, 'Toyota'),
(3, 'Daihatsu'),
(4, 'Suzuki'),
(5, 'Mitsubishi');

-- --------------------------------------------------------

--
-- Table structure for table `mobil`
--

CREATE TABLE `mobil` (
  `idmobil` int(11) NOT NULL,
  `nopol` varchar(30) NOT NULL,
  `jenis` varchar(30) NOT NULL,
  `nama_mobil` varchar(255) NOT NULL,
  `merk` varchar(30) NOT NULL,
  `harga` double NOT NULL,
  `ketersediaan` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `mobil`
--

INSERT INTO `mobil` (`idmobil`, `nopol`, `jenis`, `nama_mobil`, `merk`, `harga`, `ketersediaan`) VALUES
(1, 'E7867JF', 'MPV', 'Xenia Biru', 'Daihatsu', 300000, 'Tersedia'),
(2, 'E6576JK', 'MPV', 'Avanza New Hitam', 'Toyota', 350000, 'Tidak Tersedia');

-- --------------------------------------------------------

--
-- Table structure for table `transaksi`
--

CREATE TABLE `transaksi` (
  `idtransaksi` int(11) NOT NULL,
  `no_transaksi` varchar(11) NOT NULL,
  `no_ktp` varchar(16) NOT NULL,
  `nama_lengkap` varchar(255) DEFAULT NULL,
  `jk` char(1) DEFAULT NULL,
  `no_telp` varchar(20) DEFAULT NULL,
  `alamat` varchar(255) DEFAULT NULL,
  `jenis_mobil` varchar(30) DEFAULT NULL,
  `merk` varchar(30) DEFAULT NULL,
  `nopol` varchar(30) DEFAULT NULL,
  `nama_mobil` varchar(255) DEFAULT NULL,
  `harga_sewa` double DEFAULT NULL,
  `tgl_ambil` varchar(255) DEFAULT NULL,
  `tgl_kembali` varchar(255) DEFAULT NULL,
  `tgl_pengembalian` varchar(30) DEFAULT NULL,
  `total_biaya` double DEFAULT NULL,
  `pengembalian` varchar(30) DEFAULT NULL,
  `denda` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `transaksi`
--

INSERT INTO `transaksi` (`idtransaksi`, `no_transaksi`, `no_ktp`, `nama_lengkap`, `jk`, `no_telp`, `alamat`, `jenis_mobil`, `merk`, `nopol`, `nama_mobil`, `harga_sewa`, `tgl_ambil`, `tgl_kembali`, `tgl_pengembalian`, `total_biaya`, `pengembalian`, `denda`) VALUES
(6, '5874226', '1234567890120003', 'Khubah Khoirurobiq', 'L', '08562550270', 'Jl. Teratai no 16', 'MPV', 'Toyota', 'E6576JK', 'Avanza New Hitam', 350000, '25-Jan-2021', '26-Jan-2021', '', 350000, 'BELUM', 0),
(7, '3206196', '9876525527518700', 'Siti Khairin', 'P', '087654657110', 'Jl. Damai no 78', 'MPV', 'Daihatsu', 'E7867JF', 'Xenia Biru', 300000, '25-Jan-2021', '27-Jan-2021', '27-Jan-2021', 600000, 'SELESAI', 0);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `iduser` int(11) NOT NULL,
  `username` varchar(255) DEFAULT NULL,
  `nama_lengkap` varchar(255) DEFAULT NULL,
  `passwd` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`iduser`, `username`, `nama_lengkap`, `passwd`) VALUES
(2, 'admin', 'Admin Rental Mobil', '202cb962ac59075b964b07152d234b70'),
(3, 'khubah', 'Khubah Khoirurobiq', '202cb962ac59075b964b07152d234b70'),
(4, 'dodi', 'Dodi Saputra', '202cb962ac59075b964b07152d234b70');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `jenis_mobil`
--
ALTER TABLE `jenis_mobil`
  ADD PRIMARY KEY (`idjenis`);

--
-- Indexes for table `merk`
--
ALTER TABLE `merk`
  ADD PRIMARY KEY (`idmerk`);

--
-- Indexes for table `mobil`
--
ALTER TABLE `mobil`
  ADD PRIMARY KEY (`idmobil`);

--
-- Indexes for table `transaksi`
--
ALTER TABLE `transaksi`
  ADD PRIMARY KEY (`idtransaksi`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`iduser`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `jenis_mobil`
--
ALTER TABLE `jenis_mobil`
  MODIFY `idjenis` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT for table `merk`
--
ALTER TABLE `merk`
  MODIFY `idmerk` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `mobil`
--
ALTER TABLE `mobil`
  MODIFY `idmobil` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `transaksi`
--
ALTER TABLE `transaksi`
  MODIFY `idtransaksi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `iduser` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
