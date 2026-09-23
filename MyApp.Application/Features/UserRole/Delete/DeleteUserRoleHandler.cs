using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.UserRole.Delete
{
    public class DeleteUserRoleHandler : IRequestHandler<DeleteUserRoleCommand, GenericResponse<string>>
    {
        private readonly IUserRoleRepository _userRoleRepo;

        public DeleteUserRoleHandler(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepo = userRoleRepository;
        }

        public async Task<GenericResponse<string>> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userRole = await _userRoleRepo.GetActiveUserRoleByIdAsync(request.UserRoleId);

                if(userRole == null)
                {
                    return new GenericResponse<string>
                    {
                        message = "User role not found or inactive.",
                        isSuccess = false
                    };
                }

                userRole.DeleteUserRole();
                await _userRoleRepo.SaveChangesAsync();

                return new GenericResponse<string>
                {
                    message = "User role deleted successfully.",
                    isSuccess = true
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
