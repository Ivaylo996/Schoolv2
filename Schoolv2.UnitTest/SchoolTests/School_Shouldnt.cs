using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Schoolv2.UnitTest.SchoolTests
{
    [TestFixture]
    [Author("Ivaylo Glindzhurski")]
    public class School_Shouldnt
    {
        [Test]
        public void TrySchoolCreated_With_EmptyName()
        {
            var newEmptyName = "";          

            Assert.Throws<Exception>( () => new School(newEmptyName));
        }

        [Test]
        public void TryStudentAddedToSchool_With_InitializesEmptyStringStudentName()
        {
            var newSchool = new School("new school");

            Assert.Throws<Exception>( () => newSchool.AddStudentToSchool(new Student("", 25123)));
        }

        [Test]
        public void TryCourseAddedToSchool_With_InitializesEmptyStringCourseName()
        {
            var newSchool = new School("some school");

            Assert.Throws<Exception>( () => newSchool.AddCourseToSchool(new Course("")));
        }

        [Test]
        public void TryStudentExpelledFromSchool_When_StudentIsNotInSchoolCollectionOfStidents()
        {
            var newSchool = new School("Tech School");
            var wrongStudent = new Student("Wrong student", 22222);

            Assert.Throws<Exception>( () => newSchool.ExpelStudentFromSchool(wrongStudent));
        }

        [Test]
        public void TryCourseRemovedFromSchool_When_CourseIsNotInSchoolCollectionOfCourses()
        {
            var newSchool = new School("Some school");
            var wrongCourse = new Course("wrong course");

            Assert.Throws<Exception>(() => newSchool.RemoveCourse(wrongCourse));
        }

        [Test]
        public void TryManyStudentsAddedToSchool_When_StudentsAlreadyExistInSchoolCollectionOfStudents()
        {
            var newSchool = new School("PMG", CreateListOfStudents(25000, 40));

            Assert.Throws<Exception>( () => newSchool.AddManyStudentsToSchool(CreateListOfStudents(25000,5)));
        }

        [Test]
        public void TryManyCoursesAddedToSchool_When_CoursesAlreadyExistInSchoolCollectionOfCourses()
        {
            var newSchool = new School("Javascript School", CreateListOfCourses(5));

            Assert.Throws<Exception>( () => newSchool.AddManyCoursesToSchool(CreateListOfCourses(3)));
        }

        public static List<Student> CreateListOfStudents(uint startI, uint count)
        {
            var students = new List<Student>();
            for (uint i = 0; i < count; i++)
            {
                students.Add(new Student($"Jack{ i + 1 }",startI + i + 1));
            }
            return students;
        }

        public static List<Course> CreateListOfCourses(uint count)
        {
            var courses = new List<Course>();
            for (uint i = 0; i < count; i++)
            {
                courses.Add(new Course($"JavaScrpt part{ i + 1 }"));
            }
            return courses;
        }
    }
}
