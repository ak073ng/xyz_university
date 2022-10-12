using StudentsTuitionPay.Models.Student.Utility;
using StudentsTuitionPay.Models.Student;

namespace StudentsTuitionPay.Data
{
    public static class StudentDbInitializer
    {
        public static void InitializeModelsInDb(StudentDbContext context)
        {
            InitializeStudents(context);
            InitializeStudentCourses(context);
            InitializeStudentFees(context);
            InitializeFees(context);
            InitializeCourses(context);
            InitializeFaculties(context);
        }

        private static void InitializeStudents(StudentDbContext context)
        {
            var Students = new Student[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Andrew Koteng",
                    StudentId = 123456,
                    Gender = "Male",
                    Email = "andrew.koteng@gmail.com",
                    PhoneNumber = "254705651787",
                    YearOfBirth = 1996,
                    CreatedAt = Convert.ToDateTime("2021/06/18"),
                    UpdatedAt = Convert.ToDateTime("2021/08/04"),
                },
                new Student
                {
                    Id = 2,
                    Name = "Karanja Kirigo",
                    StudentId = 789101,
                    Gender = "Female",
                    Email = "test.karanja@gmail.com",
                    PhoneNumber = "254XXXXXXXXX",
                    YearOfBirth = 1995,
                    CreatedAt = Convert.ToDateTime("2020/01/06"),
                    UpdatedAt = Convert.ToDateTime("2020/02/19"),
                },
                new Student
                {
                    Id = 3,
                    Name = "Jonah Mbaya",
                    StudentId = 127452,
                    Gender = "Male",
                    Email = "test.jonah@gmail.com",
                    PhoneNumber = "254XXXXXXXXX",
                    YearOfBirth = 1998,
                    CreatedAt = Convert.ToDateTime("2021/07/17"),
                    UpdatedAt = Convert.ToDateTime("2021/08/01"),
                },
                new Student
                {
                    Id = 4,
                    Name = "Kylie Jenner",
                    StudentId = 328765,
                    Gender = "Female",
                    Email = "test.kylie@gmail.com",
                    PhoneNumber = "254XXXXXXXXX",
                    YearOfBirth = 1998,
                    CreatedAt = Convert.ToDateTime("2020/12/11"),
                    UpdatedAt = Convert.ToDateTime("2021/04/28"),
                },
                new Student
                {
                    Id = 5,
                    Name = "Boniface Okoth",
                    StudentId = 311765,
                    Gender = "Male",
                    Email = "test.boniface@gmail.com",
                    PhoneNumber = "254XXXXXXXXX",
                    YearOfBirth = 1998,
                    CreatedAt = Convert.ToDateTime("2020/09/22"),
                    UpdatedAt = Convert.ToDateTime("2020/10/01"),
                },
            };

            context.Students.AddRange(Students);
            context.SaveChanges();
        }

        private static void InitializeStudentCourses(StudentDbContext context)
        {
            var StudentCourses = new StudentCourse[]
            {
                new StudentCourse
                {
                    Id = 1,
                    StudentId = 123456,
                    CourseId = 1,
                    DateStarted = Convert.ToDateTime("2021/06/24"),
                    CreatedAt = Convert.ToDateTime("2021/06/18"),
                    UpdatedAt = Convert.ToDateTime("2021/08/04"),
                },
                new StudentCourse
                {
                    Id = 2,
                    StudentId = 789101,
                    CourseId = 2,
                    DateStarted = Convert.ToDateTime("2020/03/04"),
                    CreatedAt = Convert.ToDateTime("2020/01/06"),
                    UpdatedAt = Convert.ToDateTime("2020/02/19"),
                },
                new StudentCourse
                {
                    Id = 3,
                    StudentId = 127452,
                    CourseId = 3,
                    DateStarted = Convert.ToDateTime("2021/08/12"),
                    CreatedAt = Convert.ToDateTime("2021/07/17"),
                    UpdatedAt = Convert.ToDateTime("2021/08/01"),
                },
                new StudentCourse
                {
                    Id = 4,
                    StudentId = 328765,
                    CourseId = 4,
                    DateStarted = Convert.ToDateTime("2021/06/24"),
                    CreatedAt = Convert.ToDateTime("2020/12/11"),
                    UpdatedAt = Convert.ToDateTime("2021/04/28"),
                },
                new StudentCourse
                {
                    Id = 5,
                    StudentId = 311765,
                    CourseId = 5,
                    DateStarted = Convert.ToDateTime("2021/09/24"),
                    CreatedAt = Convert.ToDateTime("2020/09/22"),
                    UpdatedAt = Convert.ToDateTime("2020/10/01"),
                },
            };

            context.StudentCourses.AddRange(StudentCourses);
            context.SaveChanges();
        }

