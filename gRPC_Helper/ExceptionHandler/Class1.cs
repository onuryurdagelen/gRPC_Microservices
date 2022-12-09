using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace gRPC_Helper.ExceptionHandler
{
	public class CustomException : Exception
	{
		public HttpStatusCode StatusCode { get; set; }
		public string Message { get; set; }
		public CustomException(HttpStatusCode code, string message)
		{
			StatusCode = code;
			Message = message;
		}
	}
}
