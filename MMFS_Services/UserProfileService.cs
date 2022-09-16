using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MMFS_Context;
using MMFS_Context.UserProfile;
using MMFS_Models.UserProfileDto;
using MMFS_POCO;
using MMFS_POCO.UserManagement;
using MMFS_POCO.UserProfile;
using MMFS_Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_Services
{
    public class UserProfileService
    {
        private readonly _DbContext _DbContext;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserProfileService(_DbContext DbContext,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _DbContext = DbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IQueryable<PaymentMethod> GetPaymentMethod()
        {
            var result = _DbContext.PaymentMethod.Where(x => x.IsActive == true && x.IsDeleted == false);
            return result;
        }

        public IQueryable<Race> GetRaces()
        {
            var result = _DbContext.Race.Where(x => x.IsActive == true && x.IsDeleted == false);
            return result;
        }

        public IQueryable<Religion> GetReligion()
        {
            var result = _DbContext.Religions.Where(x => x.IsActive == true && x.IsDeleted == false);
            return result;
        }

        public IQueryable<City> GetAllState()
        {
            var result = _DbContext.City.Where(x => x.IsActive == true && x.IsDeleted == false);
            return result;
        }

        public IQueryable<State> GetAllCity()
        {
            var result = _DbContext.States.Where(x => x.IsActive == true && x.IsDeleted == false);
            return result;
        }

        public void AddPersonalProfileAsync(PersonalProfile model,string UserId)
        {
            PersonalProfile profile = new PersonalProfile()
            {
                UserId = UserId,
                FullName = model.FullName,
                AGPIdCard = model.AGPIdCard,
                UserTypeId = model.UserTypeId,
                NewNRICNo = model.NewNRICNo,
                OldNRICNo = model.OldNRICNo,
                MobilePhoneNo = model.MobilePhoneNo,
                Gender = model.Gender,
                EmailAddress = model.EmailAddress,
                DOB = model.DOB,
                RaceId = model.RaceId,
                ReligionId = model.ReligionId,
                JoiningDate = model.JoiningDate,
                DrivingLicenseType = model.DrivingLicenseType,
                DrivingLicenseClass = model.DrivingLicenseClass,
                CompanyVehiclePlateNo = model.CompanyVehiclePlateNo,
                CompanyVehicleModel = model.CompanyVehicleModel,
                CompanyHouseAddress = model.CompanyHouseAddress,
                Postcode = model.Postcode,
                CityId = model.CityId,
                StateId = model.StateId,
                Status = model.Status,
            };
            _DbContext.UserPersonalProfile.Add(profile);
            _DbContext.SaveChanges();
        }

        public void UpdatePersonalProfile(PersonalProfile model)
        {
            var result = _DbContext.UserPersonalProfile.Where(x=>x.UserId == model.UserId).FirstOrDefault();
            if(result != null)
            {
                result.FullName = model.FullName;
                result.AGPIdCard = model.AGPIdCard;
                result.UserTypeId = model.UserTypeId;
                result.NewNRICNo = model.NewNRICNo;
                result.OldNRICNo = model.OldNRICNo;
                result.MobilePhoneNo = model.MobilePhoneNo;
                result.Gender = model.Gender;
                result.EmailAddress = model.EmailAddress;
                result.DOB = model.DOB;
                result.RaceId = model.RaceId;
                result.ReligionId = model.ReligionId;
                result.JoiningDate = model.JoiningDate;
                result.DrivingLicenseType = model.DrivingLicenseType;
                result.DrivingLicenseClass = model.DrivingLicenseClass;
                result.CompanyVehiclePlateNo = model.CompanyVehiclePlateNo;
                result.CompanyVehicleModel = model.CompanyVehicleModel;
                result.CompanyHouseAddress = model.CompanyHouseAddress;
                result.Postcode = model.Postcode;
                result.CityId = model.CityId;
                result.StateId = model.StateId;
                result.Status = model.Status;

                _DbContext.UserPersonalProfile.Update(result);
                _DbContext.SaveChanges();
            }
        }
        public ICollection<UserProfileDto> getUserProfile()
        {
            var result = (from p in _DbContext.UserPersonalProfile
                          join u in _DbContext.Users
                          on p.UserId equals u.Id
                          join roles in _DbContext.Roles
                          on p.UserTypeId equals roles.Id
                          select new UserProfileDto
                          {
                              UserId = u.Id,
                              UserName = u.FullName,
                              EmailAddress = u.Email,
                              UserTypeId = roles.Id,
                              UserTypeName = roles.Name,
                              MobilePhoneNo = p.MobilePhoneNo,
                              DOB = p.DOB,
                              JoiningDate = p.JoiningDate,
                              Status = (p.Status == "1")? "Active":"InActive"
                          }).ToList();
            return result;
        }

        public void AddUserBusinessProfile(BusinessProfile model)
        {
            BusinessProfile profile = new BusinessProfile()
            {
                UserId = model.UserId,
                Company = model.Company,
                EnterpriseSSMNo = model.EnterpriseSSMNo,
                SSMExpiryDate = model.SSMExpiryDate,
                BusinessAddress = model.BusinessAddress,
                Postcode = model.Postcode,
                CityId = model.CityId,
                StateId = model.StateId,
                BankAccountNo = model.BankAccountNo,
                AGPManagerName = model.AGPManagerName,
                AGPManagerPhoneNo = model.AGPManagerPhoneNo,
                HouseType = model.HouseType,
                HomeFurnishing = model.HomeFurnishing,
                ShopLot = model.ShopLot,
            };
            _DbContext.UserBusinessProfile.Add(profile);
            _DbContext.SaveChanges();
        }
        public void UpdateUserBusinessProfile(BusinessProfile model)
        {
            var result = _DbContext.UserBusinessProfile.Where(x => x.UserId == model.UserId).FirstOrDefault();
            if (result != null)
            {
                result.Company = model.Company;
                result.EnterpriseSSMNo = model.EnterpriseSSMNo;
                result.SSMExpiryDate = model.SSMExpiryDate;
                result.BusinessAddress = model.BusinessAddress;
                result.Postcode = model.Postcode;
                result.CityId = model.CityId;
                result.StateId = model.StateId;
                result.BankAccountNo = model.BankAccountNo;
                result.AGPManagerName = model.AGPManagerName;
                result.AGPManagerPhoneNo = model.AGPManagerPhoneNo;
                result.HouseType = model.HouseType;
                result.HomeFurnishing = model.HomeFurnishing;
                result.ShopLot = model.ShopLot;

                _DbContext.UserBusinessProfile.Update(result);
                _DbContext.SaveChanges();
            }
            else
            {
                BusinessProfile b = new BusinessProfile()
                {
                    UserId = model.UserId,
                    Company = model.Company,
                    EnterpriseSSMNo = model.EnterpriseSSMNo,
                    SSMExpiryDate = model.SSMExpiryDate,
                    BusinessAddress = model.BusinessAddress,
                    Postcode = model.Postcode,
                    CityId = model.CityId,
                    StateId = model.StateId,
                    BankAccountNo = model.BankAccountNo,
                    AGPManagerName = model.AGPManagerName,
                    AGPManagerPhoneNo = model.AGPManagerPhoneNo,
                    HouseType = model.HouseType,
                    HomeFurnishing = model.HomeFurnishing,
                    ShopLot = model.ShopLot
                };
                _DbContext.UserBusinessProfile.Add(b);
                _DbContext.SaveChanges();
            }
             
        }

        public void AddUserEmergencyProfile(UserEmergencyProfile model)
        {
            UserEmergencyProfile profile = new UserEmergencyProfile()
            {
                UserId = model.UserId,
                ContactName = model.ContactName,
                Relationship = model.Relationship,
                ContactNo = model.ContactNo,
                Vaccination = model.Vaccination
            };
            _DbContext.UserEmergencyProfile.Add(profile);
            _DbContext.SaveChanges();
        }

        public void UpdateUserEmergencyProfile(UserEmergencyProfile model)
        {
            var result = _DbContext.UserEmergencyProfile.Where(x => x.UserId == model.UserId).FirstOrDefault();
            if (result != null)
            {
                result.ContactName = model.ContactName;
                result.Relationship = model.Relationship;
                result.ContactNo = model.ContactNo;
                result.Vaccination = model.Vaccination;
                _DbContext.UserEmergencyProfile.Update(result);
                _DbContext.SaveChanges();
            }
            else
            {
                UserEmergencyProfile e = new UserEmergencyProfile()
                {
                    UserId = model.UserId,
                    ContactName = model.ContactName,
                    Relationship = model.Relationship,
                    ContactNo = model.ContactNo,
                    Vaccination = model.Vaccination
                };
                _DbContext.UserEmergencyProfile.Add(e);
                _DbContext.SaveChanges();
            }
                
        }


        public void AddUserChequeProfile(UserChequeProfile model)
        {
            UserChequeProfile profile = new UserChequeProfile()
            {
                UserId = model.UserId,
                PloteAmount = model.PloteAmount,
                PlotePaymentMethod = model.PlotePaymentMethod,
                PloteRemark = model.PloteRemark,
                OperationReserveAmount = model.OperationReserveAmount,
                OperationReservePaymentMethod = model.OperationReservePaymentMethod,
                OperationReserveRemark = model.OperationReserveRemark,
                JVAgreementAmount = model.JVAgreementAmount,
                JVAgreementPaymentMethod = model.JVAgreementPaymentMethod,
                JVAgreementRemark = model.JVAgreementRemark,
                StampingAmount = model.StampingAmount,
                StampingPaymentMethod = model.StampingPaymentMethod,
                StampingRemark = model.StampingRemark,
                HouseUtilitiesAmount = model.HouseUtilitiesAmount,
                HouseUtilitiesPaymentMethod = model.HouseUtilitiesPaymentMethod,
                HouseUtilitiesRemark = model.HouseUtilitiesRemark,
                HouseFurnishingAmount = model.HouseFurnishingAmount,
                HouseFurnishingPaymentMethod = model.HouseFurnishingPaymentMethod,
                HouseFurnishingRemark = model.HouseFurnishingRemark,
                ShopLotAmount = model.ShopLotAmount,
                ShopLotPaymentMethod = model.ShopLotPaymentMethod,
                ShopLotRemark = model.ShopLotRemark,
            };
            _DbContext.UserChequeProfile.Add(profile);
            _DbContext.SaveChanges();
        }

        

        public void UpdateUserChequeProfile(UserChequeProfile model)
        {
            var result = _DbContext.UserChequeProfile.Where(x => x.UserId == model.UserId).FirstOrDefault();
            if (result != null)
            {
                result.PloteAmount = model.PloteAmount;
                result.PlotePaymentMethod = model.PlotePaymentMethod;
                result.PloteRemark = model.PloteRemark;
                result.OperationReserveAmount = model.OperationReserveAmount;
                result.OperationReservePaymentMethod = model.OperationReservePaymentMethod;
                result.OperationReserveRemark = model.OperationReserveRemark;
                result.JVAgreementAmount = model.JVAgreementAmount;
                result.JVAgreementPaymentMethod = model.JVAgreementPaymentMethod;
                result.JVAgreementRemark = model.JVAgreementRemark;
                result.StampingAmount = model.StampingAmount;
                result.StampingPaymentMethod = model.StampingPaymentMethod;
                result.StampingRemark = model.StampingRemark;
                result.HouseUtilitiesAmount = model.HouseUtilitiesAmount;
                result.HouseUtilitiesPaymentMethod = model.HouseUtilitiesPaymentMethod;
                result.HouseUtilitiesRemark = model.HouseUtilitiesRemark;
                result.HouseFurnishingAmount = model.HouseFurnishingAmount;
                result.HouseFurnishingPaymentMethod = model.HouseFurnishingPaymentMethod;
                result.HouseFurnishingRemark = model.HouseFurnishingRemark;
                result.ShopLotAmount = model.ShopLotAmount;
                result.ShopLotPaymentMethod = model.ShopLotPaymentMethod;
                result.ShopLotRemark = model.ShopLotRemark;


                _DbContext.UserChequeProfile.Update(result);
                _DbContext.SaveChanges();
            }
            else
            {
                UserChequeProfile c = new UserChequeProfile()
                {
                    UserId = model.UserId,
                    PloteAmount = model.PloteAmount,
                    PlotePaymentMethod = model.PlotePaymentMethod,
                    PloteRemark = model.PloteRemark,
                    OperationReserveAmount = model.OperationReserveAmount,
                    OperationReservePaymentMethod = model.OperationReservePaymentMethod,
                    OperationReserveRemark = model.OperationReserveRemark,
                    JVAgreementAmount = model.JVAgreementAmount,
                    JVAgreementPaymentMethod = model.JVAgreementPaymentMethod,
                    JVAgreementRemark = model.JVAgreementRemark,
                    StampingAmount = model.StampingAmount,
                    StampingPaymentMethod = model.StampingPaymentMethod,
                    StampingRemark = model.StampingRemark,
                    HouseUtilitiesAmount = model.HouseUtilitiesAmount,
                    HouseUtilitiesPaymentMethod = model.HouseUtilitiesPaymentMethod,
                    HouseUtilitiesRemark = model.HouseUtilitiesRemark,
                    HouseFurnishingAmount = model.HouseFurnishingAmount,
                    HouseFurnishingPaymentMethod = model.HouseFurnishingPaymentMethod,
                    HouseFurnishingRemark = model.HouseFurnishingRemark,
                    ShopLotAmount = model.ShopLotAmount,
                    ShopLotPaymentMethod = model.ShopLotPaymentMethod,
                    ShopLotRemark = model.ShopLotRemark,
                };
                _DbContext.UserChequeProfile.Add(c);
                _DbContext.SaveChanges();
            }
        }

        public UserProfileForEditDto getFullProfileOfUser(string userId)
        {
            try
            {
                var result = _DbContext.Users
                .Include(x => x.PersonalProfile)
                .Include(x => x.BusinessProfile)
                .Include(x => x.UserEmergencyProfile)
                .Include(x => x.UserChequeProfile)
                .Where(x => x.Id == userId)
                .Select(x => new UserProfileForEditDto
                {
                    PersonalProfile = x.PersonalProfile,
                    BusinessProfile = x.BusinessProfile,
                    UserEmergencyProfile = x.UserEmergencyProfile,
                    UserChequeProfile = x.UserChequeProfile

                })
                .FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DeleteUserById(string UserId)
        {
            var result = _DbContext.Users.Find(UserId);
            if (result != null)
            {
                _DbContext.Users.Remove(result);
                _DbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
