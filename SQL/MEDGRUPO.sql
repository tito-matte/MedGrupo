if not exists(SELECT * FROM sys.databases WHERE name = 'MEDGRUPO')
	CREATE DATABASE [MEDGRUPO] ON ( NAME = App, FILENAME = 'C:\Projetos\MedGrupo\SQL\MEDGRUPO.mdf')
go

use [MEDGRUPO]


if exists(select 1 from sysobjects where ID = OBJECT_ID(N'dbo.tbContatos') and OBJECTPROPERTY(ID, N'IsUserTable') = 1)
	drop table dbo.tbContatos
go


create table dbo.tbContatos
(
	 ContatoID			int				not null identity(1, 1)
	,Nome				varchar(100)	not null
	,Nascimento			Date			not null
	,Sexo				char(1)			not null
	,Status				int				not null

	,constraint PK_tbEmpresas primary key clustered (ContatoID)
)


insert into dbo.tbContatos (Nome, Nascimento, Sexo, Status) values
('Contato 1', '05/03/1960', 'M', 1)