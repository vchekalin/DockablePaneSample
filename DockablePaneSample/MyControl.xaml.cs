using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Revit.UI;

namespace DockablePaneSample
{
    /// <summary>
    /// Interaction logic for MyControl.xaml
    /// </summary>
    public partial class MyControl : UserControl, IDockablePaneProvider
    {
        public MyControl()
        {
            InitializeComponent();
        }

        public void SetupDockablePane(DockablePaneProviderData data)
        {
            data.FrameworkElement = this;            
        }

        public static DockablePaneId PaneId
        {
            get
            {
                return new DockablePaneId(new Guid("E6EF9DE9-F5F2-454B-8968-4BA2622E5CE5"));
            }
        }

        public static string PaneName
        {
            get
            {
                return "ADN-CIS";
            }
        }
    }
}
