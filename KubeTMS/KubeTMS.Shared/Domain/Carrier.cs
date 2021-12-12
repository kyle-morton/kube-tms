namespace KubeTMS.Shared.Domain
{
    public class Carrier : EntityBase
    {
        public int ExternalId { get; set; }
        public string Name { get; set; }
        public string Scac { get; set; }
    }
}
