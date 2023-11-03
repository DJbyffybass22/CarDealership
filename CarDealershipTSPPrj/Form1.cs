using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace CarDealershipTSPPrj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarsOp carsOp = new CarsOp();
            carsOp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientOps clientOps = new ClientOps();
            clientOps.Show();
        }

        
        Connection connect = new Connection();
        private void DisplayData()
        {
            string mySelect = "SELECT Sales.SalesID, Clints.CName, Clints.EGN, Clints.PhoneNumber, Clints.Address," +
                " Sales.SaleDate, Koli.RegNumber, Brands.BrandName, Koli.YearOfProduction, Koli.Price, Colors.Color " +
                "FROM Clints INNER JOIN(Brands INNER JOIN (Colors INNER JOIN (Koli INNER JOIN Sales ON Koli.KoliID = Sales.KoliID)" +
                " ON Colors.ID = Koli.ColorsID) ON Brands.BrandsID = Koli.BrandsID) ON Clints.ClientsID = Sales.ClinetsID;";
            DataTable dt = connect.DTCon(mySelect);
            dataGridView1.DataSource = dt;
            connect.ConClose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // DisplayData();
        }

        private void markaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QryMarka qryMarka = new QryMarka();
            qryMarka.Show();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClients frmClients = new FrmClients();
            frmClients.Show();
        }

        private void carsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InqCars inqCars = new InqCars();
            inqCars.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
