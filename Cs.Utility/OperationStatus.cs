using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsHealthcare.Utility
{
    public class OperationStatus
    {
        public static string UNDERPROCESS
        {
            get
            {
                const string val = "UNDERPROCESS";
                return val;
            }
        }
        public static string DISCHARGED
        {
            get
            {
                const string val = "DISCHARGED";
                return val;
            }
        }
        public static string ADMITTED
        {
            get
            {
                const string val = "ADMITTED";
                return val;
            }
        }

        public static string TRANSFERRED
        {
            get
            {
                const string val = "TRANSFERRED";
                return val;
            }
        }
        public static string COMPLETED
        {
            get
            {
                const string val = "COMPLETED";
                return val;
            }
        }
        public static string REPORTDELEVERED
        {
            get
            {
                const string val = "REPORTDELEVERED";
                return val;
            }
        }
        public static string COMPLETEDTEST
        {
            get
            {
                const string val = "COMPLETEDTEST";
                return val;
            }
        }


        public static string COLLECTED
        {
            get
            {
                const string val = "COLLECTED";
                return val;
            }
        }

        public static string LABPROCCESING
        {
            get
            {
                const string val = "LABPROCCESING";
                return val;
            }
        }
        public static string DELIVERED
        {
            get
            {
                const string val = "DELIVERED";
                return val;
            }
        }
        public static string CANCEL
        {
            get
            {
                const string val = "CANCEL";
                return val;
            }
        }

        public static string PREPARE
        {
            get
            {
                const string val = "PREPARE";
                return val;
            }
        }

        public static string CONFIRM
        {
            get
            {
                const string val = "CONFIRM";
                return val;
            }
        }

        public static string UNPAID
        {
            get
            {
                const string val = "UNPAID";
                return val;
            }
        }

        public static string ALL
        {
            get
            {
                const string val = "ALL";
                return val;
            }
        }

        public static string YES
        {
            get
            {
                const string val = "Y";
                return val;
            }
        }

        public static string NO
        {
            get
            {
                const string val = "N";
                return val;
            }
        }

        public static string ACTIVE
        {
            get
            {
                const string val = "Active";
                return val;
            }
        }

        public static string INACTIVE
        {
            get
            {
                const string val = "Inactive";
                return val;
            }
        }

        public static string RIGHT
        {
            get
            {
                const string val = "Right";
                return val;
            }
        }

        public static string WRONG
        {
            get
            {
                const string val = "Wrong";
                return val;
            }
        }

        public static string NOT_SET
        {
            get
            {
                const string val = "Not Set";
                return val;
            }
        }

        public static string SEND
        {
            get
            {
                const string val = "Send";
                return val;
            }
        }

        public static string READ
        {
            get
            {
                const string val = "Read";
                return val;
            }
        }

        public static string FAILURE
        {
            get
            {
                const string val = "Failure";
                return val;
            }
        }

        public static string DENY
        {
            get
            {
                const string val = "Deny";
                return val;
            }
        }

        public static string NEW
        {
            get
            {
                const string val = "N";
                return val;
            }
        }

        public static string MODIFY
        {
            get
            {
                const string val = "M";
                return val;
            }
        }

        public static string DELETE
        {
            get
            {
                const string val = "D";
                return val;
            }
        }

        public static string DOCTOR_ID
        {
            get
            {
                string val = "DOC-" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "-" +
                    DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                return val;
            }
        }

        public static string EMPLOYEE_ID
        {
            get
            {
                string val = "EMP-" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "-" +
                    DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                return val;
            }
        }

        public static string COMPANY_ID
        {
            get
            {
                string val = "COM-" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "-" +
                    DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                return val;
            }
        }

        public static string TRANSACTION_ID
        {
            get
            {
                string val = "TRIP-" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "-" +
                    DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                return val;
            }
        }


        public static string SI_CODE
        {
            get
            {
                string val = "SU-" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "-" +
                    DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                return val;
            }
        }
        public static string UNIQUE_ID
        {
            get
            {
                string val = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "-" +
                    DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                return val;
            }
        }

        public static string VOUCHER_NO
        {
            get
            {
                string val = "VOU-" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "-" +
                    DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                return val;
            }
        }

        public static string INVOICE_NO
        {
            get
            {
                string val = "INV-" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "-" +
                    DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                return val;
            }
        }

        public static string IMG_ID
        {
            get
            {
                string val = "img-" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "-" +
                    DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                return val;
            }
        }

        public static string PAYMENT
        {
            get
            {
                const string val = "PAYMENT";
                return val;
            }
        }

        public static string PENDING
        {
            get
            {
                const string val = "Pending";
                return val;
            }
        }

        public static string ENROLLED
        {
            get
            {
                const string val = "ENROLLED";
                return val;
            }
        }

        public static string PAID
        {
            get
            {
                const string val = "PAID";
                return val;
            }
        }

        public static string HISTORY
        {
            get
            {
                const string val = "HISTORY";
                return val;
            }
        }

        public static string PRESCRIPTION
        {
            get
            {
                const string val = "PRESCRIPTION";
                return val;
            }
        }

        public static string BARCODE_LEVEL
        {
            get
            {
                string val = "LBL-" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "-" +
                    DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                return val;
            }
        }

    }
}