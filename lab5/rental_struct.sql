BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "offer" (
	"offer_id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"dvd_id"	INTEGER,
	"customer_id"	INTEGER,
	"offer_date"	TEXT,
	"return_date"	TEXT
);
CREATE TABLE IF NOT EXISTS "customer" (
	"customer_id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"first_name"	TEXT,
	"last_name"	TEXT,
	"passport_code"	INTEGER,
	"registration_date"	TEXT
);
CREATE TABLE IF NOT EXISTS "dvd" (
	"dvd_id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"title"	TEXT,
	"production_year"	INTEGER
);
COMMIT;
