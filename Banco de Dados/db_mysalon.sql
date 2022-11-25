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

create table Servico(
id_ser int primary key auto_increment,
foto_ser blob,
valor_ser float,
nome_ser varchar (500),
tipo_ser varchar (500),
id_sal_fk int,
foreign key (id_sal_fk) references Salao (id_sal)
);

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

create table login (
id_log int primary key auto_increment, 
user_log varchar(300),
senha_log varchar(300),
id_cli_fk int,
foreign key (id_cli_fk) references Cliente (id_cli)
);

/*teste
insert into cliente values (null, null, 'Test', '32131', '32131', '321321', '312@email', 'masculino');
insert into salao values (null, null, 'salao para feios', '9999', 'spf', '123123', '2@hotmali.com', null, 1);
insert into Servico values (null, null, 10, 'Corte 1', 'Corte muito bom', 1);
insert into Servico values (null, null, 15, 'Corte 2', 'Corte muito bom', 1);
insert into Servico values (null, null, 25, 'Corte 3', 'Corte muito bom', 1);
insert into login values (null, 'user', 'senha', 1);
test*/

# ------------------------ INSERT - TABELA ENDEREÇO --------------------------------

DELIMITER $$
CREATE PROCEDURE InsertEndereco(rua varchar(200), bairro varchar(200), numero varchar(50), cidade varchar(50), estado varchar(50), cep varchar(50))
BEGIN
		if (rua is not null) or (numero is not null) then 
            insert into endereco values (null, rua, bairro, numero, cidade, estado, cep);
                select 'Endereço inserido com sucesso' as Confirmacao;
		else 
			select 'Não foi possível inserir este endereço. Verifique as informações!' as Erro;	
		end if;
end;
$$ DELIMITER ;

# ---------------------------------------------- CALL DE INSERT - TABELA DE ENDEREÇO -----------------------------------------------------------

CALL InsertEndereco('Rua Nova Brasilia 2621', 'Lino Alves Teixeira', '3312', 'Presidente Médici', 'RO', '76916-000');
CALL InsertEndereco('Rua Silvana Leal', 'Hernandes Gonçalves', '2351', 'Presidente Médici', 'RO', '76916-000');
CALL InsertEndereco('Rua Minas Gerais', 'Cunha e Silva', '1023', 'Presidente Médici', 'RO', '76916-000');
CALL InsertEndereco('Rua das Acacias', 'Colina Park', '4123', 'Presidente Médici', 'RO', '76916-000');
CALL InsertEndereco('Rua Paraná', 'Centro', '2844', 'Presidente Médici', 'RO', '76916-000');
CALL InsertEndereco('Rua José Vidal', 'Nova Presidente Médici', '5987', 'Presidente Médici', 'RO', '76916-000');
CALL InsertEndereco('Rua da Paz', 'Cunha e Silva', '2247', 'Presidente Médici', 'RO', '76916-000');
CALL InsertEndereco('Rua das Violetas', 'Colina Park', '1151', 'Presidente Médici', 'RO', '76916-000');
CALL InsertEndereco('Rua Frei Caneca', 'Centro', '4219', 'Presidente Médici', 'RO', '76916-000');
CALL InsertEndereco('Rua da Saudade', 'Nova Presidente Médici', '3546', 'Presidente Médici', 'RO', '76916-000');

#SELECT * FROM Endereco;


# ---------------------------------------------- DELETE - TABELA DE ENDEREÇO -----------------------------------------------------------

DELIMITER $$
CREATE PROCEDURE DeleteEndereco(id int)
BEGIN
	delete from Endereco where (id_end = id); 
end;
$$ DELIMITER ;

# ---------------------------------------------- INSERT - TABELA DE CLIENTE -----------------------------------------------------------

#DROP PROCEDURE InsertCliente;

DELIMITER $$
CREATE PROCEDURE InsertCliente(nome varchar(500), cpf varchar(50), rg varchar(50), telefone varchar(50), email varchar(400), sexo varchar(50))
BEGIN
		if (nome <> '') then 
			if (cpf is not null) then 
				insert into Cliente values (null, null, nome, cpf, rg, telefone, email, sexo);
                select 'Cliente inserido com sucesso' as Confirmacao;
			else 
				select 'Não foi possível inserir este cliente. Verifique as informações!' as Erro;	
			end if;
	else 
		select 'Não foi possível inserir este cliente. Verifique as informações!' as Erro;	
		end if;
end;
$$ DELIMITER ;

