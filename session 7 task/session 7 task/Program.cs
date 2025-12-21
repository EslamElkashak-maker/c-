using System.Collections.Generic;

namespace session_7_task
{
    class Student(int studentId, string name, int age)
    {
        public int studentId = studentId;
        public string name = name;
        public int age = age;
        public List<Course> courses = [];
        public bool Enroll(Course course)
        {
            foreach (Course item in courses)
            {
                if (item.courseId == course.courseId)
                    return false;
            }
            courses.Add(course);
            return true;
        }
        public string PrintDetails()
        {
            string details = $"Student ID: {studentId}, Name: {name}, Age: {age}, Enrolled Courses: ";
            if (courses.Count == 0)
            {
                details += "None";
            }
            else
            {
                foreach (Course course in courses)
                {
                    details += $"{course.courseTitle}  ID: {course.courseId}, ";
                }
            }
            return details;
        }
    }
    class Course(int courseId, string courseTitle, Instructor instructor)
    {
        public int courseId = courseId;
        public string courseTitle = courseTitle;
        public Instructor instructor = instructor;
        public string PrintDetails()
        {
            return $"Course ID: {courseId}, Title: {courseTitle}, Instructor: {instructor.instructorName}";
        }
    }
    class Instructor(int instructorId, string instructorName, string specialization)
    {
        public int instructorId = instructorId;
        public string instructorName = instructorName;
        public string specialization = specialization;
        public string PrintDetails()
        {
            return $"Instructor ID: {instructorId}, Name: {instructorName}, Specialization: {specialization}";
        }
    }
    class StudentManager
    {
        public List<Student> students = [];
        public List<Course> courses = [];
        public List<Instructor> instructors = [];
        public bool AddStudent(Student student)
        {
            students.Add(student);
            return true;
        }
        public bool AddCourse(Course course)
        {
            courses.Add(course);
            return true;
        }
        public bool AddInstructor(Instructor instructor)
        {
            instructors.Add(instructor);
            return true;
        }
        public Student FindStudent(int studentId)
        {
            foreach (Student student in students)
            {
                if (student.studentId == studentId)
                    return student;
            }
            return null;
        }
        public Course FindCourse(int courseId)
        {
            foreach (Course course in courses)
            {
                if (course.courseId == courseId)
                    return course;
            }
            return null;
        }
        public Instructor FindInstructor(int instructorId)
        {
            foreach (Instructor instructor in instructors)
            {
                if (instructor.instructorId == instructorId)
                    return instructor;
            }
            return null;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);
            if (student != null && course != null)
            {
                return student.Enroll(course);
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            StudentManager manager = new StudentManager();
            string choice;
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1.Add Student");
                Console.WriteLine("2.Add Instructor");
                Console.WriteLine("3.Add Course");
                Console.WriteLine("4.Enroll Student in Course");
                Console.WriteLine("5.Show All Students");
                Console.WriteLine("6.Show All Courses");
                Console.WriteLine("7.Show All Instructors");
                Console.WriteLine("8.Find the student by id");
                Console.WriteLine("9.Fine the course by id");
                Console.WriteLine("10.Exit");

                Console.WriteLine("Enter your choice:");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter Student ID:");
                        int studentId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Student Name:");
                        string studentName = Console.ReadLine();
                        Console.WriteLine("Enter Student Age:");
                        int studentAge = Convert.ToInt32(Console.ReadLine());
                        Student student = new Student(studentId, studentName, studentAge);
                        manager.AddStudent(student);
                        Console.WriteLine("Student added successfully.");
                        break;
                    case "2":
                        Console.WriteLine("Enter Instructor ID:");
                        int instructorId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Instructor Name:");
                        string instructorName = Console.ReadLine();
                        Console.WriteLine("Enter Instructor Specialization:");
                        string specialization = Console.ReadLine();
                        Instructor instructor = new Instructor(instructorId, instructorName, specialization);
                        manager.AddInstructor(instructor);
                        Console.WriteLine("Instructor added successfully.");
                        break;
                    case "3":
                        Console.WriteLine("Enter Course ID:");
                        int courseId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Course Title:");
                        string courseTitle = Console.ReadLine();
                        Console.WriteLine("Enter Instructor ID for the Course:");
                        int instrId = Convert.ToInt32(Console.ReadLine());
                        Instructor courseInstructor = manager.FindInstructor(instrId);
                        if (courseInstructor != null)
                        {
                            Course course = new Course(courseId, courseTitle, courseInstructor);
                            manager.AddCourse(course);
                            Console.WriteLine("Course added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Instructor not found. Course not added.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Enter Student ID:");
                        int stuId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Course ID:");
                        int courId = Convert.ToInt32(Console.ReadLine());
                        if (manager.EnrollStudentInCourse(stuId, courId))
                        {
                            Console.WriteLine("Student enrolled in course successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Enrollment failed. Check Student ID and Course ID.");
                        }
                        break;
                    case "5":
                        Console.WriteLine("All Students:");
                        foreach (Student stud in manager.students)
                        {
                            Console.WriteLine(stud.PrintDetails());
                        }
                        break;
                    case "6":
                        Console.WriteLine("All Courses:");
                        foreach (Course cour in manager.courses)
                        {
                            Console.WriteLine(cour.PrintDetails());
                        }
                        break;
                    case "7":
                        Console.WriteLine("All Instructors:");
                        foreach (Instructor instr in manager.instructors)
                        {
                            Console.WriteLine(instr.PrintDetails());
                        }
                        break;
                    case "8":
                        Console.WriteLine("Enter Student ID to find:");
                        int findStuId = Convert.ToInt32(Console.ReadLine());
                        Student foundStudent = manager.FindStudent(findStuId);
                        if (foundStudent != null)
                        {
                            Console.WriteLine("Student Found:");
                            Console.WriteLine(foundStudent.PrintDetails());
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                        break;
                    case "9":
                        Console.WriteLine("Enter Course ID to find:");
                        int findCourId = Convert.ToInt32(Console.ReadLine());
                        Course foundCourse = manager.FindCourse(findCourId);
                        if (foundCourse != null)
                        {
                            Console.WriteLine("Course Found:");
                            Console.WriteLine(foundCourse.PrintDetails());
                        }
                        else
                        {
                            Console.WriteLine("Course not found.");
                        }
                        break;

                    case "10":
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;



                }
            } while (choice != "10");
        }
    }
}
