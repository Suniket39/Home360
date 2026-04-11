using AutoMapper;
using Home360.Application.DTOs;
using Home360.Domain.Entities;

namespace Home360.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region 
            // User Management Mappings
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>().ReverseMap();

            //Role Master
            CreateMap<RoleMasterRequest, RoleMaster>();
            CreateMap<RoleMaster, RoleMasterResponse>();
            #endregion

            #region 
            // Expense Tracker Mappings
            CreateMap<ExpenseCategoryRequest, ExpenseCategory>();
            CreateMap<ExpenseCategory, ExpenseCategoryResponse>();

            CreateMap<ExpenseTypeRequest, ExpenseTypes>();
            CreateMap<ExpenseTypes, ExpenseTypeResponse>();

            CreateMap<ExpenseTransactionRequest, ExpenseTransaction>();
            CreateMap<ExpenseTransaction, ExpenseTransactionResponse>();

            #endregion
        }
    }
}
