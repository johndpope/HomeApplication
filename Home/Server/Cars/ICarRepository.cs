using Home.Server.Common;
using System.Threading.Tasks;

namespace Home.Server.Cars
{
    public interface ICarRepository
    {
        Task<CollectionResult<Car>> GetAll();
        Task<DataResult<Car>> Get(int id);
        Task<OperationResult> Save(Car Car);
    }
}