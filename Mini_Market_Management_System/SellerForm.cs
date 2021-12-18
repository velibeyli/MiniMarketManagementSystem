using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mini_Market_Management_System
{
    public partial class SellerForm : Form
    {
        DBConnect dbCon = new DBConnect();
        public SellerForm()
        {
            InitializeComponent();
        }

        private void button_seller_Click(object sender, EventArgs e)
        {
            ProductForm product = new ProductForm();
            product.Show();
            this.Hide();
        }

        private void button_category_Click(object sender, EventArgs e)
        {
            CategoryForm category = new CategoryForm();
            category.Show();
            this.Hide();
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Red;
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Goldenrod;
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_logout_MouseEnter(object sender, EventArgs e)
        {
            label_logout.ForeColor = Color.Red;
        }

        private void label_logout_MouseLeave(object sender, EventArgs e)
        {
            label_logout.ForeColor = Color.Goldenrod;
        }

        private void label_logout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void Clear()
        {
            TextBox_Id.Clear();
            TextBox_name.Clear();
            TextBox_age.Clear();
            TextBox_phone.Clear();
            TextBox_password.Clear();
        }
        private void GetTable()
        {
            string selectQuery = "SELECT * FROM Seller";
            SqlCommand command = new SqlCommand(selectQuery,dbCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView_seller.DataSource = table;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "INSERT INTO Seller VALUES("+TextBox_Id.Text+", '"+TextBox_name.Text+"', '"+TextBox_age.Text+"', '"+TextBox_phone.Text+"', '"+TextBox_password.Text+"')";
                SqlCommand command = new SqlCommand(insertQuery,dbCon.GetCon());
                dbCon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Seller Added Successfully", "Add information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                dbCon.CloseCon();
                GetTable();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_Id.Text == "" || TextBox_name.Text == "" || TextBox_age.Text == "" || TextBox_phone.Text == "" || TextBox_password.Text == "")
                {
                    MessageBox.Show("Missing Information" , "Warning!" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string updateQuery = "UPDATE Seller SET SellerName = '" + TextBox_name.Text + "' , SellerAge = '" + TextBox_age.Text + "', SellerPhone = '" + TextBox_phone.Text + "' , SellerPass = '" + TextBox_password.Text + "' WHERE SellerId = " + TextBox_Id.Text + "";
                    SqlCommand command = new SqlCommand(updateQuery, dbCon.GetCon());
                    dbCon.OpenCon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Seller Updated Successfully", "Update Seller", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbCon.CloseCon();
                    GetTable();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_seller_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TextBox_Id.Text = dataGridView_seller.SelectedRows[0].Cells[0].Value.ToString();
            TextBox_name.Text = dataGridView_seller.SelectedRows[0].Cells[1].Value.ToString();
            TextBox_age.Text = dataGridView_seller.SelectedRows[0].Cells[2].Value.ToString();
            TextBox_phone.Text = dataGridView_seller.SelectedRows[0].Cells[3].Value.ToString();
            TextBox_password.Text = dataGridView_seller.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_Id.Text == "")
                {
                    MessageBox.Show("Missing Information", "Missing Information", MessageBoxButtons.OK , MessageBoxIcon.Error);
                }
                else
                {
                    if ((MessageBox.Show("Are you sure to do this operation?" , "Delete record", MessageBoxButtons.YesNo,MessageBoxIcon.Question)) == DialogResult.Yes)
                    {
                        string deleteQuery = "DELETE FROM Seller WHERE SellerId = '" + TextBox_Id.Text + "'";
                        SqlCommand command = new SqlCommand(deleteQuery, dbCon.GetCon());
                        dbCon.OpenCon();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Seller Deleted Successfully", "Seller Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dbCon.CloseCon();
                        GetTable();
                        Clear();
                    }                    
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void SellerForm_Load(object sender, EventArgs e)
        {
            GetTable();
        }

        private void button_selling_Click(object sender, EventArgs e)
        {
            SellingForm selling = new SellingForm();
            selling.Show();
            this.Hide();
        }
    }
}
