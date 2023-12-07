
use quanlyquancf;


DELIMITER $$
DROP PROCEDURE IF EXISTS login;
CREATE PROCEDURE login(IN username varchar(100), IN pwd varchar(100))
BEGIN
   SELECT * FROM account 
    where account.UserName =username and account.Password = pwd;
END; $$ 


Begin
DECLARE @s int default -1;
end 


set @i:="";
select @i := TABLEfood.name from TABLEfood WHERE id = 2;

select @i as ok;

call AddFoodToBill(33, 4, 1, -5)

call test(5, 4, 1, 2)


select *
from bill
left join billinfo on bill.id = billinfo.idBill
left join tablefood on tablefood.id = bill.idTable
left join food on food.id = billinfo.idFood
where idtable = 1

DELIMITER //
DROP PROCEDURE IF EXISTS AddFoodToBill;
CREATE PROCEDURE AddFoodToBill(idBill int, idTable int, idFood int, count int)
BEGIN
	set @count := -1 ;
    set @billinfoid := -1 ;
	set @tam := -1 ;
    
SELECT idBill, idTable, idFood, count;
    
SELECT 
    @count:=billinfo.count, @billinfoid:=billinfo.id
FROM
    billinfo
WHERE
    billinfo.idBill = idBill
        AND billinfo.idFood = idFood;
SELECT 
    *
FROM
    billinfo
WHERE
    billinfo.idBill = idBill
        AND billinfo.idFood = idFood;
SELECT @count, @billinfoid;
    
    if (@count > 0  ) then
		if (@count + count <= 0) then
			set @tam  := 10;
			DELETE FROM billinfo 
WHERE
    billinfo.id = @billinfoid;
            
            set @amountBillInfo := 0;
SELECT 
    @amountBillInfo:=COUNT(*)
FROM
    bill
        INNER JOIN
    billinfo ON bill.id = billinfo.idBill
WHERE
    bill.id = idBill;
            
SELECT @amountBillInfo;
            if ( @amountBillInfo = 0 ) then
				DELETE FROM bill WHERE bill.id = idBill;
                
UPDATE tablefood 
SET 
    status = 'Trống'
WHERE
    id = idTable
                -- update table tablefood 	
--                 SET statusTable = "Trống"
-- 				WHERE id = 3;
            end if;
		else    
			set @tam  := 20;
			UPDATE billinfo 
SET 
    count = @count + count
WHERE
    idBill = idBill
        AND billinfo.id = @billinfoid
		end if;
	else
		if (count > 0) then
			set @tam  := 30;
			INSERT INTO billinfo 
			VALUES (null, idBill, idFood, count);
        end if;
    END IF;
   
SELECT @tam
  
END //
DELIMITER ;


DELETE FROM billinfo;
DELETE FROM bill foodcategory;


select count(*) as count from  billinfo where billinfo.idBill = 1 and billinfo.idFood = 2;
-- -------------------------------------------------------------------------
call test(5, 4, 1, 2);

DELIMITER //
 DROP PROCEDURE IF EXISTS test;
CREATE PROCEDURE test(idBill int, idTable int, idFood int, count int)
BEGIN
	 -- set @count := -1 ;
--      set @billinfoid := -1 ;
-- 	set @tam := -1 ;
    
    select idBill,idTable,idFood,count;
    
    select * from  billinfo where billinfo.idBill = idBill and billinfo.idFood = idFood;   
END //
DELIMITER ;
-- -------------------------------------------------------------------------
select * from  billinfo where idBill = 5 and idFood = 1;
-- -------------------------------------------------------------------------
set @count := -1 ;
     set @billinfoid := -1 ;
	
    select  @count := billinfo.count,  @billinfoid := billinfo.id from  billinfo where idBill = 5 and idFood = 1;
    
    select @count , @billinfoid;
-- -------------------------------------------------------------------------
call AddFoodToBill()




