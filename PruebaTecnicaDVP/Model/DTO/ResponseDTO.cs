using System.ComponentModel;

namespace PruebaTecnicaDVP.Model.DTO
{
    public class ResponseDTO
    {
        [DefaultValue(false)]   
        public bool Status { get; set; }

        public required string Message { get; set; }

    }
}
