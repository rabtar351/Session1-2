using System.Collections.ObjectModel;
using System.Net.Http;
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
using Newtonsoft.Json;
using WpfApp3.Models;
using WpfApp3.Views;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ObservableCollection<EmployeeModel>? EmployeeList {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        public async Task LoadDataAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("https://localhost:7260/api/v1/Employee");
                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();
                    EmployeeList = JsonConvert.DeserializeObject<ObservableCollection<EmployeeModel>>(content);
                    ListViewEmployee.ItemsSource = EmployeeList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button != null)
            {
                if (button.Name == "btn1")
                {
                    ListViewEmployee.ItemsSource = EmployeeList;
                    return;
                }

                ListViewEmployee.ItemsSource = EmployeeList.Where(p => p.DepartmentName.Contains(button.Content.ToString())).ToList();
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadDataAsync();
        }

        private  void ListViewEmployee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var selectedEmployee = ListViewEmployee.SelectedItem as EmployeeModel;

                if (selectedEmployee == null) throw new Exception("Выберите сотрудника");

                var win = new CardEmployeeWindow(selectedEmployee);
                win.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}