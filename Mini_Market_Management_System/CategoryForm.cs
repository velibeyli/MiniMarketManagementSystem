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
    public partial class CategoryForm : Form
    {
        DBConnect dbCon = new DBConnect();
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void getTable()
        {
            string selectQuery = "SELECT * FROM Category";
            SqlCommand command = new SqlCommand(selectQuery, dbCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_category.DataSource = table;
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "INSERT INTO Category VALUES ("+TextBox_Id.Text+", '"+TextBox_name.Text+"', '"+TextBox_description.Text+"')";
                SqlCommand command = new SqlCommand(insertQuery, dbCon.GetCon());
                dbCon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Category Added Successfully","Add Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                dbCon.CloseCon();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            getTable();
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_Id.Text == "" || TextBox_name.Text == "" || TextBox_description.Text == "")
                {
                    MessageBox.Show("Missing information", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                string updateQuery = "UPDATE Category set CatName = '"+TextBox_name.Text+"', CatDes = '"+TextBox_description.Text+"' WHERE CatId = "+TextBox_Id.Text+" ";
                SqlCommand command = new SqlCommand(updateQuery, dbCon.GetCon());
                dbCon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Category Updated Successfully","Update Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                dbCon.CloseCon();
                getTable();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView_category_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView_category_Click(object sender, EventArgs e)
        {
            TextBox_Id.Text = DataGridView_category.SelectedRows[0].Cells[0].Value.ToString();
            TextBox_name.Text = DataGridView_category.SelectedRows[0].Cells[1].Value.ToString();
            TextBox_description.Text = DataGridView_category.SelectedRows[0].Cells[2].Value.ToString();
        }
        private void Clear()
        {
            TextBox_Id.Clear();
            TextBox_name.Clear();
            TextBox_description.Clear();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteQuery = "DELETE FROM Category WHERE CatId = " + TextBox_Id.Text + "";
                SqlCommand command = new SqlCommand(deleteQuery, dbCon.GetCon());
                dbCon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Category Deleted Successfully", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbCon.CloseCon();
                getTable();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Red;
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Goldenrod;
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

        private void button_product_Click(object sender, EventArgs e)
        {
            ProductForm product = new ProductForm();
            product.Show();
            this.Hide();
        }

        private void button_seller_Click(object sender, EventArgs e)
        {
            SellerForm seller = new SellerForm();
            seller.Show();
            this.Hide();
        }

        private void button_selling_Click(object sender, EventArgs e)
        {
            SellingForm selling = new SellingForm();
            selling.Show();
            this.Hide();
        }
    }
}
