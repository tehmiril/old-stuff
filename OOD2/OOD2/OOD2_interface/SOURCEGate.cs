using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace OOD2_interface
{
    class SOURCEGate :GATE
    {
        //private bool outputvalue;
        //private bool outputSelected;

        public SOURCEGate(int locX, int locY, bool input1, bool input2, bool output, bool input1Sel, bool input2Sel, bool outputSel)
            : base(locX, locY)
        {
            input1value = input1;
            input2value = input2;
            outputvalue = output;
            input1Selected = input1Sel;
            input2Selected = input2Sel;
            outputSelected = outputSel;
        }

        public SOURCEGate(int locX, int locY)
            : base(locX, locY)
        {
            //pre: true
            input1locationX = -1;
            input1locationY = -1;
            input2locationX = -1;
            input2locationY = -1;
            outputvalue = false;
            //post: variable value set to false
        }

        public bool changeSourceValue()
        {
            throw new System.NotImplementedException();
        }

        public override void draw(PaintEventArgs a)
        {
            SolidBrush myTrueBrush = new SolidBrush(Color.Green);
            SolidBrush myFalseBrush = new SolidBrush(Color.Red);
            Font myFont = new Font("Verdana", 8);
            Pen myPen = new Pen(Color.Red);
            Brush mystringBrush = new SolidBrush(Color.Black);
            if (outputvalue)
            {
                a.Graphics.FillEllipse(myTrueBrush, locationX, locationY, 60, 40);
                a.Graphics.DrawLine(myPen, locationX + 60, locationY + 30, outputlocationX, outputlocationY);
                a.Graphics.DrawString("SOURCE", myFont, mystringBrush, locationX + 5, locationY + 7);
            }
            else
            {
                a.Graphics.FillEllipse(myFalseBrush, locationX, locationY, 60, 40);
                a.Graphics.DrawLine(myPen, locationX + 60, locationY + 30, outputlocationX, outputlocationY);
                a.Graphics.DrawString("SOURCE", myFont, mystringBrush, locationX + 5, locationY + 7);
            }
        }

        public override void changeValue()
        {
            if (outputvalue)
                outputvalue = false;
            else
            outputvalue = true;
        }

        //public void remove()
        //{
        //}
    }
}
