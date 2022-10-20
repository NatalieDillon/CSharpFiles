using System;
using CSharpFiles.Classes;

namespace CSharpFiles
{
    internal class Program
    {
        public static void Main()
        {
            TextFileExample();
            BinaryFileExample();
        }

        public static void TextFileExample()
        {
            string fileName = @"Files\DiaryEvents.csv";

            if (File.Exists(fileName))
            {
                // Read Diary events
                var diaryEvents = Diary.ReadDiaryEvents(fileName);
                Console.WriteLine($"There are {diaryEvents.Count} events");
                for (int i = 0; i < diaryEvents.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {diaryEvents[i]}");
                }

                // Write Diary events
                var newEvents = new List<Diary.DiaryRecord> {
                    new Diary.DiaryRecord(new DateOnly(2022, 11, 11), new TimeOnly(10, 00), "Richmond Park", "Bike ride"),
                    new Diary.DiaryRecord(new DateOnly(2022, 12, 25), new TimeOnly(09, 00), "Home", "Christmas Day", 12 * 60) };
                Diary.WriteDiaryEvents(fileName, newEvents);
                
                Console.WriteLine();
            }
        }

        public static void BinaryFileExample()
        {
            string fileName = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Students.bin";
            Console.WriteLine(fileName);

            // Write to binary file
            var students = new List<Student.StudentRecord> {
                    new Student.StudentRecord("James", 15),
                    new Student.StudentRecord("Rosie", 21),
                    new Student.StudentRecord("Graham", 19) };

            Student.WriteToBinaryFile(fileName, students);

            //Read Byte string
            Console.WriteLine(Student.ReadBinaryFileBytes(fileName));

            //Read Student records
            var studentRecords = Student.ReadBinaryFile(fileName);
            Console.WriteLine($"There are {studentRecords.Count} students");
            for (int i = 0; i < studentRecords.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {studentRecords[i]}");
            }
        }
    }
}