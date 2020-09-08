using Demo.Models;
using Demo.Services.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MimeMapping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

// see https://www.youtube.com/watch?v=aTv5t7oH6X8 for more references
namespace Demo.Services
{
    public class GoogleDriveFileRepository: IGoogleDriveService
    {
        private static IWebHostEnvironment _hostingEnvironment;

        public GoogleDriveFileRepository(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        //defined scope.
        public string[] Scopes = { DriveService.Scope.Drive, DriveService.Scope.DriveFile, DriveService.Scope.DriveMetadata };

        //create Drive API service.
        public DriveService GetService()
        {
            //get Credentials from client_secret.json file 
            GoogleCredential credential;
            using (var stream = new FileStream(@"client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                String FolderPath = @"\";
                String FilePath = Path.Combine(FolderPath, "DriveServiceCredentials.json");

                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(Scopes);
            }

            //create Drive API service.
            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GoogleDriveRestAPI-v3",
            });
            return service;
        }

        //get all files from Google Drive.
        public List<GoogleDriveFile> GetDriveFiles()
        {
            DriveService service = GetService();

            // define parameters of request.
            FilesResource.ListRequest FileListRequest = service.Files.List();

            //listRequest.PageSize = 10;
            //listRequest.PageToken = 10;
            FileListRequest.Fields = "nextPageToken, files(id, name, size, version, createdTime)";

            //get file list.
            IList<Google.Apis.Drive.v3.Data.File> files = FileListRequest.Execute().Files;
            List<GoogleDriveFile> FileList = new List<GoogleDriveFile>();

            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    GoogleDriveFile File = new GoogleDriveFile
                    {
                        Id = file.Id,
                        Name = file.Name,
                        Size = file.Size,
                        Version = file.Version,
                        CreatedTime = file.CreatedTime
                    };
                    FileList.Add(File);
                }
            }
            return FileList;
        }

        //file Upload to the Google Drive.
        public async Task FileUpload(IFormFile file)
        {
            // Copy file to local folder
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            if (file.Length > 0)
            {
                var filePath = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            if (file != null && file.Length > 0)
            {
                DriveService service = GetService();

                string path = Path.GetFileName(file.FileName);/*Path.Combine(_hostingEnvironment.WebRootPath.MapPath("~/GoogleDriveFile"),*/
                path = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                //Path.GetFileName(file.FileName);
                //file.SaveAs(path);

                var FileMetaData = new Google.Apis.Drive.v3.Data.File();
                FileMetaData.Name = Path.GetFileName(file.FileName);
                FileMetaData.MimeType = MimeUtility.GetMimeMapping(path);

                FilesResource.CreateMediaUpload request;

                using (var stream = new FileStream(path, FileMode.Open))
                {
                    //service. Create(FileMetaData, stream, FileMetaData.MimeType);
                    request = service.Files.Create(FileMetaData, stream, FileMetaData.MimeType);
                    request.Fields = "id";
                    request.Upload();
                }
            }
        }

        //Create google drive folder
        public void CreateFolder(string FolderName)
        {
            DriveService service = GetService();

            Google.Apis.Drive.v3.Data.File FileMetaData = new Google.Apis.Drive.v3.Data.File();
            FileMetaData.Name = FolderName;
            FileMetaData.MimeType = "application/vnd.google-apps.folder";

            FilesResource.CreateRequest request;

            request = service.Files.Create(FileMetaData);
            request.Fields = "id";
            var file = request.Execute();
            Console.WriteLine("Folder ID: " + file.Id);
        }

        //Upload file to google drive folder
        public async Task FileUploadInFolder(IFormFile file, string folderId = null)
        {
            if (file != null && file.Length > 0)
            {
                // Copy file to local folder
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                if (file.Length > 0)
                {
                    var filePath = Path.Combine(uploads, file.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    DriveService service = GetService();

                    string path = Path.GetFileName(file.FileName);
                    //string path = Path.Combine(HttpContext.Current.Server.MapPath("~/GoogleDriveFiles"),
                    //Path.GetFileName(file.FileName));
                    //file.SaveAs(path);

                    var FileMetaData = new Google.Apis.Drive.v3.Data.File()
                    {
                        Name = Path.GetFileName(file.FileName),
                        MimeType = GetMimeType(/*path*/filePath), 
                        Shared = true, 
                        Parents = new List<string> { "1_gq-nr7D78Zh2NqPBn-a6Bo2igBkYPCJ" }
                    };

                    FilesResource.CreateMediaUpload request;
                    using (var stream = new FileStream(filePath, FileMode.Open))
                    {
                        request = service.Files.Create(FileMetaData, stream, FileMetaData.MimeType);
                        request.Fields = "id";
                        request.Upload();
                    }
                    var file1 = request.ResponseBody;
                }
            }
        }

        ////Download file from Google Drive by fileId.
        //public static string DownloadGoogleFile(string fileId)
        //{
        //    DriveService service = GetService();

        //    string FolderPath = System.Web.HttpContext.Current.Server.MapPath("/GoogleDriveFile/");
        //    FilesResource.GetRequest request = service.Files.Get(fileId);

        //    string FileName = request.Execute().Name;
        //    string FilePath = System.IO.Path.Combine(FolderPath, FileName);

        //    MemoryStream stream1 = new MemoryStream();

        //    // Add a handler which will be notified on progress changes.
        //    // It will notify on each chunk download and when the
        //    // download is completed or failed.
        //    request.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
        //    {
        //        switch (progress.Status)
        //        {
        //            case DownloadStatus.Downloading:
        //                {
        //                    Console.WriteLine(progress.BytesDownloaded);
        //                    break;
        //                }
        //            case DownloadStatus.Completed:
        //                {
        //                    Console.WriteLine("Download complete.");
        //                    SaveStream(stream1, FilePath);
        //                    break;
        //                }
        //            case DownloadStatus.Failed:
        //                {
        //                    Console.WriteLine("Download failed.");
        //                    break;
        //                }
        //        }
        //    };
        //    request.Download(stream1);
        //    return FilePath;
        //}

        // file save to server path

        private void SaveStream(MemoryStream stream, string FilePath)
        {
            using (System.IO.FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                stream.WriteTo(file);
            }
        }

        //Delete file from the Google drive
        public void DeleteFile(GoogleDriveFile files)
        {
            DriveService service = GetService();
            try
            {
                // Initial validation.
                if (service == null)
                {
                    throw new ArgumentNullException("service");
                }

                if (files == null)
                {
                    throw new ArgumentNullException(files.Id);
                }

                // Make the request.
                service.Files.Delete(files.Id).Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Files.Delete failed.", ex);
            }
        }

        private static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }
    }
}
