using System.Runtime.Serialization;
using System.ServiceModel;

namespace RequiredServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string[] Weather5day(string zipcode);

        [OperationContract]
        string WordFilter(string str);

        [OperationContract]
        string[] ExchangeRates(string cryptoInUSD);

    }
}
