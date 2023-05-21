using ConcertDB.DAL.Entities;

namespace ConcertDB.DAL
{
    public class SeederDb
    {

        private readonly DataBaseContext _DBContext;
        public SeederDb(DataBaseContext Context)
        {
            _DBContext = Context;
        }
        public async Task SeederAsync()
        {
            await _DBContext.Database.EnsureCreatedAsync();

            await PopulateTicketsAsync();

            await _DBContext.SaveChangesAsync();

        }
        private async Task PopulateTicketsAsync()
        {
            if (!_DBContext.Tickets.Any())
            {
                for (int a = 0; a < 50000; a++)
                {
                    _DBContext.Tickets.Add(new Tickets { UseDate = null, IsUsed = false, EntranceGate = null });
                }
            }
        }

    }
}