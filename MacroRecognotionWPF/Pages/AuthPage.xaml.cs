using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json.Linq;
using MacroRecognotionWPF.API;
using MacroRecognotionWPF.ViewModel;
using System.Net;
using Syncfusion.Windows.Shared;
using System.Configuration;

namespace MacroRecognotionWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private readonly HttpClient _client;

        public AuthPage()
        {
            InitializeComponent();
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            int year = DateTime.Now.Year;
            YearBlock.Text = year.ToString();
            CheckConnectionServer();
        }

       

        private async void CheckConnectionServer() {

            // Проверяем доступность сайта
            try {
                var response = await _client.GetAsync("http://192.168.0.41/api/DamaskClasses");
                if (response.IsSuccessStatusCode) {
                    ellipse.Fill = Brushes.Green;
                }
                else {
                    ellipse.Fill = Brushes.Red;
                }
            }
            catch (Exception) {

                throw;
            }
            
        }
        

        private async void LoginBtnClick(object sender, RoutedEventArgs e)
        {


            // Получите имя пользователя и пароль из соответствующих текстовых полей:
            string username = loginBox.Text;
            string password = passwordBox.Password;

            // Проверьте, выбран ли флажок "Сохранить пароль":
            bool savePassword = SavePasswordCheckBox.IsChecked ?? false;

            // Если флажок установлен, сохраните пароль в параметры приложения:
            if (savePassword) {
                Properties.Settings.Default.Username = username;
                Properties.Settings.Default.Password = password;
                Properties.Settings.Default.Save();
            }


            var values = new Dictionary<string, string>
            {
                { "username", loginBox.Text },
                { "password", passwordBox.Password }
            };

            var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");


            var response = await _client.PostAsync("http://192.168.0.41/api/Users/login", content);
            var responseUpdate = await _client.GetAsync("http://192.168.0.41/api/DamaskClasses/update");

            await Console.Out.WriteLineAsync(response.ToString());
            if (response.IsSuccessStatusCode && responseUpdate.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                this.NavigationService.Navigate(new MainPage());
            }
            else
            {
                MessageBox.Show("Проверьте логин/пароль", "Error", MessageBoxButton.OK);
            }

            
          
        }



    
        private void Page_Loaded(object sender, RoutedEventArgs e) {
            // Загрузите сохраненные значения параметров:
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Username)) {
                loginBox.Text = Properties.Settings.Default.Username;
            }

            if (!string.IsNullOrEmpty(Properties.Settings.Default.Password)) {
                passwordBox.Password = Properties.Settings.Default.Password;
                SavePasswordCheckBox.IsChecked = true;
            }
        }

        private void CheckConUpd_Click(object sender, RoutedEventArgs e) {
            CheckConnectionServer();
        }
    }
}
