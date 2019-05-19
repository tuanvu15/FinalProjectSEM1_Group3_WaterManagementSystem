drop database projectdata;
create database if not exists projectData;

use projectData;
create table Customer(
customer_id int primary key,
customer_name nvarchar(50),
customer_address nvarchar(100),
phone_number nvarchar(50)
);

create table Invoice(
invoice_id int primary key,
date_create date,
old_number int,
new_number int
);

create table Managers(
managers_id int primary key,
pass varchar(50),
full_name varchar(100),
email varchar(100)
);
create table Cus_managers(
customer_id int,
managers_id int,

constraint fk_cusManagers_Customer foreign key (customer_id) references customer(customer_id),
constraint fk_cusManagers_Managers foreign key (managers_id) references Managers(managers_id)
);
create table InvoiceDetail(
customer_id int,
invoice_id int,
from_date date,
to_date date,
constraint fk_InvoiceDetail_Customer foreign key (customer_id) references customer(customer_id),
constraint fk_InvoiceDetail_Invoice foreign key (invoice_id) references Invoice(invoice_id)
);
select * from Customer;


insert into Managers value ('123456789', '12345678','Đỗ Văn Hoàng','hoang123@gmail.com');

 

select * from Customer;
select * from Managers;
