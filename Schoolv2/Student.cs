namespace Schoolv2
{
    public class Student : IEquatable<Student?>
    {
        private string _name;
        private uint _uniqueNumber;

        public Student(string name, uint uniqueId)
        {
            Name = name;
            UniqueNumber = uniqueId;
        }

        public uint UniqueNumber
        {
            get
            {
                return _uniqueNumber;
            }
            private set
            {
                if (value > 10000 && value < 99999)
                {
                    _uniqueNumber = value;
                }
                else
                {
                    throw new Exception("ID must be between 10000 and 99999");
                }
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (!value.Equals(""))
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("Name should not be null");
                }
            }
        }

        //Override
        public override string ToString()
        {
            return $"The student is {_name}, {_uniqueNumber} ID";
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Student);
        }

        public bool Equals(Student? other)
        {
            return other != null &&
                   _uniqueNumber == other._uniqueNumber;
        }
    }
}
