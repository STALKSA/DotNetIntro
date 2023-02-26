using System.Runtime.InteropServices.JavaScript;

namespace ADOnet;

internal class Visitation
{
    public Visitation(int id, string name, DateOnly date)
    {
        Id = id;
        Name = name;
        Date = date;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly Date { get; set; }

    public override string ToString()
    {
        return $"{Id.ToString()} {Name} {Date.ToString()}";
    }
}