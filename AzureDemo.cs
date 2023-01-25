using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploadPrototype
{
    internal class AzureDemo
    {
        public void AzureFileUpload(string fileName, string containerName)
        {
            string myFile,
                myFileName,
                myConnectionString;
            Stream file;

            myConnectionString = "DefaultEndpointsProtocol=https;AccountName=gordonhomerg8039;AccountKey=L4a620Ik3qt9u3pgRO4avbz9kfr1XD5FGGbHMDYmbJKTlib7THYNSAZBGKZuKgs+bix+0GUjLSab+AStGMIVRA==;EndpointSuffix=core.windows.net";


            file = new FileStream(fileName, FileMode.Open);

            CloudStorageAccount myCloudStorageAccount = CloudStorageAccount.Parse(myConnectionString);
            CloudBlobClient blobClient = myCloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            if (container.CreateIfNotExists())
            {
                container.SetPermissionsAsync(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
            }

            myFile = Path.GetExtension(fileName);
            myFileName = Path.GetExtension(fileName);

            CloudBlockBlob myBlockBlob = container.GetBlockBlobReference(myFileName);
            myBlockBlob.Properties.ContentType = myFile;

            //upload file to blob storage
            myBlockBlob.UploadFromStreamAsync(file);

            Console.WriteLine("Upload Successful");
        }


        public void AzureFileDownload(string fileName, string containerName)
        {
            string myConnectionString = "DefaultEndpointsProtocol=https;AccountName=gordonhomerg8039;AccountKey=L4a620Ik3qt9u3pgRO4avbz9kfr1XD5FGGbHMDYmbJKTlib7THYNSAZBGKZuKgs+bix+0GUjLSab+AStGMIVRA==;EndpointSuffix=core.windows.net";

            CloudStorageAccount myCloudStorageAccount = CloudStorageAccount.Parse(myConnectionString);
            CloudBlobClient myBlob = myCloudStorageAccount.CreateCloudBlobClient();

            CloudBlobContainer myContainer = myBlob.GetContainerReference(containerName);
            CloudBlockBlob myBlockBlob = myContainer.GetBlockBlobReference(fileName);

            Stream fileupd = File.OpenWrite(@"C:\Users\gordo\Downloads\" + fileName);
            myBlockBlob.DownloadToStream(fileupd);

            Console.WriteLine("Download successful?");
        }
    }
}
