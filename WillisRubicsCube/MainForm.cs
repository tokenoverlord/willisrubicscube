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
        private RCubeManager _clsManager = new RCubeManager();
        private CommandManager _clsCmdManager = new CommandManager();
        private Random _clsRand = new Random(DateTime.Now.Second);
        private CubeSolver _clsSolver = new CubeSolver();

        #region Face Rotation
        private CommandRotateFace _clsRotateFaceRight;
        private CommandRotateFace _clsRotateFaceIRight;
        
        private CommandRotateFace _clsRotateFaceLeft;
        private CommandRotateFace _clsRotateFaceILeft;

        private CommandRotateFace _clsRotateFaceBack;
        private CommandRotateFace _clsRotateFaceIBack;

        private CommandRotateFace _clsRotateFaceDown;
        private CommandRotateFace _clsRotateFaceIDown;

        private CommandRotateFace _clsRotateFaceFront;
        private CommandRotateFace _clsRotateFaceIFront;

        private CommandRotateFace _clsRotateFaceUp;
        private CommandRotateFace _clsRotateFaceIUp;
        #endregion Face Rotation

        #region Cube Rotation
        private CommandRotateCube _clsRotateCubeUp;
        private CommandRotateCube _clsRotateCubeDown;
        private CommandRotateCube _clsRotateCubeRight;
        private CommandRotateCube _clsRotateCubeLeft;
        private CommandRotateCube _clsRotateCubeCW;
        private CommandRotateCube _clsRotateCubeCCW;
        #endregion Cube Rotation

        #region Undo Redo Clear
        CommandClearHistory _clsCommandClearHistory;
        CommandUndo _clsCommandUndo;
        CommandRedo _clsCommandRedo;
        #endregion Undo Redo Clear
        #endregion Private Members

        public MainForm()
        {
            InitializeComponent();
            
            cubeFaceDisplay1.LoadManager(_clsManager);
            historyControl1.LoadManager(_clsCmdManager);

            #region Face Rotations
            _clsRotateFaceBack = new CommandRotateFace(_clsManager, FaceRotateNotation.Back, FaceRotateNotation.Back_Inverted);
            _clsRotateFaceDown = new CommandRotateFace(_clsManager, FaceRotateNotation.Down, FaceRotateNotation.Down_Inverted);
            _clsRotateFaceFront = new CommandRotateFace(_clsManager, FaceRotateNotation.Front, FaceRotateNotation.Front_Inverted);

            _clsRotateFaceIBack = new CommandRotateFace(_clsManager, FaceRotateNotation.Back_Inverted, FaceRotateNotation.Back);
            _clsRotateFaceIDown = new CommandRotateFace(_clsManager, FaceRotateNotation.Down_Inverted, FaceRotateNotation.Down);
            _clsRotateFaceIFront = new CommandRotateFace(_clsManager, FaceRotateNotation.Front_Inverted, FaceRotateNotation.Front);

            _clsRotateFaceILeft = new CommandRotateFace(_clsManager, FaceRotateNotation.Left_Inverted, FaceRotateNotation.Left);
            _clsRotateFaceIRight = new CommandRotateFace(_clsManager, FaceRotateNotation.Right_Inverted, FaceRotateNotation.Right);
            _clsRotateFaceIUp = new CommandRotateFace(_clsManager, FaceRotateNotation.Up_Inverted, FaceRotateNotation.Up);

            _clsRotateFaceLeft = new CommandRotateFace(_clsManager, FaceRotateNotation.Left, FaceRotateNotation.Left_Inverted);
            _clsRotateFaceRight = new CommandRotateFace(_clsManager, FaceRotateNotation.Right, FaceRotateNotation.Right_Inverted);
            _clsRotateFaceUp = new CommandRotateFace(_clsManager, FaceRotateNotation.Up, FaceRotateNotation.Up_Inverted);
            #endregion Face Rotations

            #region Cube Rotations
            _clsRotateCubeCCW = new CommandRotateCube(_clsManager, CubeRotateNotation.CounterClockWise, CubeRotateNotation.ClockWise);
            _clsRotateCubeCW = new CommandRotateCube(_clsManager, CubeRotateNotation.ClockWise, CubeRotateNotation.CounterClockWise);
            _clsRotateCubeDown = new CommandRotateCube(_clsManager, CubeRotateNotation.Down, CubeRotateNotation.Up);
            _clsRotateCubeLeft = new CommandRotateCube(_clsManager, CubeRotateNotation.Left, CubeRotateNotation.Right);
            _clsRotateCubeRight = new CommandRotateCube(_clsManager, CubeRotateNotation.Right, CubeRotateNotation.Left);
            _clsRotateCubeUp = new CommandRotateCube(_clsManager, CubeRotateNotation.Up, CubeRotateNotation.Down);
            #endregion Cube Rotations

            #region Undo Redo Clear
            _clsCommandClearHistory = new CommandClearHistory(_clsCmdManager);
            _clsCommandUndo = new CommandUndo(_clsCmdManager);
            _clsCommandRedo = new CommandRedo(_clsCmdManager);
            #endregion Undo Redo Clear
        }

        #region Private Methods
        #region Face Rotation
        private void Button_Right_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsRotateFaceRight);//.Execute();
        }

        private void Button_IRight_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsRotateFaceIRight);//.Execute();
        }

        private void Button_Left_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsRotateFaceLeft);//.Execute();
        }

        private void Button_ILeft_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsRotateFaceILeft);//.Execute();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsRotateFaceBack);//.Execute();
        }

        private void ButtonIBack_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsRotateFaceIBack);//.Execute();
        }

        private void ButtonDown_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsRotateFaceDown);//.Execute();
        }

        private void ButtonIDown_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsRotateFaceIDown);//.Execute();
        }

        private void ButtonFront_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsRotateFaceFront);//.Execute();
        }

        private void ButtonIFront_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsRotateFaceIFront);//.Execute();
        }

        private void ButtonUp_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsRotateFaceUp);//.Execute();
        }

        private void ButtonIUp_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsRotateFaceIUp);//.Execute();
        }
        #endregion Face Rotation

        #region Cube Rotation
        private void ButtonCubeUp_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsRotateCubeUp);//.Execute();
        }

        private void ButtonCubeRight_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsRotateCubeRight);//.Execute();
        }

        private void ButtonCubeLeft_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsRotateCubeLeft);//.Execute();
        }

        private void ButtonCubeDown_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsRotateCubeDown);//.Execute();
        }

        private void ButtonCubeCW_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsRotateCubeCW);//.Execute();
        }

        private void ButtonCubeCCW_Click(object sender, EventArgs e)
        {
            //_clsRotateCubeCCW.Execute();
            ExecuteICommand(_clsRotateCubeCCW);
        }
        #endregion Cube Rotation

        private void ButtonScramble_Click(object sender, EventArgs e)
        {
            // get the num
            decimal numLoop = numericUpDown1.Value;

            while (numLoop >= 0)
            {
                switch (_clsRand.Next(0, 11))
                {
                    case 0:
                        ExecuteICommand(_clsRotateFaceBack);
                        break;
                    case 1:
                        ExecuteICommand(_clsRotateFaceDown);
                        break;
                    case 2:
                        ExecuteICommand(_clsRotateFaceFront);
                        break;
                    case 3:
                        ExecuteICommand(_clsRotateFaceIBack);
                        break;
                    case 4:
                        ExecuteICommand(_clsRotateFaceIDown);
                        break;
                    case 5:
                        ExecuteICommand(_clsRotateFaceIFront);
                        break;
                    case 6:
                        ExecuteICommand(_clsRotateFaceILeft);
                        break;
                    case 7 :
                        ExecuteICommand(_clsRotateFaceIRight);
                        break;
                    case 8:
                        ExecuteICommand(_clsRotateFaceIUp);
                        break;
                    case 9:
                        ExecuteICommand(_clsRotateFaceLeft);
                        break;
                    case 10:
                        ExecuteICommand(_clsRotateFaceRight);
                        break;
                    case 11:
                        ExecuteICommand(_clsRotateFaceUp);
                        break;
                }

                numLoop--;
            }
        }

        private void ButtonSolve_Click(object sender, EventArgs e)
        {

        }

        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsCommandUndo);
        }

        private void ButtonRedo_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsCommandRedo);
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            ExecuteICommand(_clsCommandClearHistory);
        }

        private void ExecuteICommand(ICommand clsCommand)
        {
            clsCommand.Execute();
            _clsCmdManager.Add(clsCommand);
            textBoxPercentSolved.Text = _clsSolver.GetPercentSolved(_clsManager.RubicsCube).ToString();
        }
        #endregion Private Methods
    }
}
