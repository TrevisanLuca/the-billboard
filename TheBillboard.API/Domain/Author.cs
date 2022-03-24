namespace TheBillboard.API.Domain;

public record Author
(
    string Name = "",
    string Surname = "",
    int? Id = default,
    string? Email = "",
    DateTime? CreatedAt = null,
    DateTime? UpdatedAt = null
)
{
    public Author(int id, string name, string surname, string? mail, DateTime? createdAt) : this(name, surname, id, mail, createdAt)
    {
    }

    public override string ToString()
    {
        return Name + " " + Surname;
    }
}
//public record Author
//{ 
//public Author(
//    string name = "",
//    string surname = "",
//    int? id = default,
//    string? email = "",
//    DateTime? createdAt = default,
//    DateTime? updatedAt = default
//)
//    {
//        Id = id;
//        Name = name;
//        Surname = surname;
//        Email = email;
//        CreatedAt = createdAt;
//    }
//System.Int32 Id, System.String Name, System.String Surname, System.String Mail, System.DateTime CreatedAt


//{
//    Id = id;
//    Name = name;
//    Surname= surname;
//    Email = mail;
//    CreatedAt = createdAt;
//}
//public int? Id { get; init; }
//public string Name { get; init; }
//public string Surname { get; init; }
//public string? Email { get; init; }
//public DateTime? CreatedAt { get; init; }
//public DateTime? UpdatedAt { get; init; }


//public record Author(
//    int? Id=default, 
//    string Name="",
//    string Surname="",
//    string? Mail="",
//    DateTime? CreatedAt=default
//    )
//{ 
//    public override string ToString() => Name + " " + Surname;
//}
