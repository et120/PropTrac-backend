using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropTrac_backend.Models.DTO;
using PropTrac_backend.Models.DTO.ManagerDashboard;
using PropTrac_backend.Services.Context;

namespace PropTrac_backend.Services
{
    public class ManagerService
    {
        private readonly DataContext _context;
        public ManagerService(DataContext context)
        {
            _context = context;
        }

        public PropertyStatsDTO GetPropertyStats(int userId)
        {
            // Get the manager corresponding to the user ID
            var manager = _context.Managers.SingleOrDefault(m => m.UserID == userId);

            // If manager is not found, return counts as 0
            if (manager == null)
            {
                return null;
            }

            // Get the property IDs managed by the manager
            var propertyIds = _context.ManagerProperties
                .Where(mp => mp.ManagerID == manager.ID)
                .Select(mp => mp.PropertyInfoID)
                .ToList();

            // Get the count of tenants associated with the properties managed by the manager
            var activeTenantsCount = _context.Tenants
                .Where(t => propertyIds.Contains(t.PropertyInfoID))
                .Count();

            // Get the count of open listings with the properties managed by the manager
            var openListingsCount = 0;
            foreach (var propertyId in propertyIds)
            {
                var property = _context.PropertyInfo.Find(propertyId);
                if (property != null)
                {
                    // If the property type is "house," check if any tenants are assigned
                    if (property.HouseOrRoomType.ToLower() == "house")
                    {
                        if (!_context.Tenants.Any(t => t.PropertyInfoID == propertyId))
                        {
                            openListingsCount++;
                        }
                    }
                    // If the property type is "rooms," check if any of the associated rooms are unoccupied
                    else if (property.HouseOrRoomType.ToLower() == "rooms")
                    {
                        var roomIds = _context.RoomInfo
                            .Where(r => r.PropertyInfoID == propertyId)
                            .Select(r => r.ID)
                            .ToList();

                        if (!_context.Tenants.Any(t => t.RoomInfoID.HasValue && roomIds.Contains(t.RoomInfoID.Value)))
                        {
                            openListingsCount++;
                        }
                    }
                }
            }

            // Get the count of properties managed by the manager
            var propertiesCount = propertyIds.Count;

            // Return the property statistics
            return new PropertyStatsDTO
            {
                ActiveTenants = activeTenantsCount,
                OpenListings = openListingsCount,
                Properties = propertiesCount
            };
        }

        public MaintenanceStatsDTO GetMaintenanceStats(int userId)
        {
            return null;
        }

    }
}