# ---------------------------------------------- CALL DE INSERT - TABELA DE CLIENTE -----------------------------------------------------------

CALL InsertCliente('Maria ', '654.403.457-60', '19.198.554-5', '(81) 2812-5902', 'sara_goncalves@effem.com', 'Feminino');
CALL InsertCliente('Luana', '526.084.169-77', '44.643.981-2', '(47) 2574-0510', 'carvalho@atualecomex.com.br', 'Feminino');
CALL InsertCliente('Lukas', '618.783.386-41', '38.358.721-9', '(51) 2981-7645', 'yuri-fernandes85@mirafactoring.com.br', 'Masculino');
CALL InsertCliente('José', '438.225.383-70', '41.558.630-6', '(81) 2834-4508', 'anderson_lima@fibran.com.br', 'Masculino');
CALL InsertCliente('Antonio', '821.528.227-06', '11.920.131-8', '(31) 3560-7812', 'helena_oliveira@vilarreal.com.br', 'Feminino');

CALL InsertCliente('Eduardo', '726.528.414-32', '43.733.433-8', '(79) 2567-7803', 'maite_andrea_moraes@gmapst.com', 'Feminino');
CALL InsertCliente('Daiane', '402.283.238-00', '22.592.116-9', '(11) 2909-5310', 'daiane_dasneves@thewishes.com.br', 'Feminino');
CALL InsertCliente('Henry', '657.253.759-51', '39.295.269-5', '(21) 2719-4781', 'henry_damata@power.alstom.com', 'Masculino');
CALL InsertCliente('Mário', '428.352.221-03', '17.656.898-0', '(21) 2884-7786', 'mario.anthony.depaula@akaer.com.br', 'Masculino');
CALL InsertCliente('Yasmin', '728.385.294-80', '43.123.756-6', '(91) 3521-7048', 'yasmin_damota@alanamaral.com.br', 'Feminino');

#SELECT * FROM Cliente;

# ---------------------------------------------- DELETE - TABELA DE CLIENTE -----------------------------------------------------------

DELIMITER $$
CREATE PROCEDURE DeleteCliente(id int)
BEGIN
	delete from Cliente where (id_cli = id); 
end;
$$ DELIMITER ;

# ------------------------------------------------------- INSERT - TABELA DE SALÃO -----------------------------------------------------

DELIMITER $$ 
CREATE PROCEDURE InsertSalao(nome varchar(300), telefone varchar(50), rSocial varchar(200), cnpj varchar(50), email varchar(300), fkEnd int, fkCli int)
begin
		if (nome <> '') then 
			if (telefone <> '') then 
					insert into Salao VALUES (null, null, nome, telefone, rSocial, cnpj, email, fkEnd, fkCli);
                select 'Salão inserido com sucesso!' as Confirmacao;
			else 
				select 'Não foi possível inserir este salão. Verifique as informações!' as Erro;	
			end if;
	else 
		select 'Não foi possível inserir este salão. Verifique as informações!' as Erro;	
		end if;
end;
$$ DELIMITER ;

# ------------------------------------------------------- CALL DE INSERT - TABELA DE SALÃO -----------------------------------------------------

CALL InsertSalao('Salão Da Sidy', '(69) 3471-3152', 'DA LU CABELO E ESTETICA LTDA - ME', '23.540.478/0001-00', null, 1, 1);
CALL InsertSalao('Espaço Gi Pereira', '(69) 99224-0728', 'HAIR & NAILS CABELO E ESTETICA LTDA - ME', '28.415.443/0001-62', null, 2, 2);
CALL InsertSalao('Beleza única', '(69) 99218-2508', 'NEW HAIR CABELO E ESTETICA LTDA - ME', '28.612.099/0001-00', null, 3, 3);
CALL InsertSalao('Studio Jessica Orrigo', '(69) 9937-43600', 'JESICA HAIR CABELO E ESTETICA LTDA - ME', '28.967.145/0001-85', null, 4, 4);
CALL InsertSalao('Wagner cabeleireiro', '(69) 99927-3492', 'SKM COMERCIO E ESCOLA DE ESTETICA E CABELO EIRELI - EPP', '28.763.512/0001-29', null, 5, 5);

#SELECT * FROM Salao;

# ------------------------------------------------------- UPDATE - TABELA DE SALÃO -------------------------------------------------------------

