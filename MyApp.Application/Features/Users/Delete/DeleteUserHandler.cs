using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Users.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, GenericResponse<string>>
    {
        private readonly IUserRepository _userRepo;

        public DeleteUserHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<GenericResponse<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepo.GetUserByIdAsync(request.UserId);

                if (user == null)
                {
                    return new GenericResponse<string>
                    {
                        message = "User not found",
                        isSuccess = false
                    };
                }

                user.DeleteUser();
                await _userRepo.SaveChangesAsync();

                return new GenericResponse<string>
                {
                    message = "User deleted successfully.",
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
