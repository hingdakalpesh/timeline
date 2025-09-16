using BlazorTimeline.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTimeline.Client.Services
{
    public class TimelineService
    {
        private List<Route> allRoutes;

        public TimelineService()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            var driver1 = new Driver { Id = 1, Name = "John Doe" };
            var driver2 = new Driver { Id = 2, Name = "Jane Smith" };
            var driver3 = new Driver { Id = 3, Name = "Peter Jones" };

            var vehicle1 = new Vehicle { Id = 1, Registration = "TRUCK1" };
            var vehicle2 = new Vehicle { Id = 2, Registration = "TRUCK2" };
            var vehicle3 = new Vehicle { Id = 3, Registration = "TRUCK3" };

            var contract1 = new Contract { Id = 1, Code = "next01", Name = "Retail" };
            var contract2 = new Contract { Id = 2, Code = "mana02", Name = "Logistics" };

            allRoutes = new List<Route>
            {
                new Route
                {
                    Id = 1,
                    Driver = driver1,
                    Vehicle = vehicle1,
                    Contract = contract1,
                    PlannedStartTime = DateTime.Today.AddHours(8),
                    ActualStartTime = DateTime.Today.AddHours(8).AddMinutes(10),
                    Deliveries = new List<Delivery>
                    {
                        new Delivery { Id = 1, DropNumber = 1, PlannedTime = DateTime.Today.AddHours(9), ActualTime = DateTime.Today.AddHours(9).AddMinutes(10), StoreName = "Store A" },
                        new Delivery { Id = 2, DropNumber = 2, PlannedTime = DateTime.Today.AddHours(10), ActualTime = DateTime.Today.AddHours(10).AddMinutes(45), StoreName = "Store B" },
                        new Delivery { Id = 3, DropNumber = 3, PlannedTime = DateTime.Today.AddHours(11), ActualTime = null, StoreName = "Store C" }
                    }
                },
                new Route
                {
                    Id = 2,
                    Driver = driver2,
                    Vehicle = vehicle2,
                    Contract = contract2,
                    PlannedStartTime = DateTime.Today.AddHours(9),
                    ActualStartTime = DateTime.Today.AddHours(8).AddMinutes(45),
                    Deliveries = new List<Delivery>
                    {
                        new Delivery { Id = 4, DropNumber = 1, PlannedTime = DateTime.Today.AddHours(10), ActualTime = DateTime.Today.AddHours(9).AddMinutes(50), StoreName = "Store D" },
                        new Delivery { Id = 5, DropNumber = 2, PlannedTime = DateTime.Today.AddHours(11), ActualTime = DateTime.Today.AddHours(11).AddMinutes(5), StoreName = "Store E" },
                    }
                },
                new Route
                {
                    Id = 3,
                    Driver = driver3,
                    Vehicle = vehicle3,
                    Contract = contract1,
                    PlannedStartTime = DateTime.Today.AddHours(10),
                    ActualStartTime = DateTime.Today.AddHours(10).AddMinutes(35),
                    Deliveries = new List<Delivery>
                    {
                        new Delivery { Id = 6, DropNumber = 1, PlannedTime = DateTime.Today.AddHours(11), ActualTime = DateTime.Today.AddHours(11).AddMinutes(40), StoreName = "Store F" }
                    }
                }
            };
        }

        public Task<List<Route>> GetRoutesAsync(DateTime selectedDate, int? contractId, int? driverId, int? vehicleId)
        {
            var filteredRoutes = allRoutes.Where(r => r.PlannedStartTime.Date == selectedDate.Date);

            if (contractId.HasValue)
            {
                filteredRoutes = filteredRoutes.Where(r => r.Contract.Id == contractId.Value);
            }

            if (driverId.HasValue)
            {
                filteredRoutes = filteredRoutes.Where(r => r.Driver.Id == driverId.Value);
            }

            if (vehicleId.HasValue)
            {
                filteredRoutes = filteredRoutes.Where(r => r.Vehicle.Id == vehicleId.Value);
            }

            return Task.FromResult(filteredRoutes.ToList());
        }

        public Task<List<Contract>> GetContractsAsync()
        {
            var contracts = allRoutes.Select(r => r.Contract).Distinct().ToList();
            return Task.FromResult(contracts);
        }

        public Task<List<Driver>> GetDriversAsync()
        {
            var drivers = allRoutes.Select(r => r.Driver).Distinct().ToList();
            return Task.FromResult(drivers);
        }

        public Task<List<Vehicle>> GetVehiclesAsync()
        {
            var vehicles = allRoutes.Select(r => r.Vehicle).Distinct().ToList();
            return Task.FromResult(vehicles);
        }
    }
}
