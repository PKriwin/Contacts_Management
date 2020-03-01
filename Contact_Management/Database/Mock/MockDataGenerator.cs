namespace Contact_Management.Database.Mock
{
    public class MockDataGenerator
    {
        private readonly ContactManagementDBContext _dbContext;

        public MockDataGenerator(ContactManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
