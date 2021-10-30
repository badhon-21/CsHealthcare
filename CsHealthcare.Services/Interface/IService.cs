using System.Security.Policy;
using CsHealthcare.DataAccess.Entity.Accounts;
using CsHealthcare.DataAccess.Entity.Diagnostic;
using CsHealthcare.DataAccess.Entity.HumanResource;

using CsHealthcare.DataAccess.HumanResource;
using CsHealthcare.Repositories;

namespace CsHealthcare.Services.Interface
{
    public interface IService
    {
        Repository<DEPARTMENT> DepartmentRepository { get; }
        Repository<GL_ACCOUNT> GLAccountRepository { get; } 
        Repository<BankAccount> BankAccountRepository { get; }
        Repository<BankTransaction> BankTransactionRepository { get; }
        Repository<EmployeeDesignation> EmployeeDesignationRepository { get; }
        Repository<Test_Name> TestNameRepository { get; }
        Repository<EmployeeInfo> EmployeeInfoRepository { get; }
        int Commit();
    }
}
