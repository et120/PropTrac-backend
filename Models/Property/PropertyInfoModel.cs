using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropTrac_backend.Models
{
    public class PropertyInfoModel
    {
        public int ID { get; set; } // Primary Key
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string HouseOrRoomType { get; set; }
        public int HouseRent { get; set; }
        public int Rooms { get; set; }
        public int Baths { get; set; }
        public int Sqft { get; set; }
        public string AmenFeatList { get; set; }
        public string Description { get; set; }
        public int Expenses { get; set; }
        public int Income { get; set; }

        // Navigation properties

        // TenantModel
        public ICollection<TenantModel> Tenant { get; set; } // Ensure this is correctly defined as a collection

        // RoomInfoModel
        public ICollection<RoomInfoModel>? RoomInfo { get; set; } // Ensure this is correctly defined as a collection

        // ManagerProperties
        public ManagerPropertiesModel? ManagerProperties { get; set; }

        // PropertyExpensesModel
        public PropertyExpenseModel? PropertyExpense { get; set; }

        // PropertyIncomeModel
        public PropertyIncomeModel? PropertyIncome { get; set; }

        // PropertyMaintenanceModel
        public ICollection<PropertyMaintenanceModel>? PropertyMaintenance { get; set; } // Ensure this is correctly defined as a collection

        public PropertyInfoModel()
        {

        }
    }
}