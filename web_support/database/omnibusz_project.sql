-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2016. Dec 04. 13:28
-- Kiszolgáló verziója: 10.1.19-MariaDB
-- PHP verzió: 5.5.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `omnibusz_project`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `forums`
--

CREATE TABLE `forums` (
  `forum_id` int(11) NOT NULL,
  `forum_name` varchar(40) CHARACTER SET utf8 COLLATE utf8_hungarian_ci NOT NULL,
  `forum_create_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `forum_status` tinyint(1) NOT NULL DEFAULT '1',
  `forum_private` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- A tábla adatainak kiíratása `forums`
--

INSERT INTO `forums` (`forum_id`, `forum_name`, `forum_create_date`, `forum_status`, `forum_private`) VALUES
(1, 'Kezdőknek', '2016-12-04 12:01:14', 0, 0),
(2, 'A játékról', '2016-12-04 12:02:46', 0, 0),
(3, 'Ötletek', '2016-12-04 12:06:05', 0, 0),
(4, 'Mérföldkövek', '2016-12-04 12:08:31', 0, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `forums_posts`
--

CREATE TABLE `forums_posts` (
  `forum_post_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `forum_text` varchar(1000) NOT NULL,
  `forum_post_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- A tábla adatainak kiíratása `forums_posts`
--

INSERT INTO `forums_posts` (`forum_post_id`, `user_id`, `forum_text`, `forum_post_date`) VALUES
(1, 5, 'Sziasztok! Nekem nagyon tetszik a játék. Nektek mi a véleményetek err?l?', '2016-12-04 12:13:22'),
(2, 3, 'Nekem nagyon bejött. Bár még lenne mit alakítani rajta, de kezdetnek nem rossz.', '2016-12-04 12:14:34'),
(3, 6, 'Szerintetetk mivel tudnánk fejleszetni a jétékosok élményét?', '2016-12-04 12:16:45'),
(4, 2, 'Szerintem jó lenne, hogyha tudnánk egymásnak privát üzenetet is írni', '2016-12-04 12:19:58');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `forums_posts_contact`
--

CREATE TABLE `forums_posts_contact` (
  `contact_id` int(11) NOT NULL,
  `forum_id` int(11) NOT NULL,
  `post_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- A tábla adatainak kiíratása `forums_posts_contact`
--

INSERT INTO `forums_posts_contact` (`contact_id`, `forum_id`, `post_id`) VALUES
(1, 2, 1),
(2, 2, 2),
(3, 4, 3),
(4, 4, 4);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `login`
--

CREATE TABLE `login` (
  `login_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `login_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `user_nickname` varchar(25) CHARACTER SET utf8 COLLATE utf8_hungarian_ci NOT NULL,
  `user_e_mail` varchar(40) NOT NULL,
  `user_born_date` date NOT NULL,
  `user_points` int(11) NOT NULL DEFAULT '0',
  `user_admin` tinyint(1) NOT NULL DEFAULT '0',
  `user_status` enum('aktív','inaktív','törölt','kitiltott') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`user_id`, `user_nickname`, `user_e_mail`, `user_born_date`, `user_points`, `user_admin`, `user_status`) VALUES
(1, 'kisbajusz', 'kisbajsz@gmail.com', '1994-03-01', 0, 0, 'aktív'),
(2, 'gringó', 'gringo@citromail.hu', '2000-12-14', 10, 1, 'aktív'),
(3, 'bud22', 'bud22@freemail.hu', '1998-04-05', 100, 0, 'kitiltott'),
(4, 'mimóza10', 'mimoza@gmail.hu', '2001-06-23', 5, 0, 'aktív'),
(5, 'bill', 'bill@gmail.hu', '1972-10-22', 0, 0, 'kitiltott'),
(6, 'ornagy1', 'ornagy1@gmail.com', '2002-12-30', 10, 1, 'aktív'),
(7, 'kisjátékos', 'kisjatekos22@citromail.hu', '1999-12-31', 150, 0, 'törölt');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `forums`
--
ALTER TABLE `forums`
  ADD PRIMARY KEY (`forum_id`);

--
-- A tábla indexei `forums_posts`
--
ALTER TABLE `forums_posts`
  ADD PRIMARY KEY (`forum_post_id`);

--
-- A tábla indexei `forums_posts_contact`
--
ALTER TABLE `forums_posts_contact`
  ADD PRIMARY KEY (`contact_id`);

--
-- A tábla indexei `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`login_id`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `forums`
--
ALTER TABLE `forums`
  MODIFY `forum_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT a táblához `forums_posts`
--
ALTER TABLE `forums_posts`
  MODIFY `forum_post_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT a táblához `forums_posts_contact`
--
ALTER TABLE `forums_posts_contact`
  MODIFY `contact_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT a táblához `login`
--
ALTER TABLE `login`
  MODIFY `login_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
