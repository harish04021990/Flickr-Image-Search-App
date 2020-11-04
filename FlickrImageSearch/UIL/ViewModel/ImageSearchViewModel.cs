using FlickrImageSearch.UIL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FlickrImageSearch.UIL.ViewModel
{
    /// <summary>
    /// View model class of ImageSearchView
    /// </summary>
    public class ImageSearchViewModel : ViewModelBase
    {
        private ImageSearchModel m_ImageSearchModel;
        public ImageSearchViewModel()
        {
            m_ImageSearchModel = new ImageSearchModel();
        }


        private string m_SearchString;

        /// <summary>
        /// Binding to get Image Search string 
        /// </summary>
        public string SearchString
        {
            get
            {
                return m_SearchString;
            }
            set
            {
                if (value == SearchString)
                    return;

                m_SearchString = value;
                OnPropertyChanged("SearchString");
            }
        }


        private ObservableCollection<Uri> m_ImageSource;

        /// <summary>
        /// Collection of Images to be displayed
        /// </summary>
        public ObservableCollection<Uri> ImageSource
        {
            get
            {
                if (m_ImageSource == null)
                    m_ImageSource = new ObservableCollection<Uri>();
                return m_ImageSource;
            }
            set
            {
                if (value == m_ImageSource)
                    return;

                m_ImageSource = value;
                OnPropertyChanged("ImageSource");
                OnPropertyChanged("IsVisible");

            }
        }
     
        /// <summary>
        /// Sets the visibilty of the list box
        /// </summary>
        public bool IsVisible
        {
            get
            {
                return (ImageSource.Count > 0) ? true : false;
            }           

        }

        #region Command


        RelayCommand m_Search;

        /// <summary>
        /// Search button click
        /// </summary>
        public ICommand Search
        {
            get
            {
                if (m_Search == null)
                {
                    m_Search = new RelayCommand(
                        param => this.SearchImages(),
                        param => this.CanSearch());
                }
                return m_Search;
            }
        }


        /// <summary>
        /// Enables the search button
        /// </summary>
        /// <returns></returns>
        private bool CanSearch()
        {
            return !string.IsNullOrEmpty(SearchString);
        }


        /// <summary>
        /// Executes search operation
        /// </summary>
        private void SearchImages()
        {
            m_ImageSearchModel.GetImageCollection(SearchString, OnQueryComletion);
        }

        #endregion

        private void OnQueryComletion(IEnumerable<Uri> imageUri)
        {
            var myObservableCollection = new ObservableCollection<Uri>(imageUri);
            ImageSource = myObservableCollection; ;
        }
    }
}
