using AdvancedValidationExample.DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedValidationExample.DataAccess
{
    public class SiteRepository : ISiteRepository
    {
        private readonly List<Site> sites;

        public SiteRepository()
        {
            this.sites = new List<Site>() {
                new Site() { Id =1, Title= "Food post" },
                new Site() { Id = 2, Title= "Vehicles" }
            };

        }

        public Site GetById(int siteId)
        {
            return sites.SingleOrDefault(s => s.Id == siteId);
        }
    }
}
