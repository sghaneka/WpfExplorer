namespace Explorer.DataLayer.confusings
{
    public class MockUnitOfWork : IUnitOfWork<AdventureWorks.AdventureWorksContext>
    {
        public void Dispose()
        {
        }

        public int Save()
        {
            return 0;
        }

        public AdventureWorks.AdventureWorksContext Context { get; private set; }
    }
}
