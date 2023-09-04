using Domain.Command.Response;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.User
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        public Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //CreateUser

            //return user
            return Task.FromResult(new CreateUserCommandResponse(false, new List<string> { "No problem" }, "User Created"));
        }
    }
}