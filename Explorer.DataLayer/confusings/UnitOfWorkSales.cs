namespace Explorer.DataLayer.confusings
{
    public class UnitOfWorkSales : IUnitOfWork<AdventureWorks.AdventureWorksContext>
    {
        private readonly AdventureWorks.AdventureWorksContext _context;

        public UnitOfWorkSales()
        {
            _context = new AdventureWorks.AdventureWorksContext();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        /*public UnitOfWorkSales(AdventureWorksLT2012Entities context)
        {
            _context = context;
        }*/

        public AdventureWorks.AdventureWorksContext Context
        {
            get { return _context; }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
