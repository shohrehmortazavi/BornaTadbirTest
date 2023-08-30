using BornaTadbirTest.Application.Entities.Vehicles.Dtos;

namespace BornaTadbirTest.Application.Entities.Vehicles.Services
{
    public interface ICalculateDailyTaxService
    {
        int GetDailyTollFee(VehicleRequestDto vehicle, DateTime date);
    }
}
