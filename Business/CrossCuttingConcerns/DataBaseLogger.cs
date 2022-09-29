using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CrossCuttingConcerns
{
    public class DataBaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged is succesfully to database");
        }
    }
}
