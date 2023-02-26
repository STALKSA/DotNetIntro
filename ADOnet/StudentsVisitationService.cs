using System.Data;
using Microsoft.Data.Sqlite;

namespace ADOnet;

internal class StudentsVisitationService
{
    public void CreateTableVisitations()
    {
        var connectionString = "Data Source=myapp.db";
        using var connection = new SqliteConnection(connectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = $"CREATE TABLE Visitations (" +
                              "Id     INT NOT NULL PRIMARY KEY," +
                              "Name   TEXT NOT NULL," +
                              "Date   DATE NOT NULL" +
                              ")";
        command.ExecuteNonQuery();
    }

    public Visitation[] GetVisitations()
    {
        var connectionString = "Data Source=myapp.db";
        var sql = "select * from Visitations";
        using var connection = new SqliteConnection(connectionString);
        connection.Open();
        using var command = new SqliteCommand(sql, connection);
        using var reader = command.ExecuteReader();
        var result = new List<Visitation>();
        foreach (IDataRecord item in reader)
        {
            var visit = new Visitation
            (
                item.GetInt32(reader.GetOrdinal("Id")),
                item.GetString(reader.GetOrdinal("Name")),
                DateOnly.FromDateTime(DateTime.Parse(reader.GetString(reader.GetOrdinal("Date"))))
            );
            result.Add(visit);
        }

        return result.ToArray();
    }


    public void AddVisit(int id, string name, DateOnly date)
    {
        var connectionString = "Data Source=myapp.db";
        using var connection = new SqliteConnection(connectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = $"INSERT INTO Visitations (Id, Name, Date) " +
                              $"VALUES ({id}, '{name}', '{date}')";
        command.ExecuteNonQuery();
    }

    public void CreateTableStudents()
    {
        var connectionString = "Data Source=myapp.db";
        using var connection = new SqliteConnection(connectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = $"CREATE TABLE Students (" +
                              "Id     INT NOT NULL PRIMARY KEY," +
                              "Name   TEXT NOT NULL," +
                              "Date   DATE NOT NULL" +
                              ")";
        command.ExecuteNonQuery();
    }

    public Student[] GetStudents()
    {
        var connectionString = "Data Source=myapp.db";
        var sql = "select * from Students";
        using var connection = new SqliteConnection(connectionString);
        connection.Open();
        using var command = new SqliteCommand(sql, connection);
        using var reader = command.ExecuteReader();
        var result = new List<Student>();
        foreach (IDataRecord item in reader)
        {
            var student = new Student
            (
                item.GetInt32(reader.GetOrdinal("Id")),
                item.GetString(reader.GetOrdinal("Name")),
                DateOnly.FromDateTime(DateTime.Parse(reader.GetString(reader.GetOrdinal("Date"))))
            );
            result.Add(student);
        }

        return result.ToArray();
    }

    public void AddStudent(int id, string name, DateOnly date)
    {
        var connectionString = "Data Source=myapp.db";
        using var connection = new SqliteConnection(connectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = $"INSERT INTO Students (Id, Name, Date) " +
                              $"VALUES ({id}, '{name}', '{date}')";
        command.ExecuteNonQuery();
    }
}

