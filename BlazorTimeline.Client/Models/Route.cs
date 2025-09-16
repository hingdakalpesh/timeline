using System.Collections.Generic;

namespace BlazorTimeline.Client.Models
{
    public class Route
    {
        public int Id { get; set; }
        public Driver Driver { get; set; }
        public Vehicle Vehicle { get; set; }
        public Contract Contract { get; set; }
        public List<Delivery> Deliveries { get; set; }
        public DateTime PlannedStartTime { get; set; }
        public DateTime? ActualStartTime { get; set; }
    }
}
