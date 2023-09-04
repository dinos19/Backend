using Domain.Entity;
using Domain.Query.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Query.User
{
    public class GetUserQuery : IRequest<GetUserResponse>
    {
        public GetUserQuery(UserEntity user)
        {
            User = user;
        }

        public UserEntity User { get; set; }
    }
}