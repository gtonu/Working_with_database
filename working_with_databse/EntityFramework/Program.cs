using EntityFramework;

TrainingDbContext trainingDbContext = new TrainingDbContext();

Student student1 = new Student();
student1.Name = "Rayhan";
student1.Cgpa = 3.04;
student1.DateOfBirth = new DateTime(2000, 01, 14);

Teacher teacher1 = new Teacher();
teacher1.Name = "Jalaluddin";
teacher1.salary = 8000;

trainingDbContext.Students.Add(student1);
trainingDbContext.Teachers.Add(teacher1);
trainingDbContext.SaveChanges();

Console.WriteLine("Done");
