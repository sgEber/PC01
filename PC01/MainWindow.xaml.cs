using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data.SqlClient;
using System.Data;

namespace PC01
{
 
    public partial class MainWindow : Window
    {
        private DataTable ProductsTable;
        private DataTable CategoriesTable;
        private DataTable suppliersTable;
        public MainWindow()
        {
            InitializeComponent();
            ProductsTable = new DataTable();
            CategoriesTable = new DataTable();
            suppliersTable = new DataTable();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string connectionString = "Data Source=LAB1504-31\\SQLEXPRESS; Initial Catalog=NeptunoDB;User Id=eber; Password=123456;";
            string uspp = "USP_ListarProductos";

            try {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(uspp, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(ProductsTable);

                connection.Close();

                productos.ItemsSource = ProductsTable.DefaultView;
            } catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAB1504-31\\SQLEXPRESS; Initial Catalog=NeptunoDB;User Id=eber; Password=123456;";
            string uspc = "USP_ListarCategorias";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(uspc, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(CategoriesTable);

                connection.Close();

                categorias.ItemsSource = CategoriesTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAB1504-31\\SQLEXPRESS; Initial Catalog=NeptunoDB;User Id=eber; Password=123456;";
            string uspd = "USP_ListarProovedores";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(uspd, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(suppliersTable);

                connection.Close();

                proveedores.ItemsSource = suppliersTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}