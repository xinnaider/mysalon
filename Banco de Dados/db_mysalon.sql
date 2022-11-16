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

insert into endereco values (null, 'rua jk', 'cunha e silva', '1010', 'Presidente Medici', 'RO', '76916-000');
insert into endereco values (null, 'rua jk', 'cunha e silva', '1010', 'Presidente Medici', 'AC', '76916-000');
insert into endereco values (null, 'rua jk', 'cunha e silva', '1010', 'Presidente Medici', 'RJ', '76916-000');
insert into endereco values (null, 'rua jk', 'cunha e silva', '1010', 'Presidente Medici', 'SP', '76916-000');
insert into endereco values (null, 'rua jk', 'cunha e silva', '1010', 'Presidente Medici', 'MG', '76916-000');

create table Cliente(
id_cli int primary key auto_increment,
foto_cli blob,
nome_cli varchar (500),
cpf_cli varchar (50),
rg_cli varchar (50),
telefone_cli varchar (50),
email_cli varchar (500),
sexo_cli varchar (50)
);

insert into cliente values (null, null, 'Lucas', '32131', '32131', '321321', '312@email', 'masculino');
insert into cliente values (null, null, 'Jorge', '32131', '32131', '321321', '312@email', 'masculino');
insert into cliente values (null, null, 'Matheus', '32131', '32131', '321321', '312@email', 'masculino');
insert into cliente values (null, null, 'Douglas', '32131', '32131', '321321', '312@email', 'masculino');


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

insert into salao values (null, null, 'salao para feios', '9999', 'spf', '123123', '2@hotmali.com', 1);
insert into salao values (null, null, 'salao para lindo', '9999', 'spf', '123123', '2@hotmali.com', 2);
insert into salao values (null, null, 'salao para cabelos', '9999', 'spf', '123123', '2@hotmali.com', 3);
insert into salao values (null, null, 'salao para carecas', '9999', 'spf', '123123', '2@hotmali.com', 4);


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
id_sal_fk int,
foreign key (id_sal_fk) references Salao (id_sal)
);

insert into Servico values (null, null, 10, 'Corte 1', 'Corte muito bom', 1);
insert into Servico values (null, null, 15, 'Corte 2', 'Corte muito bom', 2);
insert into Servico values (null, null, 25, 'Corte 3', 'Corte muito bom', 3);

create table Agenda(
id_age int primary key auto_increment,
data_age date,
horario_age time,
status_age varchar(300),
id_ser_fk int,
foreign key (id_ser_fk) references Servico (id_ser),
id_cli_fk int, 
foreign key (id_cli_fk) references Cliente (id_cli),
id_sal_fk int,
foreign key (id_sal_fk) references Salao (id_sal)
);

insert into Agenda values (null, '0000-00-00', '00:00:00', 'Indisponível', 1, 1, 1);
insert into Agenda values (null, '0000-00-00', '00:00:00', 'Indisponível', 2, 2, 2);
insert into Agenda values (null, '0000-00-00', '00:00:00', 'Indisponível', 3, 3, 3);

create table Funcionario_Servico(
id_func_ser int primary key auto_increment,
id_func_fk int,
foreign key (id_func_fk) references Funcionario (id_func),
id_ser_fk int,
foreign key (id_ser_fk) references Servico (id_ser)
);

create table login (
id_log int primary key auto_increment, 
user_log varchar(300),
senha_log varchar(300),
id_cli_fk int,
foreign key (id_cli_fk) references Cliente (id_cli)
);

insert into login values (null, 'user', 'senha', 1);

