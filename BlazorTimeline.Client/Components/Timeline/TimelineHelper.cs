using System;
using BlazorTimeline.Client.Models;

namespace BlazorTimeline.Client.Components.Timeline
{
    public static class TimelineHelper
    {
        public static double CalculateLeftPosition(DateTime time, DateTime startOfDay)
        {
            var totalMinutesInDay = 24 * 60;
            var minutesFromStart = (time - startOfDay).TotalMinutes;
            return (minutesFromStart / totalMinutesInDay) * 100;
        }

        public static string GetStatusColorClass(DateTime planned, DateTime? actual, bool isDriverTile = false)
        {
            if (!actual.HasValue)
            {
                return "status-upcoming";
            }

            var diff = actual.Value - planned;

            if (isDriverTile)
            {
                if (diff.TotalMinutes > 30 || diff.TotalMinutes < -30) return "status-red";
                if (diff.TotalMinutes >= 0 && diff.TotalMinutes <= 15) return "status-blue";
                if (diff.TotalMinutes > 15 && diff.TotalMinutes <= 30) return "status-green";
                if (diff.TotalMinutes < 0 && diff.TotalMinutes >= -30) return "status-green";
            }
            else // Delivery Tile
            {
                if (diff.TotalMinutes < 0 || diff.TotalMinutes > 30) return "status-red";
                if (diff.TotalMinutes >= 0 && diff.TotalMinutes <= 15) return "status-blue";
                if (diff.TotalMinutes > 15 && diff.TotalMinutes <= 30) return "status-green";
            }

            return "status-ontime"; // Default
        }

        public static string GetDeliveryStatusColorClass(Delivery delivery, Delivery previousDelivery)
        {
            if (delivery.ActualTime.HasValue)
            {
                return GetStatusColorClass(delivery.PlannedTime, delivery.ActualTime);
            }

            // Predicted late logic
            if (previousDelivery?.ActualTime != null && previousDelivery.ActualTime > previousDelivery.PlannedTime)
            {
                return "status-amber"; // Predicted late
            }

            return "status-upcoming";
        }
    }
}
