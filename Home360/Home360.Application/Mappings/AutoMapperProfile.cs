using AutoMapper;
using Home360.Application.DTOs;
using Home360.Domain.Entities;

namespace Home360.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Admin
            // User Management Mappings
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>().ReverseMap();

            //Role Master
            CreateMap<RoleMasterRequest, RoleMaster>();
            CreateMap<RoleMaster, RoleMasterResponse>();

            //Screen Master
            CreateMap<ScreenMasterRequest, ScreenMaster>();
            CreateMap<ScreenMaster, ScreenMasterResponse>();
            CreateMap<RoleAccessManagerRequest, RoleAccessManager>();
            CreateMap<RoleAccessManager, RoleAccessManagerResponse>();
            #endregion

            #region Expense Tracker
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
