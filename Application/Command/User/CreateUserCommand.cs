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
    public class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        public CreateUserCommand(UserEntity user)
        {
            User = user;
        }

        public UserEntity User { get; set; }
    }
}