namespace KubeCustomer.Core.Dtos
{
    public class CustomerReadDto : EntityBaseDto
    {
        public string Name {get;set;}
        public string CustomerNumber { get; set; }
        public decimal? SpendingLimit { get; set; }
        public bool IsOnHold { get; set; }
    }
}