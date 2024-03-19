using CrudDefinitivo.Context;
using CrudDefinitivo.Interface;
using CrudDefinitivo.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudDefinitivo.Service
{
    public class UsuarioService : InterfaceUsuario
    {

        //inyectamos el contexto
        private readonly MyUsuarioContext _context;


        public UsuarioService(MyUsuarioContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> BuscarUsuariosPorNombre(string nombre)
        {
            // Filtrar usuarios por nombre utilizando LINQ
            var usuarios = await _context.Usuarios.Where(u => u.Name.Contains(nombre)).ToListAsync();
            return usuarios;
        }
        public async Task<bool> DeleteUsuarioById(int id)
        {
            // Buscar el usuario por su id
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario != null) // Verificar si el usuario no es nulo antes de eliminar
            {
                // Eliminar el usuario encontrado
                _context.Usuarios.Remove(usuario);
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                return false; // O manejar de otra forma la situación de usuario no encontrado
            }
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuarios()
        {
            // Devuelve una lista de todos los usuarios
            var usuarios = await _context.Usuarios.ToListAsync();

            // Verifica si la lista de usuarios es nula antes de devolverla
            return usuarios ?? Enumerable.Empty<Usuario>();
        }


        public async Task<Usuario> GetUsuarioById(int id)
        {
            // Devuelve el usuario si se encuentra, de lo contrario, devuelve null
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<bool> InsertUsuario(Usuario usuario)
        {
            //agrego el usuario
            _context.Usuarios.Add(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        //servicio decide cuando llama a insert y update
        //separacion entre capas, separo responsabilidad
        public async Task<bool> SaveUsuario(Usuario usuario)
        {
            if (usuario.Id > 0)
                return await UpdateUsuario(usuario);
            else
                return await InsertUsuario(usuario);
        }

        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            //Remplazo el usuario
            _context.Entry(usuario).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
