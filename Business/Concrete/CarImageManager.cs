using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelperService _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelperService fileHelper)
        {
            _carImageDal=carImageDal;
            _fileHelper=fileHelper;
        }

        public IResult Add(IFormFile formFile, CarImage image)
        {
            var result = BusinessRules.Run(CheckCarImageLimit(image.CarID));
            if(result!=null)
            {
                return result;
            }
            image.ImagePath = _fileHelper.Upload(formFile, @"wwwroot\\Uploads\\Images\\");
            if(image.ImagePath==null)
            {
                image.ImagePath += "default.jpg";
            }
            image.ImageDate = DateTime.Now;

            _carImageDal.Add(image);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage image)
        {
            _fileHelper.Delete(@"wwwroot\\Uploads\\Images\\"+image.ImagePath);
            _carImageDal.Delete(image);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            var result = BusinessRules.Run(CheckCarImageLimit(id));
            if(result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(id).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(C=>C.CarID == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.GetByID(c => c.CarImageID == imageId));
        }

        public IResult Update(IFormFile formfile, CarImage image)
        {
            var result = _carImageDal.GetByID(c => c.CarImageID == image.CarImageID);
            image.ImagePath = _fileHelper.Update(formfile, @"wwwroot\\Uploads\\Images\\" + result.ImagePath, @"wwwroot\\Uploads\\Images\\");
            image.ImageDate = DateTime.Now;
            _carImageDal.Update(image);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarID = carId, ImageDate =DateTime.Now, ImagePath = "default.png" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarID == carId).Count;
            if(result>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IResult CheckCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarID == carId).Count;
            if(result>5)
            {
                return new ErrorResult(Messages.CarImageLimitBound); 
            }
            return new SuccessResult();
        }

        IDataResult<List<CarImage>> ICarImageService.GetDefaultImage(int carId)
        {
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarID = carId, ImageDate = DateTime.Now, ImagePath =@"wwwroot\\Uploads\\Images\\" + "default.png" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }
    }
}
