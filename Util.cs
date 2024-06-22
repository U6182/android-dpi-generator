using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AndroidDPIGenerator
{
    class Util
    {
        public static string ConvertStr(string str)
        {
            //大文字の場合、小文字に変換する
            string convert = str.ToLowerInvariant();
            //その他、リソース名として使用できない文字は_へ変換する
            convert = Regex.Replace(convert, "[^a-z0-9_]", "_");
            return convert;
        }
    }
}
