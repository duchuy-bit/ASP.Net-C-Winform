Create Database QuanLyQuanCF
Go

use QuanLyQuanCF
Go

-- Food
-- TableFood
-- FoodCategory
-- Account
-- Bill
-- BillInfo

Create Table TableFood
(
	id int Identity Primary Key,
	name nvarchar(100),
	status nvarchar(100) -- trống || có người
)
GO
