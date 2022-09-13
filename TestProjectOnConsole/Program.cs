using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace TestProjectOnConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EFCarDal());

           
            EFCarDal eFCarDal = new EFCarDal();
            eFCarDal.Add(new Car { DailyPrice=366.0m ,ModelName="GMC", c}) ;

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.DailyPrice+" "+item.Description);
            }
        }
    }
}
