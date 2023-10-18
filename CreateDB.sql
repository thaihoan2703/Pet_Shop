create database QuanlyPetStore
go

use QuanlyPetStore
go



create table Suplier
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max),
	Address nvarchar(max),
	Phone nvarchar(20),
	Email nvarchar(200),
	MoreInfo nvarchar(max),
)
go
create table Pet
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max),
	Dob datetime not null,
	Breed nvarchar(50),
	Species nvarchar(50),
	MoreInfo nvarchar(max),

)
go

create table Customer
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max),
	Address nvarchar(max),
	Phone nvarchar(20),
	Email nvarchar(200),
	MoreInfo nvarchar(max),
	IdPet int
	foreign key(IdPet) references Pet(Id),

)
go

create table Product
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max),
	Price float not null,
	IdSuplier int not null,
	BarCode nvarchar(max),
	Inventory int default 0,
	image nvarchar(Max)
	foreign key(IdSuplier) references Suplier(Id),
)
go
create table Service
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max),
	Description nvarchar(max),
	Price float 
)
go
create table UserRole
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max)
)
go

insert into UserRole(DisplayName) values(N'Admin')
go
insert into UserRole(DisplayName) values(N'Nhân viên')
go

create table Users
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max),
	UserName nvarchar(100),
	Password nvarchar(max),
	IdRole int not null

	foreign key (IdRole) references UserRole(Id)
)

create table Input
(
	Id int identity(1,1) primary key,
	DateInput DateTime
)
go

create table InputInfo
(
	Id int identity(1,1) primary key,
	IdProduct int not null,
	IdInput int not null,
	Count int,
	InputPrice float default 0,
	OutputPrice float default 0,
	Status nvarchar(max)


	foreign key (IdProduct) references Product(Id),
	foreign key (IdInput) references Input(Id)
)
go

create table Invoice
(
	Id int identity(1,1) primary key,
	DateOutput DateTime,
	TotalPrice float
)
go

create table InvoiceInfo
(
	Id int identity(1,1) primary key,
	IdProduct int,
	IdService int,
	IdInvoice int  not null,
	IdCustomer int,
	Quantity int default 1,
	Price float,
	TotalPrice float default 0,	
	Status nvarchar(max)

	foreign key (IdProduct) references Product(Id),
	foreign key (IdInvoice) references Invoice(Id),
	foreign key (IdCustomer) references Customer(Id),
	foreign key (IdService) references Service(Id),

)
go
