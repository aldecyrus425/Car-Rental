using MediatR;
using Microsoft.AspNetCore.Http;
using MyApp.Application.DTOs;
using MyApp.Application.Features.RentalDestination.Create;
using MyApp.Application.Features.RentalVehicle.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.RentalAgreement.Create
{
    public class CreateRentalAgreementCommand : IRequest<GenericResponse<string>>
    {
        public string RentalNumber { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime ExpectedReturnDateTime { get; set; }
        public string Status { get; set; }
        public string RentalType { get; set; }
        public string PickupLocation { get; set; }
        public string ReturnLocation { get; set; }
        public decimal StartingMileage { get; set; }
        public decimal StartingFuelLevel { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PenaltyAmount { get; set; }
        public decimal AdditionalCharges { get; set; }
        public decimal DepositAmount { get; set; }
        public Guid CreatedBy { get; set; }
        public CreateRentalDistinationCommand RentalDestination { get; set; }
        public List<RentalDocument> RentalDocuments { get; set; } = new();
        public CreateRentalVehicleCommand RentalVehicle { get; set; }

    }

    public class RentalDocument
    {
        public IFormFile Documents { get; set; }
        public string MimeType { get; set; }
        public string DocumentType { get; set; }
    }

}
