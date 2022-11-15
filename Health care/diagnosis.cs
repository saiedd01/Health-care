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
    public partial class diagnosis : Form
    {
        Function Con;
        public diagnosis()
        {
            InitializeComponent();
            Con = new Function();
            Getpatients();
            GetTests();
            ShowDiagnosis();
        }
        private void Getcost()
        {
            string Query = "select * from TestTbl where TestCode = {0}";
            Query = string.Format(Query, testCb.SelectedValue.ToString());
            foreach(DataRow dr in Con.GetData(Query).Rows)
            {
                costTb.Text = dr["TestCost"].ToString();

            }

        }

        private void Getpatients()
        {
            string Query = "select * from PatientTbl";
            patientCb.DisplayMember = Con.GetData(Query).Columns["PatName"].ToString();
            patientCb.ValueMember = Con.GetData(Query).Columns["PatCode"].ToString();
            patientCb.DataSource = Con.GetData(Query);
        }

        private void GetTests()
        {
            string Query = "select * from TestTbl";
            testCb.DisplayMember = Con.GetData(Query).Columns["testName"].ToString();
            testCb.ValueMember = Con.GetData(Query).Columns["testCode"].ToString();
            testCb.DataSource = Con.GetData(Query);
        }


        private void clear()
        {
            costTb.Text = "";
            patientCb.SelectedIndex = -1;
            testCb.SelectedIndex = -1;
            ResultTb.Text = "";
        }
        private void diagnosis_Load(object sender, EventArgs e)
        {

        }
        private void ShowDiagnosis()
        {
            string Query = "Select * from PatientTbl";
            DiagnosisListView.DataSource = Con.GetData(Query);
            
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (patientCb.SelectedIndex == -1 || costTb.Text == "" || ResultTb.Text == "" )
            {
                MessageBox.Show("Missing Data !!!!");
            }
            else
            {
                string DDate = DiagDateTb.Value.Date.ToString("yyyy-MM-dd");
                int patient = Convert.ToInt32(patientCb.SelectedValue.ToString());
                int test = Convert.ToInt32(testCb.SelectedValue.ToString());
                int cost = Convert.ToInt32(costTb.Text);
                string Result = ResultTb.Text;
                string Query = "insert into DiadnosisTbl values ('{0}','{1}','{2}','{3}','{4}')";
                Query = string.Format(Query, DDate, patient, test, cost, Result);
                Con.SetData(Query);
                ShowDiagnosis();
                clear();
                MessageBox.Show("Diagnosis Added");
            }
        }

        private void testCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Getcost();
        }
        int key = 0;

        private void DiagnosisListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DiagDateTb.Text = DiagnosisListView.SelectedRows[0].Cells[1].Value.ToString();
            patientCb.SelectedItem = DiagnosisListView.SelectedRows[0].Cells[2].Value.ToString();
            testCb.SelectedItem = DiagnosisListView.SelectedRows[0].Cells[3].Value.ToString();
            costTb.Text = DiagnosisListView.SelectedRows[0].Cells[4].Value.ToString();
            ResultTb.Text = DiagnosisListView.SelectedRows[0].Cells[5].Value.ToString();
            if (costTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DiagnosisListView.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Test !!!!");
            }
            else
            {
                string Query = "Delete from DiadnosisTbl where DiagCode = {0} ";
                Query = string.Format(Query, key);
                Con.SetData(Query);
                ShowDiagnosis();
                clear();
                MessageBox.Show("Diadnosis Delete");
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (patientCb.SelectedIndex == -1 || costTb.Text == "" || ResultTb.Text == "")
            {
                MessageBox.Show("Missing Data !!!!");
            }
            else
            {
                string DDate = DiagDateTb.Value.Date.ToString("yyyy-MM-dd");
                int patient = Convert.ToInt32(patientCb.SelectedValue.ToString());
                int test = Convert.ToInt32(testCb.SelectedValue.ToString());
                int cost = Convert.ToInt32(costTb.Text);
                string Result = ResultTb.Text;
                string Query = "Update DiadnosisTbl set values DiagDate ='{0}',patient ='{1}',Test = '{2}', Cost= '{3}',Result = '{4}' where DiagCode = {5}";
                Query = string.Format(Query, DDate, patient, test, cost, Result,key);
                Con.SetData(Query);
                ShowDiagnosis();
                clear();
                MessageBox.Show("Diagnosis Added");
            }
        }
    }
}
