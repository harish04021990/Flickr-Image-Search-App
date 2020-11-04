using FlickrImageSearch.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrImageSearch.UIL.Model
{
    /// <summary>
    /// Model class for ImageSearchView
    /// </summary>
    public class ImageSearchModel
    {
        IImageRepository m_ImageRepository;
        public ImageSearchModel()
        {
            RepositoryFactory factory = new RepositoryFactory();
            m_ImageRepository = factory.GetRepository();
        }

        /// <summary>
        /// Retrives the collection of images
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="OnTaskCompletion"></param>
        public void GetImageCollection(string keyword, Action<IEnumerable<Uri>> OnTaskCompletion)
        {
            string searchTags = GetSearchTags(keyword);
            m_ImageRepository.GetImageCollection(searchTags, OnTaskCompletion);

        }

        /// <summary>
        /// if user enters multiple words , we are generating tags with comma seperated values
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        internal string GetSearchTags(string keyword)
        {          
            StringBuilder searchString = new StringBuilder();
            var inputStringArray = keyword.Split();
            foreach (var item in inputStringArray)
            {
                if (!string.IsNullOrEmpty(searchString.ToString()))
                    searchString.Append(",");

                searchString.Append(item);
            }
            return searchString.ToString();
        }
    }
}
