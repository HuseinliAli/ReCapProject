using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace TestProjectOnConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EFCarDal());

            foreach (var item in carManager.GetByProductPrice(50,100))
            {
                Console.WriteLine(item.DailyPrice+" "+item.Description);
            }
        }
    }
}
