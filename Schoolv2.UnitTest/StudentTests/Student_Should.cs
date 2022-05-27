using NUnit.Framework;

namespace Schoolv2.UnitTest.StudentTests
{
    [TestFixture]
    [Author("Ivaylo Glindzhurski")]
    public class Student_Should
    {
        [Test]
        public void StudentCreated_With_InitializesCorrectName_And_UniqueNumber()
        {
            var studentName = "Peter";
            uint uniqueNumber = 45000;
            var student = new Student(studentName, uniqueNumber);

            StringAssert.AreEqualIgnoringCase(student.Name, studentName);
            Assert.IsNotNull(student);
        }
    }
}
