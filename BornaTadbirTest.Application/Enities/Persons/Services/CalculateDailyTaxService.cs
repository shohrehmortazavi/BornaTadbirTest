using AutoMapper;
using BornaTadbirTest.Application.Entities.Vehicles.Dtos;
using BornaTadbirTest.Domain.Shared.Interfaces;

namespace BornaTadbirTest.Application.Entities.Vehicles.Services
{
    public class CalculateDailyTaxService : BaseService, ICalculateDailyTaxService
    {
        public CalculateDailyTaxService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public int GetDailyTollFee(VehicleRequestDto vehicle, DateTime date)

        {
            if (IsTollFreeDay(date.DayOfWeek) || IsTollFreeDate(date) || IsTollFreeVehicleType(vehicle.VehicleTypeId))
                return 0;

            return GetFee(TimeOnly.FromDateTime(date));
        }

        private int GetFee(TimeOnly time)
        {
            var fees = _unitOfWork.TollFeeReadRepository.GetAllAsynce().Result;

            if (!fees.Any()) throw new Exception("TollFee not found");

            var totalFee = 0;

            foreach (var fee in fees)
                if (time.CompareTo(fee.MinTime) >= 0 && time.CompareTo(fee.MaxTime) <= 0)
                    totalFee += fee.Fee;

            return totalFee;
        }

        private bool IsTollFreeDay(DayOfWeek day)
        {
            var tollFreeDays = _unitOfWork.TollFreeDayReadRepository.GetAllAsynce().Result;

            if (!tollFreeDays.Any()) throw new Exception("TollFreeDay not found");


            foreach (var freeDay in tollFreeDays)
                if (day.Equals(freeDay))
                    return true;

            return false;
        }

        private bool IsTollFreeDate(DateTime date)
        {
            var tollFreeDates = _unitOfWork.TollFreeDateReadRepository.GetAllAsynce().Result;

            if (!tollFreeDates.Any()) throw new Exception("TollFreeDates not found");

            var dateOnly = DateOnly.FromDateTime(date);

            foreach (var freeDate in tollFreeDates)
                if (dateOnly.Equals(freeDate))
                    return true;

            return false;
        }

        private bool IsTollFreeVehicleType(Guid vehicleTypeId)
        {
            var tollFreeVehicle = _unitOfWork.TollFreeVehicleTypeReadRepository.Find(x => x.Id == vehicleTypeId).Result;
            if (tollFreeVehicle.Any())
                return true;
            else
                return false;
        }
    }
}
