using Microsoft.EntityFrameworkCore;
using AppWebAPI.Models;

namespace AppWebAPI.Data;

    public class DataContext : DbContext
    {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tareas> Tareas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Usuario>().ToTable("usuarios");

        modelBuilder.Entity<Usuario>().Property(u => u.Nombre).HasColumnName("name");
        modelBuilder.Entity<Usuario>().Property(u => u.Correo).HasColumnName("email");
        modelBuilder.Entity<Usuario>().Property(u => u.Contrasena).HasColumnName("password");
        modelBuilder.Entity<Usuario>().Property(u => u.CreatedAt).HasColumnName("created_at");

        modelBuilder.Entity<Tareas>().ToTable("tareas");

        modelBuilder.Entity<Tareas>().Property(t => t.NombreTarea).HasColumnName("name_task");
        modelBuilder.Entity<Tareas>().Property(t => t.Descripcion).HasColumnName("description");
        modelBuilder.Entity<Tareas>().Property(t => t.CreatedAt).HasColumnName("created_at");

    }

}
