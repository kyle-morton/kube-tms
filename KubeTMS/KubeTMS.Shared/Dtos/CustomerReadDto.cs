namespace KubeTMS.Shared.Dtos
{
    public class CustomerReadDto
    {
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public string Name { get; set; }
        public string CustomerNumber { get; set; }
        public decimal? SpendingLimit { get; set; }
        public bool IsOnHold { get; set; }
    }
}
