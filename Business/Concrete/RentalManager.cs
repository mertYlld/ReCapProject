﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }


        //[SecuredOperation("Rental.List")]
        
        public IResult AddRental(Rental rental)
        {
            var result = BusinessRules.Run(IsCarEverRented(rental.CarId), IsCarReturned(rental.CarId), IsCarAvaible(rental.CarId));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);

        }

        public IResult DeleteRental(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        //[ValidationAspect(typeof(RentalValidator))]
        //[SecuredOperation("Rental.List")]
        //[SecuredOperation("Admin")]
        public IDataResult<List<Rental>> GetAllRentals()
        {
            var result = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(result);
        }

        public IDataResult<Rental> GetByRentalId(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == Id));
        }

        public IResult UpdateRental(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult IsCarEverRented(int carId)
        {
            var result = _rentalDal.GetAll(c => c.CarId == carId && c.RentDate != null).Count;

            if (result > 0)
            {
                return new ErrorResult(Messages.CarRented);
            }

            return new SuccessResult();
        }

        public IResult IsCarReturned(int carId)
        {
            var result = _rentalDal.GetAll(c => c.CarId == carId && c.ReturnDate == null).Count;

            if (result > 0)
            {
                return new ErrorResult("Araç henüz geri dönmedi");
            }

            return new SuccessResult();
        }

        public IResult IsCarAvaible(int Id)
        {
            if (IsCarEverRented(Id).Success)
            {
                if (IsCarReturned(Id).Success)
                {
                    return new SuccessResult();
                }
            }
            return new ErrorResult();
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            var result = _rentalDal.GetRentalDetails();
            return new SuccessDataResult<List<RentalDetailDto>>(result);
        }
    }
}
