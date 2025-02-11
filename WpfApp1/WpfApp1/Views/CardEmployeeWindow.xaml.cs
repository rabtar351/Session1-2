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
using Newtonsoft.Json;
using WpfApp1.Models;

namespace WpfApp1.Views
{
    /// <summary>
    /// Логика взаимодействия для CardEmployeeWindow.xaml
    /// </summary>
    public partial class CardEmployeeWindow : Window
    {
        private static bool isEdit { get; set; } = false;
        private static int idEmployee;
        public CardEmployeeWindow(EmployeeModel employee)
        {
            InitializeComponent();
            idEmployee = employee.EmployeeId;
            LoadEmployeeData(employee);
            LoadDataDepartament();
            LoadDataPosition();
            LoadDataEmployee();
        }

        public void LoadEmployeeData(EmployeeModel employee)
        {
            txbEmail.Text = employee.Email;
            txbFirstName.Text = employee.FirstName;
            txbLastName.Text = employee.LastName;
            txbPatronymic.Text = employee.Patronymic;
            txbMobilePhone.Text = employee.MobilePhone;
            txbOffice.Text = employee.Office;
            txbWorkPhone.Text = employee.WorkPhone;
            txbInfo.Text = employee.AdditionalInfo;
            dpDateBirth.Text = employee.BirthDate.ToString();
        }

        public async  Task LoadDataDepartament()
        {
            try
            {
                // Полученние данных отделов с последующей записей их в combobox
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("https://localhost:7192/api/v1/Department");
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

        public async Task LoadDataPosition()
        {
            try
            {
                // Полученние данных должностей с последующей записей их в combobox
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("https://localhost:7192/api/v1/Position");
                    var content = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<List<PositionModel>>(content);
                    cmbPosition.ItemsSource = list;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public async Task LoadDataEmployee()
        {
            try
            {
                // Получение данных сотрудников с последующей записей их в combobox
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("https://localhost:7192/api/v1/Employee");
                    var content = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<List<EmployeeModel>>(content);
                    cmbDirector.ItemsSource = list;
                    cmbAssistent.ItemsSource = list;
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
            var selectedAssistent = cmbAssistent.SelectedItem as EmployeeModel;

            var selectedDepartament = cmbDepartment.SelectedItem as DepartmentModel;
            var selectedPosition = cmbPosition.SelectedItem as PositionModel;

            // Проверка выбран ли директор и ассистент
            if (selectedDirector == null || selectedAssistent == null || selectedDepartament == null || selectedPosition == null)
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }

            // Проверка выбрана ли дата рождения 
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
                MobilePhone = txbMobilePhone.Text,
                BirthDate = DateOnly.Parse(dpDateBirth.Text),
                DepartmentId = selectedDepartament.DepartmentId,
                DepartmentName = selectedDepartament.DepartmentName,
                PositionId = selectedPosition.PositionId,
                PositionName = selectedPosition.PositionName,
                SupervisorId = selectedDirector.SupervisorId,
                AssistentId = selectedAssistent.DepartmentId,
                WorkPhone = txbWorkPhone.Text,
                Email = txbEmail.Text,
                Office = txbOffice.Text,
                EmployeeId = idEmployee
            };
            var json = JsonConvert.SerializeObject(employee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), "https://localhost:7192/api/v1/Employee")
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
                gridBlock1.IsEnabled = true;
                gridBlock2.IsEnabled = true;
                isEdit = true;
            }
            else
            {
                gridBlock1.IsEnabled = false;
                gridBlock2.IsEnabled = false;
                isEdit = false;
            }
        }
    }
}
