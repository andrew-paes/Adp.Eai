namespace Adp.Eai.Domain.Models
{
    public abstract class GenericModel
    {
        protected GenericModel() { }

        protected GenericModel(DateTime? createdDate)
        {
            CreatedDate = createdDate;
        }

        public Guid Id { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}