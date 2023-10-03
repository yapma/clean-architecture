using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class RestApiRequestResponse: BaseEntity<int>
    {
        public string UserId { get; set; }
        public string UrlPath { get; set; }
        public string RequestHeader { get; set; }
        public string RequestBody { get; set; }
        public string ResponseHeader { get; set; }
        public string ResponseBody { get; set; }
    }
}
