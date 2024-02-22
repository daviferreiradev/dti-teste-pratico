using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data.Map;
using SIstemaDeTarefas.Models;

namespace SIstemaDeTarefas.Data
{
    public class SistemaTarefasDBContext : DbContext
    {
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options)
            : base(options)
        {
        }

        public DbSet<TarefaModel> Tarefas {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
