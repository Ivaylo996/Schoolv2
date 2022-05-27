namespace Schoolv2
{
    public class School
    {
        private string _schoolName;
        List<Student> _students = new List<Student>();
        List<Course> _courses = new List<Course>();

        public School(string name)
        {
            SchoolName = name;
        }

        public School(string name, List<Student> students) : this(name)
        {
            Students = students;
        }

        public School(string name, List<Course> courses) : this(name)
        {
            Courses = courses;
        }

        public School(string name, List<Course> courses, List<Student> students) : this(name, courses)
        {
            Students = students;
        }

        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }

        public string SchoolName
        {
            get 
            { 
                return _schoolName; 
            }
            set
            {
                if (!value.Equals(""))
                {
                    _schoolName = value;
                }
                else
                {
                    throw new Exception("The name of the school shouldn't be null");
                }
            }
        }

        public void AddStudentToSchool(Student stu)
        {
            if (!_students.Contains(stu))
            {
                _students.Add(stu);
            }
            else
            {
                throw new Exception("This student already exists");
            }
        }

        public void AddCourseToSchool(Course course)
        {
            if (!course.CourseName.Equals(""))
            {
                if (!_courses.Contains(course))
                {
                    _courses.Add(course);
                }
                else
                {
                    throw new Exception("This course already exists");
                }
            }
            else
            {
                throw new Exception("The name of the course should not be empty string");
            }
        }

        public void ExpelStudentFromSchool(Student stu)
        {
            if (_students.Contains(stu))
            {
                _students.Remove(stu);
            }
            else
            {
                throw new Exception("This student does not exist in the particular school");
            }
        }

        public void RemoveCourse(Course courseToBeRemoved)
        {
            if (_courses.Contains(courseToBeRemoved))
            {
                _courses.Remove(courseToBeRemoved);
            }
            else
            {
                throw new Exception("This course does not exist in the particular school");
            }
        }

        public void AddManyStudentsToSchool(List<Student> newStudents)
        {
            foreach (Student student in newStudents)
            {
                if (!_students.Contains(student))
                {
                    AddStudentToSchool(student);
                }
                else
                {
                    throw new Exception($"{student.Name}, {student.UniqueNumber} already exists");
                }
            }
        }

        public void AddManyCoursesToSchool(List<Course> newCourses)
        {
            foreach (Course course in newCourses)
            {
                if (!_courses.Contains(course))
                {
                    AddCourseToSchool(course);
                }
                else
                {
                    throw new Exception($"{course.CourseName} already exists");
                }
            }
        }
    }
}