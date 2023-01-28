using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Kitware.VTK;


namespace CowDemoC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.renderWindowControl = new Kitware.VTK.RenderWindowControl();
            this.renderWindowControl.AddTestActors = false;
            this.renderWindowControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderWindowControl.Location = new System.Drawing.Point(0, 0);
            this.renderWindowControl.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.renderWindowControl.Name = "renderWindowControl";
            this.renderWindowControl.Size = new System.Drawing.Size(617, 347);
            this.renderWindowControl.TabIndex = 0;
            this.renderWindowControl.TestText = null;
            this.renderWindowControl.Load += new System.EventHandler(this.VTKrenderWindowControl_Load);
            pictureBox1.Controls.Add(this.renderWindowControl);
        }


        public Kitware.VTK.RenderWindowControl renderWindowControl;

        private void VTKrenderWindowControl_Load(object sender, EventArgs e)
        {
            try
            {
                CowTransformTestFun();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK);
            }
        }

        private void CowTransformTestFun()
        {
            string strPath1 = "cow.vtp";

            vtkRenderWindow renWin = renderWindowControl.RenderWindow;
            vtkRenderer render = renWin.GetRenderers().GetFirstRenderer();

            vtkXMLPolyDataReader reader = vtkXMLPolyDataReader.New();
            reader.SetFileName(strPath1);
            reader.Update();

            vtkAxesActor axes01 = vtkAxesActor.New();
            double[] bounds = new double[6];
            bounds = reader.GetOutput().GetBounds();
            Debug.WriteLine(bounds[0] + " " + bounds[1] + " " + bounds[2] + " " + bounds[3] + " "
                + bounds[4] + " " + bounds[5] + " ");
            double[] axeLength = new double[3] { bounds[1] - bounds[0], bounds[3] - bounds[2], 4 * (bounds[5] - bounds[4]) };

            IntPtr paxeLength = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(double)) * 3);
            Marshal.Copy(axeLength, 0, paxeLength, 3);
            axes01.SetTotalLength(paxeLength);
            Marshal.FreeHGlobal(paxeLength);

            vtkPolyDataMapper mapper01 = vtkPolyDataMapper.New();
            mapper01.SetInputConnection(reader.GetOutputPort());

            vtkActor actor01 = vtkActor.New();
            vtkTransform myTrans01 = vtkTransform.New();
            double r = (bounds[5] - bounds[4]) + 1;
            double alpha = 90 * Math.PI / 180.0;
            double[] origin01 = new double[3] {Math.Cos(alpha)* r,
                0, Math.Sin(alpha)*r };
            IntPtr porigin01 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(double)) * 3);
            Marshal.Copy(origin01, 0, porigin01, 3);
            myTrans01.Translate(porigin01);
            myTrans01.Update();
            Marshal.FreeHGlobal(porigin01);
            actor01.SetMapper(mapper01);
            actor01.SetUserMatrix(myTrans01.GetMatrix());

            alpha = 30 * Math.PI / 180.0;
            vtkActor actor02 = vtkActor.New();
            vtkTransform myTrans02 = vtkTransform.New();
            double[] origin02 = new double[3] {Math.Cos(alpha)* r,
                0, Math.Sin(alpha)*r };
            IntPtr porigin02 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(double)) * 3);
            Marshal.Copy(origin02, 0, porigin02, 3);
            myTrans02.Translate(porigin02);
            myTrans02.RotateY(60);
            myTrans02.Update();
            Marshal.FreeHGlobal(porigin02);
            actor02.SetMapper(mapper01);
            actor02.SetUserMatrix(myTrans02.GetMatrix());

            alpha = (-30) * Math.PI / 180.0;
            vtkActor actor03 = vtkActor.New();
            vtkTransform myTrans03 = vtkTransform.New();
            double[] origin03 = new double[3] {Math.Cos(alpha)* r,
                0, Math.Sin(alpha)*r };
            IntPtr porigin03 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(double)) * 3);
            Marshal.Copy(origin03, 0, porigin03, 3);
            myTrans03.Translate(porigin03);
            myTrans03.RotateY(120);
            myTrans03.Update();
            Marshal.FreeHGlobal(porigin03);
            actor03.SetMapper(mapper01);
            actor03.SetUserMatrix(myTrans03.GetMatrix());

            alpha = (-90) * Math.PI / 180.0;
            vtkActor actor04 = vtkActor.New();
            vtkTransform myTrans04 = vtkTransform.New();
            double[] origin04 = new double[3] {Math.Cos(alpha)* r,
                0, Math.Sin(alpha)*r };
            IntPtr porigin04 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(double)) * 3);
            Marshal.Copy(origin04, 0, porigin04, 3);
            myTrans04.Translate(porigin04);
            myTrans04.RotateY(180);
            myTrans04.Update();
            Marshal.FreeHGlobal(porigin04);
            actor04.SetMapper(mapper01);
            actor04.SetUserMatrix(myTrans04.GetMatrix());

            alpha = 210 * Math.PI / 180.0;
            vtkActor actor05 = vtkActor.New();
            vtkTransform myTrans05 = vtkTransform.New();
            double[] origin05 = new double[3] {Math.Cos(alpha)* r,
                0, Math.Sin(alpha)*r };
            IntPtr porigin05 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(double)) * 3);
            Marshal.Copy(origin05, 0, porigin05, 3);
            myTrans05.Translate(porigin05);
            myTrans05.RotateY(-120);
            myTrans05.Update();
            Marshal.FreeHGlobal(porigin05);
            actor05.SetMapper(mapper01);
            actor05.SetUserMatrix(myTrans05.GetMatrix());

            alpha = 150 * Math.PI / 180.0;
            vtkActor actor06 = vtkActor.New();
            vtkTransform myTrans06 = vtkTransform.New();
            double[] origin06 = new double[3] {Math.Cos(alpha)* r,
                0, Math.Sin(alpha)*r };
            IntPtr porigin06 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(double)) * 3);
            Marshal.Copy(origin06, 0, porigin06, 3);
            myTrans06.Translate(porigin06);
            myTrans06.RotateY(-60);
            myTrans06.Update();
            Marshal.FreeHGlobal(porigin06);
            actor06.SetMapper(mapper01);
            actor06.SetUserMatrix(myTrans06.GetMatrix());

            render.AddActor(axes01);
            render.AddActor(actor01);
            render.AddActor(actor02);
            render.AddActor(actor03);
            render.AddActor(actor04);
            render.AddActor(actor05);
            render.AddActor(actor06);
            render.SetBackground(0.2, 0.3, 0.4);

            renWin.AddRenderer(render);
            renWin.SetWindowName("Cow");

            renWin.Render();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
