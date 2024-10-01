using Disaster_Response_System.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Response_System.Data
{
    public class DisasterResponseSystemDBContext : DbContext
    {
        public DisasterResponseSystemDBContext(DbContextOptions<DisasterResponseSystemDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Round> Rounds { get; set; }

    }


}