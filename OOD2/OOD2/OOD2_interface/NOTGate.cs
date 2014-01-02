using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace OOD2_interface
{
    class NOTGate :GATE
    {
        //private bool inputvalue;
        //private bool outputvalue;

        //private bool inputSelected;
        //private bool outputSelected;

        public NOTGate(int locX, int locY, bool input1, bool input2, bool output, bool input1Sel, bool input2Sel, bool outputSel)
            : base(locX, locY)
        {
            input1value = input1;
            input2value = input2;
            outputvalue = output;
            input1Selected = input1Sel;
            input2Selected = input2Sel;
            outputSelected = outputSel;
        }

        public NOTGate(int locX, int locY)
            : base(locX, locY)
        {
            //pre: true
            input1value = false;
            outputvalue = false;
            input2locationX = -1;
            input2locationY = -1;
            //post: variable value set to false
        }

        public override void operation()
        {
            //pre: inputSelected & outputSelected are true
            if (input1value)
                outputvalue = false;
            else
                outputvalue = true;
            //post: get output value from the desired operation
        }

        public override void draw(PaintEventArgs a)
        {
            SolidBrush myBrush = new SolidBrush(Color.White);
            Pen myPen = new Pen(Color.Red);
            Font myFont = new Font("Verdana", 8);
            Brush mystringBrush = new SolidBrush(Color.Black);
            a.Graphics.FillRectangle(myBrush, locationX, locationY, 60, 60);
            a.Graphics.DrawLine(myPen, locationX, locationY + 20, input1locationX, input1locationY);
            //a.Graphics.DrawLine(myPen, locationX, locationY + 40, input1locationX, input2locationY);
            a.Graphics.DrawLine(myPen, locationX + 60, locationY + 30, outputlocationX, outputlocationY);
            a.Graphics.DrawString("NOT", myFont, mystringBrush, locationX + 20, locationY + 20);
        }

        //public void remove()
        //{
        //}
    }
}
