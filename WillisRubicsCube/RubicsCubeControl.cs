using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WillisRubicsCube
{
    public partial class RubicsCubeControl : UserControl
    {
        #region Private Members
        private RubicsCube _clsRubicsCube = new RubicsCube();
        #endregion Private Members

        #region Constructor
        public RubicsCubeControl()
        {
            InitializeComponent();

            _clsRubicsCube.Reset();

            // use the button click tag to save the reference for the ICommand
            Button_ILeft.Tag = _clsRubicsCube.InvRotateLeft;
            Button_Left.Tag = _clsRubicsCube.RotateLeft;

            Button_IRight.Tag = _clsRubicsCube.InvRotateRight;
            Button_Right.Tag = _clsRubicsCube.RotateRight;

            ButtonIBack.Tag = _clsRubicsCube.InvRotateBack;
            ButtonBack.Tag = _clsRubicsCube.RotateBack;

            ButtonIUp.Tag = _clsRubicsCube.InvRotateUp;
            ButtonUp.Tag = _clsRubicsCube.RotateUp;

            ButtonIDown.Tag = _clsRubicsCube.InvRotateDown;
            ButtonDown.Tag = _clsRubicsCube.RotateDown;

            ButtonIFront.Tag = _clsRubicsCube.InvRotateFront;
            ButtonFront.Tag = _clsRubicsCube.RotateFront;
        }
        #endregion Constructor

        #region Properties
        public RubicsCube TheRubicsCube { get { return _clsRubicsCube; } }
        #endregion Properties

        #region Events
        public event ICommandHandler ExecuteCommandEvent;
        #endregion Events

        #region Public Methods

        #endregion Public Methods

        #region Private Methods
        private void Refresh_Tick(object sender, EventArgs e)
        {
            RefreshRubicsCube();
        }
        #endregion Private Methods

        #region Private Methods
        private void Button_Right_Click(object sender, EventArgs e)
        {
            ExecuteICommand((sender as Button).Tag);
        }

        private void Button_Left_Click(object sender, EventArgs e)
        {
            ExecuteICommand((sender as Button).Tag);
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            ExecuteICommand((sender as Button).Tag);
        }

        private void ButtonDown_Click(object sender, EventArgs e)
        {
            ExecuteICommand((sender as Button).Tag);
        }

        private void ButtonFront_Click(object sender, EventArgs e)
        {
            ExecuteICommand((sender as Button).Tag);
        }

        private void ButtonUp_Click(object sender, EventArgs e)
        {
            ExecuteICommand((sender as Button).Tag);
        }

        private void Button_IRight_Click(object sender, EventArgs e)
        {
            ExecuteICommand((sender as Button).Tag);
        }

        private void Button_ILeft_Click(object sender, EventArgs e)
        {
            ExecuteICommand((sender as Button).Tag);
        }

        private void ButtonIBack_Click(object sender, EventArgs e)
        {
            ExecuteICommand((sender as Button).Tag);
        }

        private void ButtonIDown_Click(object sender, EventArgs e)
        {
            ExecuteICommand((sender as Button).Tag);
        }

        private void ButtonIFront_Click(object sender, EventArgs e)
        {
            ExecuteICommand((sender as Button).Tag);
        }

        private void ButtonIUp_Click(object sender, EventArgs e)
        {
            ExecuteICommand((sender as Button).Tag);
        }

        private void ExecuteICommand(object objCmd)
        {
            try
            {
                (objCmd as ICommand).Execute();
                if (ExecuteCommandEvent != null)
                {
                    ExecuteCommandEvent(this, new ICommandArgs(objCmd as ICommand));
                }
            }
            catch (Exception ex)
            {
                Debug.Assert(false, "[RubicsCubeControl::ExecuteICommand] Assert -> " + ex.Message);
            }
        }

        private void RefreshRubicsCube()
        {
            foreach (Control clsControl in this.Controls)
            {
                if (clsControl is CubieControl)
                {
                    (clsControl as CubieControl).LoadCubie(_clsRubicsCube.Cubies);
                }
            }
        }
        #endregion Private Methods
    }
}
