using NUnit.Framework;
using System.Collections.Generic;

namespace Schoolv2.UnitTest.SchoolTests
{
    [TestFixture]
    [Author("Ivaylo GLindzhurski")]
    public class School_Should
    {
        [Test]
        public void SchoolCreated_With_InitiaizesCorrectName_And_ListOfStudents()
        {
            var newSchoolName = "newSchool";
            var newSchool = new School(newSchoolName, CreateListOfStudents(40000,251));

            StringAssert.AreEqualIgnoringCase(newSchool.SchoolName, newSchoolName);
            Assert.AreEqual(newSchool.Students.Count, 251);
            CollectionAssert.AreEqual(newSchool.Students, CreateListOfStudents(40000, 251));
        }

        [Test]
        public void SchoolCreated_With_InitializesCorrectName_And_ListOfStudentsAndListOfCourses()
        {
            var schoolName = "some school's name";
            var newSchool = new School(schoolName, CreateListOfCourses(3), CreateListOfStudents(15000,15));

            StringAssert.AreEqualIgnoringCase(newSchool.SchoolName, schoolName);
            CollectionAssert.AreEqual(newSchool.Students, CreateListOfStudents(15000,15));
            CollectionAssert.AreEqual(newSchool.Courses, CreateListOfCourses(3));
        }

        [Test]
        public void SchoolNameRenamed_When_SchoolHasNameValue()
        {
            var newName = "new cooler name";
            var school = new School("Old name");
            school.SchoolName = newName;

            StringAssert.AreEqualIgnoringCase(school.SchoolName, newName);
        }

        [Test]
        public void StudentAddedToSchool_With_InitializesStudent()
        {
            var newSchool = new School("First school");
            var student = new Student("Alexander", 70000);

            newSchool.AddStudentToSchool(student);

            Assert.IsTrue(newSchool.Students.Contains(student));
        }

        [Test]
        public void ManyStudentsAddedToSchool_With_InitializesCollectionOfStudents()
        {
            var newSchool = new School("second school");

            newSchool.AddManyStudentsToSchool(CreateListOfStudents(50000, 25));

            CollectionAssert.AreEqual(newSchool.Students, CreateListOfStudents(50000, 25));
        }

        [Test]
        public void StudentRemovedFromSchool_When_StudentExistsInSchoolCollectionOfStudents()
        {
            var newSchool = new School("Some school");
            var newStudent = new Student("John", 40000);

            newSchool.AddStudentToSchool(newStudent);
            newSchool.ExpelStudentFromSchool(newStudent);

            CollectionAssert.DoesNotContain(newSchool.Students, newStudent);    
        }

        [Test]
        public void CourseAddedToSchool_With_InitializesCourse()
        {
            var newSchool = new School("new school");
            var newJavaCourse = new Course("New Java Course");

            newSchool.AddCourseToSchool(newJavaCourse);

            Assert.IsTrue(newSchool.Courses.Contains(newJavaCourse));
        }

        [Test]
        public void ManyCoursesAddedToSchool_When_InitializesCollectionOfStudents()
        {
            var newSchool = new School("new school");

            newSchool.AddManyCoursesToSchool(CreateListOfCourses(5));

            CollectionAssert.AreEqual(newSchool.Courses, CreateListOfCourses(5));
        }

        [Test]
        public void CourseRemovedFromSchool_When_CourseExistsInSchoolCollection()
        {
            var newSchool = new School("John Atanasov");
            var newCourse = new Course("Javascript");

            newSchool.AddCourseToSchool(newCourse);
            newSchool.RemoveCourse(newCourse);

            CollectionAssert.DoesNotContain(newSchool.Courses, newCourse);
        }

        public static List<Student> CreateListOfStudents(uint startI, uint count)
        {
            List<Student> students = new List<Student>();

            for (uint i = 0; i < count; i++)
            {
                students.Add(new Student($"John{i+1}", i + startI + 1));
            }
            return students;
        }

        public static List<Course> CreateListOfCourses(uint count)
        {
            List<Course> courses = new List<Course>();
            for (int i = 0; i < count; i++)
            {
                courses.Add(new Course($"C# part{i+1}"));
            }
            return courses;
        }
    }
}