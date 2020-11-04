using FlickrImageSearch.BL.DataTypes;
using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlickrImageSearch.BL
{
    public class FlickrImageRepository : IImageRepository
    {
        public void GetImageCollection(string keyword, Action<IEnumerable<Uri>> OnTaskCompletion)
        {
            if (string.IsNullOrEmpty(keyword) || OnTaskCompletion == null) return;
            GetImages(keyword, OnTaskCompletion);
        }


        /// <summary>
        /// Calls Flickr api 
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public async Task GetImages(string searchString, Action<IEnumerable<Uri>> OnTaskCompletion)
        {
            string flickerUrl = "https://api.flickr.com/services/feeds/photos_public.gne?tag={0}&api_key=aaf0721010d60c8dfdd2df28ed0ac6b9&format=json&nojsoncallback=1";
            string searchUrl = string.Format(flickerUrl, searchString);
            HttpClient client = new HttpClient();
            string jsonstring = await client.GetStringAsync(searchUrl);
            var rootObject = JsonConvert.DeserializeObject<JsonRootObject>(jsonstring);
            List<Uri> imageUriCollection = new List<Uri>();
            imageUriCollection.AddRange(rootObject.ImageDetailsCollection.Select(s => s.Path.ImageUri));
            client.Dispose();
            rootObject.Dispose();
            OnTaskCompletion(imageUriCollection);
        }

    }
}
