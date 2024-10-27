using radlab5._1.Models;  // Ensure this import is added to use the Title enum

namespace radlab5._1.Models
{
    public class FluentUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Title Title { get; set; } = Title.Mr;  // Default to Title.Mr
        public string Biography { get; set; } = string.Empty;
        public int Age { get; set; } = 0;  // Default to 0
    }

}