DELIMITER //
DROP procedure IF EXISTS test;
CREATE procedure test(n INT, m INT)
  BEGIN
    DECLARE s VARCHAR(20) default "*";

     IF n > m THEN SET s = '>';
     ELSEIF n = m THEN SET s = '=';
    ELSE SET s = '<';
    END IF;

     SET s = CONCAT(n, ' ', s, ' ', m);
     select s;


  END //
DELIMITER ;

call test(1,2);test

DELIMITER //
DROP PROCEDURE IF EXISTS test;
CREATE PROCEDURE test()
BEGIN
	set @i := 1;
	if (1>2)then
		Begin
			set @i:=2;
		end;
		else
		begin
			set @i:=3;
		end;
    END IF;
    
    select @i;
END //
DELIMITER 
 
DROP PROCEDURE IF EXISTS `checkLogin`$$
 
CREATE PROCEDURE `checkLogin`(
    IN input_username VARCHAR(255),
    IN input_password VARCHAR(255),
    OUT result VARCHAR(255)
)
BEGIN
    /*Bien flag luu tru level. Mac dinh la -1*/
    DECLARE flag INT(11) DEFAULT -1;
     
    
    IF (flag <= 0) THEN
            SET result = 'Thong tin dang nhap sai';
        ELSEIF (flag = 0) THEN
            SET result = 'Tai khoan bi khoa';
        ELSEIF (flag = 1) THEN
            SET result = 'Tai khoan admin';
        ELSE
            SET result = 'Tai khoan member';
    END IF;
END$$
 

DELIMITER //
DROP FUNCTION IF EXISTS SimpleCompare;
CREATE FUNCTION SimpleCompare(n INT, m INT)
  RETURNS VARCHAR(20)

  BEGIN
    DECLARE s VARCHAR(20) default "*";

    -- IF n > m THEN SET s = '>';
--     ELSEIF n = m THEN SET s = '=';
--     ELSE SET s = '<';
--     END IF;

    -- SET s = CONCAT(n, ' ', s, ' ', m);

    RETURN s;
  END //
DELIMITER ;

select SimpleCompare(3,4);

-- ----------------------------------------------

call AddFoodToBill(1,1,1,1);

DELIMITER //
DROP PROCEDURE IF EXISTS AddNewBill;
CREATE PROCEDURE AddNewBill(IN idBill int, idTable int, idFood int, count int)
BEGIN
	
    set @i := -1;
	-- START TRANSACTION;
-- 	insert into bill  Values (null, NOW(), null, 5, 0);
-- 	   set @i := LAST_INSERT_ID();
-- 	COMMIT;	
    set @i := -1;
    Select @i as Inha;
    -- set @i := -1;
    IF ( @i < 0 ) THEN
    BEGIN
		Select @i as Inha;
     END;
	END IF;
    
    
    SET @i := -1;
IF (@i < 0) THEN
    SELECT @i AS Inha;
END IF;
   

   	-- insert into billinfo
-- 		Values (null, @i , 1, 1);
   -- insert  into billinfo
--    Values (null, idBill, idFood, count);
   
END //


DELIMITER //
DROP PROCEDURE IF EXISTS AddNewBill;
CREATE PROCEDURE AddNewBill(IN idBill int, idTable int, idFood int, count int)
BEGIN
	if (count > 0) then
	START TRANSACTION;
 	insert into bill  Values (null, NOW(), null, idTable, 0);
    insert  into billinfo  Values (null, LAST_INSERT_ID() , idFood, count);
    update tablefood set status = "Có người"  where id = idTable;
 	COMMIT;	   
    end if;
END //


-- update tablefood set status = "Có người"  where id = -- 


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



select bill.id as id, food.name as name, billinfo.count as count, food.price as price
from bill
left join billinfo on bill.id = billinfo.idBill
left join tablefood on tablefood.id = bill.idTable
left join food on food.id = billinfo.idFood
where idtable = 4
