using DVLD_DataAccessLayer1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer1
{
    
    public class ClsLicenseClass
    {

        public enum enMode
        {
            AddNew,
            UpdateMode
        }


        public enMode Mode = enMode.AddNew;

        public int _LicenseClassID { get; set; }


        public string _ClassName { get; set; }
        public int _MinimumAllowedAge { get; set; }
        public int _ValidityLength { get; set; }
        public decimal _ClassFee { get; set; }

        ClsLicenseClass(int LicenseClassID,string ClassName, int MinimumAllowedAge, int ValidityLength,decimal ClassFee)
        {
            this._LicenseClassID= LicenseClassID;
            this._ClassName= ClassName;
            this._MinimumAllowedAge= MinimumAllowedAge;
            this._ValidityLength=ValidityLength;
            this._ClassFee= ClassFee;
            Mode = enMode.UpdateMode;
        }

        private bool _UpdateLicenseClassType()
        {
            return ClsLicenseClassData.UpdateLicenseClassType(_LicenseClassID, _ClassName, _MinimumAllowedAge, _ValidityLength, _ClassFee);

        }


        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    return false;

                case enMode.UpdateMode:

                    return _UpdateLicenseClassType();

            }


            return false;
        }

        public static DataTable GetAllApplicationTypesInfo()
        {
            return ClsLicenseClassData.GetAllLicenseClasses();
        }

        public static ClsLicenseClass FindApplicationTypeByID(int LicenseClassID)
        {

           
            string ClassName=" ";
            int MinimumAllowedAge = -1;
            int ValidityLength = -1;
            decimal ClassFee = 0;


            bool isFound = ClsLicenseClassData.FindLicenseClassByID(LicenseClassID, ref ClassName, ref MinimumAllowedAge,ref ValidityLength,ref ClassFee);
            if (isFound)
            {
                return new ClsLicenseClass(LicenseClassID, ClassName, MinimumAllowedAge, ValidityLength, ClassFee);
            }
            return null;
        }
    }
}
