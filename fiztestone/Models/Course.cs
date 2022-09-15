namespace fiztestone.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        //public string? Description { get; set; }
        //public string? Status { get; set; }
        //public string? ExternalId { get; set; }
        //public string? Hash { get; set; }
        public string? Subject { get; set; }
        public int Grade { get; set; }
        public string? Genre { get; set; }
        public List<Module>? Modules { get; set; }
    }
}
