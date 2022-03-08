using Microsoft.AspNetCore.Http;

namespace GBCSporting2021_ACH.Models
{
    public class Session
    {
        private const string TechKey = "techID";
        private const string CustKey = "custID";

        private ISession session;

        public Session(ISession sess) => session = sess;

        public int GetTechnicianID() => session.GetInt32(TechKey) ?? 0;

        public void SetTechnicianID(int technicianID) => session.SetInt32(TechKey, technicianID);

        public int GetCustomerID() => session.GetInt32(CustKey) ?? 0;

        public void SetCustomerID(int customerID) => session.SetInt32(CustKey, customerID);
    }
}
