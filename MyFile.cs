using System.IO;

namespace AndroidDPIGenerator
{
    /**
    <summary>
    ファイル操作に関するユーティリティクラス
    </summary>
    <author>木村 憂哉</author>
    <date>2023-11-05</date>
    */
    class MyFile
    {
        /**
        <summary>ディレクトリを作成する</summary>
        <param name="path">作成パス</param>
        <returns>ディレクトリ情報</returns>
        */
        public static DirectoryInfo safeCreateDirectory(string path)
        {
            //指定のパスにディレクトリが存在する場合、作成しない
            if (Directory.Exists(path))
            {
                return null;
            }

            //指定パスにディレクトリを作成し情報を返却
            return Directory.CreateDirectory(path);
        }
    }
}
