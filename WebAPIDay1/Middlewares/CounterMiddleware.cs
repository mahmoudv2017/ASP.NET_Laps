using System.Diagnostics;

namespace WebAPIDay1.Middlewares
{
    public class CounterMiddleware
    {
        public static int counter = 0;

        private ILogger<CounterMiddleware> _logger;
        public  CounterMiddleware(ILogger<CounterMiddleware> logger)
        {
            _logger = logger;
        }

        public static Func<HttpContext , RequestDelegate , Task> Countme = async ( context, next) => {

            Debug.WriteLine(++counter);
            await next(context); 
        };

        //public static Func<in RequestDelegate,out RequestDelegate> CountME = async (in HttpContext context, out RequestDelegate next ) => { 

        //    await next(context); 
        //}

    }
}
