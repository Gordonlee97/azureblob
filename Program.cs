using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace FileUploadPrototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AzureDemo azureDemo = new AzureDemo();

            azureDemo.AzureFileUpload(@"..\..\Files\azurenote.txt", "democontainer");
            //azureDemo.AzureFileDownload(".txt", "democontainer");

            Console.ReadKey(); 
        }
    }
}
