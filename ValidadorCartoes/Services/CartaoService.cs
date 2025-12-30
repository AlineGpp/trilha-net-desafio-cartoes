using System;
using System.Text.RegularExpressions;

namespace ValidadorCartoes.Services
{
    public class CartaoService
    {
        public static string ObterBandeiraPorRegex(string numero)
    {
        var n = Regex.Replace(numero ?? "", @"\D", ""); // remove espaços e traços

        if (Regex.IsMatch(n, @"^4\d{12}(\d{3})?$")) return "Visa";
        if (Regex.IsMatch(n, @"^(5[1-5]\d{14}|2(2[2-9]\d{12}|[3-6]\d{13}|7[01]\d{12}|720\d{12}))$")) return "MasterCard";
        if (Regex.IsMatch(n, @"^(4011|4312|4389)\d{12}$")) return "Elo";
        if (Regex.IsMatch(n, @"^3[47]\d{13}$")) return "American Express";
        if (Regex.IsMatch(n, @"^(6011\d{12}|65\d{14}|64[4-9]\d{13})$")) return "Discover";
        if (Regex.IsMatch(n, @"^6062\d{12}$")) return "Hipercard";

        return "Desconhecida";
    }

    }
}