using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFiles.Classes
{
    public class Student
    {
        public record StudentRecord(string name, int age);

        public static void WriteToBinaryFile(string fileName, List<StudentRecord> students)
        {
            using (BinaryWriter binWriter = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                foreach (var student in students)
                {
                    binWriter.Write(student.name);
                    binWriter.Write(student.age);
                }
            }
        }

        public static string ReadBinaryFileBytes(string fileName)
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(fileName)))
            {
                byte[] bytes = reader.ReadBytes((int)reader.BaseStream.Length);
                return string.Join(',', bytes);
            }
        }

        public static List<StudentRecord> ReadBinaryFile(string fileName)
        {
            var students = new List<StudentRecord>();
            using (BinaryReader reader = new BinaryReader(File.OpenRead(fileName)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    string name = reader.ReadString();
                    int age = reader.ReadInt32();
                    students.Add(new StudentRecord(name, age));
                }
            }
            return students;
        }
    }
}
