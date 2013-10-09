#region Namespaces

using System;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

#endregion

namespace DockablePaneSample
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;

            if (DockablePane.PaneIsRegistered(MyControl.PaneId))
            {
                DockablePane myCustomPane =
                    uiapp.GetDockablePane(MyControl.PaneId);
                myCustomPane.Show();
            }
            else
            {
                return Result.Failed;
            }

            return Result.Succeeded;
        }
    }
    
}
