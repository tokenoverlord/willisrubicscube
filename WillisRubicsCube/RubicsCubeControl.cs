using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WillisRubicsCube
{
    public partial class RubicsCubeControl : UserControl
    {
        #region Private Members
        private RCubeManager _clsRCubeManager
            = new RCubeManager();
        #endregion Private Members

        #region Constructor
        public RubicsCubeControl()
        {
            InitializeComponent();

            _clsRCubeManager.RestCommand.Execute();

            // use the button click tag to save the reference for the ICommand
            Button_ILeft.Tag = _clsRCubeManager.RotateILeftCommand;
            Button_Left.Tag = _clsRCubeManager.RotateLeftCommand;

            Button_IRight.Tag = _clsRCubeManager.RotateIRightCommand;
            Button_Right.Tag = _clsRCubeManager.RotateRightCommand;

            ButtonIBack.Tag = _clsRCubeManager.RotateIBackCommand;
            ButtonBack.Tag = _clsRCubeManager.RotateBackCommand;

            ButtonIUp.Tag = _clsRCubeManager.RotateIUpCommand;
            ButtonUp.Tag = _clsRCubeManager.RotateUpCommand;

            ButtonIDown.Tag = _clsRCubeManager.RotateIDownCommand;
            ButtonDown.Tag = _clsRCubeManager.RotateDownCommand;

            ButtonIFront.Tag = _clsRCubeManager.RotateIFrontCommand;
            ButtonFront.Tag = _clsRCubeManager.RotateFrontCommand;
        }
        #endregion Constructor

        #region Events
        public event ICommandHandler ExecuteCommandEvent;
        #endregion Events

        #region Private Methods
        private void Refresh_Tick(object sender, EventArgs e)
        {
            RefreshRubicsCube();
        }

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
                    (clsControl as CubieControl).LoadCubie(_clsRCubeManager.TheRubicsCube.Cubies);
                }
            }
        }
        #endregion Private Methods
    }
}
