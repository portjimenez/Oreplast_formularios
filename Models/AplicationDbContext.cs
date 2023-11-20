using Microsoft.EntityFrameworkCore;

namespace AccesoWindows.Models
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<MenuModel> Menu { get; set; }
        public DbSet<FrmRolModel> tbl_rol { get; set; }
        public DbSet<Usuarios> tbl_usuario { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones adicionales
        }
    }
}
