using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace OOD2_interface
{
    class ORGate :GATE
    {
        //private bool input1value;
        //private bool input2value;
        //private bool outputvalue;

        //private bool input1Selected;
        //private bool input2Selected;
        //private bool outputSelected;

        public ORGate(int locX, int locY, bool input1, bool input2, bool output, bool input1Sel, bool input2Sel, bool outputSel)
            : base(locX, locY)
        {
            input1value = input1;
            input2value = input2;
            outputvalue = output;
            input1Selected = input1Sel;
            input2Selected = input2Sel;
            outputSelected = outputSel;
        }

        public ORGate(int locX, int locY)
            : base(locX, locY)
        {
            //pre: true
            input1value = false;
            input2value = false;
            outputvalue = false;
            input1Selected = false;
            input2Selected = false;
            outputSelected = false;
            //post: variable value set to false
        }

        public override void operation()
        {
            //pre: input1Selected & input2Selected & outputSelected are true
            if (!input1value && !input2value)
                outputvalue = false;
            else
                outputvalue = true;
            //post: get output value from the desired operation
        }

        public override void draw(PaintEventArgs a)
        {
            SolidBrush myBrush = new SolidBrush(Color.White);
            Font myFont = new Font("Verdana", 8);
            Pen myPen = new Pen(Color.Red);
            Brush mystringBrush = new SolidBrush(Color.Black);
            a.Graphics.FillRectangle(myBrush, locationX, locationY, 60, 60);
            a.Graphics.DrawLine(myPen, locationX, locationY + 20, input1locationX, input1locationY);
            a.Graphics.DrawLine(myPen, locationX, locationY + 40, input1locationX, input2locationY);
            a.Graphics.DrawLine(myPen, locationX + 60, locationY + 30, outputlocationX, outputlocationY);
            a.Graphics.DrawString("OR", myFont, mystringBrush, locationX + 20, locationY + 20);
        }

        //public void remove()
        //{
        //}
    }
}
