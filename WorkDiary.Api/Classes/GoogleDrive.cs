using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
namespace ServiceDotNet.Api.Classes
{
    public class GoogleDrive
    {
        private const string ContentType = @"image/jpeg";
        private Google.Apis.Drive.v3.Data.File uploadedFile;
        private readonly string[] Scopes = new[] { DriveService.Scope.DriveFile, DriveService.Scope.Drive };
        public async Task UploadFile(string fileName, byte[] fileBytes)
        {
            UserCredential credential;
            var CSPath = System.Web.Hosting.HostingEnvironment.MapPath("~/");

            using (var stream = new FileStream(Path.Combine(CSPath, "credentials.json"), FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                  GoogleClientSecrets.Load(stream).Secrets,
                  Scopes,
                  "MyKeyName",
                  CancellationToken.None,
                  new FileDataStore(Path.Combine(CSPath, "token.json"), true)).Result;
            }

            // Create Drive API service.  
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Workdiary"
            });

            await UploadFileAsync(service, fileName);
        }

        private Task UploadFileAsync(DriveService service, string fileName)
        {
            var title = fileName;
            if (title.LastIndexOf('\\') != -1)
            {
                title = title.Substring(title.LastIndexOf('\\') + 1);
            }

            var uploadStream = new System.IO.FileStream(fileName, System.IO.FileMode.Open,
            System.IO.FileAccess.Read);

            var insert = service.Files.Create(new Google.Apis.Drive.v3.Data.File { Name = title }, uploadStream, ContentType);

            insert.ChunkSize = Google.Apis.Drive.v3.FilesResource.CreateMediaUpload.MinimumChunkSize * 2;
            insert.ProgressChanged += Upload_ProgressChanged;
            insert.ResponseReceived += Upload_ResponseReceived;

            var task = insert.UploadAsync();

            task.ContinueWith(t =>
            {
                // NotOnRanToCompletion - this code will be called if the upload fails  
                Console.WriteLine("Upload Filed. " + t.Exception);
            }, TaskContinuationOptions.NotOnRanToCompletion);
            task.ContinueWith(t =>
            {
                uploadStream.Dispose();
            });

            return task;
        }

        void Upload_ProgressChanged(IUploadProgress progress)
        {
            Console.WriteLine(progress.Status + " " + progress.BytesSent);
        }

        void Upload_ResponseReceived(Google.Apis.Drive.v3.Data.File file)
        {
            uploadedFile = file;
        }
    }
}