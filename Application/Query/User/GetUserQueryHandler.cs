using Application.Command.User;
using Domain.Command.Response;
using Domain.Query.Response;
using Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Query.User
{
    internal class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserResponse>
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public GetUserQueryHandler(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            //check if username exists
            var user = _repositoryWrapper.User.FindByCondition(u => u.Username == request.User.Username || u.UserId == request.User.UserId || u.Email == request.User.Email).FirstOrDefault();

            //CreateUser
            if (user == null)
            {
                return Task.FromResult(new GetUserResponse(true, new List<string> { "User does not exist" }, $"User does not exist"));
            }

            var userStr = JsonSerializer.Serialize(user);
            return Task.FromResult(new GetUserResponse(false, new List<string> { "No problem" }, $"{userStr} Created"));
        }
    }
}