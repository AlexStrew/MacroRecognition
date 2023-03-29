using Newtonsoft.Json;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MacroRecognotionWPF.API {

    public class MyApiDataLoader : IDisposable {

        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://192.168.0.41/api/";
        private bool _disposed;

        public MyApiDataLoader() {
            _httpClient = new HttpClient();
        }

        


        public void Dispose() {
            if (!_disposed) {
                _httpClient.Dispose();
                _disposed = true;
            }
        }

    }
}
