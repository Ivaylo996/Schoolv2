using NUnit.Framework;
using System.Collections.Generic;

namespace Schoolv2.UnitTest.CourseTests
{
    [TestFixture]
    [Author("Ivaylo Glindzhurski")]
    public class Course_Should
    {
        [Test]
        public void StudentAddedToCourse_When_StudentDoesNotExistInCourse()
        {
            //Arrange
            var course = new Course("Ruby course");
            var newStudent = new Student("Andrew", 50000);

            //Act
            course.AddStudentToCourse(newStudent);

            //Assert
            Assert.IsTrue(course.StudentsInCourse.Contains(newStudent));
        }

        [Test]
        public void CourseCreated_With_InitializesCourseName_And_ListOfStudentsWithinRange()
        {
            var courseName = "TestCourse";
            var course = new Course(courseName, CreateListOfStudents(23456, 25));

            StringAssert.AreEqualIgnoringCase(course.CourseName, courseName);
            CollectionAssert.AreEqual(course.StudentsInCourse, CreateListOfStudents(23456, 25));
        }

        [Test]
        public void CourseNameRenamed_When_CourseNameAlreadyExists()
        {
            var course = new Course("Old course name");
            var newCourseName = "New Course Name";

            course.CourseName = newCourseName;

            StringAssert.AreEqualIgnoringCase(course.CourseName, newCourseName);
        }

        [Test]
        public void StudentRemovedFromCourse_When_StudentExistsInCourseCollectionOfStudents()
        {
            var course = new Course("Another ruby course");
            var studentToBeRemoved = new Student("Remove this guy", 99998);

            course.AddStudentToCourse(studentToBeRemoved);
            course.RemoveStudentFromCourse(studentToBeRemoved);

            CollectionAssert.DoesNotContain(course.StudentsInCourse, studentToBeRemoved);
        }

        [Test]
        public void ManyStudentsAddedToCourse_When_InitializesCollectionOfStudentsWithinRange()
        {
            var course = new Course("Bulgarian course");

            course.AddManyStudentsToCourse(CreateListOfStudents(25555, 25));

            CollectionAssert.AreEqual(course.StudentsInCourse, CreateListOfStudents(25555, 25));
        }

        public static List<Student> CreateListOfStudents(uint startI, uint count)
        {
            var students = new List<Student>();
            for (uint i = 0; i < count; i++)
            {
                students.Add(new Student($"Jimmy{i+1}", startI + i + 1 ));
            }
            return students;
        }
    }
}
