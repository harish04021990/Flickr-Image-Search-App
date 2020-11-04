using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrImageSearch.BL
{
    public interface IImageRepository 
    {
       void  GetImageCollection(string keyword, Action<IEnumerable<Uri>> OnTaskCompletion);
    }
}
