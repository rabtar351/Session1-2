using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using Newtonsoft.Json;
using WpfApp3.Models;

namespace WpfApp3.Views
{
    /// <summary>
    /// Логика взаимодействия для CardEmployeeWindow.xaml
    /// </summary>
    public partial class CardEmployeeWindow : Window
    {
        private static bool isEdit {  get; set; } = false;
        private static int idEmployee;
        public CardEmployeeWindow(EmployeeModel employee)
        {
            InitializeComponent();
            idEmployee = employee.EmployeeId;
            LoadEmployeeData(employee);
            LoadDataDepartment();
            LoadDataEmployee();
            LoadDataPosition();
        }

        public  void LoadEmployeeData(EmployeeModel employee)
        {
            txbEmail.Text = employee.Email;
            txbInfo.Text = employee.AdditionalInfo;
            txbFirstName.Text = employee.FirstName;
            txbLastName.Text = employee.LastName;
            txbPatronymic.Text = employee.Patronymic;
            txbMobilePhone.Text = employee.MobilePhone;
            txbWorkPhone.Text = employee.WorkPhone;
            txbOffice.Text = employee.Office;
            dpDateBirth.Text = employee.BirthDate.ToString();
        }

        public async void LoadDataDepartment()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("https://localhost:7260/api/v1/Department");
                    var content = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<List<DepartmentModel>>(content);
                    cmbDepartment.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async void LoadDataPosition()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("https://localhost:7260/api/v1/Position");
                    var content = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<List<PositionModel>>(content);
                    cmbPositwon.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public async void LoadDataEmployee()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("https://localhost:7260/api/v1/Employee");
                    var content = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<List<EmployeeModel>>(content);
                    cmbDirector.ItemsSource = list;
                    cmbAssistest.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void btnEditSave_Click(object sender, RoutedEventArgs e)
        {
            var selectedDirector = cmbDirector.SelectedItem as EmployeeModel;
            var selectedAsistent = cmbAssistest.SelectedItem as EmployeeModel;

            var selectedDepartament = cmbDepartment.SelectedItem as DepartmentModel;
            var selectedPosition = cmbPositwon.SelectedItem as PositionModel;

            //проверка на пустые поля
            TextBox[] textBoxes = { txbEmail, txbInfo, txbFirstName, txbLastName, txbPatronymic, txbMobilePhone, txbWorkPhone, txbOffice };
            foreach (var textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show($"Все поля должны быть заполнены");
                    return;
                }
            }
            //проверка выбран ли директор и ассистент
            if (selectedDirector == null || selectedAsistent == null || selectedDepartament == null || selectedPosition == null)
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }

            //проверка выбрана ли дата рождения
            if (string.IsNullOrWhiteSpace(dpDateBirth.Text))
            {
                MessageBox.Show("Дата рождения не выбрана");
                return;
            }

            var employee = new EmployeeModel()
            {
                AdditionalInfo = txbInfo.Text,
                FirstName = txbFirstName.Text,
                LastName = txbLastName.Text,
                Patronymic = txbPatronymic.Text,
                Email = txbEmail.Text,
                AssistentId = selectedAsistent.EmployeeId,
                SupervisorId = selectedDirector.EmployeeId,
                Office = txbOffice.Text,
                BirthDate = DateOnly.Parse(dpDateBirth.Text),
                EmployeeId = idEmployee,
                MobilePhone = txbMobilePhone.Text,
                WorkPhone = txbWorkPhone.Text,
                PositionId = selectedPosition.PositionId,
                DepartmentId = selectedDepartament.DepartmentId,
                DepartmentName = selectedDepartament.DepartmentName,
                PositionName = selectedPosition.PositionName,
            };
            var json = JsonConvert.SerializeObject(employee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), "https://localhost:7260/api/v1/Employee")
                {
                    Content = content
                };

                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Данные сотрудника обновлены");

                }
            }
        }
        

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit == false)
            {
                gridBlock1.IsEnabled = false;
                gridBlock2.IsEnabled = false;
                isEdit = false;

                gridBlock1.IsEnabled = true;
                gridBlock2.IsEnabled = true;
                isEdit = true;
            }
        }

        private  void Window_Loaded(object sender, RoutedEventArgs e)
        {
             
        }
    }
}
