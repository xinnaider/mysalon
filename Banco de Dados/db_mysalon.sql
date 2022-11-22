drop database if exists db_mysalon;
create database db_mysalon;
use db_mysalon;

create table Endereco(
id_end int primary key auto_increment,
rua_end varchar (500),
bairro_end varchar (500),
numero_end varchar (20),
cidade_end varchar (50),
estado_end varchar (50),
cep_end varchar (50)
);

delimiter $$
create procedure insertEndereco(rua varchar(200), bairro varchar(200), numero varchar(50), cidade varchar(50), estado varchar(50), cep varchar(50))
begin
	insert into endereco values (null,rua, bairro, numero, cidade, estado, cep);
end;
$$ delimiter ;

delimiter $$
create procedure updateEndereco(rua varchar(200), bairro varchar(200), numero varchar(50), cidade varchar(50), estado varchar(50), cep varchar(50))
begin
	update Endereco set rua_end = rua, bairro_end = bairro, numero_end = numero, cidade_end = cidade, estado_end = estado, cep_end = cep;
end;
$$ delimiter ;

delimiter $$
create procedure deleteEndereco(id int)
begin
	delete from Endereco where (id_end = id); 
end;
$$ delimiter ;


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

delimiter $$
create procedure inserCliente(nome varchar(300), cpf varchar(50), rg varchar(50), telefone varchar(50), email varchar(400), sexo varchar(50))
begin
	
end;
$$ delimiter ;

delimiter $$
create procedure updateCliente(nome varchar(300), cpf varchar(50), rg varchar(50), telefone varchar(50), email varchar(400), sexo varchar(50))
begin
	Update Cliente set nome_cli = nome, cpf_cli = cpf, rg_cli = rg, telefone_cli = telefone, email_cli = email, sexo_cli = sexo;
end;
$$ delimiter ;

delimiter $$
create procedure delteCliente(id int)
begin
	delete from Cliente where (id_cli = id); 
end;
$$ delimiter ;

create table Salao(
id_sal int primary key auto_increment,
foto_sal blob,
nome_sal varchar (500),
telefone_sal varchar (50),
razao_social_sal varchar (500),
cnpj_sal varchar (50),
email_sal varchar (500),
id_end_fk int,
foreign key (id_end_fk) references Endereco (id_end),
id_cli_fk int,
foreign key (id_cli_fk) references Cliente (id_cli)
);

delimiter $$ 
create procedure insertSalao(nome varchar(300), telefone varchar(50), rSocial varchar(200), cnpj varchar(50), email varchar(300), fkEnd int, fkCli int)
begin
 INSERT INTO Salao VALUES (null, null, nome, telefone, rSocial, cnpj, email, fkEnd, fkCli);
end;
$$ delimiter ;

delimiter $$ 
create procedure updateSalao(nome varchar(300), telefone varchar(50), rSocial varchar(200), cnpj varchar(50), email varchar(300),  id int)
begin
 Update Salao set nome_sal = nome, telefone_sal = telefone, razao_social_sal = rSocial, cnpj_sal = cnpj, email_sal = email where (id_sal = id);
end;
$$ delimiter ;

delimiter $$
create procedure delteSalao(id int)
begin
	delete from Salao where (id_sal = id); 
end;
$$ delimiter ;

create table Servico(
id_ser int primary key auto_increment,
foto_ser blob,
valor_ser float,
nome_ser varchar (500),
tipo_ser varchar (50),
id_sal_fk int,
foreign key (id_sal_fk) references Salao (id_sal)
);

delimiter $$
create procedure insertServico(valor float, nome varchar(300), tipo varchar(50), fkSal int)
begin
	insert into servico values (null, null, valor, nome, tipo, fkSal);
end;
$$ delimite;

delimiter $$
create procedure updateServico(valor float, nome varchar(300), tipo varchar(50))
begin
	update servico set valor_ser = valor, nome_ser = nome, tipo_ser = tipo;
end;
$$ delimite;

delimiter $$
create procedure delteServico(id int)
begin
	delete from Servico where (id_ser = id); 
end;
$$ delimiter ;

