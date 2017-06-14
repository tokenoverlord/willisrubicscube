using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace WillisRubicsCube
{
    public partial class HistoryControl : UserControl
    {
        #region Private Members
        private int _numUndoPointer = 0;
        private bool _flgModified = false;
        private List<ICommand> _lstHistory;
        #endregion Private Members

        #region Constructor
        public HistoryControl()
        {
            InitializeComponent();

            // init the history list.
            _lstHistory = new List<ICommand>();
        }
        #endregion Constructor

        #region Public Methods
        public void Add(ICommand clsCommand)
        {
            // sanity check
            if (clsCommand == null)
            {
                return;
            }

            // check if the command is reversable
            if (!clsCommand.IsReversable)
            {
                return;
            }

            // check if the undo pointer is not at the
            // end of the history list
            if (_numUndoPointer < _lstHistory.Count)
            {
                // we need to remove all commands
                // after the undo pointer since they
                // will not be relevent.
                _lstHistory.RemoveRange(_numUndoPointer, _lstHistory.Count - _numUndoPointer);
            }

            // add the command to the history list.
            _lstHistory.Add(clsCommand);

            // adjust the count
            _numUndoPointer = _lstHistory.Count;

            // set the modified flag.
            _flgModified = true;
        }

        public void Undo()
        {
            // check if we have commands to undo
            if (_numUndoPointer > 0)
            {
                // undo the command at current undo pointer
                _lstHistory[_numUndoPointer - 1].UnExecute();

                // change the undo pointer
                _numUndoPointer--;

                // set the modified to true
                _flgModified = true;
            }
        }

        public void Redo()
        {
            // check if the undo pointer is not at
            // the last command
            if (_numUndoPointer < _lstHistory.Count)
            {
                // go to the next command to redo
                _numUndoPointer++;

                // redo the command
                _lstHistory[_numUndoPointer].Execute();

                // set the modified to true.
            }
        }

        public void Clear()
        {
            // clear the history
            _lstHistory.Clear();

            // reset the undo pointer
            _numUndoPointer = 0;

            // set the modified to true
            _flgModified = true;
        }
        #endregion Public Methods

        #region Private Methods
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (_flgModified)
            {
                // set modified to false
                _flgModified = false;
                // begin update
                listView1.BeginUpdate();

                // start the update
                try
                {
                    // clear the current list view
                    listView1.Items.Clear();

                    // go through the history
                    foreach (ICommand clsCmd in _lstHistory)
                    {
                        // append the ICommand
                        AppendCommand(clsCmd);

                        // mark where the current index is at.
                        if (_numUndoPointer == listView1.Items.Count - 1)
                        {
                            // marked where the undo pointer is at
                            listView1.Items[_numUndoPointer].ImageIndex = 0;
                        }
                    }
                }
                catch(Exception ex)
                {
                    // show the exception
                    Debug.Assert(false, "[HistoryControl::RefreshTimer_Tick] Assert -> " + ex.Message);
                }
                finally{
                    // end update
                    listView1.EndUpdate();
                }
            }
        }

        private void AppendCommand(ICommand clsCommand)
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
