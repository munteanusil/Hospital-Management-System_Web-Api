namespace Hospital_Management_System_Web_Api.Interface
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt{ get; set; }

        public DateTimeOffset UpdatedAt { get;set; }

        public bool IsDeleted { get; set; }

      
    }
}
