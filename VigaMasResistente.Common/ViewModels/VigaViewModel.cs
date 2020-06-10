using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Windows.Input;
using VigaMasResistente.Common.Services;

namespace VigaMasResistente.Common.ViewModels
{
    public class VigaViewModel : MvxViewModel
    {
        private readonly IVigaResistenteService _vigaResistenteService;
        private string _cadena;
        private string _result;
        private bool _isRunning;
        private MvxCommand _calculateCommand;

        public VigaViewModel(IVigaResistenteService vigaResistenteService)
        {
            _vigaResistenteService = vigaResistenteService;
            IsRunning = false;
        }

        public string Cadena
        {
            get => _cadena;
            set => SetProperty(ref _cadena, value);
        }

        public string Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public ICommand CalculateCommand
        {
            get
            {
                _calculateCommand = _calculateCommand ?? new MvxCommand(Calculate);
                return _calculateCommand;
            }
        }

        private void Calculate()
        {
            IsRunning = true;
            if (string.IsNullOrEmpty(Cadena))
            {
                Result = "Debe ingresar alguna cadena";
                IsRunning = false;
                return;
            }

            IsRunning = false;
            Result = _vigaResistenteService.Calculate(Cadena);
        }

    }
}
