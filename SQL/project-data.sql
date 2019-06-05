drop database projectdata;
create database if not exists projectData;

use projectData;
create table Customer(
customer_id int primary key auto_increment,
customer_name varchar(50) not null,
customer_address varchar(100) not null,
phone_number varchar(50) not null
);

create table Invoice(
invoice_id int auto_increment primary key ,
date_create datetime not null,
unit_price decimal not null
);

create table Managers(
managers_id int primary key auto_increment,
pass varchar(50) not null,
full_name varchar(100) not null,
email varchar(100)not null
);
create table Cus_managers(
customer_id int,
managers_id int,

constraint fk_cusManagers_Customer foreign key (customer_id) references customer(customer_id),
constraint fk_cusManagers_Managers foreign key (managers_id) references Managers(managers_id)
);
create table Month_(
month_id int primary key,
from_date varchar(50),
to_date varchar(50)
);
create table InvoiceDetail(
customer_id int ,
invoice_id int auto_increment,
month_id int,
old_number int not null,
new_number int not null,
constraint pk_ShowTable primary key (customer_id, invoice_id),
constraint fk_InvoiceSetail_Month_ foreign key (month_id) references Month_(month_id),
constraint fk_InvoiceDetail_Customer foreign key (customer_id) references customer(customer_id),
constraint fk_InvoiceDetail_Invoice foreign key (invoice_id) references Invoice(invoice_id)
);

insert into Managers(pass,full_name,email) value ('12345678','Đỗ Văn Hoàng','manager01@gmail.com');
insert into Customer(customer_name,customer_address,phone_number) 
values('Nguyễn văn A','Hà Nội','0123846579'),
('Nguyễn văn B','Hà Nội','0123745245'),
('Nguyễn văn C','Hà Nội','0123147852'),
('Nguyễn văn D','Hà Nội','0123953682'),
('Nguyễn văn E','Hà Nội','0123175248'),
('Nguyễn văn F','Hà Nội','0123723210');

 

select * from Customer;
select * from Managers;
