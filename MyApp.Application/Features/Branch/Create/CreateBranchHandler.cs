using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Branch.Create
{
    public class CreateBranchHandler : IRequestHandler<CreateBranchCommand, GenericResponse<string>>
    {
        private readonly IBranchRepository _branchRepo;

        public CreateBranchHandler(IBranchRepository branchRepo)
        {
            _branchRepo = branchRepo;
        }

        public async Task<GenericResponse<string>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var branch = new Branches(request.Name, request.Address, request.City, request.Province, request.ContactNumber, request.IsActive);
                await _branchRepo.CreateBranchAsync(branch);
                await _branchRepo.SaveChangesAsync();

                return new GenericResponse<string>
                {
                    message = "Branch created successfully.",
                    isSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<string>
                {
                    message = $"An error occurred while creating the branch: {ex.Message}",
                    isSuccess = false,
                    Data = null
                };
            }
        }
    }
}
