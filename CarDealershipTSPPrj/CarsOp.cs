using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDealershipTSPPrj
{
    public partial class CarsOp : Form
    {
        public CarsOp()
        {
            InitializeComponent();
            DisplayData();
        }


        Connection connect = new Connection();
        
        private void DisplayData()
        {
            string mySelect = "select * from Koli";
            DataTable dt = connect.DTCon(mySelect);
            dataGridView1.DataSource = dt;
            connect.ConClose();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Cars car = new Cars();
            car.RegNumber = textBox1.Text;
            car.BrandsID = (comboBox1.SelectedIndex+1).ToString();
            car.YearOfProduction = textBox2.Text;
            car.Price = textBox3.Text;
            car.ColorsID = (comboBox2.SelectedIndex+1).ToString();
            connect.InsertCars(car);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cars car = new Cars();
            car.RegNumber = textBox1.Text;
            car.CarsID = textBox4.Text;
            connect.UpdateCars(car);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cars car = new Cars();
            car.CarsID = textBox4.Text;
            connect.DeleteCars(car);
        }

        private void CarsOp_Load(object sender, EventArgs e)
        {

        }
    }
}
