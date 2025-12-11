namespace Linter.Modelos.Enums
{
    public class Enumeradores
    {
        //pra usar os enumeradores em uma view, é preciso usar o código deste jeito 
        //Enum.GetNames(typeof(Enumeradores.TipoMovimentacao))
        //<FluentListbox Items = "Enum.GetNames(typeof(Enumeradores.TipoMovimentacao))" ></ FluentListbox >
        public enum Roles
        {
            Admin = 0,
            Usuario = 1
        }
    }
}