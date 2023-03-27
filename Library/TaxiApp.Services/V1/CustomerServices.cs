using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Common;
using TaxiApp.Common.Paging;
using TaxiApp.Data.Contract;
using TaxiApp.Entities.Contract;
using TaxiApp.Services.Contract;

namespace TaxiApp.Services.V1
{
    public class CustomerServices : AbstractCustomerServices
    {
        private AbstractCustomerDao abstractCustomerDao;

        public CustomerServices(AbstractCustomerDao abstractCustomerDao)
        {
            this.abstractCustomerDao = abstractCustomerDao;
        }

        //public override PagedList<AbstractCustomer> Customer_All(PageParam pageParam, string search, AbstractCustomer abstractCustomer)
        //{
        //    return this.abstractCustomerDao.Customer_All(pageParam, search, abstractCustomer);
        //}
        //public override bool Customer_Logout(int Id)
        //{
        //    return this.abstractCustomerDao.Customer_Logout(Id);
        //}
        //public override SuccessResult<AbstractCustomer> Customer_ById(int Id)
        //{
        //    return this.abstractCustomerDao.Customer_ById(Id);
        //}
        //public override SuccessResult<AbstractCustomer> Trip_Start(int CustomerId)
        //{
        //    return this.abstractCustomerDao.Trip_Start(CustomerId);
        //}

        //public override SuccessResult<AbstractCustomer> Customer_Upsert(AbstractCustomer abstractCustomer)
        //{
        //    return this.abstractCustomerDao.Customer_Upsert(abstractCustomer);
        //}
        //public override SuccessResult<AbstractCustomer> Customer_AddressUpdate(AbstractCustomer abstractCustomer)
        //{
        //    return this.abstractCustomerDao.Customer_AddressUpdate(abstractCustomer);
        //}
        //public override SuccessResult<AbstractCustomer> Customer_Login(string Email, string Password, string DeviceToken)
        //{
        //    return this.abstractCustomerDao.Customer_Login(Email, Password, DeviceToken);
        //}
        //public override SuccessResult<AbstractCustomer> Customer_RcCardUpdate(AbstractCustomer abstractCustomer)
        //{
        //    return this.abstractCustomerDao.Customer_RcCardUpdate(abstractCustomer);
        //}
        //public override SuccessResult<AbstractCustomer> Customer_IdProofUpdate(AbstractCustomer abstractCustomer)
        //{
        //    return this.abstractCustomerDao.Customer_IdProofUpdate(abstractCustomer);
        //}
        //public override SuccessResult<AbstractCustomer> Customer_ProfilePictureUpdate(AbstractCustomer abstractCustomer)
        //{
        //    return this.abstractCustomerDao.Customer_ProfilePictureUpdate(abstractCustomer);
        //}
        //public override SuccessResult<AbstractCustomer> Customer_ChangePassword(AbstractCustomer abstractCustomer)
        //{
        //    return this.abstractCustomerDao.Customer_ChangePassword(abstractCustomer);
        //}
        //public override SuccessResult<AbstractCustomer> Customer_Delete(int Id, int DeletedBy)
        //{
        //    return this.abstractCustomerDao.Customer_Delete(Id, DeletedBy);
        //}
        //public override SuccessResult<AbstractCustomer> Customer_ActInAct(int Id)
        //{
        //    return this.abstractCustomerDao.Customer_ActInAct(Id);
        //}
        //public override SuccessResult<AbstractCustomer> Customer_RcCardApproved(int Id)
        //{
        //    return this.abstractCustomerDao.Customer_RcCardApproved(Id);
        //}
        //public override SuccessResult<AbstractCustomer> Customer_IdProofApproved(int Id)
        //{
        //    return this.abstractCustomerDao.Customer_IdProofApproved(Id);
        //}
    }

}