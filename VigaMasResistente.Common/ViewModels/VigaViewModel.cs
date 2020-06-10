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
        private readonly bool _calculated;
        private MvxCommand _calculateCommand;

        public VigaViewModel(IVigaResistenteService vigaResistenteService)
        {
            _vigaResistenteService = vigaResistenteService;
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
            Result = _vigaResistenteService.Calculate(Cadena) ? "La viga soporta el peso!" : "La viga NO soporta el peso!";
        }

    }
}
