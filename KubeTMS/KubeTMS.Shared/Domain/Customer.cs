namespace KubeTMS.Shared.Domain
{
    public class Customer : EntityBase
    {
        public int ExternalId { get; set; }
        public string Name { get; set; }
        public string CustomerNumber { get; set; }
    }
}
