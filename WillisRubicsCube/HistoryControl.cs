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
    public partial class HistoryControl : UserControl
    {
        #region Private Members
        private CommandManager _clsManager;
        #endregion Private Members

        #region Constructor
        public HistoryControl()
        {
            InitializeComponent();
            timer1.Enabled = false;
        }
        #endregion Constructor

        #region Public Methods
        public void LoadManager(CommandManager clsManager)
        {
            _clsManager = clsManager;
            timer1.Enabled = true;
        }

        //public void InsertCommand(ICommand clsCommand)
        //{
        //    if (clsCommand != null)
        //    {
        //        if (clsCommand.IsReversable)
        //        {
        //            // create list item
        //            ListViewItem clsItem = new ListViewItem();
        //            clsItem.Text = clsCommand.ToString();
        //            clsItem.Tag = clsCommand;

        //            listView1.Items.Add(clsItem);
        //        }
        //    }
        //}

        //public void Undo()
        //{
        //    //if (listView1.Items.Count > 0)
        //    //{
        //    //    ICommand clsCommand = (listView1.Items[listView1.Items.Count - 1].Tag as ICommand);
        //    //    clsCommand.UnExecute();
        //    //    listView1.Items.RemoveAt(listView1.Items.Count - 1);
        //    //}
        //}

        //public void Redo()
        //{
        //    //if (listView1.Items.Count > 0)
        //    //{
        //    //    if (_numUndoCount < listView1.Items.Count)
        //    //    {
        //    //        // go to next item
        //    //        _numUndoCount++;

        //    //        // get the i command
        //    //        ICommand clsCommand = listView1.Items[_numUndoCount - 1].Tag as ICommand;
        //    //        //listView1.Items[_numUndoCount].ImageIndex = 0;
        //    //        if (clsCommand.IsReversable)
        //    //        {
        //    //            clsCommand.Execute();
        //    //        }
        //    //        UpdateCurrentItemImage();
        //    //    }
        //    //}
        //}
        #endregion Public Methods

        #region Private Methods
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_clsManager.Modified)
            {
                listView1.BeginUpdate();

                listView1.Items.Clear();

                for (int i = 0; i < _clsManager.History.Count; i++)
                {
                    InsertCommand(_clsManager.History[i]);

                    if (i == _clsManager.Index - 1)
                    {
                        listView1.Items[i].ImageIndex = 0;
                    }

                    //if (i > _clsManager.Index)
                    //{
                    //    // High light
                    //    listView1.Items[i].BackColor = Color.Gray;
                    //}
                }
                listView1.EndUpdate();
                _clsManager.Modified = false;
            }
        }

        private void InsertCommand(ICommand clsCommand)
        {
            if (clsCommand != null)
            {
                if (clsCommand.IsReversable)
                {
                    // create list item
                    ListViewItem clsItem = new ListViewItem();
                    clsItem.Text = clsCommand.ToString();
                    clsItem.Tag = clsCommand;

                    listView1.Items.Add(clsItem);
                }
            }
        }
        #endregion Private Methods
    }
}
