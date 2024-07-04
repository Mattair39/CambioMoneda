using CambioMoneda.Models;
using CambioMoneda.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CambioMoneda
{
    public class CambioDivisasViewModel : INotifyPropertyChanged
    {
        private ConversionDivisas _model;
        public ConversionDivisas Model
        {
            get => _model;
            set
            {
                if (_model != value)
                {
                    _model = value;
                }
            }
        }
        public ICommand ComandoConvertirMoneda { get; }

        public ICommand ComandoMuestraChiste { get; }

        //Constructor
        public CambioDivisasViewModel() {
            Model = new ConversionDivisas();
            
            ComandoConvertirMoneda = new Command(async () => await ConvertirMoneda());
            ComandoMuestraChiste = new Command(async () => await ObtenerChiste());
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public async Task ConvertirMoneda()
        {
            if (Model.MonedaBase == "USD")
            {
                Model.ValorRecibido = Model.ValorAcambiar * 0.93;
            }
            else
            {
                Model.ValorRecibido = Model.ValorAcambiar * 1.18;
            }
            OnPropertyChanged(nameof(Model));
        }

        public async Task ObtenerChiste()
        {
            ChuckNorrisRespositorio repo = new ChuckNorrisRespositorio("chuck.db");
            ChuckNorris chuck = await repo.DevuelveChisteChuckNorris();
            repo.GuardarChisteChuckNorris(chuck);
            Model.ChisteChuck = chuck.value;
            OnPropertyChanged(nameof(Model));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

    }
}
