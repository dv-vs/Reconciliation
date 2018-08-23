using EvoCafe.DAL.Models;
using System.Data.Entity;

namespace EvoCafe.DAL
{
    public class BDContext: DbContext
    {
        public BDContext(): base("DBConnection") { }

        
    }
}
