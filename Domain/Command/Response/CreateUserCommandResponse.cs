using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command.Response
{
    public class CreateUserCommandResponse
    {
        public string Payload { get; set; }
        public List<string> Errors { get; set; }
        public bool Failed { get; set; }

        public CreateUserCommandResponse(bool failed, List<string> errors, string payload)
        {
            Failed = failed;
            Errors = errors;
            Payload = payload;
        }
    }
}