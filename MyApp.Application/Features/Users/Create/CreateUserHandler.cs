using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.DTOs.User;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Users.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, GenericResponse<CreateUserResponse>>
    {
        private readonly IUserRepository _userRepo;

        public CreateUserHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<GenericResponse<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var hashPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
                var user = new MyApp.Domain.Entities.Users(request.FirstName, request.MiddleName, request.LastName, request.Email, request.PhoneNumber, hashPassword, request.UserRoleId, request.IsActive);

                await _userRepo.CreateUserAsync(user);
                await _userRepo.SaveChangesAsync();

                //Fetch the user role here

                return new GenericResponse<CreateUserResponse>
                {
                    message = "User added succesfully.",
                    isSuccess = false,
                    Data = new CreateUserResponse
                    {
                        UserId = user.UserId,
                        FirstName = user.FirstName,
                        MiddleName = user.MiddleName,
                        LastName = user.LastName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        UserRoleName = user.UserRole.Name,
                        IsActive = user.IsActive
                    }
                };
            }
            catch(Exception ex)
            {
                return new GenericResponse<CreateUserResponse>
                {
                    message = ex.Message,
                    isSuccess = false
                };
            }
        }
    }
}
