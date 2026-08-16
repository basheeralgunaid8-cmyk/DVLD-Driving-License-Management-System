using DVLD_BusinessLayer;
using DVLD_DataAccessLayer1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer1
{
    public class ClsApplicationType
    {

        public enum enMode
        {
            AddNew,
            UpdateMode
        }


        public enMode Mode = enMode.AddNew;

        public int _ApplicationID {get ;set;}

       
        public decimal _ApplicationFees { get; set; }
        public string _ApplicationName { get; set; }

        ClsApplicationType(int ApplicationTypeID, decimal ApplicationFees,string applicationName)
        {
            this._ApplicationID = ApplicationTypeID;
            this._ApplicationFees = ApplicationFees;
            this._ApplicationName = applicationName;
            Mode = enMode.UpdateMode;
        }

        private bool _UpdateApplicationType ()
        {
            return ClsApplicationTypeData.UpdateApplicationType(_ApplicationID, _ApplicationName, _ApplicationFees);


        }

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    return false;

                case enMode.UpdateMode:

                    return _UpdateApplicationType();

            }


            return false;
        }

        public static DataTable GetAllApplicationTypesInfo()
        {
            return ClsApplicationTypeData.GetAllApplicationTypes();
        }

        public static ClsApplicationType  FindApplicationTypeByID(int ApplicationID)
        {
            string ApplicationName = string.Empty;
            decimal ApplicationFee = 0;
            bool isFound = ClsApplicationTypeData.FindApplicationTypeByID(ApplicationID, ref ApplicationName, ref ApplicationFee);
            if (isFound)
            {
                return new ClsApplicationType(ApplicationID, ApplicationFee, ApplicationName);
            }
            return null;
        }
    }
}
 