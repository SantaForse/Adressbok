using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok.Solutions;

internal class FileService
{
    public void Save(string FilePath, string content)
    {

        using var sw = new StreamWriter(FilePath);
        sw.WriteLine(content);
    }


    public string Read(string FilePath)
    {

        try
        {
            using var sr = new StreamReader(FilePath);

            return sr.ReadToEnd();
        }

        catch
        {
            return null!;
        }
    }


}


