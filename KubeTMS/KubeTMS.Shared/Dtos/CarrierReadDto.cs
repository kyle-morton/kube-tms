namespace KubeTMS.Shared.Dtos
{
    public class CarrierReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Scac { get; set; }
        public string SafetyRating { get; set; }
        public bool IsApproved { get; set; }
    }
}
