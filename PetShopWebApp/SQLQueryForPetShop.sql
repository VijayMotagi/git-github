Use PetShop                 --Select database or use database    
Create table Ulogin      --create table Ulogin is my table name    
(    
   UserId varchar(50) primary key not null,   --primary key not accept null value    
   Password varchar(100) not null    
)   

insert into  Ulogin values ('Karthik','Karthik')     --insert value in Ulogin table
insert into  Ulogin values ('Vijay','Vijay')

select * from Ulogin