using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace TestProjectOnConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal()); 

            foreach(var item in carManager.GetAll())
            {
                Console.WriteLine(item.CarID+" "+item.ModelYear);
            }
        }
    }
}
