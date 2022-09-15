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
            UpdateCar(carManager);
            AllCars(carManager);
            CarDetails(carManager);

            ModeLManager modeLManager = new ModeLManager(new EFModelDal());

            AddModel(modeLManager);
            AllModels(modeLManager);
        }

        private static void UpdateCar(CarManager carManager)
        {
            carManager.Update(new Car
            {
                CarID = 1,
                BrandID = 6,
                ColorID =3,
                DailyPrice =200.9m,
                Description = "car is changed",
                ModelID = 1,
                ModelYear =1945
            });
        }

        private static void AddModel(ModeLManager modeLManager)
        {
            modeLManager.Add(new Model
            {
                BrandID = 4,
                ModelName = "E350"
            });
        }

        private static void AllModels(ModeLManager modeLManager)
        {
            var result = modeLManager.GetAll();
            foreach (var item in result)
            {
                Console.WriteLine(item.ModelID+ " "+ item.ModelName);
            }
        }

        private static void AllCars(CarManager carManager)
        {
            var result = carManager.GetAll();
            foreach (var item in result)
            {
                Console.WriteLine(item.CarID+" "+item.DailyPrice+" "+item.ModelYear+" "+item.Description);
            }
        }

        private static void CarDetails(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            foreach (var item in result)
            {
                Console.WriteLine(item.BrandName+" "+item.ModelName+" "+item.Description);
            }
        }
    }
}
