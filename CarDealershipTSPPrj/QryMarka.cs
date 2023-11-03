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
    public partial class QryMarka : Form
    {
        public QryMarka()
        {
            InitializeComponent();
        }
        Connection connect = new Connection();
        private void DisplayData()
        {
            string mySelect = "SELECT Koli.RegNumber, Brands.BrandName, Koli.Price, Sales.SaleDate, Clints.CName " +
                "FROM Brands INNER JOIN  (Clints INNER JOIN (Koli INNER JOIN Sales ON Koli.KoliID = Sales.KoliID) " +
                "ON Clints.ClientsID = Sales.ClinetsID) ON Brands.BrandsID = Koli.BrandsID"
                + " WHERE Brands.BrandName = 'Mercedes' AND Koli.YearOfProduction< " + textBox1.Text + ";";
            DataTable dt = connect.DTCon(mySelect);
            dataGridView1.DataSource = dt;
            connect.ConClose();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DisplayData();
        }
    }
}
