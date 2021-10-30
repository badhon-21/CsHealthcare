using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Hospital;
using CsHealthcare.DataAccess.Entity.Views;

namespace CsHealthcare.Repositories
{
   public class VwDrugAvilableRepository:Repository<VW_DRUG_AVILABLE_STOCK>
   {
       public VwDrugAvilableRepository(AppDbContext context) : base(context)
       {
           
       }
    }
    public class VwDrugConditionRepository : Repository<VW_DRUG_CONDITION>
    {
        public VwDrugConditionRepository(AppDbContext context) : base(context)
        {

        }
    }
    public class VwDrugSaleAllRepository : Repository<VW_DRUG_SALE_ALL>
    {
        public VwDrugSaleAllRepository(AppDbContext context) : base(context)
        {

        }
    }
    public class VwIpdDrugSaleRepository : Repository<VW_IPD_DRUG_SALE>
    {
        public VwIpdDrugSaleRepository(AppDbContext context) : base(context)
        {

        }
    }
    public class VwIpdDrugSaleReturnRepository : Repository<VW_IPD_DRUG_SALE_RETURN>
    {
        public VwIpdDrugSaleReturnRepository(AppDbContext context) : base(context)
        {

        }
    }
    public class VwIpdDrugSaleTotalRepository : Repository<VW_IPD_DRUG_SALE_TOTAL>
    {
        public VwIpdDrugSaleTotalRepository(AppDbContext context) : base(context)
        {

        }
    }
    public class VwDailyUserCollectionRepository : Repository<VW_DAILY_USER_COLLECTION>
    {
        public VwDailyUserCollectionRepository(AppDbContext context) : base(context)
        {

        }
    }
}
