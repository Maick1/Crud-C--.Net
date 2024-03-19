using CrudDefinitivo.Models;

namespace CrudDefinitivo.Interface
{
    public interface InterfaceUsuario
    {
        //Devuelve a todos los usuarios
        Task<IEnumerable<Usuario>> GetAllUsuarios();
        Task<Usuario> GetUsuarioById(int id);
        Task<bool> InsertUsuario(Usuario usuario);
        Task<bool> UpdateUsuario(Usuario usuario);
        Task<bool> DeleteUsuarioById(int id);


        //aqui separo la responsabilidad
        Task<bool> SaveUsuario(Usuario usuario);
        // Método para buscar usuarios por nombre
        Task<IEnumerable<Usuario>> BuscarUsuariosPorNombre(string nombre);

    }
}