DELIMITER $$ 
CREATE PROCEDURE UpdateSalao(nome varchar(300), telefone varchar(50), rSocial varchar(200), cnpj varchar(50), email varchar(300),  id int)
BEGIN
 Update Salao set nome_sal = nome, telefone_sal = telefone, razao_social_sal = rSocial, cnpj_sal = cnpj, email_sal = email where (id_sal = id);
end;
$$ DELIMITER ;

# ------------------------------------------------------- DELETE - TABELA DE SALÃO -------------------------------------------------------------

DELIMITER $$
CREATE PROCEDURE delteSalao(id int)
BEGIN
	delete from Salao where (id_sal = id); 
end;
$$ DELIMITER ;

# -------------------------------------------------- INSERT - TABELA DE SERVIÇO -------------------------------------------------

#DROP PROCEDURE InsertServico;

DELIMITER $$
CREATE PROCEDURE InsertServico(valor float, nome varchar(300), tipo varchar(200), fkSal int)
BEGIN
		if (nome <> '') then 
			if (tipo <> '') then 
					insert into servico values (null, null, valor, nome, tipo, fkSal);
                select 'Serviço inserido com sucesso!' as Confirmacao;
			else 
				select 'Não foi possível inserir este serviço. Verifique as informações!' as Erro;	
			end if;
	else 
		select 'Não foi possível inserir este serviço. Verifique as informações!' as Erro;	
		end if;
end;
$$ DELIMITER ;

# ------------------------------------------------------- CALL DE INSERT - TABELA DE SERVIÇO -------------------------------------------------------------

CALL InsertServico(57.00, 'Pompadour comb over', 'Corte Masculino - Topete', 5);
CALL InsertServico(60.00, 'Cabelos ondulados com franja', 'Corte Masculino - Para cabelo Andulado', 5);
CALL InsertServico(20.00, 'Corte militar', 'Corte Masculino', 5);
CALL InsertServico(45.00, 'Faded', 'Corte Masculino - Para rostos mais pequenos e arredondados', 5);
CALL InsertServico(31.00, 'Dividido ao lado ora liso com textura', 'Nenhum', 5);

CALL InsertServico(64.00, 'Long bob', 'Corte Femenino - Varia entre curto e médio', 4);
CALL InsertServico(70.00, 'Blunt cut', 'Corte Femenino - Madeixas bem lisas e divididas ao meio', 4);
CALL InsertServico(100.00, 'Corte médio com franjinha', 'Corte Femenino - Fios chegam mais ou menos na altura do ombro', 4);
CALL InsertServico(40.00, 'Assimétrico', 'Corte Femenino - Chanel, só que com a diferença no comprimento de cada ponta', 4);
CALL InsertServico(29.00, 'Pixie cut', 'Corte Femenino - Corte curtíssimo, muito conhecido também como joãozinho', 4);

CALL InsertServico(33.00, 'Repicado', 'Corte Femenino - Aparência mais clássica quanto moderna', 3);
CALL InsertServico(28.00, 'Chanel', 'Corte Femenino - Tem a base reta e é feito na altura do queixo', 3);
CALL InsertServico(175.00, 'Shaggy', 'Corte Femenino - O estilo é cheio de camadas que deixam o cabelo com um movimento incrível', 3);
CALL InsertServico(123.00, 'Corte em camadas', 'Corte Femenino - O contrário do corte blunt cut e ajuda a valorizar as ondas dos fios', 3);
CALL InsertServico(99.00, 'Short bob', 'Corte Femenino - Corte na altura da nuca e que pode ter a parte da frente um pouquinho maior que a de trás', 3);

CALL InsertServico(83.00, 'Cachos espetados ', 'Corte Unissex - Se o seu rosto for mais quadrado, esse corte de cabelo cria uma harmonia interessante', 2);
CALL InsertServico(77.00, 'Cabelo curto assimétrico', 'Corte Masculino - Fios assimétricos ou manter a linha mais séria apenas jogando eles para trás com uma pomada', 2);
CALL InsertServico(26.00, 'Ondulado casual', 'Corte Unissex - Corte de cabelo mais prático para quem tem o cabelo bem ondulado', 2);
CALL InsertServico(120.00, 'Afro pra cima', 'Corte Masculino - Mais volume aparando o seu cabelo nas laterais', 2);
CALL InsertServico(44.00, 'Cachos e undercut', 'Corte Unissex - Trabalhado em cachos', 2);

