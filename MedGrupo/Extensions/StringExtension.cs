namespace System
{
    public static class StringExtension
    {
        public static string FormatCNPJ(this string cnpj)
        {
            if (cnpj.Length < 14)
                return "CNPJ Invalido";

            double.TryParse(cnpj, out double numero);

            return @$"{numero:00\.000\.000\/0000\-00}";
        }

        public static string FormatTelefone(this string tel)
        {
            if (tel.Length < 6)
                return "Telefone Invalido";

            double.TryParse(tel, out double numero);

            return @$"{numero:(00) 00000\-0000}";
        }
    }
}
