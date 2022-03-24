namespace TheBillboard.API.Domain;

public record Author
{ 
public Author(
    string name = "",
    string surname = "",
    int? id = default,
    string? email = "",
    DateTime? createdAt = default,
    DateTime? updatedAt = default
)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Email = email;
        CreatedAt = createdAt;
    }
    //System.Int32 Id, System.String Name, System.String Surname, System.String Mail, System.DateTime CreatedAt

    public Author(int id, string name,string surname,string mail,DateTime createdAt)
    {
        Id = id;
        Name = name;
        Surname= surname;
        Email = mail;
        CreatedAt = createdAt;
    }
    public int? Id { get; init; }
    public string Name { get; init; }
    public string Surname { get; init; }
    public string? Email { get; init; }
    public DateTime? CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
    

    public override string ToString()
    {
        return Name + " " + Surname;
    }
}
