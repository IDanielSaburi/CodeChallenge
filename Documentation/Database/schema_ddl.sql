CREATE SCHEMA codech AUTHORIZATION codech_user;

CREATE SEQUENCE codech.motorcycle_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;

CREATE SEQUENCE codech.renter_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;

CREATE TABLE codech.motorcycle (
	id int4 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
	"year" int4 NOT NULL,
	model varchar(255) NOT NULL,
	plate varchar(20) NOT NULL,
	CONSTRAINT motorcycle_plate_key UNIQUE (plate)
);

CREATE TABLE codech.renter (
	id int4 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
	"name" varchar(255) NOT NULL,
	cnpj varchar(20) NOT NULL,
	birthdate date NOT NULL,
	cnhnumber varchar(20) NOT NULL,
	cnhtype varchar(3) NOT NULL,
	cnhimagepath text NULL,
	CONSTRAINT renter_cnhnumber_key UNIQUE (cnhnumber),
	CONSTRAINT renter_cnhtype_check CHECK (((cnhtype)::text = ANY ((ARRAY['A'::character varying, 'B'::character varying, 'AB'::character varying])::text[]))),
	CONSTRAINT renter_cnpj_key UNIQUE (cnpj)
);