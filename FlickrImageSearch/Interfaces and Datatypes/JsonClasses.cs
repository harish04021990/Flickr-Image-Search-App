using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrImageSearch.BL.DataTypes
{
    /// <summary>
    /// Data structure representing structure of data received from API
    /// Used for serialization 
    /// </summary>
    public class JsonRootObject : IDisposable
    {
        [JsonProperty("items")]
        public IEnumerable<ImageDetails> ImageDetailsCollection { get; set; }


        #region IDisposable


        private bool _disposed = false;

        ~JsonRootObject() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                ImageDetailsCollection = null;
            }

            _disposed = true;
        }

        #endregion

    }

    public class ImageDetails
    {
        [JsonProperty("media")]
        public Path Path { get; set; }
    }

    public class Path
    {
        [JsonProperty("m")]
        public Uri ImageUri { get; set; }
    }
}