        private static void InitializeStudentFees(StudentDbContext context)
        {
            var StudentFees = new StudentFee[]
            {
                new StudentFee
                {
                    Id = 1,
                    StudentId = 123456,
                    FeeId = 1,
                    AmountPaid = 144570,
                    CreatedAt = Convert.ToDateTime("2021/06/18"),
                    UpdatedAt = Convert.ToDateTime("2021/08/04"),
                },
                new StudentFee
                {
                    Id = 2,
                    StudentId = 789101,
                    FeeId = 2,
                    AmountPaid = 208322,
                    CreatedAt = Convert.ToDateTime("2020/01/06"),
                    UpdatedAt = Convert.ToDateTime("2020/02/19"),
                },
                new StudentFee
                {
                    Id = 3,
                    StudentId = 127452,
                    FeeId = 3,
                    AmountPaid = 60890,
                    CreatedAt = Convert.ToDateTime("2021/07/17"),
                    UpdatedAt = Convert.ToDateTime("2021/08/01"),
                },
                new StudentFee
                {
                    Id = 4,
                    StudentId = 328765,
                    FeeId = 4,
                    AmountPaid = 321000,
                    CreatedAt = Convert.ToDateTime("2020/12/11"),
                    UpdatedAt = Convert.ToDateTime("2021/04/28"),
                },
                new StudentFee
                {
                    Id = 5,
                    StudentId = 311765,
                    FeeId = 5,
                    AmountPaid = 12550,
                    CreatedAt = Convert.ToDateTime("2020/09/22"),
                    UpdatedAt = Convert.ToDateTime("2020/10/01"),
                },
            };

            context.StudentFees.AddRange(StudentFees);
            context.SaveChanges();
        }

        private static void InitializeFees(StudentDbContext context)
        {
            var Fees = new Fee[]
            {
                new Fee
                {
                    Id = 1,
                    Year = 2022,
                    Semester = 1,
                    Amount = 150000,
                    CourseId = 1,
                    CreatedAt = Convert.ToDateTime("2021/06/18"),
                    UpdatedAt = Convert.ToDateTime("2021/08/04"),
                },
                new Fee
                {
                    Id = 2,
                    Year = 2022,
                    Semester = 1,
                    Amount = 210000,
                    CourseId = 2,
                    CreatedAt = Convert.ToDateTime("2020/01/06"),
                    UpdatedAt = Convert.ToDateTime("2020/02/19"),
                },
                new Fee
                {
                    Id = 3,
                    Year = 2022,
                    Semester = 2,
                    Amount = 85000,
                    CourseId = 3,
                    CreatedAt = Convert.ToDateTime("2021/07/17"),
                    UpdatedAt = Convert.ToDateTime("2021/08/01"),
                },
                new Fee
                {
                    Id = 4,
                    Year = 2022,
                    Semester = 3,
                    Amount = 320000,
                    CourseId = 4,
                    CreatedAt = Convert.ToDateTime("2020/12/11"),
                    UpdatedAt = Convert.ToDateTime("2021/04/28"),
                },
                new Fee
                {
                    Id = 5,
                    Year = 2022,
                    Semester = 2,
                    Amount = 15000,
                    CourseId = 5,
                    CreatedAt = Convert.ToDateTime("2020/09/22"),
                    UpdatedAt = Convert.ToDateTime("2020/10/01"),
                },
            };

            context.Fees.AddRange(Fees);
            context.SaveChanges();
        }

        private static void InitializeCourses(StudentDbContext context)
        {
            var Courses = new Course[]
            {
                new Course
                {
                    Id = 1,
                    FacultyId = 1,
                    Name = "Computer Science",
                    CreatedAt = Convert.ToDateTime("2021/06/18"),
                    UpdatedAt = Convert.ToDateTime("2021/08/04"),
                },
                new Course
                {
                    Id = 2,
                    FacultyId = 2,
                    Name = "Communication",
                    CreatedAt = Convert.ToDateTime("2020/01/06"),
                    UpdatedAt = Convert.ToDateTime("2020/02/19"),
                },
                new Course
                {
                    Id = 3,
                    FacultyId = 3,
                    Name = "Financial Economics",
                    CreatedAt = Convert.ToDateTime("2021/07/17"),
                    UpdatedAt = Convert.ToDateTime("2021/08/01"),
                },
                new Course
                {
                    Id = 4,
                    FacultyId = 4,
                    Name = "Hospitality",
                    CreatedAt = Convert.ToDateTime("2020/12/11"),
                    UpdatedAt = Convert.ToDateTime("2021/04/28"),
                },
                new Course
                {
                    Id = 5,
                    FacultyId = 5,
                    Name = "Law, Order and Society",
                    CreatedAt = Convert.ToDateTime("2020/09/22"),
                    UpdatedAt = Convert.ToDateTime("2020/10/01"),
                },
            };

            context.Courses.AddRange(Courses);
            context.SaveChanges();
        }

        private static void InitializeFaculties(StudentDbContext context)
        {
            var Faculties = new Faculty[]
            {
                new Faculty
                {
                    Id = 1,
                    Name = "Department Of Engineering and Technology",
                    CreatedAt = Convert.ToDateTime("2021/06/18"),
                    UpdatedAt = Convert.ToDateTime("2021/08/04"),
                },
                new Faculty
                {
                    Id = 2,
                    Name = "Faculty of Media andCommunication",
                    CreatedAt = Convert.ToDateTime("2020/01/06"),
                    UpdatedAt = Convert.ToDateTime("2020/02/19"),
                },
                new Faculty
                {
                    Id = 3,
                    Name = "School Of Financial",
                    CreatedAt = Convert.ToDateTime("2021/07/17"),
                    UpdatedAt = Convert.ToDateTime("2021/08/01"),
                },
                new Faculty
                {
                    Id = 4,
                    Name = "Faculty Of Hospitality and Tourism Management",
                    CreatedAt = Convert.ToDateTime("2020/12/11"),
                    UpdatedAt = Convert.ToDateTime("2021/04/28"),
                },
                new Faculty
                {
                    Id = 5,
                    Name = "School Of Law",
                    CreatedAt = Convert.ToDateTime("2020/09/22"),
                    UpdatedAt = Convert.ToDateTime("2020/10/01"),
                },
            };

            context.Faculties.AddRange(Faculties);
            context.SaveChanges();
        }
    }
}
