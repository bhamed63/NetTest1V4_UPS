namespace NetTest1V4_UPS.Models
{
    public class Employee : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
    }
    public class Entity
    {
        public int Id { get; set; }
    }
}
