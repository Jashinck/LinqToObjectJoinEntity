using System.Data.Entity;

namespace LinqToObjectJoinEntity
{
    public class Entity
    {
        public int EntityId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
    }

    public class EntityContext : DbContext
    {
        public IDbSet<Entity> Entitys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
