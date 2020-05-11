--1. (#15)  Напишите SQL запросы  для решения задач ниже. 
--1) Тактовые частоты CPU тех компьютеров, у которых объем памяти 3000 Мб. Вывод: id, cpu, memory
SELECT id, cpu, memory 
FROM PC 
WHERE memory = 3000;
--2) Минимальный объём жесткого диска, установленного в компьютере на складе. Вывод: hdd
SELECT MIN(hdd) AS hdd 
FROM PC;
--3) Количество компьютеров с минимальным объемом жесткого диска, доступного на складе. 
--Вывод: count, hdd
SELECT COUNT(*) AS count, hdd 
FROM PC 
WHERE hdd IN (SELECT MIN(hdd) FROM PC);


--2. Напишите SQL-запрос, возвращающий все пары (download_count, user_count), 
--    удовлетворяющие следующему условию: 
--    user_count — общее ненулевое число пользователей, сделавших 
--    ровно download_count скачиваний 19 ноября 2010 года.

SELECT download_count, COUNT(*) AS user_count
FROM (
	SELECT COUNT(*) AS download_count
	FROM track_downloads
	WHERE download_time = '2010-11-19'
	GROUP BY user_id
)
GROUP BY download_count;


--3. (#10) Опишите разницу типов данных DATETIME и TIMESTAMP

--DATETIME
--Хранит время в виде целого числа вида YYYYMMDDHHMMSS, используя для этого 8 байтов. 
--Это время не зависит от временной зоны.

--TIMESTAMP
--Хранит 4-байтное целое число, равное количеству секунд, прошедших с полуночи 1 января 1970 года 
--по усреднённому времени Гринвича (т.е. нулевой часовой пояс, точка отсчёта часовых поясов). 
--При получении из базы отображается с учётом часового пояса. 

--4.(#20)  Необходимо создать таблицу студентов (поля id, name) 
--и таблицу курсов (поля id, name). Каждый студент может посещать несколько курсов. 
--Названия курсов и имена студентов - произвольны.

CREATE TABLE "student" (
	"student_id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"name"	TEXT NOT NULL
);

CREATE TABLE "course" (
	"course_id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"name"	INTEGER NOT NULL
);

CREATE TABLE "student_course" (
	"id_student_course"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"student_id"	INTEGER NOT NULL,
	"course_id"	INTEGER NOT NULL,
	FOREIGN KEY("student_id") REFERENCES "student"("student_id"),
	FOREIGN KEY("course_id") REFERENCES "course"("course_id")
);

INSERT INTO student(name)
VALUES	('Александр'),
	('Иван'),
	('Михаил'),
	('Мария'),
	('Татьяна'),
	('Анастасия');

INSERT INTO course(name)
VALUES	('История'),
	('Физика'),
	('Литература');

INSERT INTO student_course(student_id, course_id)
VALUES	(1, 1),
	(2, 1),
	(3, 1),
	(4, 1),
	(5, 1),
	(6, 1),
	(1, 2),
	(2, 2);

--Написать SQL запросы: 
--    1. отобразить количество курсов, на которые ходит более 5 студентов

SELECT COUNT(*) 
FROM(
	SELECT * 
	FROM student_course 
	GROUP BY course_id 
	HAVING COUNT(student_id) > 5);

--    2. отобразить все курсы, на которые записан определенный студент.

SELECT course.name FROM student_course
INNER JOIN student ON student_course.student_id = student.student_id
INNER JOIN course ON student_course.course_id = course.course_id
WHERE student.student_id = 1


--5. (5#) Может ли значение в столбце(ах), на который наложено ограничение foreign key, 
--равняться null? Привидите пример. 
