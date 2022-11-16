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
        private void Clear()
        {
            PatNameTb.Text = "";
            PatGenCb.SelectedIndex = -1;
            PatPhoneTb.Text = "";
            PatAddTb.Text = "";
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
                string Gender = PatGenCb.SelectedItem.ToString();
                string bDate = PatBDD.Value.Date.ToString("yyyy-MM-dd");
                string phone = PatPhoneTb.Text;
                string address = PatAddTb.Text; 
                string Query = "insert into PatientTbl values ('{0}','{1}','{2}','{3}','{4}')";
                Query = string.Format(Query, patient, Gender, bDate, phone, address);
                Con.SetData(Query);
                ShowPatients();
                Clear();
                MessageBox.Show("Patient Added");
            }
        }
        int key = 0;
        private void PatientsListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatNameTb.Text = PatientsListView.SelectedRows[0].Cells[1].Value.ToString();
            PatGenCb.SelectedItem = PatientsListView.SelectedRows[0].Cells[2].Value.ToString();
            PatBDD.Text = PatientsListView.SelectedRows[0].Cells[3].Value.ToString();
            PatPhoneTb.Text = PatientsListView.SelectedRows[0].Cells[4].Value.ToString();
            PatAddTb.Text = PatientsListView.SelectedRows[0].Cells[5].Value.ToString();
            if (PatNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PatientsListView.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if(PatNameTb.Text == "" || PatPhoneTb.Text == "" || PatAddTb.Text == "" || PatGenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data !!!!");
            }
            else
            {
                string patient = PatNameTb.Text;
                string Gender = PatGenCb.SelectedItem.ToString();
                string bDate = PatBDD.Value.Date.ToString("yyyy-MM-dd");
                string phone = PatPhoneTb.Text;
                string address = PatAddTb.Text;
                string Query = "Update PatientTbl set PatName ='{0}', PatGen ='{1}',PatBDD= '{2}',PatPhone = '{3}',PatAdd ='{4}' where PatCode = {5}";
                Query = string.Format(Query, patient, Gender, bDate, phone, address,key);
                Con.SetData(Query);
                ShowPatients();
                Clear();
                MessageBox.Show("Patient Updated");
            }
        }
        
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key==0)
            {
                MessageBox.Show("Select a Patient");
            }
            else
            {
                string Query = "Delete from PatientTbl where PatCode = {0}";
                Query = string.Format(Query, key);
                Con.SetData(Query);
                ShowPatients();
                Clear();
                MessageBox.Show("Patient Deleted");
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Login logform = new Login();
            logform.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            tests TSform = new tests();
            TSform.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            diagnosis Diagform = new diagnosis();
            Diagform.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Login logform = new Login();
            logform.Show();
            this.Hide();
        }
    }
}
