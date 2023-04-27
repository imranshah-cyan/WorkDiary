using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using ServiceDotNet.Api.Classes;
using WorkDiaryRepository;

namespace ServiceDotNet.Api.Controllers
{
    [RoutePrefix("api/fileUpload")]
    public class FileUploadController : ApiController
    {
        [Route("file")]
        [HttpPost]
        public async Task<HttpResponseMessage> Post()
        {
            var result = 0;
            try
            {
                var id = Convert.ToInt32(HttpContext.Current.Request.Form["userId"]);
                var jobId = Convert.ToInt32(HttpContext.Current.Request.Form["jobId"]);
                int timeSheetId = Convert.ToInt32(HttpContext.Current.Request.Form["timeSheetId"]);

                int numberOfRowsInserted = 0;
                string fileName = id + '_' + '_' + Guid.NewGuid().ToString();
                HttpRequestMessage request = this.Request;
                if (!request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType));
                }
                string filePath = HttpContext.Current.Server.MapPath("~/MediaLibrary/UserLogs");
                var provider = new MultipartFormDataStreamProvider(filePath);
                var fullFilePath = Path.Combine(filePath, fileName);

                await request.Content.ReadAsMultipartAsync(provider).ContinueWith<HttpResponseMessage>(o =>
                    {
                        FileInfo finfo = new FileInfo(provider.FileData.First().LocalFileName);
                        File.Copy(finfo.FullName, Path.Combine(filePath, fileName + Path.GetExtension(fileName)));
                        if (File.Exists(fullFilePath))
                        {
                            var userLog = UserLogs.GetFormattedUserLog(id, jobId, fullFilePath);
                            var userService = new UserRepository();
                            numberOfRowsInserted = userService.InsertUserLog(userLog);

                            var screenLogs = UserLogs.GetFormattedScreenLogs(userLog, timeSheetId, jobId);
                            if (screenLogs != null && screenLogs.Count > 0)
                            {
                                result = userService.InsertScreenLog(screenLogs);
                            }

                            return new HttpResponseMessage()
                            {
                                Content = new StringContent("Number of logs inserted:" + result),
                            };
                        }
                        return new HttpResponseMessage()
                        {
                            Content = new StringContent("Number of logs inserted:" + result),
                        };
                    }
                );
            }
            catch (Exception e)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent(e.Message),

                };
            }
            return new HttpResponseMessage()
            {
                Content = new StringContent("Number of logs inserted:" + result),
            };
        }

        //[HttpPost, Route("file")]
        //public async Task<IHttpActionResult> Upload()
        //{
        //    if (!Request.Content.IsMimeMultipartContent())
        //        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

        //    var provider = new MultipartMemoryStreamProvider();
        //    await Request.Content.ReadAsMultipartAsync(provider);
        //    foreach (var file in provider.Contents)
        //    {
        //        var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
        //        var buffer = await file.ReadAsByteArrayAsync();
        //        //Do whatever you want with filename and its binaray data.
        //    }

        //    return Ok();
        //}
        //[HttpPost, Route("file")]
        //public async Task<IHttpActionResult> Upload()
        //{
        //    if (!Request.Content.IsMimeMultipartContent())
        //        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

        //    var provider = new MultipartMemoryStreamProvider();
        //    await Request.Content.ReadAsMultipartAsync(provider);
        //    foreach (var file in provider.Contents)
        //    {
        //        var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
        //        var buffer = await file.ReadAsByteArrayAsync();
        //        //Do whatever you want with filename and its binaray data.
        //    }

        //    return Ok();
        //}

        //[HttpPost, Route("file")]
        //public async Task<IHttpActionResult> Upload()
        //{
        //    int iUploadedCnt = 0;

        //    // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
        //    string sPath = "";
        //    sPath = System.Web.Hosting.HostingEnvironment.MapPath("E:\\");

        //    System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

        //    // CHECK THE FILE COUNT.
        //    for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
        //    {
        //        System.Web.HttpPostedFile hpf = hfc[iCnt];

        //        if (hpf.ContentLength > 0)
        //        {
        //            // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
        //            if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
        //            {
        //                // SAVE THE FILES IN THE FOLDER.
        //                hpf.SaveAs(sPath + Path.GetFileName(hpf.FileName));
        //                iUploadedCnt = iUploadedCnt + 1;
        //            }
        //        }
        //    }
        //var succ = "file uploaded.";
        //// RETURN A MESSAGE (OPTIONAL).
        //if (iUploadedCnt > 0)
        //{
        //    return OK;
        //}
        //else
        //{
        //    return "Upload Failed";
        //}
        //return Ok();
        //}



        //[AllowAnonymous]
        //[Route("get/{library}/{fileName}")]
        //public HttpResponseMessage GetFile(string library, string fileName)
        //{
        //    HttpResponseMessage result = null;
        //    try
        //    {
        //        string root = WebConfigurationManager.AppSettings["mediaLibraryPath"];
        //        var localFilePath = Path.Combine(root, library, fileName);

        //        if (!System.IO.File.Exists(localFilePath))
        //        {
        //            result = Request.CreateResponse(HttpStatusCode.Gone);
        //        }
        //        else
        //        {
        //            //x-filename header to send the filename. This is a custom header for convenience.
        //            //content-type mime header for your response too, so the browser knows the data format.
        //            var info = System.IO.File.GetAttributes(localFilePath);
        //            result = Request.CreateResponse(HttpStatusCode.OK);
        //            result.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
        //            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        //            result.Content.Headers.Add("x-filename", fileName);
        //            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
        //            result.Content.Headers.ContentDisposition.FileName = fileName;
        //        }
        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //}



    }
}
