using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace OOD2_interface
{
    class CONNECTION
    {
        private bool value;

        private int conn_Gate1X;
        private int conn_Gate1Y;
        private int conn_Gate2X;
        private int conn_Gate2Y;

        private int inputNumber;

        public GATE inputGate;
        public GATE outputGate;

        public CONNECTION(GATE gate1, GATE gate2, int conn1X, int conn1Y, int conn2X, int conn2Y, int inputNum)
        {
            //pre:
            value = false;
            inputGate = gate1;
            outputGate = gate2;
            conn_Gate1X = conn1X;
            conn_Gate1Y = conn1Y;
            conn_Gate2X = conn2X;
            conn_Gate2Y = conn2Y;
            inputNumber = inputNum;
        }

        public void draw(PaintEventArgs a)
        {
            Pen myRedPen = new Pen(Color.Red);
            Pen myGreenPen = new Pen(Color.Green);
            if (value)
                a.Graphics.DrawLine(myGreenPen, conn_Gate1X, conn_Gate1Y, conn_Gate2X, conn_Gate2Y);
            else
                a.Graphics.DrawLine(myRedPen, conn_Gate1X, conn_Gate1Y, conn_Gate2X, conn_Gate2Y);
        }

        public int Gate1_prop_X
        {
            get { return conn_Gate1X; }
        }

        public int inputNum
        {
            get { return inputNumber; }
        }

        public int Gate1_prop_Y
        {
            get { return conn_Gate1Y; }
        }

        public int Gate2_prop_X
        {
            get { return conn_Gate2X; }
        }

        public int Gate2_prop_Y
        {
            get { return conn_Gate2Y; }
        }

        public void transferValue()
        {
            if (inputNumber == 1)
            {
                outputGate.valueInput1 = inputGate.valueOutput;
                value = inputGate.valueOutput;
            }
            else
            {
                outputGate.valueInput2 = inputGate.valueOutput;
                value = inputGate.valueOutput;
            }
        }

        public void removeConnection()
        {
            inputGate.outpSelected = false;
            if (inputNumber == 1)
                outputGate.inp1Selected = false;
            else
                outputGate.inp2Selected = false;
        }
    }
}
