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
    public partial class tests : Form
    {
        Function Con;
        public tests()
        {
            InitializeComponent();
            Con = new Function();
            ShowTest();
        }
        private void ShowTest()
        {
            string Query = "Select * from TestTbl";
            TestListView.DataSource = Con.GetData(Query);
        }
        private void Clear()
        {
            TestNameTb.Text = "";
            TestCostTb.Text = "";
        }
        private void tests_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (TestNameTb.Text == "" || TestCostTb.Text == "")
            {
                MessageBox.Show("Missing Data !!!!");
            }
            else
            {
                string test = TestNameTb.Text;
                int cost = Convert.ToInt32(TestCostTb.Text);
                string Query = "Update TestTbl set TestName = '{0}',TestCost '{1}' where TestCode = {2} ";
                Query = string.Format(Query, test, cost,key);
                Con.SetData(Query);
                ShowTest();
                Clear();
                MessageBox.Show("Test Updated");
            }
        }
        
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (TestNameTb.Text == "" || TestCostTb.Text == "")
            {
                MessageBox.Show("Missing Data !!!!");
            }
            else
            {
                string test = TestNameTb.Text;
                int cost = Convert.ToInt32(TestCostTb.Text);
                string Query = "insert into TestTbl values ('{0}','{1}')";
                Query = string.Format(Query, test, cost);
                Con.SetData(Query);
                ShowTest();
                Clear();
                MessageBox.Show("Test Added");
            }
        }
        int key = 0; 
        private void TestListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TestNameTb.Text = TestListView.SelectedRows[0].Cells[1].Value.ToString();
            TestCostTb.Text = TestListView.SelectedRows[0].Cells[2].Value.ToString();
            if (TestNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TestListView.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeletBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Test !!!!");
            }
            else
            {
                string test = TestNameTb.Text;
                int cost = Convert.ToInt32(TestCostTb.Text);
                string Query = "Delete from TestTbl where TestCode = {0} ";
                Query = string.Format(Query, key);
                Con.SetData(Query);
                ShowTest();
                Clear();
                MessageBox.Show("Test Delete");
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Login logform = new Login();
            logform.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Login logform = new Login();
            logform.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            patient PTform = new patient();
            PTform.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            diagnosis Diagform = new diagnosis();
            Diagform.Show();
            this.Hide();
        }
    }
}