#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace RAB_Session01_Skills
{
    [Transaction(TransactionMode.Manual)]
    public class CmdSkills01 : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)

        {


            // 1. variables (string, int, double, XYZ)
            string myString = "Welcome to Revit Add-in Bootcamp";
            XYZ myPoint = new XYZ(0, 0, 0)
            XYZ offset = new XYZ(0, 1, 0); = 0, 0, 0;


            Transaction t = new Transaction(doc);
            t.start("Create text note");


            // 2. for loops
            int total = 0;
            for(int i = 0; 1 <=10; i++)
            {
                total = total + i;
            }


            // 3. conditional logic (<, >, ++, &&, ||)
            string result = "";
            if(total > 10 || total < 100)
            {
                result = "It's a big number";
            }
            
            else if(total >5)
            { 
                result = "It's a medium number!"; 
            }

            else if(total == 4)
            {
                result = "The number is 4";

            }

            else 
            { 
                result = "It's a big number!";
            }


            // 5. Filtered Element Collectors
            FilteredElementCollector collector = new FilteredElementCollector(doc)
            //collector.OfCategory(BuiltInCategory.OST_Textnotes);
            //collector.WhereElementIsElementType();
            collector.OfClass(typeof(TextNoteType));



         

            // 4. Text Notes
            TextNote myTextNote = myTextNote.Create(doc,
                doc.ActiveView.ID, myPoint, myString, collector.FirstElementID());



            t.Commit();




            
            


        }



        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // Access current selection

            Selection sel = uidoc.Selection;

            // Retrieve elements from database

            FilteredElementCollector col
              = new FilteredElementCollector(doc)
                .WhereElementIsNotElementType()
                .OfCategory(BuiltInCategory.INVALID)
                .OfClass(typeof(Wall));

            // Filtered element collector is iterable

            foreach (Element e in col)
            {
                Debug.Print(e.Name);
            }

            // Modify document within a transaction

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Transaction Name");
                tx.Commit();
            }

            return Result.Succeeded;
        }
    }
}
