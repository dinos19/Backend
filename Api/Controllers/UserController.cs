using Application.Command.User;
using Domain.Command.Response;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediatr;

        public UserController(ILogger<UserController> logger, IMediator mediatr)
        {
            _logger = logger;
            _mediatr = mediatr;
        }

        [HttpPost(Name = "CreateUser")]
        public Task<CreateUserCommandResponse> CreateUser([FromBody] UserEntity userEntity)
        {
            var command = new CreateUserCommand(userEntity);
            var commandResult = _mediatr.Send(command);
            return commandResult;
        }
    }
}