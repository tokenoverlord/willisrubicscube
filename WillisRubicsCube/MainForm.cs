using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WillisRubicsCube
{
    public partial class MainForm : Form
    {
        #region Private Members
        private Random _clsRand = new Random(DateTime.Now.Second);
        private CubeSolver _clsSolver = new CubeSolver();
        #endregion Private Members

        public MainForm()
        {
            InitializeComponent();
        }

        #region Private Methods
        private void ButtonScramble_Click(object sender, EventArgs e)
        {
        //    // get the num
        //    decimal numLoop = numericUpDown1.Value;

        //    while (numLoop >= 0)
        //    {
        //        switch (_clsRand.Next(0, 11))
        //        {
        //            case 0:
        //                ExecuteICommand(_clsRotateFaceBack);
        //                break;
        //            case 1:
        //                ExecuteICommand(_clsRotateFaceDown);
        //                break;
        //            case 2:
        //                ExecuteICommand(_clsRotateFaceFront);
        //                break;
        //            case 3:
        //                ExecuteICommand(_clsRotateFaceIBack);
        //                break;
        //            case 4:
        //                ExecuteICommand(_clsRotateFaceIDown);
        //                break;
        //            case 5:
        //                ExecuteICommand(_clsRotateFaceIFront);
        //                break;
        //            case 6:
        //                ExecuteICommand(_clsRotateFaceILeft);
        //                break;
        //            case 7 :
        //                ExecuteICommand(_clsRotateFaceIRight);
        //                break;
        //            case 8:
        //                ExecuteICommand(_clsRotateFaceIUp);
        //                break;
        //            case 9:
        //                ExecuteICommand(_clsRotateFaceLeft);
        //                break;
        //            case 10:
        //                ExecuteICommand(_clsRotateFaceRight);
        //                break;
        //            case 11:
        //                ExecuteICommand(_clsRotateFaceUp);
        //                break;
        //        }

        //        numLoop--;
        //    }
        }

        private void ButtonSolve_Click(object sender, EventArgs e)
        {

        }

        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            historyControl1.Undo();
        }

        private void ButtonRedo_Click(object sender, EventArgs e)
        {
            historyControl1.Redo();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            historyControl1.Clear();
        }

        private void cubeFaceDisplay2_ExecuteCommandEvent(object sender, ICommandArgs args)
        {
            historyControl1.Add(args.Command);
        }
        #endregion Private Methods
    }
}
