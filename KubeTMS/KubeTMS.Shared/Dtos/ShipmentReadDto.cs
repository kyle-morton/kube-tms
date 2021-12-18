namespace KubeTMS.Shared.Dtos
{
    public class ShipmentReadDto
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int WeightInPounds { get; set; }
        public DateTime? PickupDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
        public int? CarrierId { get; set; }
        public string CarrierName { get; set; }
        public string CarrierScac { get; set; }
    }
}
