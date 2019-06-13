drop database projectdata;
create database if not exists projectData;

use projectData;
create table Customer(
customer_id int primary key auto_increment,
customer_name nvarchar(50) not null,
customer_address nvarchar(100) not null,
phone_number nvarchar(20) not null,
customer_CMND nvarchar(20) not null
);

create table Managers(
managers_id int primary key auto_increment,
pass varchar(20) not null,
full_name varchar(20) not null,
email varchar(30)not null
);
create table Cus_managers(
customer_id int,
managers_id int,

constraint fk_cusManagers_Customer foreign key (customer_id) references Customer(customer_id),
constraint fk_cusManagers_Managers foreign key (managers_id) references Managers(managers_id)
);
create table Meter(
customer_id int ,
meter_id varchar(20) primary key ,
meter_status nvarchar(30),
old_number int,
new_number int,
meter_type varchar(20),
meter_place varchar(50),
constraint fk_Meter_customer foreign key (customer_id) references customer(customer_id)
);

create table Meter_logs(
ml_id int auto_increment primary key ,
meter_id varchar(20),
ml_status nvarchar(30),
ml_month varchar(15),
ml_oldnumber int,
ml_newnumber int,
ml_time date,
ml_type varchar(20),
ml_place varchar(50),
pay_status nvarchar(50),
constraint fk_Meterlog_Meter foreign key (meter_id) references Meter(meter_id)
);
create table Company(
com_id int primary key auto_increment,
com_name varchar(50) not null,
com_represent varchar(30) not null,
com_title varchar(80)not null,
com_tax varchar(30)not null,
com_accountnumber varchar(70)not null,
com_headquarters varchar(100)not null,
com_sdt varchar(20)not null);

insert into Company(com_name,com_represent,com_title,com_tax,com_accountnumber,com_headquarters,com_sdt)
value('CÔNG TY CỔ PHẦN CẤP THOÁT NƯỚC HÀ NỘI','Nguyễn Văn Minh','Giám đốc Chi nhánh Công ty Cổ phần cấp thoát nước Hà Nội',
'4000100160','0651000519969 .Tại Ngân hàng Ngoại THương Hà Nội','Tòa nhà Hàn Việt, số 203 Minh Khai, Phường Minh Khai, Minh Khai, Hai Bà Trưng, Hà Nội','02437163611');


insert into Managers(pass,full_name,email) value ('12345678','Đỗ Văn Hoàng','manager01@gmail.com');
insert into Customer(customer_name,customer_address,phone_number,customer_CMND) 
values('Nguyen Van An','191-hai ba trung-Ha Nội','0123874965','0103268963'),
	  ('Nguyen Van Binh','232-hai ba trung-Ha Nội','0987548623','0203271263'),
	  ('pham Van Chung','112-hai ba trung-Ha Nội','0123753684','0103741023'),
      ('Bui Thi kim','172-hai ba trung-Ha Nội','0900689745','0203741321'),
      ('Nguyen Văn Hoang','162-hai ba trung-Ha Nội','0123497682','0103401842'),
      ('Vu Van Thinh','292-hai ba trung-Ha Nội','0123741258','0103951324'),
      ('Pham Thanh An','92-hai ba trung-Ha Nội','0977121387','0203210258'),
	  ('Dao Phuong Duy ','108-hai ba trung-Ha Nội','0945551356','0103268963'),
	  ('Tran Van Quang','211-hai ba trung-Ha Nội','0972671335','0103148573'),
      ('Le Văn Dat','365-hai ba trung-Ha Nội','0998865365','0203258761'),
      ('Nguyen Van Linh','212-hai ba trung-Ha Nội','0123456521','0103075214'),
      ('Mai Phuong Anh','127-hai ba trung-Ha Nội','0165875963','0103847961');
