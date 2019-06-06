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
values('Nguyen Van An','191-hai ba trung-Ha Nội','0123874965'),
	  ('Nguyen Van Binh','232-hai ba trung-Ha Nội','0987548623'),
	  ('pham Van Chung','112-hai ba trung-Ha Nội','0123753684'),
      ('Bui Thi kim','172-hai ba trung-Ha Nội','0900689745'),
      ('Nguyen Văn Hoang','162-hai ba trung-Ha Nội','0123497682'),
      ('Vu Van Thinh','292-hai ba trung-Ha Nội','0123741258'),
      ('Pham Thanh An','92-hai ba trung-Ha Nội','0977121387'),
	  ('Dao Phuong Duy ','108-hai ba trung-Ha Nội','0945551356'),
	  ('Tran Van Quang','211-hai ba trung-Ha Nội','0972671335'),
      ('Le Văn Dat','365-hai ba trung-Ha Nội','0998865365'),
      ('Nguyen Van Linh','212-hai ba trung-Ha Nội','0123456521'),
      ('Mai Phuong Anh','127-hai ba trung-Ha Nội','0165875963');

 

select * from Customer;
select * from Managers;
