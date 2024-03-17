-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : ven. 12 mai 2023 à 00:14
-- Version du serveur : 10.4.27-MariaDB
-- Version de PHP : 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `dvd_gestion`
--

-- --------------------------------------------------------

--
-- Structure de la table `client`
--

CREATE TABLE `client` (
  `ClientId` int(11) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Adresse` varchar(100) NOT NULL,
  `PhoneNumber` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Déchargement des données de la table `client`
--

INSERT INTO `client` (`ClientId`, `FirstName`, `LastName`, `Adresse`, `PhoneNumber`) VALUES
(1, 'Andreas', 'San', '2 rue pages jaunes', '101010'),
(5, 'Prime', 'Rick', '11 rue des fleurs', '094575867'),
(9, 'xxx', 'dddd', 'a', '1111111111');

-- --------------------------------------------------------

--
-- Structure de la table `dvd`
--

CREATE TABLE `dvd` (
  `DVDId` int(11) NOT NULL,
  `Title` varchar(50) NOT NULL,
  `Director` varchar(50) NOT NULL,
  `Genre` varchar(50) NOT NULL,
  `ReleaseYear` int(4) NOT NULL,
  `IsAvailable` int(1) NOT NULL,
  `CoverImage` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Déchargement des données de la table `dvd`
--

INSERT INTO `dvd` (`DVDId`, `Title`, `Director`, `Genre`, `ReleaseYear`, `IsAvailable`, `CoverImage`) VALUES
(1, 'Le Seigneur des Anneaux : La Communauté de l\'Annea', 'Peter Jackson', 'FICTION', 2001, 1, NULL),
(2, 'a', 'z', 'c', 1, 1, NULL),
(3, 'Le Seigneur des Anneaux : Le Retour du Roi', 'Peter Jackson', 'FICTION', 2003, 0, NULL),
(16, 'zz', 'cc', 'dd', 1111, 0, NULL);

-- --------------------------------------------------------

--
-- Structure de la table `location`
--

CREATE TABLE `location` (
  `LocationId` int(11) NOT NULL,
  `LeClient` int(11) NOT NULL,
  `LeDVD` int(11) NOT NULL,
  `dateRented` varchar(10) NOT NULL,
  `dateReturned` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Déchargement des données de la table `location`
--

INSERT INTO `location` (`LocationId`, `LeClient`, `LeDVD`, `dateRented`, `dateReturned`) VALUES
(16, 1, 1, '2023-05-16', '2023-04-07'),
(17, 5, 2, '2023-07-15', '2023-05-17');

-- --------------------------------------------------------

--
-- Structure de la table `rapport`
--

CREATE TABLE `rapport` (
  `RapportId` int(11) NOT NULL,
  `DateGenerated` datetime NOT NULL,
  `Content` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Structure de la table `retour`
--

CREATE TABLE `retour` (
  `RetourId` int(11) NOT NULL,
  `LaLocation` int(11) NOT NULL,
  `DateReturned` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Structure de la table `user`
--

CREATE TABLE `user` (
  `UserId` int(11) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(150) NOT NULL,
  `IsAdmin` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Déchargement des données de la table `user`
--

INSERT INTO `user` (`UserId`, `Username`, `Password`, `IsAdmin`) VALUES
(1, 'admin', 'admin', 0),
(2, 'aa', 'aa', 0);

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`ClientId`);

--
-- Index pour la table `dvd`
--
ALTER TABLE `dvd`
  ADD PRIMARY KEY (`DVDId`);

--
-- Index pour la table `location`
--
ALTER TABLE `location`
  ADD PRIMARY KEY (`LocationId`),
  ADD KEY `LeClient` (`LeClient`),
  ADD KEY `LeDVD` (`LeDVD`);

--
-- Index pour la table `rapport`
--
ALTER TABLE `rapport`
  ADD PRIMARY KEY (`RapportId`);

--
-- Index pour la table `retour`
--
ALTER TABLE `retour`
  ADD PRIMARY KEY (`RetourId`),
  ADD KEY `LaLocation` (`LaLocation`);

--
-- Index pour la table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`UserId`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `client`
--
ALTER TABLE `client`
  MODIFY `ClientId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT pour la table `dvd`
--
ALTER TABLE `dvd`
  MODIFY `DVDId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT pour la table `location`
--
ALTER TABLE `location`
  MODIFY `LocationId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT pour la table `rapport`
--
ALTER TABLE `rapport`
  MODIFY `RapportId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `retour`
--
ALTER TABLE `retour`
  MODIFY `RetourId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT pour la table `user`
--
ALTER TABLE `user`
  MODIFY `UserId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `location`
--
ALTER TABLE `location`
  ADD CONSTRAINT `location_ibfk_1` FOREIGN KEY (`LeClient`) REFERENCES `client` (`ClientId`),
  ADD CONSTRAINT `location_ibfk_2` FOREIGN KEY (`LeDVD`) REFERENCES `dvd` (`DVDId`);

--
-- Contraintes pour la table `retour`
--
ALTER TABLE `retour`
  ADD CONSTRAINT `retour_ibfk_1` FOREIGN KEY (`LaLocation`) REFERENCES `location` (`LocationId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
