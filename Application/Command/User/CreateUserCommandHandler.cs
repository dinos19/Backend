using Domain.Aggregate;
using Domain.Command.Response;
using Domain.Entity;
using Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Command.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CreateUserCommandHandler(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //check if username exists
            var user = _repositoryWrapper.User.FindByCondition(u => u.Username == request.User.Username || u.Email == request.User.Email).FirstOrDefault();

            //CreateUser
            if (user != null)
            {
                return Task.FromResult(new CreateUserCommandResponse(true, new List<string> { "User exists" }, $"User exists"));
            }

            user = new Domain.Aggregate.User(request.User.Username, request.User.Password, request.User.Email, 0, request.User.UserType);
            _repositoryWrapper.User.Create(user);
            _repositoryWrapper.Save();
            var userStr = JsonSerializer.Serialize(user);
            return Task.FromResult(new CreateUserCommandResponse(false, new List<string> { "No problem" }, $"{userStr} Created"));
        }
    }
}