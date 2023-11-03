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
    public partial class ClientOps : Form
    {
        public ClientOps()
        {
            InitializeComponent();
            DisplayData();
        }
        Connection connect = new Connection();
        private void ClientOps_Load(object sender, EventArgs e)
        {

        }
        private void DisplayData()
        {
            string mySelect = "select * from Clints";
            DataTable dt = connect.DTCon(mySelect);
            dataGridView1.DataSource = dt;
            connect.ConClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clients client = new Clients();
            client.EGN = textBox2.Text;
            client.CName = textBox3.Text;
            client.Address = textBox4.Text;
            client.PhoneNumber = textBox5.Text;
            connect.InsertClients(client);
            dataGridView1.DataSource = null;
            DisplayData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clients client = new Clients();
            client.ClientsID = textBox1.Text;
            client.EGN = textBox2.Text;
            client.CName = textBox3.Text;
            client.Address = textBox4.Text;
            client.PhoneNumber = textBox5.Text;
            connect.UpdateClients(client);
            dataGridView1.DataSource = null;
            DisplayData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clients client = new Clients();
            client.ClientsID = textBox1.Text;
            connect.DeleteClients(client);
            dataGridView1.DataSource = null;
            DisplayData();
        }
    }
}
