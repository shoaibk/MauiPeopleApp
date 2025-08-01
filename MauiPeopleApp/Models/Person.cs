namespace MauiPeopleApp.Models;

public class Person
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public string Avatar { get; set; }

    public string FullName => $"{First_Name} {Last_Name}";
}