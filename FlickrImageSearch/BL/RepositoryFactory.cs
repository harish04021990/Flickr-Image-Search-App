using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace FlickrImageSearch.BL
{
    /// <summary>
    /// Repository factory
    /// </summary>
    public class RepositoryFactory
    {
        /// <summary>
        /// Reads the default repository source from settings and retrives relevant Factory accordingly
        /// </summary>
        /// <returns></returns>
        public IImageRepository GetRepository()
        {
            var defaultRepository = Properties.Settings.Default.DefaultImageRepository.Trim('\"');
            switch (defaultRepository)
            {
                case "Flickr":
                    return new FlickrImageRepository();
                default:return null;
            }            
        }      

    }
}
