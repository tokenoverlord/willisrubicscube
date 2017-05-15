using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillisRubicsCube
{
    public class CommandManager
    {
        #region Private Members
        private List<ICommand> _lstCommandHistory
            = new List<ICommand>();

        private int _numCmdIndex = 0;
        #endregion Private Members

        #region Properties
        public int Index { get { return _numCmdIndex; } }

        public List<ICommand> History { get { return _lstCommandHistory; } }

        public bool Modified { get; set; }
        #endregion Properties

        #region Constructor
        public CommandManager()
        {
            Modified = false;
        }
        #endregion Constructor

        #region Public Methods
        public void Add(ICommand clsCommand)
        {
            if (!clsCommand.IsReversable)
            {
                return;
            }

            if (_numCmdIndex < _lstCommandHistory.Count)
            {
                // remove commands starting from Cmd Index to the end of command history
                _lstCommandHistory.RemoveRange(_numCmdIndex, _lstCommandHistory.Count - _numCmdIndex);
            }
            _lstCommandHistory.Add(clsCommand);
            _numCmdIndex = _lstCommandHistory.Count;
            Modified = true;
        }

        public void Undo()
        {
            if (_numCmdIndex > 0)
            {
                _lstCommandHistory[_numCmdIndex - 1].UnExecute();
                _numCmdIndex--;
            }
            Modified = true;
        }

        public void Redo()
        {
            if (_numCmdIndex < _lstCommandHistory.Count)
            {
                _numCmdIndex++;
                _lstCommandHistory[_numCmdIndex - 1].Execute();
            }
            Modified = true;
        }

        public void Clear()
        {
            _lstCommandHistory.Clear();
            _numCmdIndex = 0;
            Modified = true;
        }
        #endregion Public Methods
    }
}
