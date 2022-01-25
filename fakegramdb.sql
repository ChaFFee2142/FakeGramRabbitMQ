-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Янв 25 2022 г., 22:09
-- Версия сервера: 10.4.18-MariaDB
-- Версия PHP: 8.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `fakegramdb`
--

-- --------------------------------------------------------

--
-- Структура таблицы `chatrooms`
--

CREATE TABLE `chatrooms` (
  `id` int(11) NOT NULL,
  `roomName` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `chatrooms`
--

INSERT INTO `chatrooms` (`id`, `roomName`) VALUES
(4, 'Vova_Vlad'),
(5, 'Vova_Hubert'),
(6, 'Vova_Oleksandr'),
(7, 'Vlad_Oleksandr'),
(8, 'Vlad_Hubert'),
(9, 'Hubert_Oleksandr'),
(10, 'hubert_Artem'),
(11, 'Artem_Vova');

-- --------------------------------------------------------

--
-- Структура таблицы `messagehistory`
--

CREATE TABLE `messagehistory` (
  `id` int(11) NOT NULL,
  `channel` varchar(255) NOT NULL,
  `message` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `messagehistory`
--

INSERT INTO `messagehistory` (`id`, `channel`, `message`) VALUES
(4, '', '{\"Author\":\"Vova\",\"Text\":\"YXNk\"}'),
(5, '', '{\"Author\":\"Vova\",\"Text\":\"SEVZ\"}'),
(6, '', '{\"Author\":\"Vova\",\"Text\":\"aG0=\"}'),
(7, '', '{\"Author\":\"Hubert\",\"Text\":\"Tm8=\"}'),
(8, '', '{\"Author\":\"Vova\",\"Text\":\"MQ0K\"}'),
(9, '', '{\"Author\":\"Vova\",\"Text\":\"Mg==\"}'),
(10, '', '{\"Author\":\"Vova\",\"Text\":\"Mw==\"}'),
(11, '', '{\"Author\":\"Vova\",\"Text\":\"NA==\"}'),
(12, 'Vova_Hubert', '{\"Author\":\"Hubert\",\"Text\":\"SGV5\"}'),
(13, 'Vova_Hubert', '{\"Author\":\"Vova\",\"Text\":\"WUVBSA==\"}'),
(14, 'Vova_Oleksandr', '{\"Author\":\"Vova\",\"Text\":\"SGV5\"}'),
(15, 'Vova_Oleksandr', '{\"Author\":\"Vova\",\"Text\":\"aG0=\"}'),
(16, 'Vova_Oleksandr', '{\"Author\":\"Oleksandr\",\"Text\":\"OkQ=\"}'),
(17, 'Vova_Oleksandr', '{\"Author\":\"Oleksandr\",\"Text\":\"OkQ=\"}'),
(18, 'Vova_Oleksandr', '{\"Author\":\"Vova\",\"Text\":\"YXNk\"}'),
(19, 'Vova_Vlad', '{\"Author\":\"Vova\",\"Text\":\"YWFzZGFzZA==\"}'),
(20, 'Vova_Oleksandr', '{\"Author\":\"Vova\",\"Text\":\"YXNkYXNk\"}'),
(21, 'Vova_Hubert', '{\"Author\":\"Vova\",\"Text\":\"YXNkYXNk\"}'),
(22, 'Vova_Oleksandr', '{\"Author\":\"Vova\",\"Text\":\"YXNk\"}'),
(23, 'Vova_Hubert', '{\"Author\":\"Vova\",\"Text\":\"YXNk\"}'),
(24, 'Vova_Hubert', '{\"Author\":\"Vova\",\"Text\":\"YXNkYXNk\"}'),
(25, 'Vova_Hubert', '{\"Author\":\"Vova\",\"Text\":\"SGV5\"}'),
(26, 'Vova_Hubert', '{\"Author\":\"Vova\",\"Text\":\"YXNk\"}'),
(27, 'Vova_Hubert', '{\"Author\":\"Vova\",\"Text\":\"YXNk\"}'),
(28, 'Vova_Hubert', '{\"Author\":\"Hubert\",\"Text\":\"YXNk\"}'),
(29, 'Vova_Hubert', '{\"Author\":\"Hubert\",\"Text\":\"YXNk\"}'),
(30, 'Vova_Oleksandr', '{\"Author\":\"Vova\",\"Text\":\"YXNk\"}'),
(31, 'Vova_Vlad', '{\"Author\":\"Vlad\",\"Text\":\"0J/RgNC40LLQtdGC\"}'),
(32, 'Vova_Hubert', '{\"Author\":\"Hubert\",\"Text\":\"SmFrIHRhbT8=\"}'),
(33, 'Vova_Vlad', '{\"Author\":\"Vlad\",\"Text\":\"RW50ZXIgdGV4dCBoZXJlLi4u\"}'),
(34, 'Vova_Hubert', '{\"Author\":\"Vova\",\"Text\":\"U3Bva28=\"}'),
(35, 'Vova_Vlad', '{\"Author\":\"Vova\",\"Text\":\"c2RmZ2hqaw==\"}'),
(36, 'Vova_Oleksandr', '{\"Author\":\"Vova\",\"Text\":\"Zmdoamts\"}'),
(37, 'Vova_Hubert', '{\"Author\":\"Vova\",\"Text\":\"VEVTVA==\"}'),
(38, 'Vova_Hubert', '{\"Author\":\"Hubert\",\"Text\":\"VEVaIFRFU1Q=\"}'),
(39, 'Vova_Oleksandr', '{\"Author\":\"Vova\",\"Text\":\"aGV5\"}'),
(40, 'Vova_Oleksandr', '{\"Author\":\"Oleksandr\",\"Text\":\"aGV5\"}'),
(41, 'Hubert_Oleksandr', '{\"Author\":\"hubert\",\"Text\":\"YXNk\"}'),
(42, 'Hubert_Oleksandr', '{\"Author\":\"Oleksandr\",\"Text\":\"YXNk\"}'),
(43, 'Hubert_Oleksandr', '{\"Author\":\"hubert\",\"Text\":\"MTMyNDNy\"}'),
(44, 'Vova_Oleksandr', '{\"Author\":\"Vova\",\"Text\":\"MQ==\"}'),
(45, 'Vova_Hubert', '{\"Author\":\"Vova\",\"Text\":\"Mg==\"}'),
(46, 'Artem_Vova', '{\"Author\":\"Vova\",\"Text\":\"Mw==\"}'),
(47, 'Artem_Vova', '{\"Author\":\"Vova\",\"Text\":\"aG0=\"}'),
(48, 'Vova_Hubert', '{\"Author\":\"Hubert\",\"Text\":\"cw==\"}'),
(49, 'Artem_Vova', '{\"Author\":\"Vova\",\"Text\":\"VEVTVA==\"}'),
(50, 'hubert_Artem', '{\"Author\":\"Artem\",\"Text\":\"VEVTVCBNRVNTQUdF\"}'),
(51, 'hubert_Artem', '{\"Author\":\"Artem\",\"Text\":\"MQ==\"}'),
(52, 'Artem_Vova', '{\"Author\":\"Artem\",\"Text\":\"Mg==\"}');

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`id`, `username`, `password`) VALUES
(1, 'Vova', '1234'),
(2, 'Vlad', '1234'),
(3, 'Oleksandr', '12345'),
(4, 'Hubert', '12345'),
(5, 'Artem', '1234');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `chatrooms`
--
ALTER TABLE `chatrooms`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `messagehistory`
--
ALTER TABLE `messagehistory`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `chatrooms`
--
ALTER TABLE `chatrooms`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT для таблицы `messagehistory`
--
ALTER TABLE `messagehistory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=53;

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
