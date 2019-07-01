drop table student;
drop table tution_fee;
drop table stu_class_routine;
drop table attendance; 
drop table teacher;
drop table salary;
drop table tea_class_routine;

create table student (
  Student_ID number(10) not null,
  student_name varchar(10),
  section varchar(10),
  class number(10),
  primary key(student_ID) 
);

create table tution_fee (
  student_id number(10) not null,
  Student_name varchar(10),
  class number(10),
  Amount number(10),
  date1 date dafault sysdate,
  foreign key (Student_ID) references student (student_id) on delete cascade
 
);

create table stu_class_routine (
   student_id number(10) not null,
   course varchar(10) not null,
   class_time varchar(10),
   class_room_no varchar(10),
   course_teacher varchar(10) not null,
   primary key (course),
   primary key(class_time, class_room_no),
   foreign key (Student_ID) references student (student_id) on delete cascade,
   foreign key (course_teacher) references teacher (teacher_name) on delete cascade
);

create class attendance (
  course varchar(10),
  student_id number(10),
  student_name varchar(10),
  date1 date default sysdate,
  foreign key (Student_ID) references student (student_id) on delete cascade,
  foreign key (course) references stu_class_routine (course) on delete cascade
);

create table teacher (
  teacher_id number(10) not null,
  teacher_name varchar(10),
  primary key (teacher_id)
);

create table salary (
  teacher_id number(10) not null,
  teacher_name varchar (10),
  month varchar(10),
  amount  number(10),
  foreign key (teacher_ID) references teacher (teacher_id) on delete cascade
);

create table tea_class_routine (
   class_time varchar(10),
   class_room_no varchar(10),
   class number(10),
   section varchar(10),
   foreign key (class_time, class_room_no) references tea_class_routine (class_time, class_room_no) on delete cascade
   
);






