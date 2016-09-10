using AdvancedValidationExample.DataAccess.Model;

namespace AdvancedValidationExample.DataAccess
{
    public interface ISiteRepository
    {
        Site GetById(int siteId);
    }
}
