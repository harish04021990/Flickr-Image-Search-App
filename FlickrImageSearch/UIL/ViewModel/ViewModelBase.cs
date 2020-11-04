using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrImageSearch.UIL.ViewModel
{
    /// <summary>
    /// Notifies elements of property change action
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged 
    {     
        /// <summary>
        /// Notifies Views about property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// To be called when propery changes. This will trigger the notification
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
