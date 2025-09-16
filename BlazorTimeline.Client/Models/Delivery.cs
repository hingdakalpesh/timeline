namespace BlazorTimeline.Client.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public int DropNumber { get; set; }
        public DateTime PlannedTime { get; set; }
        public DateTime? ActualTime { get; set; }
        public DeliveryStatus Status { get; set; }
        public string StoreName { get; set; }
        public double StoreLatitude { get; set; }
        public double StoreLongitude { get; set; }
    }
}
