using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mile_Stone_1
{
    public partial class BCview : Form
    {
        public BCview()
        {
            InitializeComponent();
        }

        BindingSource source = new BindingSource();  
      
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void BCview_Load(object sender, EventArgs e)
        {
            AllMethods allMethods = new AllMethods();
            source.DataSource = allMethods.displayStudent() ;
            dataGridView1.DataSource = source;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxSearch.Clear();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            StuNo_textBox.Clear();
            Name_textBox.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NametextBox.Clear();
            CelltextBox.Clear();
            GendertextBox.Clear();
            AdditextBox.Clear();
            StuNotextBox.Clear();
            CodestextBox.Clear();
            DOBtextBox.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            source.MovePrevious();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            source.MoveFirst();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            source.MoveNext();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            source.MoveLast();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            StudentForm stu = new StudentForm();
            stu.Show();
            this.Hide();
        }

        private void btnModule_Click(object sender, EventArgs e)
        {
            ModuleForm mod = new ModuleForm();
            mod.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string name = NametextBox.Text;
            string cell = CelltextBox.Text;
            string gender = GendertextBox.Text;
            string address = AdditextBox.Text;
            string student_no = StuNotextBox.Text;
            string codes = CodestextBox.Text;
            string dob = DOBtextBox.Text;
            string age = AgetextBox1.Text;

            AllMethods methods = new AllMethods();

            //Checking if anything is empty


            if (name.Equals("") || cell.Equals("") || gender.Equals("") || address.Equals("") || student_no.Equals("") ||
                codes.Equals("") || dob.Equals("") || age.Equals(""))
            {

            }
            else
            {

                methods.UpdateStudents(name, dob, gender, student_no, cell, address, codes, int.Parse(age));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AllMethods methods = new AllMethods();
            if (StuNo_textBox.Text.Equals(""))
            {
                MessageBox.Show("The text box is empty, please enter values");
            }
            else
            {
                methods.DeleteStudent(StuNo_textBox.Text);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            AllMethods allMethods = new AllMethods();
            if (textBoxSearch.Text.Equals(""))
            {
                MessageBox.Show("Please enter student number to search");
            }
            else
            {
                dataGridView1.DataSource = allMethods.Search(textBoxSearch.Text);
            }
        }
    }
}

