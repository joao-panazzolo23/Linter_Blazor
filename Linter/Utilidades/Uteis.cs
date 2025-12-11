using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Linter.Utilidades
{
    public static class Uteis
    {
        public static string PegaNomeDeExibicao(this Enum enumValue)
        {
            return enumValue.GetType()?
                            .GetMember(enumValue.ToString())?
                            .First()?
                            .GetCustomAttribute<DisplayAttribute>()?
                            .Name;
        } 
        
        public static bool ValidarCPF(string cpf)
        {

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 || !cpf.All(char.IsDigit))
            {
                return false;
            }

            if (new string(cpf[0], 11) == cpf)
            {
                return false;
            }

            int soma1 = 0;
            for (int i = 0; i < 9; i++)
            {
                soma1 += int.Parse(cpf[i].ToString()) * (10 - i);
            }
            int resto1 = soma1 % 11;
            int digito1 = (resto1 < 2) ? 0 : 11 - resto1;

            int soma2 = 0;
            for (int i = 0; i < 10; i++)
            {
                soma2 += int.Parse(cpf[i].ToString()) * (11 - i);
            }
            int resto2 = soma2 % 11;
            int digito2 = (resto2 < 2) ? 0 : 11 - resto2;

            return cpf[9] == digito1.ToString()[0] && cpf[10] == digito2.ToString()[0];
        }
    }

}
