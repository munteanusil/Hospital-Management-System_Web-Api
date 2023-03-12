namespace Hospital_Management_System_Web_Api.Interface
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset EnteredAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