insert into Meter value ('1','a1', 'đang hoạt động',0,0,'sinh hoạt','hà nội'),
						('2','a2', 'đang hoạt động',0,0,'sinh hoạt','hà nội'),
                        ('3','a3', 'đang hoạt động',0,0,'sinh hoạt','hà nội'),
                        ('4','a4', 'đang hoạt động',0,0,'sinh hoạt','hà nội'),
                        ('5','a5', 'đang hoạt động',0,0,'sinh hoạt','hà nội'),
                        ('6','a6', 'đang hoạt động',0,0,'sinh hoạt','hà nội'),
                        ('7','a7', 'đang hoạt động',0,0,'sinh hoạt','hà nội'),
                        ('8','a8', 'đang hoạt động',0,0,'sinh hoạt','hà nội'),
                        ('9','a9', 'đang hoạt động',0,0,'sinh hoạt','hà nội'),
                        ('10','a10', 'đang hoạt động',0,0,'sinh hoạt','hà nội'),
                        ('11','a11', 'đang hoạt động',0,0,'sinh hoạt','hà nội'),
                        ('12','a12', 'đang hoạt động',0,0,'sinh hoạt','hà nội');
select * from Meter;
select * from Company;
select * from Customer;
select * from Managers;
select * from Meter_logs;
select meter_id ,ml_status,ml_month ,ml_oldnumber,ml_newnumber ,ml_time, ml_type, ml_place
            from Meter_logs where Meter_id = '2' and ml_month = '6/2019';
update Meter_logs set Pay_status = 'Đã thanh toán' where meter_id = '1' and ml_month = '6/2019';
select * from Meter_logs where ml_month = '5/2019';

select c.customer_name,  m.meter_id, c.customer_id, m.meter_status from customer c inner join Meter m 
on c.customer_id = m.customer_id;
select c.customer_id, c.customer_name, Meter_id from customer c  inner join Meter m on c.customer_id = m.customer_id where Meter_id = 'a2';
select meter_id,ml_id ,ml_status,ml_month ,ml_oldnumber,ml_newnumber ,ml_time, ml_type, ml_place, pay_status from Meter_Logs where ml_month = '6/2019' ;
select meter_id,meter_status,old_number,new_number,meter_type,meter_place from Meter where meter_id = 'a1';
insert into Meter_Logs
value  (1,'a1','Đang hoạt động','5/2019',10,'25','2019/5/15','sinh hoạt','187 Ha Nội','Đã thanh toán'),
       (2,'a2','Đang hoạt động','5/2019',5,'20','2019/5/15','sinh hoạt','182 Ha Nội','Đã thanh toán'),
       (3,'a3','Đang hoạt động','5/2019',7,'15','2019/5/15','sinh hoạt','133 Ha Nội','Đã thanh toán'),
       (4,'a4','Đang hoạt động','5/2019',9,'30','2019/5/15','sinh hoạt','87 Ha Nội','Đã thanh toán'),
       (5,'a5','Đang hoạt động','5/2019',12,'150','2019/5/15','kinh doanh','144 Ha Nội','Đã thanh toán'),
       (6,'a6','Đang hoạt động','5/2019',17,'45','2019/5/15','sinh hoạt','186 Ha Nội','Đã thanh toán'),
       (7,'a7','Đang hoạt động','5/2019',16,'44','2019/5/15','sinh hoạt','192 Ha Nội','Đã thanh toán'),
       (8,'a8','Đang hoạt động','5/2019',21,'27','2019/5/15','sinh hoạt','16 Ha Nội','Đã thanh toán'),
       (9,'a9','Đang hoạt động','5/2019',1,'14','2019/5/15','sinh hoạt','18 Ha Nội','Đã thanh toán'),
       (10,'a10','Đang hoạt động','5/2019',12,'85','2019/5/15','sinh hoạt','17 Ha Nội','Đã thanh toán'),
       (11,'a11','Đang hoạt động','5/2019',18,'125','2019/5/15','sản xuất','31 Ha Nội','Đã thanh toán'),
       (12,'a12','Đang hoạt động','5/2019',19,'25','2019/5/15','sinh hoạt','77 Ha Nội','Đã thanh toán'),
       (13,'a1','Đang hoạt động','6/2019',25,33,'2019/6/15','sinh hoạt','187 Ha Nội','Đã thanh toán'),
       (14,'a2','Đang hoạt động','6/2019',20,'25','2019/6/15','sinh hoạt','182 Ha Nội','Đã thanh toán'),
       (15,'a3','Đang hoạt động','6/2019',15,'25','2019/6/15','sinh hoạt','133 Ha Nội','Đã thanh toán');
       