using NUnit.Framework;
using System;

namespace Schoolv2.UnitTest.StudentTests
{
    [TestFixture]
    [Author("Ivaylo Glindzhurski")]
    public class Student_Shouldnt
    {
        [Test]
        public void TryStudentCreated_With_EmptyStringForName_And_UniqueNumberWithinRange()
        {
            var studentName = "";
            uint studentId = 40000;

            Assert.Throws<Exception>( () => new Student(studentName, studentId));
        }

        [Test]
        public void TryStudentCreated_With_CorrectStringForName_And_UniqueNumberOutOfRange()
        {
            var studentName = "George";
            uint studentId = 3;

            Assert.Throws<Exception>( () => new Student(studentName, studentId));
        }
    }
}
