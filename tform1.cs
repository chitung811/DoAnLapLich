using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lập_lịch_thông_báo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private PlanData job;

        public PlanData Job
        {
            get { return job; }
            set { job = value; }
        }
        
    }
    
}
