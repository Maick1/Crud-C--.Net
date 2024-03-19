using CrudDefinitivo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CrudDefinitivo.Context
{
    public class MyUsuarioContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        //metodo para sobreescribir
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Crud;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
