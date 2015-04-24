using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;

namespace AutocadAddin
{
    public partial class DrawForm : Form
    {
        public DrawForm()
        {
            InitializeComponent();
        }

        private Button _selected;

        private void InnerBtn_Click(object sender, EventArgs e)
        {
            _selected = InnerBtn;
            ShowColorDialog();
        }

        private void MiddleBtn_Click(object sender, EventArgs e)
        {
            _selected = MiddleBtn;
            ShowColorDialog();
        }

        private void OuterBtn_Click(object sender, EventArgs e)
        {
            _selected = OuterBtn;
            ShowColorDialog();
        }

        private void ShowColorDialog()
        {
            DialogResult result = colorDialog.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                _selected.BackColor = colorDialog.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DrawCirle();
        }

        public void DrawCirle()
        {
            Database db = HostApplicationServices.WorkingDatabase;

            Document doc = (Document)Autodesk.AutoCAD.ApplicationServices.
                Application.DocumentWindowCollection.ActiveDocumentWindow.Document;
            
            // Lock the document before we access it
            DocumentLock loc = doc.LockDocument();

            using (loc)
            {

                Transaction tr = db.TransactionManager.StartTransaction();

                using (tr)
                {

                    // Create our circles
                    Circle Outer = new Circle(new Point3d(0, 0, 0), new Vector3d(0, 0, 1), 10);
                    Circle Middle = new Circle(new Point3d(0, 0, 0), new Vector3d(0, 0, 1), 7);
                    Circle Inner = new Circle(new Point3d(0, 0, 0), new Vector3d(0, 0, 1), 4);

                    //set the colors
                    Outer.Color = Autodesk.AutoCAD.Colors.Color.FromColor(OuterBtn.BackColor);
                    Inner.Color = Autodesk.AutoCAD.Colors.Color.FromColor(InnerBtn.BackColor);
                    Middle.Color = Autodesk.AutoCAD.Colors.Color.FromColor(MiddleBtn.BackColor);

                    Outer.SetDatabaseDefaults(db);
                    Inner.SetDatabaseDefaults(db);
                    Middle.SetDatabaseDefaults(db);

                    // Add it to the current space
                    BlockTableRecord btr = (BlockTableRecord)tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);

                    btr.AppendEntity(Outer);
                    btr.AppendEntity(Middle); 
                    btr.AppendEntity(Inner);

                    tr.AddNewlyCreatedDBObject(Outer, true);
                    tr.AddNewlyCreatedDBObject(Middle, true);
                    tr.AddNewlyCreatedDBObject(Inner, true);


                    ObjectIdCollection outerCollection = new ObjectIdCollection();
                    outerCollection.Add(Outer.ObjectId);

                    // Create the hatch object and append it to the block table record
                    Hatch outerHatch = new Hatch();
                    btr.AppendEntity(outerHatch);
                    tr.AddNewlyCreatedDBObject(outerHatch, true);

                    // Set the properties of the hatch object
                    // Associative must be set after the hatch object is appended to the 
                    // block table record and before AppendLoop
                    outerHatch.SetDatabaseDefaults();
                    outerHatch.SetHatchPattern(HatchPatternType.PreDefined, "FLEX");
                    outerHatch.Associative = true;
                    outerHatch.AppendLoop(HatchLoopTypes.Outermost, outerCollection);

                    // Adds the circle to an object id collection
                    outerCollection.Clear();
                    outerCollection.Add(Middle.ObjectId);

                    // Append the circle as the inner loop of the hatch and evaluate it
                    outerHatch.AppendLoop(HatchLoopTypes.Default, outerCollection);
                    outerHatch.EvaluateHatch(true);

                    //innerCollection
                    ObjectIdCollection innerCollection = new ObjectIdCollection();
                    innerCollection.Add(Middle.ObjectId);

                    // Create the hatch object and append it to the block table record
                    Hatch innerHatch = new Hatch();
                    btr.AppendEntity(innerHatch);
                    tr.AddNewlyCreatedDBObject(innerHatch, true);

                    // Set the properties of the hatch object
                    // Associative must be set after the hatch object is appended to the 
                    // block table record and before AppendLoop
                    innerHatch.SetDatabaseDefaults();
                    innerHatch.SetHatchPattern(HatchPatternType.PreDefined, "ANGLE");
                    innerHatch.Associative = true;
                    innerHatch.AppendLoop(HatchLoopTypes.Outermost, innerCollection);

                    // Adds the circle to an object id collection
                    innerCollection.Clear();
                    innerCollection.Add(Inner.ObjectId);

                    // Append the circle as the inner loop of the hatch and evaluate it
                    innerHatch.AppendLoop(HatchLoopTypes.Default, innerCollection);
                    innerHatch.EvaluateHatch(true);

                    //create new block reference
                    BlockReference outerHatchblockRef = tr.GetObject(outerHatch.ObjectId,
                               OpenMode.ForRead) as BlockReference;

                    BlockReference innerHatchblockRef = tr.GetObject(innerHatch.ObjectId,
                                OpenMode.ForRead) as BlockReference;
 
                    tr.Commit();
                }

            }

        }
   }
}