CALL InsertServico(137.00, 'Corte reto', 'Corte Femenino - Tem a base super retinha, sem desfiados ou camadas pelo cabelo', 1);
CALL InsertServico(39.00, 'Sidecut', 'Corte Femenino - Estilo em que apenas um lado da cabeça é raspado', 1);
CALL InsertServico(180.00, 'Progressiva', 'Corte Femenino - Alisamento com Aminoácidos', 1);
CALL InsertServico(155.00, 'Descoloramento de Mechas', 'Corte Femenino - Mechas Loiras e Platinadas', 1);
CALL InsertServico(142.00, 'Hidratação Profunda', 'Corte Femenino - Produtos com Vitaminas e Anti-Quedas', 1);

# ------------------------------------------------------- DELETE - TABELA DE SERVIÇO -------------------------------------------------------------

DELIMITER $$
CREATE PROCEDURE DeleteServico(id int)
BEGIN
	delete from Servico where (id_ser = id); 
end;
$$ DELIMITER ;

# ------------------------------------------- INSERT - TABELA DE AGENDA -------------------------------------------------

#DROP PROCEDURE InsertAgenda;

DELIMITER $$
CREATE PROCEDURE InsertAgenda(datahora varchar(100), fkSer int, fkCli int , fkSal int)
BEGIN
declare datatime datetime;
select dataHorario_age into datatime from agenda where (dataHorario_Age = str_to_date(datahora, "%d/%m/%Y %H:%i:%s") and (id_sal_fk = fkSal));
if (datatime is null) then
	insert into Agenda values (null, str_to_date(datahora, "%d/%m/%Y %H:%i:%s"), "Indisponível", fkSer, fkCli, fkSal);
end if;
end;
$$ DELIMITER ;

# ------------------------------------------- CALL DE INSERT - TABELA DE AGENDA -------------------------------------------------

/*CALL InsertAgenda('2022-11-18 13:17:17', 1, 1, 1);
CALL InsertAgenda('2022-09-02 14:30:00', 2, 2, 2);
CALL InsertAgenda('2022-04-20 15:40:00', 3, 3, 3);
CALL InsertAgenda('2022-05-30 10:45:10', 4, 4, 4);
CALL InsertAgenda('2022-02-29 18:00:00', 5, 5, 5);*/

# ------------------------------------------- UPDATE - TABELA DE AGENDA -------------------------------------------------

DELIMITER $$
CREATE PROCEDURE UpdateAgenda(datahora varchar(100), statuss varchar(300))
BEGIN
	update Agenda set dataHorario_age = str_to_date(datahora, "%d/%m/%Y %H:%i:%s"), status_age = statuss;
end;
$$ DELIMITER ;

# ------------------------------------------- DELETE - TABELA DE AGENDA -------------------------------------------------

DELIMITER $$
CREATE PROCEDURE DeleteAgenda(id int)
BEGIN
	delete from Agenda where (id_age = id); 
end;
$$ DELIMITER ;

# -------------------------------------------------------------- INSERT - TABELA DE LOGIN ---------------------------------------------------------------------

DELIMITER $$
CREATE PROCEDURE InsertLogin(usuario varchar(300), senha varchar(300), fkCli int)
BEGIN
		if (usuario <> '') then 
			if (senha <> '') then 
				insert into Login values (null, usuario, senha, fkCli);
                select 'Login efetuado com sucesso!' as Confirmacao;
			else 
				select 'Não foi possível efetuar login. Verifique as informações!' as Erro;	
			end if;
	else 
		select 'Não foi possível efetuar login. Verifique as informações!' as Erro;	
		end if;
end;
$$ DELIMITER ;

# ------------------------------------------- CALL DE INSERT - TABELA DE LOGIN -------------------------------------------------

CALL InsertLogin ('maria', '123', 1);
CALL InsertLogin ('luana', '123', 2);
CALL InsertLogin ('lukas', '123', 3);
CALL InsertLogin ('jose', '123', 4);
CALL InsertLogin ('antonio', '123', 5);
CALL InsertLogin ('eduardo', '123', 6);

#SELECT * FROM Login;

# ------------------------------------------- DELETE - TABELA DE LOGIN -------------------------------------------------

DELIMITER $$
CREATE PROCEDURE DeleteLogin(id int)
BEGIN
	delete from Login where (id_log = id); 
end;
$$ DELIMITER ;

# ------------------------------------------------------------- UPDATE - TABELA DE ENDEREÇO  --------------------------------------------------------------- 

