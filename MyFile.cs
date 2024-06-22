using System.IO;

namespace AndroidDPIGenerator
{
    class MyFile
    {
       
        /// <summary>
        /// ディレクトリを作成する
        /// </summary>
        /// <param name="path">作成パス</param>
        /// <returns>ディレクトリ情報</returns>
        /// 2022/09/22 木村
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
