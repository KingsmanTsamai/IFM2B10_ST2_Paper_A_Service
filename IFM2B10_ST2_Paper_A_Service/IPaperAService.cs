using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IFM2B10_ST2_Paper_A_Service
{
    [ServiceContract]
    public interface IPaperAService
    {
        [OperationContract]
        List<Item> getOEI();
        [OperationContract]
        List<itemMenu> getmealType();
        [OperationContract]
        itemMenu getSingleProduct(int ID);

        [OperationContract]
        bool addBooking(string name, string email, int persons, string phone, DateTime mydate, string time, string note);

        [OperationContract]
        bool checkIfExist(string email);

        [OperationContract]
        Reservation getEmail(int ID);

        [OperationContract]
        bool editReservation(string name, string email, int persons, string phone, DateTime mydate, string time, string note);

    }
}
