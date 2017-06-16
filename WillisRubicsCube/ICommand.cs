using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WillisRubicsCube
{
    public interface ICommand
    {
        bool IsReversable { get; }
        void Execute();
        void UnExecute();
    }

    public delegate void ICommandHandler(object sender, ICommandArgs args);

    public class ICommandArgs : EventArgs
    {
        public ICommand Command { get; private set; }

        public ICommandArgs(ICommand clsCommand)
        {
            this.Command = clsCommand;
        }
    }

    //public class CommandRotateCube : ICommand
    //{
    //    #region Private Members
    //    private RCubeManager _clsManager;
    //    private CubeRotateNotation _flgExecute;
    //    private CubeRotateNotation _flgUnExecute;
    //    #endregion Private Members

    //    #region Constructor
    //    public CommandRotateCube(RCubeManager clsManager, CubeRotateNotation flgExecute,
    //        CubeRotateNotation flgUnExecute)
    //    {
    //        _clsManager = clsManager;
    //        _flgExecute = flgExecute;
    //        _flgUnExecute = flgUnExecute;
    //    }
    //    #endregion Constructor

    //    #region Properties
    //    public bool IsReversable
    //    {
    //        get { return true; }
    //    }
    //    #endregion Properties

    //    #region Public Methods
    //    public void Execute()
    //    {
    //        _clsManager.RotateCube(_flgExecute);
    //    }

    //    public void UnExecute()
    //    {
    //        _clsManager.RotateCube(_flgUnExecute);
    //    }

    //    public override string ToString()
    //    {
    //        return "Rotate Cube : " + _flgExecute.ToString();
    //    }
    //    #endregion Public Methods
    //}

    //public class CommandRotateFace : ICommand
    //{
    //    #region Private Members
    //    private FaceRotateNotation _flgExecute;
    //    private FaceRotateNotation _flgUnExecute;
    //    private RCubeManager _clsManager;
    //    #endregion Private Members

    //    #region Constructor
    //    public CommandRotateFace(RCubeManager clsManager, FaceRotateNotation flgExecute,
    //        FaceRotateNotation flgUnExecute)
    //    {
    //        _clsManager = clsManager;
    //        _flgExecute = flgExecute;
    //        _flgUnExecute = flgUnExecute;
    //    }
    //    #endregion Constructor

    //    #region Properties
    //    public bool IsReversable
    //    {
    //        get { return true; }
    //    }
    //    #endregion Properties

    //    #region Public Methods
    //    public void Execute()
    //    {
    //        _clsManager.RotateFace(_flgExecute);
    //    }

    //    public void UnExecute()
    //    {
    //        _clsManager.RotateFace(_flgUnExecute);
    //    }
        
    //    public override string ToString()
    //    {
    //        return "Rotate Face : " + _flgExecute.ToString();
    //    }
    //    #endregion Public Methods
    //}

    //public class CommandUndo : ICommand
    //{
    //    #region Private Memebers
    //    private CommandManager _clsManager;
    //    #endregion Private Memebers

    //    #region Properties
    //    public bool IsReversable
    //    {
    //        get { return false; }
    //    }
    //    #endregion Properties

    //    #region Constructor
    //    public CommandUndo(CommandManager clsManager)
    //    {
    //        _clsManager = clsManager;
    //    }
    //    #endregion Constructor

    //    #region Public Methods
    //    public void Execute()
    //    {
    //        _clsManager.Undo();
    //    }

    //    public void UnExecute()
    //    {
    //        throw new NotImplementedException();
    //    }
    //    #endregion Public Methods
    //}

    //public class CommandRedo : ICommand
    //{
    //    #region Private Memebers
    //    private CommandManager _clsManager;
    //    #endregion Private Memebers

    //    #region Properties
    //    public bool IsReversable
    //    {
    //        get { return false; }
    //    }
    //    #endregion Properties

    //    #region Constructor
    //    public CommandRedo(CommandManager clsManager)
    //    {
    //        _clsManager = clsManager;
    //    }
    //    #endregion Constructor

    //    #region Public Methods
    //    public void Execute()
    //    {
    //        _clsManager.Redo();
    //    }

    //    public void UnExecute()
    //    {
    //        throw new NotImplementedException();
    //    }
    //    #endregion Public Methods
    //}

    //public class CommandClearHistory : ICommand
    //{
    //    #region Private Members
    //    private CommandManager _clsManager;
    //    //private List<ICommand> _lstHistory;
    //    #endregion Private Members

    //    #region Properties
    //    public bool IsReversable
    //    {
    //        get { return false; }
    //    }
    //    #endregion Properties

    //    #region Constructor
    //    public CommandClearHistory(CommandManager clsManager)
    //    {
    //        _clsManager = clsManager;
    //    }
    //    #endregion Constructor

    //    #region Public Methods
    //    public void Execute()
    //    {
    //        // take the old history
    //        //_lstHistory = _clsManager.History;
    //        _clsManager.Clear();
    //    }

    //    public void UnExecute()
    //    {
    //        //foreach (ICommand command in _lstHistory)
    //        //{
    //        //    _clsManager.Add(command);
    //        //}
    //        //_lstHistory.Clear();
    //    }
    //    #endregion Public Methods
    //}

    //public class CommandUpdateCubeColor : ICommand
    //{
    //    #region Private Members
    //    private string _strLocation;
    //    private RCubeManager _clsManager;
    //    //private CubeSurface _flgSurface;
    //    private Control _clsFace;
    //    private Dictionary<CubeSurface, Control> _lstControls
    //        = new Dictionary<CubeSurface, Control>();
    //    #endregion Private Members

    //    #region Properties
    //    public bool IsReversable
    //    {
    //        get { return false; }
    //    }
    //    #endregion Properties

    //    #region Constructor
    //    public CommandUpdateCubeColor(Control clsFace, Control clsBack, Control clsUp, Control clsDown, Control clsRight, Control clsLeft, string strCubeLocation,
    //        RCubeManager clsManager)
    //    {
    //        _clsFace = clsFace;
    //        _clsManager = clsManager;
    //        _strLocation = strCubeLocation;
            
    //        if (clsFace != null)
    //        {
    //            _lstControls.Add(CubeSurface.Face, clsFace);
    //        }
    //        if (clsBack != null)
    //        {
    //            _lstControls.Add(CubeSurface.Back, clsBack);
    //        }
    //        if (clsDown != null)
    //        {
    //            _lstControls.Add(CubeSurface.Down, clsDown);
    //        }
    //        if (clsLeft != null)
    //        {
    //            _lstControls.Add(CubeSurface.Left, clsLeft);
    //        }
    //        if (clsRight != null)
    //        {
    //            _lstControls.Add(CubeSurface.Right, clsRight);
    //        }
    //        if (clsUp != null)
    //        {
    //            _lstControls.Add(CubeSurface.Up, clsUp);
    //        }
    //    }
    //    #endregion Constructor

    //    #region Public Methods
    //    public void Execute()
    //    {
    //        // look for the cube in location

    //        if (_clsManager.TheRubicsCube.Exists(x => x.ToString() == _strLocation))
    //        {
    //            // get the cube
    //            Cubie clsCube = _clsManager.TheRubicsCube.Find(x => x.ToString() == _strLocation);

    //            if (_lstControls.ContainsKey(CubeSurface.Back))
    //            {
    //                _lstControls[CubeSurface.Back].BackColor = GetColor(clsCube.Back);
    //            }
    //            if (_lstControls.ContainsKey(CubeSurface.Down))
    //            {
    //                _lstControls[CubeSurface.Down].BackColor = GetColor(clsCube.Down);
    //            }
    //            if (_lstControls.ContainsKey(CubeSurface.Face))
    //            {
    //                _lstControls[CubeSurface.Face].BackColor = GetColor(clsCube.Face);
    //            }
    //            if (_lstControls.ContainsKey(CubeSurface.Left))
    //            {
    //                _lstControls[CubeSurface.Left].BackColor = GetColor(clsCube.Left);
    //            }
    //            if (_lstControls.ContainsKey(CubeSurface.Right))
    //            {
    //                _lstControls[CubeSurface.Right].BackColor = GetColor(clsCube.Right);
    //            }
    //            if (_lstControls.ContainsKey(CubeSurface.Up))
    //            {
    //                _lstControls[CubeSurface.Up].BackColor = GetColor(clsCube.Up);
    //            }
    //        }
    //    }

    //    public void UnExecute()
    //    {
    //    }
    //    #endregion Public Methods

    //    #region Private Methods
    //    private Color GetColor(CubeColor flgColor)
    //    {
    //        switch (flgColor)
    //        {
    //            case CubeColor.Blue:
    //                return Color.Blue;
                
    //            case CubeColor.Green:
    //                return Color.Green;
                    
    //            case CubeColor.Orange:
    //                return Color.Orange;
                    
    //            case CubeColor.Red:
    //                return Color.Red;
                    
    //            case CubeColor.White:
    //                return Color.White;
                    
    //            case CubeColor.Yellow:
    //                return Color.Yellow;
                    
    //            default:
    //                return Color.Black;
    //        }
    //    }
    //    #endregion Private Methods
    //}

}
