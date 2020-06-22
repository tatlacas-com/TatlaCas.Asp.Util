using System;

namespace TatlaCas.Asp.Core.Util.FormsAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ImageFileAttribute : Attribute
    {
        public string MimeTypeField { get; }
        public string UploadEndpoint { get; }
        /// <summary>
        /// Max file size in Kilobytes
        /// </summary>
        public int MaxFileSizeKb { get; }
        public int MaxFiles { get; }
        public int MinNumberOfFiles { get; }
        public string[] AllowedMimeTypes { get;  }

     /// <summary>
     /// 
     /// </summary>
     /// <param name="mimeTypeField"></param>
     /// <param name="uploadEndpoint"></param>
     /// <param name="allowedMimeTypes"></param>
     /// <param name="maxFileSizeKb">Max files size in Kilobytes</param>
     /// <param name="maxFiles"></param>
     /// <param name="minNumberOfFiles"></param>
        public ImageFileAttribute(string mimeTypeField, string uploadEndpoint, string[] allowedMimeTypes,
            int maxFileSizeKb = 1000, int maxFiles = 1,
            int minNumberOfFiles = 1)
        {
            MimeTypeField = mimeTypeField;
            UploadEndpoint = uploadEndpoint;
            AllowedMimeTypes = allowedMimeTypes;
            MaxFileSizeKb = maxFileSizeKb;
            MaxFiles = maxFiles;
            MinNumberOfFiles = minNumberOfFiles;
        }
    }
}