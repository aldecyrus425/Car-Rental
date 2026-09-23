using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Users.Reactivate
{
    public class ReactivateUserHandler : IRequestHandler<ReactivateUserCommand, GenericResponse<string>>
    {
        private readonly IUserRepository _userRepository;

        public ReactivateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GenericResponse<string>> Handle(ReactivateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(request.UserId);
                if(user == null)
                {
                    return new GenericResponse<string>
                    {
                        message = "User not found",
                        isSuccess = false
                    };
                }

                user.ReactivateUser();
                await _userRepository.SaveChangesAsync();

                return new GenericResponse<string>
                {
                    message = "User reactivated successfully.",
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
