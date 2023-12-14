namespace PruebaTecnicaDVP.Repository.IRepository
{
    public interface  IUtil
    {
        public bool ValidateFormatEmail(string email);

        public bool  ValidateFormatPassword(string password);
    }
}
