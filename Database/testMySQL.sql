create database quanlyquancf;

use quanlyquancf;


-- Food 
-- TableFood
-- FoodCategory
-- Account
-- Bill
-- BillInfo

create table TableFood(
	id int primary key auto_increment,
    name varchar(100) not null,
    status varchar(100) not null  default "Trống"  -- Trống  || Có người
);

create table Account(
	id int primary key auto_increment,
    DisplayName varchar(100) not null,
    UserName varchar(100) not null,
    Password varchar(100) not null,
    Type int not null   -- 0: Staff   || 1: Admin
);


create table FoodCategory(
	id int primary key auto_increment,
    name varchar(100) not null
);

create table Food(
	id int primary key auto_increment,
    name varchar(100) not null,
    idCategory int not null,
    price int not null
);

create table Bill(
	id int primary key auto_increment,
    DateCheckIn datetime,
    DateCheckOut datetime,
    idTable int,
    Status int not null default 0 --    1: Đã thanh toán || 0: Chưa thanh toán
);


create table BillInfo(
	id int primary key auto_increment,
    idBill int,
    idFood int,
    Count int not null default 0
);


-- Insert Foreign Key 
alter table Food
ADD FOREIGN KEY (idCategory) REFERENCES FoodCategory(id);


-- Insert Foreign Key 
alter table Bill
ADD FOREIGN KEY (idTable) REFERENCES TableFood(id);

-- Insert Foreign Key 
alter table BillInfo
ADD FOREIGN KEY (idBill) REFERENCES Bill(id),
ADD FOREIGN KEY (idFood) REFERENCES Food(id);

