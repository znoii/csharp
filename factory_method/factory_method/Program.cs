using factory_method;
EducationSystem system = new EducationSystem();

system.LoadFromFile("G:\\c#\\factory_method\\1.txt");

// Add some entities
system.entities.Add(new Student(1, "ghmm", new List<int> { 1, 2, 3 }));
system.entities.Add(new Teacher(2, "Jndjs", 5, new List<int> { 1, 2 }));
system.entities.Add(new Course(1, "Pal", 2, new List<int> { 1, 2, 3 }));

Console.WriteLine("Classes:");
foreach (Base_class entity in system.entities)
{
    if (entity is Student student)
    {
        Console.WriteLine($"Student: {student.Id }, {student.Name }, Courses: {string.Join(", ", student.Courses)}");
    }
    else if (entity is Teacher teacher)
    {
        Console.WriteLine($"Teacher: {teacher.Id }, {teacher.Name }, Experience: {teacher.Experience }, Courses: {string.Join(", ", teacher.Courses)}");
    }
    else if (entity is Course course)
    {
        Console.WriteLine($"Course: {course.Id }, {course.Name }, TeacherId: {course.TeacherId }, Students: {string.Join(", ", course.Students)}");
    }
}

system.SaveToFile("G:\\c#\\factory_method\\1.txt");