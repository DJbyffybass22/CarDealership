using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDealershipTSPPrj
{
    public partial class InqCars : Form
    {
        public InqCars()
        {
            InitializeComponent();
        }
        Connection connect = new Connection();

        private void DisplayData()
        {
            string mySelect = "SELECT Koli.KoliID, Koli.RegNumber, Brands.BrandName, Koli.YearOfProduction, Koli.Price, Colors.Color" +
                " FROM Colors INNER JOIN(Brands INNER JOIN Koli ON Brands.BrandsID = Koli.BrandsID) ON Colors.ID = Koli.ColorsID;";
            DataTable dt = connect.DTCon(mySelect);
            dataGridView1.DataSource = dt;
            connect.ConClose();
        }
        private void InqCars_Load(object sender, EventArgs e)
        {
            DisplayData();
        }
        private void DisplayColorData()
        {
            string mySelect = "SELECT Koli.KoliID, Koli.RegNumber, Brands.BrandName, Koli.YearOfProduction, Koli.Price, Colors.Color" +
                " FROM Colors INNER JOIN(Brands INNER JOIN Koli ON Brands.BrandsID = Koli.BrandsID) ON Colors.ID = Koli.ColorsID" +
                " WHERE Colors.ID=" + (comboBox2.SelectedIndex + 1).ToString() + ";";
            DataTable dt = connect.DTCon(mySelect);
            dataGridView1.DataSource = dt;
            connect.ConClose();
        }
        private void DisplayBrandData()
        {
            string mySelect = "SELECT Koli.KoliID, Koli.RegNumber, Brands.BrandName, Koli.YearOfProduction, Koli.Price, Colors.Color" +
                " FROM Colors INNER JOIN(Brands INNER JOIN Koli ON Brands.BrandsID = Koli.BrandsID) ON Colors.ID = Koli.ColorsID" +
                " WHERE Brands.BrandsID="+(comboBox1.SelectedIndex+1).ToString() +";";
            DataTable dt = connect.DTCon(mySelect);
            dataGridView1.DataSource = dt;
            connect.ConClose();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayColorData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayBrandData();
        }
    }
}
