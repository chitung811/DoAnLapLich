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
    public partial class Dailyplan : Form
    {
        public string filePath = "data.xml";

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private PlanData job;

        public PlanData Job
        {
            get { return job; }
            set { job = value; }
        }

        FlowLayoutPanel fPanel = new FlowLayoutPanel();

        public Dailyplan(DateTime date, PlanData job)
        {
            InitializeComponent();

            this.Date = date;
            this.Job = job;

            fPanel.Width = pnlJob.Width;
            fPanel.Height = pnlJob.Height;

            pnlJob.Controls.Add(fPanel); 
            dateTimePicker1.Value = Date;
        }

        private void Dailyplan_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void ShowJobByDate(DateTime date)
        {
            fPanel.Controls.Clear(); 
            if (Job != null && Job.Job != null)
            {
                List<PlanItem> todayJob = GetJobByDate(date);
                for (int i = 0; i < todayJob.Count; i++)
                {
                    AddJob(todayJob[i]);
                }
            }
        }

        void AddJob(PlanItem job)
        {
            AJob aJob = new AJob(job);
            aJob.Edited += aJob_Edited;
            aJob.Deleted += aJob_Deleted;

            fPanel.Controls.Add(aJob);
        }

        private void aJob_Deleted(object sender, EventArgs e)
        {
            AJob userControl = sender as AJob;
            PlanItem job = userControl.Job;

            fPanel.Controls.Remove(userControl);
            Job.Job.Remove(job);
        }

        private void aJob_Edited(object sender, EventArgs e)
        {
            
        }

        List<PlanItem> GetJobByDate(DateTime date)
        {
            return Job.Job.Where(p => p.Date.Year == date.Year && p.Date.Month == date.Month && p.Date.Day == date.Day).ToList();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ShowJobByDate((sender as DateTimePicker).Value);
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
        }

        private void btnPreviousDay_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(-1);
        }

        private void mnsiAddJob_Click(object sender, EventArgs e)
        {
            PlanItem item = new PlanItem() { Date = dateTimePicker1.Value};
            Job.Job.Add(item);
            AddJob(item);
        }

        private void mnsiToDay_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now; 
        }
    }
}
   