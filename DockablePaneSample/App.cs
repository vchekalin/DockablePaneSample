#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;

#endregion

namespace DockablePaneSample
{
    class App : IExternalApplication
    {
        public static MyControl MyDockablePaneControl;

        public Result OnStartup(UIControlledApplication a)
        {
            a.ViewActivated += OnViewActivated;

            MyDockablePaneControl = new MyControl();

            MyDockablePaneViewModel dockablePaneViewModel =
               new MyDockablePaneViewModel();

            MyDockablePaneControl.DataContext = dockablePaneViewModel;

            if (!DockablePane.PaneIsRegistered(MyControl.PaneId))
            {
                a.RegisterDockablePane(MyControl.PaneId,
                    MyControl.PaneName,
                    MyDockablePaneControl);
            }
            

            return Result.Succeeded;
        }

        private void OnViewActivated(object sender, ViewActivatedEventArgs e)
        {
            if (e.Document == null)
                return;

            var viewModel = MyDockablePaneControl.DataContext as MyDockablePaneViewModel;

            if (viewModel != null)
            {
                viewModel.DocumentTitle = e.Document.Title;
            }
        }

           
        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
