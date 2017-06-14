using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WillisRubicsCube
{
    public partial class CubeFaceDisplay : UserControl
    {
        #region Dictionary
        //private Dictionary<string, CommandUpdateCubeColor> _lstCommands
        //    = new Dictionary<string, CommandUpdateCubeColor>();
        #endregion Dictionary

        #region Private Members
        private RubicsCube _clsRubicsCube = new RubicsCube();
        #endregion Private Members

        #region Constructor
        public CubeFaceDisplay()
        {
            InitializeComponent();

            // Up Commands
            //_lstButtons.Add("(0, 0, 2)", Up002);
            //_lstButtons.Add("(0, 1, 2)", Up012);
            //_lstButtons.Add("(0, 2, 2)", Up022);
            
            //_lstButtons.Add("(1, 0, 2)", Up102);
            //_lstButtons.Add("(1, 1, 2)", Up112);
            //_lstButtons.Add("(1, 2, 2)", Up122);

            //_lstButtons.Add("(2, 0, 2)", Up202);
            //_lstButtons.Add("(2, 1, 2)", Up212);
            //_lstButtons.Add("(2, 2, 2)", Up222);
        }
        #endregion Constructor

        #region Properties
        public RubicsCube TheRubicsCube { get { return _clsRubicsCube; } }
        #endregion Properties

        #region Public Methods
        //public void LoadManager(RCubeManager clsManager)
        //{
        //    timer1.Enabled = false;
        //    //_lstCommands.Clear();

        //    //#region Up
        //    //// block (0, 0, 0)
        //    //_lstCommands.Add("(0, 0, 0)",
        //    //    new CommandUpdateCubeColor( Face000, null, null, Down000, null, Left000, "(0, 0, 0)", clsManager));
        //    //// block (0, 0, 1)
        //    //_lstCommands.Add("(0, 0, 1)",
        //    //    new CommandUpdateCubeColor(Face001, null, null, null, null, Left001, "(0, 0, 1)", clsManager));
        //    //// block (0, 0, 2)
        //    //_lstCommands.Add("(0, 0, 2)",
        //    //    new CommandUpdateCubeColor(Face002, null, Up002, null, null, Left002, "(0, 0, 2)", clsManager));
            
        //    //// block (0, 1, 0)
        //    //_lstCommands.Add("(0, 1, 0)",
        //    //    new CommandUpdateCubeColor(null, null, null, Down010, null, Left010, "(0, 1, 0)", clsManager));
        //    //// block (0, 1, 1)
        //    //_lstCommands.Add("(0, 1, 1)",
        //    //    new CommandUpdateCubeColor(null, null, null, null, null, Left011, "(0, 1, 1)", clsManager));
        //    //// block (0, 1, 2)
        //    //_lstCommands.Add("(0, 1, 2)",
        //    //    new CommandUpdateCubeColor(null, null, Up012, null, null, Left012, "(0, 1, 2)", clsManager));

        //    //// block (0, 2, 0)
        //    //_lstCommands.Add("(0, 2, 0)",
        //    //    new CommandUpdateCubeColor(null, Back020, null, Down020, null, Left020, "(0, 2, 0)", clsManager));
        //    //// block (0, 2, 1)
        //    //_lstCommands.Add("(0, 2, 1)",
        //    //    new CommandUpdateCubeColor(null, Back021, null, null, null, Left021, "(0, 2, 1)", clsManager));
        //    //// block (0, 2, 2)
        //    //_lstCommands.Add("(0, 2, 2)",
        //    //    new CommandUpdateCubeColor(null, Back022, Up022, null, null, Left022, "(0, 2, 2)", clsManager));

        //    //// block (1, 0, 0)
        //    //_lstCommands.Add("(1, 0, 0)",
        //    //    new CommandUpdateCubeColor(Face100, null, null, Down100, null, null, "(1, 0, 0)", clsManager));
        //    //// block (1, 0, 1)
        //    //_lstCommands.Add("(1, 0, 1)",
        //    //    new CommandUpdateCubeColor(Face101, null, null, null, null, null, "(1, 0, 1)", clsManager));
        //    //// block (1, 0, 2)
        //    //_lstCommands.Add("(1, 0, 2)",
        //    //    new CommandUpdateCubeColor(Face102, null, Up102, null, null, null, "(1, 0, 2)", clsManager));

        //    //// block (1, 1, 0)
        //    //_lstCommands.Add("(1, 1, 0)",
        //    //    new CommandUpdateCubeColor(null, null, null, Down110, null, null, "(1, 1, 0)", clsManager));
        //    //// block (1, 1, 1)
        //    //// nothing here
        //    //// block (1, 1, 2)
        //    //_lstCommands.Add("(1, 1, 2)",
        //    //    new CommandUpdateCubeColor(null, null, Up112, null, null, null, "(1, 1, 2)", clsManager));

        //    //// block (1, 2, 0)
        //    //_lstCommands.Add("(1, 2, 0)",
        //    //    new CommandUpdateCubeColor(null, Back120, null, Down120, null, null, "(1, 2, 0)", clsManager));
        //    //// block (1, 2, 1)
        //    //_lstCommands.Add("(1, 2, 1)",
        //    //    new CommandUpdateCubeColor(null, Back121, null, null, null, null, "(1, 2, 1)", clsManager));
        //    //// block (1, 2, 2)
        //    //_lstCommands.Add("(1, 2, 2)",
        //    //    new CommandUpdateCubeColor(null, Back122, Up122, null, null, null, "(1, 2, 2)", clsManager));

        //    //// block (2, 0, 0)
        //    //_lstCommands.Add("(2, 0, 0)",
        //    //    new CommandUpdateCubeColor(Face200, null, null, Down200, Right200, null, "(2, 0, 0)", clsManager));
        //    //// block (2, 0, 1)
        //    //_lstCommands.Add("(2, 0, 1)",
        //    //    new CommandUpdateCubeColor(Face201, null, null, null, Right201, null, "(2, 0, 1)", clsManager));
        //    //// block (2, 0, 2)
        //    //_lstCommands.Add("(2, 0, 2)",
        //    //    new CommandUpdateCubeColor(Face202, null, Up202, null, Right202, null, "(2, 0, 2)", clsManager));

        //    //// block (2, 1, 0)
        //    //_lstCommands.Add("(2, 1, 0)",
        //    //    new CommandUpdateCubeColor(null, null, null, Down210, Right210, null, "(2, 1, 0)", clsManager));
        //    //// block (2, 1, 1)
        //    //_lstCommands.Add("(2, 1, 1)",
        //    //    new CommandUpdateCubeColor(null, null, null, null, Right211, null, "(2, 1, 1)", clsManager));
        //    //// block (2, 1, 2)
        //    //_lstCommands.Add("(2, 1, 2)",
        //    //    new CommandUpdateCubeColor(null, null, Up212, null, Right212, null, "(2, 1, 2)", clsManager));

        //    //// block (2, 2, 0)
        //    //_lstCommands.Add("(2, 2, 0)",
        //    //    new CommandUpdateCubeColor(null, Back220, null, Down220, Right220, null, "(2, 2, 0)", clsManager));
        //    //// block (2, 2, 1)
        //    //_lstCommands.Add("(2, 2, 1)",
        //    //    new CommandUpdateCubeColor(null, Back221, null, null, Right221, null, "(2, 2, 1)", clsManager));
        //    //// block (2, 2, 2)
        //    //_lstCommands.Add("(2, 2, 2)",
        //    //    new CommandUpdateCubeColor(null, Back222, Up222, null, Right222, null, "(2, 2, 2)", clsManager));
        //    //#endregion Up

        //    timer1.Enabled = true;
        //}
        #endregion Public Methods

        #region Private Methods
        private void timer1_Tick(object sender, EventArgs e)
        {

            //foreach (KeyValuePair<string, CommandUpdateCubeColor> command in _lstCommands)
            //{
            //    command.Value.Execute();
            //}
        }
        #endregion Private Methods
    }
}
