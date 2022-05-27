using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Schoolv2.UnitTest.CourseTests
{
    [TestFixture]
    [Author("Ivaylo Glindzhurski")]
    public class Course_Shouldnt
    {
        [Test]
        public void TryCourseCreated_With_InitializesEmptyStringForCourseName()
        {
            var courseName = "";

            Assert.Throws<Exception>( () => new Course(courseName));
        }

        [Test]
        public void TryCourseNameRenamed_With_InitializesEmptyStringForCourseName()
        {
            var course = new Course("SomeCourse to be renamed");
            var emptyStringName = "";

            Assert.Throws<Exception>( () => course.CourseName = emptyStringName);
        }

        [Test]
        public void TryStudentAddedToCourse_When_StudentAlreadyExistsInCourseCollectionOfStudents()
        {
            var newCourse = new Course("Something with C");
            var studentToBeAddedTwice = new Student("Something with c", 51234);

            newCourse.AddStudentToCourse(studentToBeAddedTwice);

            Assert.Throws<Exception>( () => newCourse.AddStudentToCourse(studentToBeAddedTwice));
        }

        [Test]
        public void TryStudentRemovedFromCourse_When_StudentDoesNotExistInCourseCollectionOfStudents()
        {
            var course = new Course("Another one with Java");
            var wrongStudent = new Student("Wrong dude", 10001);

            Assert.Throws<Exception>( () => course.RemoveStudentFromCourse(wrongStudent));
        }

        [Test]
        public void TryManyStudentsAddedToCourse_With_InitializesCollectionOfStudentsOutOfRange()
        {
            var course = new Course("Something with paskal?");

            Assert.Throws<Exception>( () => course.AddManyStudentsToCourse(CreateListOfStudents(25000, 100)));
        }

        public static List<Student> CreateListOfStudents(uint startI, uint count)
        {
            var students = new List<Student>();
            for (uint i = 0; i < count; i++)
            {
                students.Add(new Student($"David{i + 1}", startI + i + 1));
            }
            return students;
        }
    }
}
