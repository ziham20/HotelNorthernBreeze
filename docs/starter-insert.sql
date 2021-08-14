delete from Booking
delete from Room
delete from dbo.[User]


insert into dbo.[User] values('960343460v','asd@gmail.com','123456','0757123123','John', 'Doe') 
insert into dbo.[User] values('760343460v','clark@gmail.com','123456','0767123123','Stuart', 'clark') 
insert into dbo.[User] values('860343460v','Emma@gmail.com','123456','0727123123','Emma', 'Watsom') 
insert into dbo.[User] values('560343460v','joe@gmail.com','123456','0117123123','Joe', 'Root') 


insert into Room values('Standard','Single', '2000','4')
insert into Room values('Standard','Double', '2500','3')
insert into Room values('Standard','Triple', '3000','3')
insert into Room values('Executive','Single', '3500','3')
insert into Room values('Executive','Double', '4000','3')
insert into Room values('Executive','Triple', '4500','3')
insert into Room values('Royal','Single', '5000','2')
insert into Room values('Royal','Double', '5500','2')
insert into Room values('Royal','Triple', '6000','2')



insert into Booking values('Standard','Single','560343460v', '2021-04-10 22:17:30.033','2021-04-11 22:17:30.033')
insert into Booking values('Executive','Double','560343460v', '2021-03-10 22:17:30.033','2021-03-15 22:17:30.033')
insert into Booking values('Executive','Double','860343460v', '2020-03-20 22:17:30.033','2021-03-21 22:17:30.033')
insert into Booking values('Royal','Triple','860343460v', '2019-02-10 22:17:30.033','2021-02-21 22:17:30.033')
insert into Booking values('Executive','Single','860343460v', '2018-03-10 22:17:30.033','2021-03-15 22:17:30.033')
insert into Booking values('Royal','Single','860343460v', '2017-02-10 22:17:30.033','2021-02-21 22:17:30.033')
insert into Booking values('Executive','Double','760343460v', '2016-03-10 22:17:30.033','2021-03-15 22:17:30.033')
insert into Booking values('Standard','Triple','760343460v', '2015-02-10 22:17:30.033','2021-02-21 22:17:30.033')



select * from Booking
select * from Room
select * from dbo.[User]