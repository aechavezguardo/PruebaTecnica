using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PruebaTecnica.Context;
using PruebaTecnica.Models;
using PruebaTecnica.Secutiry;
using PruebaTecnica.Utils;

namespace PruebaTecnica.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly PruebaTecnicaContext db = new PruebaTecnicaContext();
        private readonly IPasswordEncripter _passordEncripter = new PasswordEncripter();

        public AuthResults Auth(string user, string password, out Usuario usuario)
        {
            usuario = db.Usuarios.Where(x => x.UsuarioNombre.Equals(user)).FirstOrDefault();

            if (usuario == null)
                return AuthResults.NotExists;

            password = _passordEncripter.Encript(password, new List<byte[]>()
                .AddHash(usuario.HashKey)
                .AddHash(usuario.HashIV)
                );
            if (password != usuario.Pass)
                return AuthResults.PasswordNotMatch;

            return AuthResults.Success;
        }
    }
}