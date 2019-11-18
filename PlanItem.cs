using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lập_lịch_thông_báo
{
    public class PlanItem
    {
        private DateTime date;
        private string job
        { 
            get { return job; }
            set { job = value; }
        }

        private Point fromTime;

        private Point FromTime
        {
            get { return formTime; }
            set { fromTime = value;  }
        }
        private Point toTime;

        private Point ToTime
        {
            get { return toTime; }
            set { toTime = Value; }
        }
        private string status;

        private string Status
        {
            get { return status; }
            set { status = Value; }
        }

        public static List<string> ListStatus = new List<string>() { "DONE", "DOING", "COMING", "MISSED" };

    }

    public enum EplanItem
    {
        DONE,
        DOING,
        COMJING,
        MISSED
    }
}
