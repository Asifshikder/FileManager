using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Project.Services.Media;
using Project.Infrastructure.Repository;
using Project.Core.Domain.Media;
using Project.Core.Enums;
using Project.Core.Miscellaneous;

namespace EasyShop.Web.Services
{
    public class MediaService : IMediaFileService
    {
        #region Constant
        public const string foldername = "useruploads";
        public const string CompressedThumb = "~/staticfiles/compressed.jpg";
        public const string DocumentThumb = "~/staticfiles/document.png";
        public const string ExcelThumb = "~/staticfiles/excel.png";
        public const string OthersThumb = "~/staticfiles/others.png";
        public const string PdfThumb = "~/staticfiles/pdf.png";
        public const string PptThumb = "~/staticfiles/ppt.png";
        public const string VideoThumb = "~/staticfiles/video.png";
        public const string AudioThumb = "~/staticfiles/audio.png";
        #endregion
        #region ctor
        private IWebHostEnvironment webHost;
        private IEntityRepository<MediaFile> mediaRepository;

        public MediaService(IWebHostEnvironment webHost,
            IEntityRepository<MediaFile> mediaRepository)
        {
            this.webHost = webHost;
            this.mediaRepository = mediaRepository;
        }

        #endregion
        #region methods
        public MediaFile UploadFile(MediaFolder folder,IFormFile file)
        {
            return UploadFileInFolder(folder,file);

        }
        public void UpdateFile(MediaFile media, IFormFile file)
        {
            if (media.FileUrl != null)
            {
                if (media.MediaType == MediaType.Image)
                {
                    DeleteFileInFolder(media.ThumbnailUrl);
                }
                DeleteFileInFolder(media.FileUrl);
            }
            UpdateFileInFolder(media, file);
        }
        public MediaFile GetById(long id)
        {
            try
            {
                var media = mediaRepository.GetByIdAsync(id).Result;
                return media;
            }
            catch (Exception)
            {
                MediaFile media = null;
                return media;
            }
        }
        public void DeleteFile(string fileurl, string thumburl, int mediaType)
        {
            if (mediaType == (int)MediaType.Image)
            {
                DeleteFileInFolder(thumburl);
            }
            DeleteFileInFolder(fileurl);
        }
        public void DeleteFileWithMedia(MediaFile media)
        {
            if (media.MediaType == MediaType.Image)
            {
                DeleteFileInFolder(media.ThumbnailUrl);
            }
            DeleteFileInFolder(media.FileUrl);
            mediaRepository.PermanentDeleteAsync(media);
        }
        #endregion
        #region functions
        public void DeleteFileInFolder(string filename)
        {
            string dbpath = filename.Replace("~/", "").ToString();
            string uppath = dbpath.Replace("/", "\\").ToString();
            string fullpath = webHost.WebRootPath + "\\" + uppath;
            System.IO.File.Delete(fullpath);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        public MediaFile UploadFileInFolder(MediaFolder folder,IFormFile file)
        {
            string baseFileName = file.FileName;
            MediaThumbnailModel model = SaveIcon(file);
            MediaFile media = new MediaFile()
            {
                FileName = baseFileName,
                FileSize = Convert.ToInt64(file.Length),
                FileUrl = SaveFileInFolder(folder,file),
                ThumbnailUrl = model.ThumbnailUrl,
                MediaType = model.MediaType,
                MediaFolderId = folder.Id
            };

            var dbmedia = mediaRepository.AddAsync(media).Result;
            return dbmedia;

        }


        private void UpdateFileInFolder(MediaFile media, IFormFile file)
        {
            string baseFileName = file.FileName;
            MediaThumbnailModel model = SaveIcon(file);

            media.FileName = baseFileName;
            media.FileSize = Convert.ToInt64(file.Length);
            media.FileUrl = SaveFile(file);
            media.ThumbnailUrl = model.ThumbnailUrl;
            media.MediaType = model.MediaType;
            mediaRepository.UpdateAsync(media);
        }
        public string SaveFile(IFormFile file)
        {
            //MediaType mediaType = GetMediaType(file);
            //if (mediaType == MediaType.Image)
            //{
            //    Guid nameguid = Guid.NewGuid();
            //    string webrootpath = webHost.WebRootPath;
            //    string filename = nameguid.ToString();
            //    string extension = Path.GetExtension(file.FileName);
            //    filename = filename + extension;
            //    string path = Path.Combine(webrootpath, foldername, filename);

            //    using var image = Image.Load(file.OpenReadStream());
            //    ImageAspects aspects = new ImageAspects();
            //    aspects = GetAspectsByImageHeightWidth(image.Height, image.Width);
            //    int newheight = 1200;
            //    int newWidth = image.Width * (int)(1200 * aspects.AspectByWidth);
            //    image.Mutate(x => x.Resize(newWidth, newheight));
            //    image.Save(path);
            //    string fileUrl = "~/" + foldername + "/" + filename;

            //    return fileUrl;
            //}
            //else
            //{
                Guid nameguid = Guid.NewGuid();
                string webrootpath = webHost.WebRootPath;
                string filename = nameguid.ToString();
                string extension = Path.GetExtension(file.FileName);
                filename = filename + extension;
                string path = Path.Combine(webrootpath, foldername, filename);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                string pathName = Path.Combine(foldername, filename);
                string fileUrl = "~/" + foldername + "/" + filename;
                return fileUrl;
            //}

        }


        private string SaveFileInFolder(MediaFolder folder, IFormFile file)
        {
            string dbpath = folder.FolderUrl.Replace("~/", "").ToString();
            string uppath = dbpath.Replace("/", "\\").ToString();
            string fullpath = webHost.WebRootPath + "\\" + uppath;
            Guid nameguid = Guid.NewGuid();
            string webrootpath = webHost.WebRootPath;
            string filename = nameguid.ToString();
            string extension = Path.GetExtension(file.FileName);
            filename = filename + extension;
            string path = Path.Combine(webrootpath, fullpath, filename);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            string pathName = Path.Combine(foldername, filename);
            string fileUrl = folder.FolderUrl + "/" + filename;
            return fileUrl;
        }
        private MediaThumbnailModel SaveIcon(IFormFile file)
        {
            MediaType mediaType = GetMediaType(file);
            if (mediaType == MediaType.Image)
            {
                Guid nameguid = Guid.NewGuid();
                string webrootpath = webHost.WebRootPath;
                string filename = nameguid.ToString();
                string extension = Path.GetExtension(file.FileName);
                filename = filename + extension;

                string path = Path.Combine(webrootpath, foldername, filename);

                using var image = Image.Load(file.OpenReadStream());
                ImageAspects aspects = new ImageAspects();
                aspects = GetAspectsByImageHeightWidth(image.Height, image.Width);
                int newheight = 100;
                int newWidth = image.Width * (int)(100 * aspects.AspectByWidth);
                image.Mutate(x => x.Resize(newWidth, newheight));
                image.Save(path);
                string fileUrl = "~/" + foldername + "/" + filename;


                MediaThumbnailModel model = new MediaThumbnailModel()
                {
                    MediaType = mediaType,
                    ThumbnailUrl = fileUrl
                };
                return model;
            }
            else
            {
                string fileurl = GetThumbnailForFile(mediaType);
                MediaThumbnailModel model = new MediaThumbnailModel()
                {
                    MediaType = mediaType,
                    ThumbnailUrl = fileurl
                };
                return model;
            }

        }

        private ImageAspects GetAspectsByImageHeightWidth(int height, int width)
        {
            ImageAspects imageasp = new ImageAspects();
            imageasp.AspectByWidth = width / height;
            imageasp.LowerHeight = height > 1200 ? height / 1200 : 1;
            imageasp.LowerWidth = height > 720 ? height / 720 : 1;
            return imageasp;
        }

        private string GetThumbnailForFile(MediaType mediaType)
        {
            if (mediaType == MediaType.Audio)
                return AudioThumb;
            if (mediaType == MediaType.Video)
                return VideoThumb;
            if (mediaType == MediaType.PDF)
                return PdfThumb;
            if (mediaType == MediaType.DOC)
                return DocumentThumb;
            if (mediaType == MediaType.XLS)
                return ExcelThumb;
            if (mediaType == MediaType.PPT)
                return PptThumb;
            if (mediaType == MediaType.Compressed)
                return CompressedThumb;
            else
                return OthersThumb;
        }
        private MediaType GetMediaType(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName);

            if (FileExtensions.Audio.Contains(extension))
                return MediaType.Audio;
            if (FileExtensions.Video.Contains(extension))
                return MediaType.Video;
            if (FileExtensions.Pdf.Contains(extension))
                return MediaType.PDF;
            if (FileExtensions.Doc.Contains(extension))
                return MediaType.DOC;
            if (FileExtensions.Xls.Contains(extension))
                return MediaType.XLS;
            if (FileExtensions.Ppt.Contains(extension))
                return MediaType.PPT;
            if (FileExtensions.Compressed.Contains(extension))
                return MediaType.Compressed;
            return MediaType.Others;
        }

        #endregion

    }
    public class MediaThumbnailModel
    {
        public MediaType MediaType { get; set; }
        public string ThumbnailUrl { get; set; }
    }
    public class ImageAspects
    {
        public decimal LowerHeight { get; set; }
        public decimal LowerWidth { get; set; }
        public decimal AspectByWidth { get; set; }
    }
}
