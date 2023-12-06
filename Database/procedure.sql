
use quanlyquancf;


DELIMITER $$
DROP PROCEDURE IF EXISTS login;
CREATE PROCEDURE login(IN username varchar(100), IN pwd varchar(100))
BEGIN
   SELECT * FROM account 
    where account.UserName =username and account.Password = pwd;
END; $$ 


DELIMITER $$
DROP PROCEDURE IF EXISTS AddBill;
CREATE PROCEDURE AddBill(IN idBill int, idTable int, idFood int, count int)
BEGIN
   select * from bill inner join billinfo on bill.id = billinfo.idBill where bill.id = "1";
   
END; $$ 


call login("admin", '123');


DECLARE  i_tam int ;
-- DELIMITER $$ 

DECLARE total INT DEFAULT 0 ; 

while i <=10
Begin
	insert into table tablefood(id,name,status)
		values(null, "Bàn " + i, ,"Trống")
    set i = i + 1;
end

insert into  tablefood(name,status) values ( "Bàn 1", "Trống");
insert into  tablefood(name,status) values ( "Bàn 2", "Trống");
insert into  tablefood(id,name,status) values (null, "Bàn 3" ,"Trống");
insert into  tablefood(id,name,status) values (null, "Bàn 4" ,"Trống");
insert into  tablefood(id,name,status) values (null, "Bàn 5" ,"Trống");
insert into  tablefood(id,name,status) values (null, "Bàn 6" ,"Trống");
insert into  tablefood(id,name,status) values (null, "Bàn 7" ,"Trống");
insert into  tablefood(id,name,status) values (null, "Bàn 8" ,"Trống");
insert into  tablefood(id,name,status) values (null, "Bàn 9" ,"Trống");

update tablefood set status = "Có người" where id  = 8;

select * from tablefood



select * from tablefood where ;

billselect * from bill 
left join billinfo on bill.id = billinfo.idBill
left join tablefood on tablefood.id = bill.idTable
left join food on food.id = billinfo.idFood
where idtable = 2


-- DELIMITER //
-- Begin
-- 	DECLARE  @i int;
-- 	-- -- set @i := 10;

-- 	select @i;

-- End 
-- DELIMITER

-- DECLARE--  vSite VARCHAR(40);


-- set i = 0;
