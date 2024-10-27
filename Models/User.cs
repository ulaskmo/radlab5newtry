namespace radlab5._1.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum Title
{
    Mr,
    Ms,
    Mrs,
    Dr
}

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Title Title { get; set; } = Title.Mr;  // Default to Title.Mr
    public string Biography { get; set; } = string.Empty;
    public int Age { get; set; } = 0;  // Default to 0
}

