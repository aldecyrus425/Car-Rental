using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class DamageReports
    {
        public Guid DamageReportId { get; private set; }
        public Guid RentalId { get; private set; }
        public RentalAgreements Agreement { get; private set; }
        public Guid VehicleId { get; private set; }
        public Vehicles Vehicles { get; private set; }
        public string DamageType { get; private set; }
        public string Description { get; private set; }
        public decimal EstimatedCost { get; private set; }
        public decimal? FinalCost { get; private set; }
        public string Status { get; private set; }
        public Guid ReportedByUserId { get; private set; }
        public Users Users {  get; private set; }
        public DateTime CreatedAt { get; private set; }

        protected DamageReports() { }
    }
}
