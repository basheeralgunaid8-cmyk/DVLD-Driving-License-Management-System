using DVLD_DataAccessLayer1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer1
{
    public class ClsTestType
    {

        public enum enMode
        {
            AddNew,
            UpdateMode
        }


        public enMode Mode = enMode.AddNew;

        public int _TestTypeID { get; set; }


        public decimal _Fees { get; set; }
        public string _Description { get; set; }
        public string _TestTypeTitle { get; set; }

        ClsTestType(int TestTypeID,string Title, decimal Fees, string Description)
        {
            this._TestTypeID = TestTypeID;
            this._TestTypeTitle = Title;
            this._Description = Description;
            this._Fees = Fees;
            Mode = enMode.UpdateMode;
        }

        private bool _UpdateTestTypeInfo()
        {
            return ClsTestTypeData.UpdateTestType(_TestTypeID,_TestTypeTitle, _Description, _Fees);


        }

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    return false;

                case enMode.UpdateMode:

                    return _UpdateTestTypeInfo();

            }


            return false;
        }

        public static DataTable GetAllTestTypesInfo()
        {
            return ClsTestTypeData.GetAllTestTypes();
        }

        public static ClsTestType FindTestTypeByID(int TestTypeID)
        {
            string Description = string.Empty;
            string Title = string.Empty;
            decimal Fees = 0;
            bool isFound = ClsTestTypeData.FindTestTypeByID(TestTypeID,ref Title, ref Description, ref Fees);
            if (isFound)
            {
                return new ClsTestType(TestTypeID,Title, Fees, Description);
            }
            return null;
        }
    }
}
