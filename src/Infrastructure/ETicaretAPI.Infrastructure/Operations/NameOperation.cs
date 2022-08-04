using System.Text.RegularExpressions;

namespace ETicaretAPI.Infrastructure.Operations
{
    public static class NameOperation
    {
        public static string CharacterRegulatory(string name)
        {
            name.Replace("İ", "I");
            name.Replace("ı", "i");
            name.Replace("ğ", "g");
            name.Replace("Ğ", "G");
            name.Replace("ç", "c");
            name.Replace("Ç", "C");
            name.Replace("ö", "o");
            name.Replace("Ö", "O");
            name.Replace("ş", "s");
            name.Replace("Ş", "S");
            name.Replace("ü", "u");
            name.Replace("Ü", "U");
            name.Replace("'", "");
            name.Replace("ß", "ss");
            name.Replace("â", "a");
            name.Replace("î", "i");
            name.Replace("\"", "");

            char[] replacerList = @"$€æ%#°!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
            for (int i = 0; i < replacerList.Length; i++)
            {
                string strChr = replacerList[i].ToString();
                if (name.Contains(strChr))
                {
                    name = name.Replace(strChr, string.Empty);
                }
            }
            Regex regex = new Regex("[^a-zA-Z0-9_-]");
            name = regex.Replace(name, "-");
            while (name.IndexOf("--", StringComparison.Ordinal) > -1)
                name = name.Replace("--", "-");
            return name;
        }
    }
}
