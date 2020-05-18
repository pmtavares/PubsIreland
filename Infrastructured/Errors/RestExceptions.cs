using System;
using System.Net;


namespace Infrastructured.Errors
{
    public class RestExceptions : Exception
    {
        public HttpStatusCode Code { get; set; }

        public object Erros { get; set; }


        public RestExceptions(HttpStatusCode code, object erros = null)
        {
            Code = code;
            Erros = erros;
        }
    }
}
