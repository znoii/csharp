using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace factory_method
{
    internal abstract class Base_class
    {
        internal int Id { get; set; }
    }
    internal class Student : Base_class
    {
        internal string Name { get; set; }
        internal List<int> Courses { get; set; }

        internal Student(int id, string name, List<int> courses)
        {
            Id = id;
            Name = name;
            Courses = courses;
        }
    }

    internal class Teacher : Base_class
    {
        internal string Name { get; set; }
        internal int Experience { get; set; }
        internal List<int> Courses { get; set; }

        internal Teacher(int id, string name, int experience, List<int> courses)
        {
            Id = id;
            Name = name;
            Experience = experience;
            Courses = courses;
        }
    }

    internal class Course : Base_class
    {
        internal string Name { get; set; }
        internal int TeacherId { get; set; }
        internal List<int> Students { get; set; }

        internal Course(int id, string name, int teacherId, List<int> students)
        {
            Id = id;
            Name = name;
            TeacherId = teacherId;
            Students = students;
        }
    }
    internal abstract class EducationFactory
    {
        internal abstract Base_class CreateEntity(string[] attributes);
    }

    internal class StudentFactory : EducationFactory
    {
        internal override Base_class CreateEntity(string[] attributes)
        {
            return new Student(int.Parse(attributes[1]), attributes[2], attributes[3].Split(',').Select(int.Parse).ToList());
        }
    }

    internal class TeacherFactory : EducationFactory
    {
        internal override Base_class CreateEntity(string[] attributes)
        {
            return new Teacher(int.Parse(attributes[1]), (attributes[2]), int.Parse(attributes[3]), attributes[4].Split(',').Select(int.Parse).ToList());
        }
    }

    internal class CourseFactory : EducationFactory
    {
        internal override Base_class CreateEntity(string[] attributes)
        {
            return new Course(int.Parse(attributes[1]), attributes[2], int.Parse(attributes[3]), attributes[4].Split(',').Select(int.Parse).ToList());
        }
    }
    


    internal class EducationSystem
    {
        internal List<Base_class> entities;
         
        internal EducationSystem()
        {
            entities = new List<Base_class>();
        }

        internal void LoadFromFile(string filePath)
        {
            entities.Clear();
            filePath = "G:\\c#\\factory_method\\1.txt";
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] attributes = line.Split(',');
                string entityType = attributes[0];

                EducationFactory factory;

                switch (entityType)
                {
                    case "student":
                        factory = new StudentFactory();
                        break;
                    case "teacher":
                        factory = new TeacherFactory();
                        break;
                    case "course":
                        factory = new CourseFactory();
                        break;
                }
                
            }
        }

        internal void SaveToFile(string filePath)
        {
            List<string> lines = new List<string>();

            foreach (Base_class entity in entities)
            {
                if (entity is Student student)
                {
                    lines.Add($"student,{student.Id},{student.Name},{string.Join(",", student.Courses)}");
                }
                else if (entity is Teacher teacher)
                {
                    lines.Add($"teacher,{teacher.Id},{teacher.Name},{teacher.Experience},{string.Join(",", teacher.Courses)}");
                }
                else if (entity is Course course)
                {
                    lines.Add($"course,{course.Id},{course.Name},{course.TeacherId},{string.Join(",", course.Students)}");
                }
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}
