using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPC_Shared.ViewModels
{
	public class ResponseViewModel
	{
        public string Code { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}
