drop database if exists db_mysalon;
create database db_mysalon;
use db_mysalon;

create table Endereco(
id_end int primary key auto_increment,
rua_end varchar (500),
bairro_end varchar (500),
numero_end varchar (50),
cidade_end varchar (50),
estado_end varchar (50),
cep_end varchar (50)
);

create table Cliente(
id_cli int primary key auto_increment,
foto_cli blob,
nome_cli varchar (500),
cpf_cli varchar (50),
rg_cli varchar (50),
telefone_cli varchar (50),
email_cli varchar (500),
sexo_cli varchar (50),
id_end_fk int,
foreign key (id_end_fk) references Endereco (id_end)
);

create table Salao(
id_sal int primary key auto_increment,
foto_sal blob,
nome_sal varchar (500),
telefone_sal varchar (50),
razao_social_sal varchar (500),
cnpj_sal varchar (50),
email_sal varchar (500),
id_end_fk int,
foreign key (id_end_fk) references Endereco (id_end)
);

create table Funcionario(
id_func int primary key auto_increment,
foto_cli blob,
nome_cli varchar (500),
cpf_cli varchar (50),
rg_cli varchar (50),
telefone_cli varchar (50),
email_cli varchar (500),
sexo_cli varchar (50),
id_end_fk int,
foreign key (id_end_fk) references Endereco (id_end),
id_sal_fk int,
foreign key (id_sal_fk) references Salao (id_sal)
);

create table Servico(
id_ser int primary key auto_increment,
foto_ser blob,
valor_ser float,
nome_ser varchar (500),
tipo_ser varchar (50),
descriçao_sal text,
id_sal_fk int,
foreign key (id_sal_fk) references Salao (id_sal)
);

create table Agenda(
id_age int primary key auto_increment,
data_age date,
horario_age time,
valor_age float,
tempo_estimado time,
id_cli_fk int, 
foreign key (id_cli_fk) references Cliente (id_cli),
id_sal_fk int,
foreign key (id_sal_fk) references Salao (id_sal)
);


create table Agenda_Servico(
id_ageSer int primary key auto_increment,
qtd_ageSer int,
id_ser_fk int,
foreign key (id_ser_fk) references Servico (id_ser),
id_age_fk int,
foreign key (id_age_fk) references Agenda (id_age)
);

create table Funcionario_Servico(
id_func_ser int primary key auto_increment,
id_func_fk int,
foreign key (id_func_fk) references Funcionario (id_func),
id_ser_fk int,
foreign key (id_ser_fk) references Servico (id_ser)
);
 
