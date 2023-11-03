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
    public partial class FrmClients : Form
    {
        public FrmClients()
        {
            InitializeComponent();
        }
        Connection connect = new Connection();
        private void DisplayData1()
        {
            string mySelect = "SELECT Clints.CName, Clints.EGN, Clints.PhoneNumber, Clints.Address FROM Clints;";
            DataTable dt = connect.DTCon(mySelect);
            dataGridView1.DataSource = dt;
            connect.ConClose();
        }
        private void DisplayData2()
        {
            string mySelect = "SELECT Koli.RegNumber, Brands.BrandName, Koli.Price, Sales.SaleDate, Clints.CName " +
                "FROM Brands INNER JOIN  (Clints INNER JOIN (Koli INNER JOIN Sales ON Koli.KoliID = Sales.KoliID) " +
                "ON Clints.ClientsID = Sales.ClinetsID) ON Brands.BrandsID = Koli.BrandsID"
                + " WHERE Clints.CName='"+textBox1.Text +"';";
            DataTable dt = connect.DTCon(mySelect);
            dataGridView2.DataSource = dt;
            connect.ConClose();
        }
        private void FrmClients_Load(object sender, EventArgs e)
        {
            DisplayData1();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayData2();
        }
    }
}
