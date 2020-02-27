USE master

GO

IF NOT EXISTS(
	SELECT name FROM sys.databases WHERE name LIKE '%CaixaEletronico%'
)BEGIN
	exec sp_executesql N'CREATE DATABASE CaixaEletronico'
END

GO

USE CaixaEletronico

GO

IF NOT EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'ContaCorrentes'
)BEGIN
	CREATE TABLE ContaCorrentes(
		Conta INT PRIMARY KEY,
		Saldo DECIMAL(18, 10) NOT NULL DEFAULT(0)
	)
END