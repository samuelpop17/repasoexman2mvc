using RepaExamenPelis2.Data;
using RepaExamenPelis2.Models;

namespace RepaExamenPelis2.Repositories
{
    public class RepositoryUsuarios
    {
        private PeliculasContext context;
        public RepositoryUsuarios(PeliculasContext context)
        {
            this.context = context;
        }


        public async Task< Usuario> GetUserByEmailPassword(string email, string password)
        {
            return this.context.Usuarios.Where(x => x.Email == email && x.Password == password).AsEnumerable().FirstOrDefault();
        }

    }
}
