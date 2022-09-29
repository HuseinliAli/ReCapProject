using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile formFile,CarImage image);
        
        IResult Update(IFormFile formfile,CarImage image);
        
        IResult Delete(CarImage image);
        
        IDataResult<List<CarImage>> GetAll();
        
        IDataResult<List<CarImage>> GetByCarId(int id);
        
        IDataResult<CarImage> GetByImageId(int imageId);
    }
}
