using System.ComponentModel.DataAnnotations;

namespace KubeCustomer.Core.Dtos
{
    public class CustomerCreateDto
    {
        [Required]
        public string Name {get;set;}
        [Required]
        public string CustomerNumber {get;set;}
        public decimal? SpendingLimit { get; set; }
        public bool IsOnHold { get; set; }
    }
}