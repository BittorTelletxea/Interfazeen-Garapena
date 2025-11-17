-- Adminer 5.4.1 PostgreSQL 17.6 dump

CREATE DATABASE "tpv";
\connect "tpv";

DROP TABLE IF EXISTS "erreserbak";
DROP SEQUENCE IF EXISTS erreserbak_id_seq;
CREATE SEQUENCE erreserbak_id_seq INCREMENT 1 MINVALUE 1 MAXVALUE 9223372036854775807 CACHE 1;

CREATE TABLE "public"."erreserbak" (
    "erreserba_id" integer DEFAULT nextval('erreserbak_id_seq') NOT NULL,
    "izena" text NOT NULL,
    "ordua" text NOT NULL,
    "pertsonak" integer NOT NULL,
    "mahaia" integer NOT NULL,
    "bazkaria" boolean,
    "eguna" text
)
WITH (oids = false);

INSERT INTO "erreserbak" ("erreserba_id", "izena", "ordua", "pertsonak", "mahaia", "bazkaria", "eguna") VALUES
(2,	'manolo',	'12:10',	2,	1,	'1',	NULL),
(3,	'Ricardo',	'13:10',	4,	5,	'1',	NULL),
(4,	'Bittor',	'20:20',	5,	2,	'0',	NULL),
(10,	'bittor',	'12:10',	1,	1,	'1',	'2025-11-14');

DROP TABLE IF EXISTS "products";
DROP SEQUENCE IF EXISTS products_product_id_seq;
CREATE SEQUENCE products_product_id_seq INCREMENT 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1;

CREATE TABLE "public"."products" (
    "product_id" integer DEFAULT nextval('products_product_id_seq') NOT NULL,
    "name" character varying(100) NOT NULL,
    "description" text,
    "price" numeric(10,2) DEFAULT '0' NOT NULL,
    "stock" real DEFAULT '0',
    CONSTRAINT "products_pkey" PRIMARY KEY ("product_id")
)
WITH (oids = false);

INSERT INTO "products" ("product_id", "name", "description", "price", "stock") VALUES
(2,	'Wine',	'House red wine',	3.00,	50),
(4,	'Cheese',	'Aged cheddar cheese',	2.20,	20),
(5,	'Coffee',	'Hot espresso',	1.50,	80),
(6,	'Tea',	'Green tea',	1.20,	60),
(3,	'Bread',	'Freshly baked bread',	1.00,	30),
(7,	'Juice1',	'Fresh orange juice',	2.00,	40),
(1,	'Beer2',	'Local craft beer',	2.50,	100);

DROP TABLE IF EXISTS "tables";
DROP SEQUENCE IF EXISTS tables_table_id_seq;
CREATE SEQUENCE tables_table_id_seq INCREMENT 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1;

CREATE TABLE "public"."tables" (
    "table_id" integer DEFAULT nextval('tables_table_id_seq') NOT NULL,
    "table_number" integer NOT NULL,
    "seats" integer DEFAULT '4',
    CONSTRAINT "tables_pkey" PRIMARY KEY ("table_id")
)
WITH (oids = false);

CREATE UNIQUE INDEX tables_table_number_key ON public.tables USING btree (table_number);

INSERT INTO "tables" ("table_id", "table_number", "seats") VALUES
(1,	1,	4),
(2,	2,	4),
(3,	3,	6),
(4,	4,	8),
(5,	5,	2),
(6,	6,	4),
(7,	7,	6),
(8,	8,	8);

DROP TABLE IF EXISTS "users";
DROP SEQUENCE IF EXISTS users_user_id_seq;
CREATE SEQUENCE users_user_id_seq INCREMENT 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1;

CREATE TABLE "public"."users" (
    "user_id" integer DEFAULT nextval('users_user_id_seq') NOT NULL,
    "username" character varying(50) NOT NULL,
    "password_hash" text NOT NULL,
    "role" character varying(20) DEFAULT 'User',
    "created_at" timestamp DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT "users_pkey" PRIMARY KEY ("user_id")
)
WITH (oids = false);

CREATE UNIQUE INDEX users_username_key ON public.users USING btree (username);

INSERT INTO "users" ("user_id", "username", "password_hash", "role", "created_at") VALUES
(3,	'mary',	'Mary123!',	'User',	'2025-11-10 11:20:10.877594'),
(4,	'alice',	'Alice123!',	'User',	'2025-11-10 11:20:10.877594'),
(1,	'admin',	'admin',	'Admin',	'2025-11-10 11:20:10.877594'),
(2,	'john',	'John123!',	'User',	'2025-11-10 11:20:10.877594'),
(7,	'bittor',	'bittor',	'User',	'2025-11-10 11:51:24.05254'),
(5,	'paul22',	'Paul123!',	'User',	'2025-11-10 11:20:10.877594');

-- 2025-11-17 10:16:14 UTC
