using DVLD_DataAccessLayer1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer1
{
    public class ClsDriver
    {

        public enum enMode
        {
            AddNew,
            UpdateMode
        }

        public int _DriverID { get; set; } = 0;
        public int _PersonID { get; set; } = 0;
        public enMode _Mode { get; set; }

        public int CreatedByUserID { get; set; } = 0;
        public string DriverNumber { get; set; } = string.Empty;

        public string DriverStatus { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;


       public ClsDriver()
        {
            this._DriverID = -1;
            this.DriverStatus = string.Empty;
            this.CreatedDate = DateTime.Now;
            this._PersonID = -1;
            this.CreatedByUserID = -1;
            this.DriverNumber = string.Empty;
            enMode _Mode = enMode.AddNew;

        }

        public ClsDriver(int DriverID,int PersonID, string DriverNumber, string DriverStatus, DateTime CreatedDate, int CreatedByUserID)
        {
            this._DriverID = DriverID;
            this.DriverStatus = DriverStatus;
            this.CreatedDate = CreatedDate;
            this._PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.DriverNumber = DriverNumber;
            enMode _Mode = enMode.UpdateMode;
        }

        

        private bool _AddNewDriver()
        {
            this._DriverID = ClsDriverData.AddNewDriver(this._PersonID, this.DriverNumber,this.CreatedDate, this.DriverStatus, this.CreatedByUserID);

            return (this._DriverID != -1);
        }
        static public ClsDriver FindByPersonID(int PersonID)
        {
            int DriverID = -1;
            string driverNumber = string.Empty;
            string driverStatus = string.Empty;
            DateTime createdDate = DateTime.Now;
            int createdByUserID = -1;

            if(ClsDriverData.FindDriverByPersonID(ref DriverID, ref driverNumber, ref driverStatus, ref createdDate, ref createdByUserID, PersonID))
            {
                return new ClsDriver(DriverID,PersonID, driverNumber, driverStatus, createdDate, createdByUserID);
            }
            return null;
        }
        public bool Save()
        {

            switch (_Mode)
            {

                case enMode.AddNew:


                    if (_AddNewDriver())
                    {
                        _Mode = enMode.UpdateMode;
                        return true;
                    }

                    return false;


                case enMode.UpdateMode:

                    return false;

            }


            return false;
        }



    }
}
