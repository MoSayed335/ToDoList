namespace ToDoList.Models
{
    public class Mission
    {
        public int Id { get; set; }
        public string TaskTitle { get; set; }
        public string? Description { get; set; }
        public string? FilePath { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime Deadline { get; set; }
        public string Status { get; set; } = "Pending";

       
        public int PersonId { get; set; }
        public Person? Person { get; set; }
    }

}
