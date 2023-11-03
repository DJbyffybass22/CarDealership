using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Threading.Tasks;

namespace CarDealershipTSPPrj
{
    class Connection
    {
        OleDbConnection connect;
        OleDbCommand command;
        private void ConnectionTo()
        {
            connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\byffe\Documents\Car dealership.accdb");
            command = connect.CreateCommand();
        }

        public Connection()
        {
            ConnectionTo();
        }

        public DataTable DTCon(string mySelect)
        {
            connect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(mySelect, connect);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            return dt;
        }
        public void ConClose()
        {
            connect.Close();
        }


        public void InsertCars(Cars cars)
        {
            try
            {
                command.CommandText = "Insert into Koli(RegNumber, BrandsID, YearOfProduction, Price, ColorsID)Values('"
                    + cars.RegNumber + "'," + cars.BrandsID + "," + cars.YearOfProduction + "," + cars.Price + "," + cars.ColorsID + ")";
                command.CommandType = CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data");

            }
            finally
            {
                if (connect != null)
                {
                    ConClose();
                }
            }
        }
        
        public void UpdateCars(Cars cars)
        {
            try
            {
                command.CommandText = "Update Koli Set RegNumber=" + cars.RegNumber + "Where KoliID=" + cars.CarsID;
                command.CommandType = CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data");
                throw;
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        public void DeleteCars(Cars cars)
        {
            try
            {
                command.CommandText = "Delete From Koli Where KoliID=" + cars.CarsID;
                command.CommandType = CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data");
                throw;
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }
        public void InsertClients(Clients clients)
        {
            try
            {
                command.CommandText = "Insert into Clints(EGN, CName, Address, PhoneNumber)Values("
                    + clients.EGN + ",'" + clients.CName + "','" + clients.Address + "'," + clients.PhoneNumber + ")";
                command.CommandType = CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data");
                throw;
            }
            finally
            {
                if (connect != null)
                {
                    ConClose();
                }
            }
        }
        public void UpdateClients(Clients clients)
        {
            try
            {
                command.CommandText = "Update Clints Set EGN=" + clients.EGN + ",CName='" + clients.CName + 
                    "',Address='" + clients.Address + "',PhoneNumber='" + clients.PhoneNumber + "'Where ClientsID="+clients.ClientsID;
                command.CommandType = CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data");
                throw;
            }
            finally
            {
                if (connect != null)
                {
                    ConClose();
                }
            }
        }
        public void DeleteClients(Clients clients)
        {
            try
            {
                command.CommandText = "Delete From Clints Where ClientsID=" + clients.ClientsID;
                command.CommandType = CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data");
                throw;
            }
            finally
            {
                if (connect != null)
                {
                    ConClose();
                }
            }
        }

    }
}