create table Agenda(
id_age int primary key auto_increment,
dataHorario_age datetime,
status_age varchar(300),
id_ser_fk int,
foreign key (id_ser_fk) references Servico (id_ser),
id_cli_fk int, 
foreign key (id_cli_fk) references Cliente (id_cli),
id_sal_fk int,
foreign key (id_sal_fk) references Salao (id_sal)
);

delimiter $$
create procedure insertAgenda(datahora varchar(100),fkser int, fkcli int , fksal int)
begin
declare datatime datetime;
select dataHorario_age into datatime from agenda where (dataHorario_Age = str_to_date(datahora, "%d/%m/%Y %H:%i:%s") and (id_sal_fk = fkSal));
if (datatime is null) then
	insert into Agenda values (null, str_to_date(datahora, "%d/%m/%Y %H:%i:%s"), "Indisponível", fkser, fkcli, fksal);
end if;
end;
$$ delimiter ; 

delimiter $$
create procedure updateAgenda(datahora varchar(100), statuss varchar(300))
begin
	update Agenda set dataHorario_age = str_to_date(datahora, "%d/%m/%Y %H:%i:%s"), status_age = statuss;
end;
$$ delimiter ;

delimiter $$
create procedure delteAgenda(id int)
begin
	delete from Agenda where (id_age = id); 
end;
$$ delimiter ;

create table login (
id_log int primary key auto_increment, 
user_log varchar(300),
senha_log varchar(300),
id_cli_fk int,
foreign key (id_cli_fk) references Cliente (id_cli)
);

delimiter $$
create procedure insertLogin(usuario varchar(300), senha varchar(300), fkCli int)
begin
	insert into Login values (null, usuario, senha, fkCli);
end;
$$ delimiter ;

delimiter $$
create procedure updateLogin(usuario varchar(300), senha varchar(300))
begin
	Update Login set user_log = usuario, senha_log = senha;
end;
$$ delimiter ;

delimiter $$
create procedure delteLogin(id int)
begin
	delete from Login where (id_log = id); 
end;
$$ delimiter ;

insert into endereco values (null, 'rua jk', 'cunha e silva', '1010', 'Presidente Medici', 'RO', '76916-000');
insert into endereco values (null, 'rua jk', 'cunha e silva', '1010', 'Presidente Medici', 'AC', '76916-000');
insert into endereco values (null, 'rua jk', 'cunha e silva', '1010', 'Presidente Medici', 'RJ', '76916-000');
insert into endereco values (null, 'rua jk', 'cunha e silva', '1010', 'Presidente Medici', 'SP', '76916-000');
insert into endereco values (null, 'rua jk', 'cunha e silva', '1010', 'Presidente Medici', 'MG', '76916-000');

insert into cliente values (null, null, 'Lucas', '32131', '32131', '321321', '312@email', 'masculino');
insert into cliente values (null, null, 'Jorge', '32131', '32131', '321321', '312@email', 'masculino');
insert into cliente values (null, null, 'Matheus', '32131', '32131', '321321', '312@email', 'masculino');
insert into cliente values (null, null, 'Douglas', '32131', '32131', '321321', '312@email', 'Masculino');

insert into salao values (null, null, 'salao para feios', '9999', 'spf', '123123', '2@hotmali.com', 1, 1);
insert into salao values (null, null, 'salao para lindo', '9999', 'spf', '123123', '2@hotmali.com', 2, 2);
insert into salao values (null, null, 'salao para cabelos', '9999', 'spf', '123123', '2@hotmali.com', 3, 3);
insert into salao values (null, null, 'salao para carecas', '9999', 'spf', '123123', '2@hotmali.com', 4, 4);

insert into Servico values (null, null, 10, 'Corte 1', 'Corte muito bom', 1);
insert into Servico values (null, null, 15, 'Corte 2', 'Corte muito bom', 1);
insert into Servico values (null, null, 25, 'Corte 3', 'Corte muito bom', 1);

insert into Agenda values (null, '0000-00-00 00:00:00', 'Indisponível', 1, 1, 1);
insert into Agenda values (null, '0000-00-00 20:00:00', 'Indisponível', 2, 2, 1);
insert into Agenda values (null, '0000-00-00 10:00:00', 'Indisponível', 3, 3, 2);

insert into login values (null, 'user', 'senha', 1);

call updateSalao("a", "3213", "aa", "312", "31231", 1);





