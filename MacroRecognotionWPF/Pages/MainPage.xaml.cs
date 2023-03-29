using HandyControl.Controls;
using MacroRecognotionWPF.ViewModel;
using Newtonsoft.Json;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
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
using static MacroRecognotionWPF.API.Models;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Converter;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System.Data.SqlClient;
using System.ComponentModel;
using Syncfusion.XPS;
using MacroRecognotionWPF.API;
using System.Drawing.Printing;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Syncfusion.Windows.Shared;
using HandyControl.Tools;
using HandyControl.Tools.Extension;
using SolidColorBrush = System.Windows.Media.SolidColorBrush;

namespace MacroRecognotionWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private int _pageNumber = 1;
        private int _pageSize = 20;


        private MyApiDataLoader _dataLoader = new MyApiDataLoader();

        public ObservableCollection<DamaskClass> DamaskCollection { get; set; }
        private ObservableCollection<DamaskClass> source;
        public MainPage()
        {
            InitializeComponent();
            
            DataContext = this;
            AwaitDataLoad();
            ConfigHelper.Instance.SetLang("ru");

            //dataPager.OnDemandLoading += dataPager_OnDemandLoading;
        }

        private void dataPager_OnDemandLoading(object sender, Syncfusion.UI.Xaml.Controls.DataPager.OnDemandLoadingEventArgs args) {

        }

        private async Task AwaitDataLoad() {
            BusyBar.IsBusy = true;
            await LoadData();
            BusyBar.IsBusy = false;
        }


        public int PageNumber {
            get => _pageNumber;
            set {
                _pageNumber = value;
                //OnPropertyChanged();
                LoadData();
            }
        }
        private async Task LoadData() {
            using (var httpClient = new HttpClient()) {
                using (var response = await httpClient.GetAsync($"http://192.168.0.41/api/DamaskClasses/test?pageNumber={PageNumber}&pageSize=25")) {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    DamaskCollection = JsonConvert.DeserializeObject<ObservableCollection<DamaskClass>>(apiResponse);
                    sfDataGrid.ItemsSource = DamaskCollection;
                }
            }
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private static void ExportingHandler(object sender, GridExcelExportingEventArgs e) {

            if (e.CellType == ExportCellType.HeaderCell) {
                e.CellStyle.BackGroundBrush = new SolidColorBrush(Colors.LightSkyBlue);
                e.CellStyle.ForeGroundBrush = new SolidColorBrush(Colors.White);
                e.Handled = true;
            }

        }
        private void SaveToExcel_Click(object sender, RoutedEventArgs e)
        {

            var options = new ExcelExportingOptions();
            options.ExportingEventHandler = ExportingHandler;
            options.AllowOutlining = true;
            var excelEngine = sfDataGrid.ExportToExcel(sfDataGrid.View, options);
            var workBook = excelEngine.Excel.Workbooks[0];
           

            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog {
                FilterIndex = 2,
                Filter = "Excel 97 to 2003 Files(*.xls)|*.xls|Excel 2007 to 2010 Files(*.xlsx)|*.xlsx|Excel 2013 File(*.xlsx)|*.xlsx"
            };

            if (sfd.ShowDialog() == true) {
                using (Stream stream = sfd.OpenFile()) {

                    if (sfd.FilterIndex == 1)
                        workBook.Version = ExcelVersion.Excel97to2003;

                    else if (sfd.FilterIndex == 2)
                        workBook.Version = ExcelVersion.Excel2010;

                    else
                        workBook.Version = ExcelVersion.Excel2016;
                    workBook.SaveAs(stream);
                }

                //Message box confirmation to view the created workbook.

                if (System.Windows.MessageBox.Show("ok", "Книга создана",
                                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes) {

               
                
                }
            }
        }

        //private void LoadDataButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var vm = new RecognitViewModel();
        //    vm.GetData();
        //    this.DataContext = vm;
            
        //}


        private async void ClearSearchButton_Click(object sender, RoutedEventArgs e)
        {
            await LoadData();
            this.sfDataGrid.SearchHelper.ClearSearch();
            SearchTBox.Clear();
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchTBox.Text != String.Empty || !String.IsNullOrWhiteSpace(SearchTBox.Text)) {
                var searchRequest = SearchTBox.Text;
                using HttpClient client = new HttpClient();
                var response = await client.GetAsync($"http://192.168.0.41/api/DamaskClasses/search?searchQuery={searchRequest}");
                var json = await response.Content.ReadAsStringAsync();
                var searchResults = JsonConvert.DeserializeObject<List<DamaskClass>>(json);

                sfDataGrid.ItemsSource = searchResults;

            }
            else {
              
                Console.WriteLine(_pageNumber);
                BusyBar.IsBusy = true;
                using (var httpClient = new HttpClient()) {
                    using (var response = await httpClient.GetAsync($"http://192.168.0.41/api/DamaskClasses/test?pageNumber=1&pageSize=25")) {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        DamaskCollection = JsonConvert.DeserializeObject<ObservableCollection<DamaskClass>>(apiResponse);
                        sfDataGrid.ItemsSource = DamaskCollection;
                    }
                }
                BusyBar.IsBusy = false;
                PageLabel.Content = _pageNumber.ToString();
                this.NavigationService.Refresh();
            }


            this.sfDataGrid.SearchHelper.AllowFiltering = true;
            this.sfDataGrid.SearchHelper.Search(SearchTBox.Text);
        }



        private async Task DeleteData(int id)
        {
            string requestUrl = $"http://192.168.0.41/api/TruckDetections/{id}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    //smth
                }
                else
                {
                    HandyControl.Controls.MessageBox.Show("Строка не найдена", "Выберите нужную строку", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        private ObservableCollection<NumMain> _deleteRow = new ObservableCollection<NumMain>();
        private async void OnDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранную строку
            NumMain selectedData = (NumMain)sfDataGrid.SelectedItem;
            if (selectedData != null)
            {
                MessageBoxResult result = HandyControl.Controls.MessageBox.Show("Вы действительно хотите удалить запись?", "AHTUNG", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    int id = selectedData.idReco; // Получаем идентификатор записи
                    await DeleteData(id); // Вызываем метод удаления данных
                    sfDataGrid.View.Remove(selectedData);
                    _deleteRow.Remove(selectedData); // Удаляем данные из источника данных DataGrid
                    sfDataGrid.View.Refresh();
                }
                
                
            }
        }

        private async void PrevButton_Click(object sender, RoutedEventArgs e) {
            if(_pageNumber == 0 ) {
                PrevButton.IsEnabled = false;
            }
            else {
                _pageNumber--;

                BusyBar.IsBusy = true;
                await LoadData();
                BusyBar.IsBusy = false;
                PageLabel.Content = _pageNumber.ToString();
            }
            
            
        }
        private async void NextButton_Click(object sender, RoutedEventArgs e) {
            if (_pageNumber == 1) {
                PrevButton.IsEnabled = true;
            }
            _pageNumber++;
           
            BusyBar.IsBusy = true;
            await LoadData();
            BusyBar.IsBusy = false;
            PageLabel.Content = _pageNumber.ToString();
        }

        public async Task StartLongRunningTask(Func<Task> LoadData) {
            BusyBar.IsBusy = true;
            await LoadData();
            PageLabel.Content = _pageNumber.ToString();
            BusyBar.IsBusy = false;
        }

        private async void FilterByDateButton_Click(object sender, RoutedEventArgs e) {
            
            using (var httpClient = new HttpClient()) {
                using (var response = await httpClient.GetAsync($"http://192.168.0.41/api/DamaskClasses/betweenDates?startDate={StartDate.Text}&endDate={EndDate.Text}")) {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    DamaskCollection = JsonConvert.DeserializeObject<ObservableCollection<DamaskClass>>(apiResponse);
                    sfDataGrid.ItemsSource = DamaskCollection;
                }
            }
          
            
        }

        private async void ResetTableButton_Click(object sender, RoutedEventArgs e) {
            await LoadData();
            this.sfDataGrid.SearchHelper.ClearSearch();
            SearchTBox.Clear();
        }
    }
}
