namespace VigaMasResistente.Common.Services
{
    public interface IVigaResistenteService
    {
        string Calculate(string cadena);

        int Column(string cadena, int value);
    }
}
