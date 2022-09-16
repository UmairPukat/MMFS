using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_AutoMapper
{
    public class AutoMapperConfig
    {
        private static MapperConfiguration _mapperConfiguration;
        private static IMapper _mapper;

        public IMapper Mapper
        {
            get {
                if (_mapper != null) return _mapper;
                if (_mapperConfiguration == null)
                    Configure();

                _mapper = _mapperConfiguration.CreateMapper();
                return _mapper;
            }
            set { _mapper = value; }
        }

        public static void Configure()
        {
            try
            {
                _mapperConfiguration = new MapperConfiguration(configure =>
                {

                    //#region HR Config

                    //configure.AddProfile<MaLogProfile>();
                    //configure.AddProfile<OvertimeProfile>();


                    //#endregion

                    //#region Master Profiles

                    //configure.AddProfile<BranchDepartmentsProfile>();
                    //configure.AddProfile<BusinessUnitProfile>();
                    //configure.AddProfile<LocationProfile>();


                    //#endregion

                    //configure.AddProfile<InKindProfile>();
                    //configure.AddProfile<InKindDetailProfile>();


                    //configure.AddProfile<AttendanceSyncProfile>();

                    //#region Leaves Config

                    //configure.AddProfile<EmployeeLeaveRequestProfile>();


                    //#endregion
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
