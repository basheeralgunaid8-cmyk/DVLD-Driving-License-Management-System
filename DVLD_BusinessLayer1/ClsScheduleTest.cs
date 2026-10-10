using DVLD_DataAccessLayer1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer1
{
    public  class ClsScheduleTest
    {
        public enum enMode
        {
            AddNew,
            UpdateMode
        }


        public enMode Mode = enMode.AddNew;

        public int _ApplicationID { get; set; }

        public int _TestTypeID { get; set; }


        public DateTime _ApplicationDate { get; set; }
        public string _ClassName { get; set; }
        public string _FullName { get; set; }

        public decimal _Fees { get; set; }


      public ClsScheduleTest()
        {
            this._ApplicationID = -1;
            this._ClassName = string.Empty;
            this._FullName = string.Empty;
            
            this.Mode = enMode.AddNew;
        }

        public ClsScheduleTest( int applicationID,string className, string fullName)
        {
           
            _ApplicationID = applicationID;
            
            _ClassName = className;
            _FullName = fullName;
            this.Mode = enMode.UpdateMode;
        }

       public  ClsScheduleTest (int TestTypeID, decimal Fees)
        {
            this._TestTypeID = TestTypeID;
            this._Fees = Fees;
        }
        public static ClsScheduleTest FindDrivingLicenseInfo(int ID)
        {
          
            string ClassName = "";
            string FullName = "";

          


            if (ClsScheduleTestData.GetScheduleTestInfoData(
                ID,
                ref ClassName,
                ref FullName
               ))
            {
                return new ClsScheduleTest(ID, ClassName, FullName);


            }


            return null;
        }
        public static ClsScheduleTest FindTestTypeInfo(int ID)
        {

            decimal Fees = 0;
            if (ClsScheduleTestData.GetScheduleTestInfoOfTestType(
                ID,
                ref Fees
               
               ))
            {
                return new ClsScheduleTest(ID, Fees);


            }


            return null;
        }
    }
}
