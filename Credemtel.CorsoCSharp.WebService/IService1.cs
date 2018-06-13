using System.ServiceModel;
using System.Threading.Tasks;

namespace Credemtel.CorsoCSharp.WebService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Task<string> GetData(int value);
    }
}