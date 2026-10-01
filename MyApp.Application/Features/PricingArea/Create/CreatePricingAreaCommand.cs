using MediatR;
using MyApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.PricingArea.Create
{
    public class CreatePricingAreaCommand : IRequest<GenericResponse<string>>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string AreaType { get; set; }
        public bool IsActive { get; set; }
    
    }
}
