using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseServiceInMiddleware.Services
{
    public class TimerService
    {
        public string Time { get; }
        public TimerService()
        {
            Time = System.DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
