using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.UserRole.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserRoleCommand, GenericResponse<string>>
    {
        private readonly IUserRoleRepository _userRoleRepo;

        public CreateUserHandler(IUserRoleRepository userRoleRepo)
        {
            _userRoleRepo = userRoleRepo;
        }

        public async Task<GenericResponse<string>> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userRole = new UserRoles(request.Name, request.Description, request.IsActive);
                await _userRoleRepo.CreateUserRoleAsync(userRole);
                await _userRoleRepo.SaveChangesAsync();

                return new GenericResponse<string>
                {
                    message = "User role added successfully.",
                    isSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<string>
                {
                    message = ex.Message,
                    isSuccess = false
                };
            }
        }
    }
}
