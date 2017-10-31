namespace Test.Model.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=ModelConn")
        {
        }

        public virtual DbSet<Card> Card { get; set; }
        public virtual DbSet<CardType> CardType { get; set; }
        public virtual DbSet<Trait> Trait { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .HasMany(e => e.Trait)
                .WithMany(e => e.Card)
                .Map(m => m.ToTable("CardsTraits").MapLeftKey("CardId").MapRightKey("TraitId"));

            modelBuilder.Entity<CardType>()
                .HasMany(e => e.Card)
                .WithRequired(e => e.CardType1)
                .HasForeignKey(e => e.CardType)
                .WillCascadeOnDelete(false);
        }
    }
}
