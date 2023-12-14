using PruebaTecnicaDVP.Repository.IRepository;
using System.Text.RegularExpressions;

namespace PruebaTecnicaDVP.Repository
{
    public class UtilRepository : IUtil
    {
        public bool ValidateFormatEmail(string email)
        {
            string pattern = @"\b[\w-%+]+@[\w-%+]+\.[a-zA-Z]{2,}\b";
            return Regex.Match(email, pattern).Success;
        }

        public bool ValidateFormatPassword(string password)
        {
            string pattern = @"\b^[A-Z](?=.*[a-z])(?=.*\d+)(?=.*[#$%&\.*])\w{8,16}\b";
            return Regex.Match(password, pattern).Success;
        }
    }
}
