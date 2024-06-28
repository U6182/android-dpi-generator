using System;
using System.Text.RegularExpressions;

namespace AndroidDPIGenerator
{
    /**
    <summary>
    ユーティリティクラス
    </summary>
    <author>木村 憂哉</author>
    <date>2023-11-05</date>
    */
    class Util
    {
        /**
        <summary>
        文字列をAndroidのリソース名として適切な形式に変換する
        </summary>
        <param name="str">変換対象の文字列</param>
        <returns>変換後の文字列</returns>
        */
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
