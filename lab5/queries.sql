--3.  Подготовьте SQL запросы для заполнения таблиц данными.

INSERT INTO dvd (title,production_year)
VALUES	('Побег из Шоушенка',1994),
	('Начало',2010),
	('Гарри Поттер и Дары Смерти: Часть I',2010);

INSERT INTO customer (first_name,last_name,passport_code,registration_date)
VALUES ('Tommy','Vercetti','ABC1951','1986-01-01');

INSERT INTO offer (dvd_id,customer_id,offer_date,return_date)
VALUES	(2,1,'2020-01-01','2020-01-02'),
	(1,1,'2020-01-01','2021-01-02'),
	(3,1,'2020-01-01',null);

--4.  Подготовьте SQL запрос получения списка всех DVD, год выпуска которых 2010, 
#10 отсортированных в алфавитном порядке по названию DVD.

SELECT * FROM dvd
WHERE production_year = 2010
ORDER BY title ASC;

--5.  Подготовьте SQL запрос для получения списка DVD дисков, которые в настоящее время
#10 находятся у клиентов.

SELECT dvd.*
FROM dvd
INNER JOIN offer ON dvd.dvd_id = offer.dvd_id
WHERE offer.return_date IS NULL;

--6.  Напишите SQL запрос для получения списка клиентов, которые брали какие-либо DVD 
#10 диски в текущем году. В результатах запроса необходимо также отразить какие диски 
    брали клиенты.

SELECT customer.*, dvd.*
FROM  offer
INNER JOIN dvd ON dvd.dvd_id = offer.dvd_id
INNER JOIN customer ON customer.customer_id = offer.customer_id
WHERE STRFTIME('%Y', DATE('now')) = STRFTIME('%Y', offer.offer_date);