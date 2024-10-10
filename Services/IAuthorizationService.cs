using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnica.Models;

namespace PruebaTecnica.Services
{
    public interface IAuthorizationService
    {
        AuthResults Auth(string user, string password, out Usuario usuario);
    }

    public enum AuthResults
    {
        Success,
        PasswordNotMatch,
        NotExists,
        Error
    }
}
