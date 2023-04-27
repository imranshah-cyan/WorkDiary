using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using ServiceDotNet.Api.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using WorkDiaryRepository;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Entities;


namespace ServiceDotNet.Api.Controllers
{
    [RoutePrefix("api/image")]
    public class ImageController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("screenshot")]
        [System.Web.Http.HttpPost]
        public int Post([FromBody]ImageStore imageStore)
        {
            var fileName = imageStore.PROVIDER_ID + "_" + imageStore.IMAGE_NAME + "_" + Guid.NewGuid();

            if (imageStore.IS_DELETED == true)
            {
                fileName = "cancelled.jpg";
            }

            imageStore.IMAGE_NAME = fileName;

            var ist = new IMAGE_STORE
            {
                TIME_SHEET_ID = imageStore.TIME_SHEET_ID,
                IMAGE_NAME = imageStore.IMAGE_NAME,
                KEY_LOG = imageStore.KEY_LOG,
                KEY_STROKE_LEVEL = imageStore.KEY_STROKE_LEVEL,
                MOUSE_CLICK = imageStore.MOUSE_CLICK,
                ACTIVE_WINDOW_TITLE = imageStore.ACTIVE_WINDOW_TITLE,
                JOB_ID = imageStore.JOB_ID,
                JOB_OFFER_ID = imageStore.JOB_OFFER_ID,
                JOB_AWARDED_ID = imageStore.JOB_AWARDED_ID,
                BUYER_ID = imageStore.BUYER_ID,
                PROVIDER_ID = imageStore.PROVIDER_ID,
                CREATED_BY = imageStore.CREATED_BY,
                CREATED_ON = DateTime.Now,
                IS_EMAIL_SENT = imageStore.IS_EMAIL_SENT,
                IS_DELETED = imageStore.IS_DELETED,
                DELETED_BY = imageStore.DELETED_BY,
                DELETED_ON = imageStore.DELETED_ON,
                WINDOWS_SWITCHED = imageStore.WINDOWS_SWITCHED,
                TIME_SPENT_IN_SECONDS = imageStore.TIME_SPENT_IN_SECONDS,
            };
            var insertedImageStoreId = new JobRepository().InsertScreenShot(ist);

            if (imageStore.IS_DELETED == false)
            {
                ///var t = new GoogleDrive().UploadFile(fileName, imageStore.IMAGE_BINARY);

                //#################################################################
                //                Azure Blob Storage
                //#################################################################
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("images");
                container.CreateIfNotExists();
                container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                blockBlob.Properties.ContentType = "Jpg";
                blockBlob.UploadFromByteArray(imageStore.IMAGE_BINARY, 0, imageStore.IMAGE_BINARY.Length);
            }

            if (insertedImageStoreId != null)
                return (int)insertedImageStoreId;

            return 0;

        }

        [HttpPost]
        [Route("search")]
        public List<GetImagesInGivenTime_Result> SearchImages([FromBody]ImageModel img)
        {
            return new JobRepository().GetImagesInGivenTime(Convert.ToInt32(img.PROVIDER_ID), Convert.ToInt32(img.JOB_ID), Convert.ToDateTime(img.START_TIME), Convert.ToDateTime(img.END_TIME));
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}