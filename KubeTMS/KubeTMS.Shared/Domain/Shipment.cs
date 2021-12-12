﻿namespace KubeTMS.Shared.Domain
{
    public class Shipment : EntityBase
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int WeightInPounds { get; set; }
        public DateTime? PickupDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? CarrierId { get; set; }
        public Carrier Carrier { get; set; }
    }
}
