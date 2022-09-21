# ReCapProject
## 1
1.Create Blank Solution "ReCapProject"; <br/>
2.Create Entities, DataAccess, Business Layers in solution; <br/>
3.Create Car class and it contains : Id, BrandId, ColorId, ModelYear, DailyPrice, Description; <br/>
4.Write methods of GetById, GetAll, Add, Update, Delete in InMemory format; <br/>
## 2
1.Add new classes(Brand , Color) id,name; <br/>
2.Create SQL Server (Brands, Colors, Cars tables); <br/>
3.Write IEntityRepository architecture; <br/>
4.Write EntityFramework arch. for Car,Color,Brand; <br/>
5.Add GetCarByBrandId, GetCarByColorId Services; <br/>
## 3
1.Create Core layer in Project; <br/>
2.Add to project IEntity, IDto, IEntityRepository, EfEntityRepositoryBase files; <br/>
3.Write CRUD operations for Car, Brand, Color; <br/>
4.Test operations on Console; <br/>
5.Join to tables(Car, Brand, Model, Color); <br/>
6.Add Model entity (ModelID, BrandID, ModelName); <br/>

## 4
1.Create Utilities Folder in Core (Abstract(IDataResult, IResult), Concrete(Result,DataResult,ErrorResult,ErrorDataResult,SuccessResult,SuccessDataResult)) <br/>
2.Create a user dashboard. Users-->Id,FirstName,LastName,Email,Password <br/>
3.Create a customer dashboard. Customers-->UserId,CompanyName <br/>
4.Users and customers are related.Create a table that contains the car rental information. Rentals-->Id, CarId, CustomerId, RentDate(Rental Date), ReturnDate(Delivery Date). ReturnDate is null if the cart has not been delivered. <br/>
5.Create these entities in your project. <br/>
6.Write CRUD operations. <br/>
7.Code the car rental option. <br/>
8.Rental-->Add In order for the car to be rented, the car must be delivered. <br/>
