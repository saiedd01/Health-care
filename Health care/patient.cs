using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Health_care
{
    public partial class patient : Form
    {
        Function Con;
        public patient()
        {
            InitializeComponent();
            Con = new Function();
            ShowPatients();
        }
        private void ShowPatients()
        {
            string Query = "Select * from PatientTbl" ;
            PatientsListView.DataSource = Con.GetData(Query);
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PatNameTb.Text == "" || PatPhoneTb.Text == "" ||PatAddTb.Text=="" || PatGenCb.SelectedIndex==-1)
            {
                MessageBox.Show("Missing Data !!!!"); 
            }
            else
            {
                string patient = PatNameTb.Text;
                string address = PatAddTb.Text;
                string phone = PatPhoneTb.Text;
                string Gender = PatGenCb.SelectedItem.ToString();
                string bDate = PatBDD.Value.Date.ToString();
            }
        }
    }
}
