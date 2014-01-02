using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OOD2_interface
{
    abstract class GATE
    {
        protected int locationX;
        protected int locationY;

        protected bool input1value;
        protected bool input2value;
        protected bool outputvalue;

        protected int input1locationX;
        protected int input1locationY;

        protected int input2locationX;
        protected int input2locationY;
        
        protected int outputlocationX;
        protected int outputlocationY;

        protected bool input1Selected;
        protected bool input2Selected;
        protected bool outputSelected;

        public GATE(int X, int Y)
        {
            //pre: true
            locationX = X;
            locationY = Y;
            input1locationX = locationX - 20;
            input1locationY = locationY + 20;
            input2locationX = locationX - 20;
            input2locationY = locationY + 40;
            outputlocationX = locationX + 80;
            outputlocationY = locationY + 30;
            //post:
        }

        public int prop_X
        {
            get { return locationX; }
        }

        public int prop_Y
        {
            get { return locationY; }
        }

        public int inp1_prop_X
        {
            get { return input1locationX; }
        }

        public int inp1_prop_Y
        {
            get { return input1locationY; }
        }

        public int inp2_prop_X
        {
            get { return input2locationX; }
        }

        public int inp2_prop_Y
        {
            get { return input2locationY; }
        }

        public int outp_prop_X
        {
            get { return outputlocationX; }
        }

        public int outp_prop_Y
        {
            get { return outputlocationY; }
        }

        public bool inp1Selected
        {
            get { return input1Selected; }
            set { input1Selected = value; }
        }

        public bool inp2Selected
        {
            get { return input2Selected; }
            set { input2Selected = value; }
        }

        public bool outpSelected
        {
            get { return outputSelected; }
            set { outputSelected = value; }
        }

        public bool valueInput1
        {
            get { return input1value; }
            set { input1value = value; }
        }

        public bool valueInput2
        {
            get { return input2value; }
            set { input2value = value; }
        }

        public bool valueOutput
        {
            get { return outputvalue; }
        }

        public virtual void draw(PaintEventArgs a)
        {
        }

        public virtual void operation()
        {
        }

        public virtual void changeValue()
        {
        }

        //public void remove()
        //{
        //}
    }
}
