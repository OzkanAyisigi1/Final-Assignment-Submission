using System;
using CodeFirstDemo.Data;
using CodeFirstDemo.Models;

namespace CodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Code First Örneği - Öğrenci Veritabanı");
            
            using (var context = new SchoolContext())
            {
                try
                {
                    // Veritabanını sil ve yeniden oluştur
                    context.Database.EnsureDeleted();
                    Console.WriteLine("Veritabanı silindi.");
                    
                    context.Database.EnsureCreated();
                    Console.WriteLine("Veritabanı yeniden oluşturuldu.");
                    
                    // Yeni bir Grade ekle
                    var grade = new Grade
                    {
                        GradeName = "Grade 1",
                        Section = "Section A"
                    };
                    context.Grades.Add(grade);
                    
                    // Yeni bir öğrenci ekle
                    var student = new Student
                    {
                        Name = "John Smith",
                        DateOfBirth = new DateTime(2000, 10, 15),
                        Height = 170.5m,
                        Weight = 65.5f,
                        Grade = grade
                    };
                    context.Students.Add(student);
                    
                    // Değişiklikleri kaydet
                    context.SaveChanges();
                    
                    // Kaydedilen öğrenci bilgisini görüntüle
                    Console.WriteLine($"Öğrenci eklendi: {student.StudentID} - {student.Name}");
                    Console.WriteLine("Veritabanı oluşturuldu ve bir öğrenci kaydı eklendi!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata oluştu: {ex.Message}");
                }
            }
        }
    }
}