DELIMITER $$
CREATE PROCEDURE UpdateEndereco(rua varchar(200), bairro varchar(200), numero varchar(200), cidade varchar(200), estado varchar(200), cep varchar(100), id int)
BEGIN
if (rua <> '') then
	if (bairro <> '') then
       		update Endereco set rua_end = rua, bairro_end = bairro, numero_end = numero, cidade_end = cidade, estado_end = estado, cep_end = cep where id_end = id;
            select 'Endereço de Bairro atualizado com sucesso!' as Confirmacao;
	else
		select 'Erro - ao atualizar Endereço!' as Erro;
	end if;
else
	select 'Erro - ao atualizar Endereço!' as Erro;
end if;
end;
$$ DELIMITER ;

Call UpdateEndereco('Santana', 'Lino Alves', null, null, null, null, 1);

# ------------------------------------------------------------- UPDATE - TABELA DE SALÃO  --------------------------------------------------------------- 

DELIMITER $$
/*CREATE PROCEDURE UpdateSalao(nome varchar(200), telefone varchar(200), razaoSocial varchar(200), cnpj varchar(200), email varchar(200), id int)
BEGIN

if(nome <> '') then
	if(telefone <> '') then
		update Salao set nome_sal = nome, telefone_sal = telefone, razao_social_sal = razaoSocial, cnpj_sal = cnpj, email_sal = email where id_sal = id;
		select 'Salão atualizado com sucesso!' as Confirmacao;
	end if;
    else
		select 'Erro - ao atualizar Salão!' as Erro;
end if;
end;
$$ DELIMITER ;*/

/*Call UpdateSalao('Carla Santos', '(69) 4563 3678', null, null, null, 1);*/

# ------------------------------------------------------------- UPDATE - TABELA DE SERVIÇO  --------------------------------------------------------------- 

DELIMITER $$
CREATE PROCEDURE UpdateServico(valor float, nome varchar(200), tipo varchar(200), id int) 
BEGIN

if(valor is not null) then
	if(nome <> '') then
		update Servico set valor_ser = valor, nome_ser = nome, tipo_ser = tipo where id_ser = id;
		select 'Salão atualizado com sucesso!' as Confirmacao;
	else 
		select 'Erro - ao atualizar Serviço!' as Erro;
	end if;
else
select 'Erro - ao atualizar Serviço!' as Erro;
end if;
end;
$$ DELIMITER ;	
Call UpdateServico(10, 'Monicano Chave', null, 1); 

# ------------------------------------------------------------- UPDATE - TABELA DE CLIENTE  --------------------------------------------------------------- 

DELIMITER $$
CREATE PROCEDURE UpdateCliente(nome varchar (200), cpf varchar (200), rg varchar (200), telefone varchar (200), email varchar (200), sexo varchar (200), id int) 
BEGIN
if(nome is not null) then
	if(cpf <> '') then
		update Cliente set nome_cli = nome, cpf_cli = cpf, rg_cli = rg, telefone_cli = telefone, email_cli = email, sexo_cli = sexo where id_ser = id;
		select 'Cliente atualizado com sucesso!' as Confirmacao;
	else 
		select 'Erro ao atualizar Cliente!' as Erro;
	end if;
else
select 'Erro ao atualizar Cliente!' as Erro;
end if;
end;
$$ DELIMITER ;	

# ------------------------------------------------------------- UPDATE - TABELA DE LOGIN  --------------------------------------------------------------- 

DELIMITER $$
CREATE PROCEDURE UpdateLogin(usuario varchar (200), senha varchar (200), id int) 
BEGIN
if(usuario is not null) then
	if(senha <> '') then
		update Login set user_log = usuario, senha_log = senha where id_ser = id;
		select 'Login atualizado com sucesso!' as Confirmacao;
	else 
		select 'Erro ao atualizar Login!' as Erro;
	end if;
else
select 'Erro ao atualizar Login!' as Erro;
end if;
end;
$$ DELIMITER ;	

select * from agenda;select * from salao;
Select Agenda.id_age as Id, Agenda.dataHorario_age as DataHorario, Agenda.status_age as Status, Servico.nome_ser as Servico, Cliente.nome_cli as Cliente, Salao.nome_sal as Salao from Agenda, Servico, Cliente, Salao where (Agenda.id_ser_fk = Servico.id_ser) and (Agenda.id_cli_fk = Cliente.id_cli) and (Agenda.id_sal_fk = Salao.id_sal) and (Agenda.id_cli_fk =Cliente.id_cli) and (Salao.id_sal = + 1)