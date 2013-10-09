using System.ComponentModel;
using DockablePaneSample.Annotations;

namespace DockablePaneSample
{
    public class MyDockablePaneViewModel : INotifyPropertyChanged
    {
        private string _documentTitle;

        public string DocumentTitle
        {
            get { return _documentTitle; }
            set
            {
                _documentTitle = value;
                OnPropertyChanged("DocumentTitle");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}