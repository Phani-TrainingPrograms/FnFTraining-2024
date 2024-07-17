using DataAccessRecap.Data;
using DataAccessRecap.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessRecap.Services;

public interface IDataService
{
    void AddNewStudent(Student student);

    List<Student> GetAllStudents();

    void UpdateStudent(Student student);

    void DeleteStudent(int id);
}

public class StudentDataService : IDataService
{
    private readonly StudentDbContext _context;
    public StudentDataService(StudentDbContext context)
    {
        if(context == null) throw new ArgumentNullException("context cannot be null");
        _context = context;
    }

    public void AddNewStudent(Student student)
    {
        _context.Students.Add(student);//Adds to the DbSet
        _context.SaveChanges();//Updates to the database.
    }

    public void DeleteStudent(int id)
    {
        var selected = _context.Students.FirstOrDefault(s => s.StudentId == id);
        _context.Students.Remove(selected);
        _context.SaveChanges();
    }

    public List<Student> GetAllStudents() => _context.Students.ToList();

    public void UpdateStudent(Student student)
    {
        //find the matching student
        var rec = _context.Students.ToList().FirstOrDefault((s) => s.StudentId == student.StudentId);
        if (rec == null)
        {
            throw new Exception("Student not found to update");
        }
        //fill the updated data to the found student
        rec.StudentName = student.StudentName;
        rec.StudentEmail = student.StudentEmail;
        rec.ContactNo = student.ContactNo;
        //save changes
        _context.SaveChanges();
    }
}