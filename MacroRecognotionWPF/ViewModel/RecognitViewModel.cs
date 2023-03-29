using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MacroRecognotionWPF.API;
using static MacroRecognotionWPF.API.Models;
using System.ComponentModel;

namespace MacroRecognotionWPF.ViewModel
{
    public class RecognitViewModel  {
        public ObservableCollection<DamaskClass> DataVM { get; set; }



        
    }
}
