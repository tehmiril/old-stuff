using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace OOD2_interface
{
    class SINKGate :GATE
    {
        //private bool inputvalue;
        //private bool inputSelected;

        public SINKGate(int locX, int locY, bool input1, bool input2, bool output, bool input1Sel, bool input2Sel, bool outputSel)
            : base(locX, locY)
        {
            input1value = input1;
            input2value = input2;
            outputvalue = output;
            input1Selected = input1Sel;
            input2Selected = input2Sel;
            outputSelected = outputSel;
        }

        public SINKGate(int locX, int locY)
            : base(locX, locY)
        {
            //pre: true
            input1locationY = -1;
            outputlocationX = -1;
            outputlocationY = -1;
            input2value = false;
            //post: variable value set to false
        }

        public override void draw(PaintEventArgs a)
        {
            Pen myRedPen = new Pen(Color.Red);
            SolidBrush trueBrush = new SolidBrush(Color.Green);
            SolidBrush falseBrush = new SolidBrush(Color.Red);
            Pen myPen = new Pen(Color.Red);
            if(input2value)
                a.Graphics.FillEllipse(trueBrush, locationX, locationY, 40, 40);
            else
                a.Graphics.FillEllipse(falseBrush, locationX, locationY, 40, 40);
            a.Graphics.DrawLine(myRedPen, new Point(locationX + 10, locationY + 36), new Point(locationX + 10, locationY + 46));
            a.Graphics.DrawLine(myRedPen, new Point(locationX + 10, locationY + 46), new Point(locationX + 30, locationY + 46));
            a.Graphics.DrawLine(myRedPen, new Point(locationX + 30, locationY + 36), new Point(locationX + 30, locationY + 46));
            a.Graphics.DrawLine(myPen, locationX, locationY + 40, input1locationX, input2locationY);
        }

        //public void remove()
        //{
        //}
    }
}
