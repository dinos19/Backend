using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Query.Response
{
    public class GetUserResponse
    {
        public string Payload { get; set; }
        public List<string> Errors { get; set; }
        public bool Failed { get; set; }

        public GetUserResponse(bool failed, List<string> errors, string payload)
        {
            Failed = failed;
            Errors = errors;
            Payload = payload;
        }
    }
}