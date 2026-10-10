using DVLD_DataAccessLayer1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer1
{
    public  class ClsAppointments
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int _AppointmentID { get; set; }
        public DateTime _AppointmentDate { get; set; }

        public Decimal _PaidFee { get; set; }

        public bool _IsLocked { get; set; }
        public int _TestTypeID { get; set; }
        public int _ApplicationLicenseClassID { get; set; }
        public int CreatedByUserID { get; set; }

        ClsAppointments( int appointmentID, DateTime appointmentDate, decimal paidFee, bool isLocked, int testTypeID, int applicationLicenseClassID, int createdByUserID)
        {
           
            _AppointmentID = appointmentID;
            _AppointmentDate = appointmentDate;
            _PaidFee = paidFee;
            _IsLocked = isLocked;
            _TestTypeID = testTypeID;
            _ApplicationLicenseClassID = applicationLicenseClassID;
            CreatedByUserID = createdByUserID;
            Mode = enMode.Update;
        }

        public ClsAppointments()
        {
            this._AppointmentID = -1;
            this._AppointmentDate = DateTime.Now;
            this._PaidFee = 0;
            this._IsLocked = false;
            this._TestTypeID = -1;
            this._ApplicationLicenseClassID = -1;
            this.CreatedByUserID = -1;
            this.Mode = enMode.AddNew;
        }

        public static ClsAppointments FindAppointmentID(int applicationLicenseClassID)
        {
            DateTime appointmentDate = DateTime.Now;
            decimal paidFee = 0;
            bool isLocked = false;
            int TestTypeID = -1;
            int AppointmentID = -1;
            int CreatedByUserID = -1;

            if(ClsTestAppointmentsData.FindTestAppointmentIDByApplicationLicenseID(ref AppointmentID,ref appointmentDate,ref paidFee,
                                                  ref isLocked,ref TestTypeID,applicationLicenseClassID,ref CreatedByUserID))
            {
                return new ClsAppointments(AppointmentID,appointmentDate,paidFee, isLocked,TestTypeID,applicationLicenseClassID,CreatedByUserID);
            }

            return null;
        }
        public static ClsAppointments FindAppointmentIDByID(int AppointmentID)
        {
            DateTime appointmentDate = DateTime.Now;
            decimal paidFee = 0;
            bool isLocked = false;
            int TestTypeID = -1;
            int applicationLicenseClassID = -1;
            int CreatedByUserID = -1;

            if (ClsTestAppointmentsData.FindTestAppointmentIDByID( AppointmentID, ref appointmentDate, ref paidFee,
                                                  ref isLocked, ref TestTypeID, ref applicationLicenseClassID, ref CreatedByUserID))
            {
                return new ClsAppointments(AppointmentID, appointmentDate, paidFee, isLocked, TestTypeID, applicationLicenseClassID, CreatedByUserID);
            }

            return null;
        }
        private bool _AddNewAppointment()
        {
            
            this._AppointmentID = ClsTestAppointmentsData.AddNewAppointment(this._AppointmentDate, this._PaidFee,
                this._IsLocked,this._TestTypeID,this._ApplicationLicenseClassID,this.CreatedByUserID);

            return (this._AppointmentID != -1);
        }

        private bool _UpdateAppointmentInfo()
        {
            return ClsTestAppointmentsData.UpdateTestAppointmentInfo(_AppointmentID, _AppointmentDate);
        }

        private bool _UpdateAppointmentInfoByLocked()
        {
            return ClsTestAppointmentsData.UpdateTestAppointmentInfoBylocking(_AppointmentID, _IsLocked);
        }
        public bool Save()
         {

            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewAppointment())
                    {
                        Mode = enMode.Update;

                        return true;
                    }

                    return false;
                 
                case enMode.Update:

                   return _UpdateAppointmentInfo();
            }

            return false;
        }

        public bool LockAppointment()
        {
            return _UpdateAppointmentInfoByLocked();
        }
        public static DataTable GetTestAppointmentData()
        {
            return ClsTestAppointmentsData.GetAlltestAppointmentDetails();
        }

        public static DataTable GetWrittenTestAppointmentData(int TestTypeID)
        {
            return ClsTestAppointmentsData.GetAlltestWrittenTestAppointmentDetails(TestTypeID);
        }

        public static bool DoesPersonHaveActiveAppointment(int PersonID,int TestTypeID)
        {
            return ClsTestAppointmentsData.DoesPersonHaveActiveAppointment(PersonID, TestTypeID);
        }
    }
}
