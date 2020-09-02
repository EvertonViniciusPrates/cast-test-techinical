
create table categorias (
	cd_categoria_id uniqueidentifier default newid() ,
	ds_descricao varchar(50),

	CONSTRAINT PK_CATEGORIA PRIMARY KEY(cd_categoria_id)

);


create table cursos(
	cd_curso_id uniqueidentifier default newid() ,
	ds_descricao varchar(100) NOT NULL,
	dt_inicio datetime NOT NULL,
	dt_termino datetime NOT NULL,
	qtd_alunos int NULL,
	cd_categoria uniqueidentifier NOT NULL,

	CONSTRAINT PK_CURSO_ID PRIMARY KEY (cd_curso_id),
	CONSTRAINT FK_CURSO_CATEGORIA FOREIGN KEY(cd_categoria) REFERENCES categorias(cd_categoria_id)
);


insert into dbo.categorias (ds_descricao) values ('Comportamental');
insert into dbo.categorias (ds_descricao) values ('Programação');
insert into dbo.categorias (ds_descricao) values ('Qualidade e Processos');


