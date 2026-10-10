using DVLD_DataAccessLayer1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer1
{
    public class ClsTestResult
    {

        public enum enMode
        {
            AddNew = 0,
            UpdateMode = 1
        }
        public enMode Mode { get; set; }

        public int _TestResultID { get; set; }
        public string _Notes { get; set; }
       public bool Result { get; set; }
        public int _Appointment { get; set; }

        public ClsTestResult()
        {
            this._TestResultID = -1;
            this.Result = false;
            this._Notes = string.Empty;
            this._Appointment = -1;

            Mode = enMode.AddNew;
        }

        public static bool HasFailedTest(int applicationID, int testTypeID)
        {
            return ClsTestResultData.HasFailedTest(applicationID, testTypeID);
        }

        private bool _AddNewTestResult()
        {
            _TestResultID = ClsTestResultData.AddNewTestResult(this._Appointment, this.Result, this._Notes);

            return (_TestResultID != -1);
        }

        public  bool Save()
        {
            {

                switch (Mode)
                {

                    case enMode.AddNew:

                        if (_AddNewTestResult())
                        {
                            Mode = enMode.UpdateMode;

                            return true;
                        }

                        return false;



                    //case enMode.UpdateMode:

                      //  return _UpdateUser();

                }


                return false;
            }

        }

        public static bool HasPassedTest(int ApplicationID, int TestTypeID)
        {
            return ClsTestResultData.HasPassedTest(ApplicationID,TestTypeID);
        }
        public static int? GetLatestTestResult(int ApplicationID, int TestTypeID)
        {
            return ClsTestResultData.GetLatestTestResult(
                ApplicationID,
                TestTypeID);
        }
    }
}
