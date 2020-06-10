namespace VigaMasResistente.Common.Services
{
    public class VigaResistenteService : IVigaResistenteService
    {
        public string Calculate(string cadena)
        {
            if (cadena.Contains("**")) return "La viga está mal construida!";
            int result = 0;
            while(cadena.Length > 0 && result < cadena.Length)
            {
                string character = cadena.Substring(result, 1);
                cadena = cadena.Remove(0, result + 1);
                result = Column(cadena, (character.Equals("#") ? 90 : character.Equals("%") ? 10 : character.Equals("&") ? 30 : 0));
                
                if (result < 0) 
                    return "La viga NO soporta el peso!";
            }

            return "La viga soporta el peso!";
        }

        public int Column(string cadena, int value)
        {
            int val = 1;
            int i;
            for (i = 0; i < cadena.Length; i++)
            {
                if (cadena[i] != '=' && cadena[i] != '*')
                {
                    break;
                }
                val += 1;

                if (val > value)
                    return -1;
                if (cadena[i] == '*')
                {
                    val *= 2;
                }
            }
            if (val > value) i = -1;
            return i;
        }

    }
}
