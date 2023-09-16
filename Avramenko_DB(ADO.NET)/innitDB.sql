DROP TABLE  IF EXISTS `orders`;
DROP TABLE  IF EXISTS `workers`;
DROP TABLE  IF EXISTS `cars`;


CREATE TABLE `workers`(
    id int PRIMARY KEY AUTO_INCREMENT,
    Name varchar(50)
    );
    

 CREATE TABLE `cars`(
    id int PRIMARY KEY AUTO_INCREMENT,
    manufactorer varchar(50),
    model varchar(50)
    );
   
 
CREATE TABLE `orders`(
    id int PRIMARY KEY AUTO_INCREMENT,
    accepcerId int,
    repairerId int,
    carId int,
    defect varchar(1000),
    fixed varchar(1000),
    
    
    FOREIGN KEY (accepcerId) REFERENCES workers(id),
    FOREIGN KEY (repairerId) REFERENCES workers(id),
    FOREIGN KEY (carId) REFERENCES cars(id)
    );
insert into `workers`(Name)
VALUES("Gotto"),("Rod"),("Tom"),("Asport"),("KOlt"),("Jerry"),("Qwerty"),("Qazzi");   

insert into `cars`(manufactorer, model)
VALUES("BMW","M5"),("Tesla","model X"),("Aston Martin","DB11");

insert into `orders`(accepcerId, repairerId,carId,defect,fixed)
SELECT wa.id, wr.id,c.id, "не аккума", "Купить на алике аккум" 
from `workers` as wa,  `cars` as c, `workers` as wr
where wa.Name="Qwerty" and wr.Name="kOlt" and c.model="model X";

insert into `orders`(accepcerId, repairerId,carId,defect,fixed)
SELECT wa.id, wr.id,c.id, "подделка", "Предложить купить Ладу седан баклажан" 
from `workers` as wa, `cars` as c, `workers` as wr
where wa.Name="Tom" and wr.Name="Jerry" and c.model="DB11";
