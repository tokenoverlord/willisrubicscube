using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WillisRubicsCube
{
    #region Constant
    /// <summary>
    /// Rotation will be clockwise unless it is inverted.
    /// </summary>
    public enum FaceRotateNotation
    {
        Right,
        Right_Inverted,
        Left,
        Left_Inverted,
        Front,
        Front_Inverted,
        Back,
        Back_Inverted,
        Up,
        Up_Inverted,
        Down,
        Down_Inverted,
    }

    public enum CubeRotateNotation
    {
        Right,
        Left,
        Up,
        Down,
        ClockWise,
        CounterClockWise,
    }

    public enum CubeColor
    {
        None,
        White,
        Orange,
        Blue,
        Red,
        Green,
        Yellow,
    }

    public enum CubeSurface
    {
        Up,
        Down,
        Face,
        Back,
        Left,
        Right,
    }
    #endregion Constants

    public class RCubeManager
    {
        #region Private Members
        //private List<Cubium> _lstCubies = new List<Cubium>();
        private RubicsCube _clsRubicsCube;
        #endregion Private Members

        #region Constructor
        public RCubeManager()
        {
            //_lstCubies = GetNewRCube();
        }
        #endregion Constructor

        #region Properties
        //public List<Cubium> RubicsCube
        //{
        //    get { return _lstCubies; }
        //}
        #endregion Properties

        #region Events
        public event EventHandler NewRubicsCubeLoadedEvent;
        #endregion Events

        #region Public Methods
        public void LoadRubicsCube(RubicsCube clsRubicsCube)
        {
            _clsRubicsCube = clsRubicsCube;
        }

        //public void RotateFaceDelegate(CubeRotateNotation flgRotate)
        //{
        //    switch (flgRotate)
        //    {
        //        case CubeRotateNotation.Up:
        //            // rotate all cubes on the x axis clockwise
        //            Face.RotateXAxis(_lstCubies, true);
        //            break;
        //        case CubeRotateNotation.Down:
        //            // rotate all cubes on the x axis counter clockwise
        //            Face.RotateXAxis(_lstCubies, false);
        //            break;
        //        case CubeRotateNotation.Right:
        //            // rotate all cubes on the z axis counter clockwise
        //            Face.RotateZAxis(_lstCubies, false);
        //            break;
        //        case CubeRotateNotation.Left:
        //            // rotate all cubes on the z axis clockwise
        //            Face.RotateZAxis(_lstCubies, true);
        //            break;
        //        case CubeRotateNotation.CounterClockWise:
        //            // rotate all cubes on the y axis clockwise
        //            Face.RotateYAxis(_lstCubies, false);
        //            break;
        //        case CubeRotateNotation.ClockWise:
        //            // rotate all cubes on the y axis counter clockwise
        //            Face.RotateYAxis(_lstCubies, true);
        //            break;
        //        default:
        //            Debug.Assert(false, "[RCubeManager::RotateFaceDelegate] Unknown cube rotation : " + flgRotate.ToString());
        //            break;
        //    }
        //}

        //public void RotateFaceDelegate(FaceRotateNotation flgRotate)
        //{
        //    List<Cubium> lstTemp = new List<Cubium>();
        //    switch (flgRotate)
        //    {
        //        case FaceRotateNotation.Back:
        //            // all back cubes should have Y = 2
        //            lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.Y == 2));
        //            // rotate the temp list on the y axis counter clockwise
        //            Face.RotateYAxis(lstTemp, false);
        //            break;
        //        case FaceRotateNotation.Back_Inverted:
        //            // all back cubes should have Y = 2
        //            lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.Y == 2));
        //            // rotate the temp list on the y axis clockwise
        //            Face.RotateYAxis(lstTemp, true);
        //            break;
        //        case FaceRotateNotation.Down:
        //            // all back cubes should have z = 0
        //            lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.Z == 0));
        //            // rotate the temp list on the z axis clockwise
        //            Face.RotateZAxis(lstTemp, true);
        //            break;
        //        case FaceRotateNotation.Down_Inverted:
        //            // all back cubes should have z = 0
        //            lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.Z == 0));
        //            // rotate the temp list on the z axis counter clockwise
        //            Face.RotateZAxis(lstTemp, false);
        //            break;
        //        case FaceRotateNotation.Front:
        //            // all back cubes should have y = 0
        //            lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.Y == 0));
        //            // rotate the temp list on the Y axis clockwise
        //            Face.RotateYAxis(lstTemp, true);
        //            break;
        //        case FaceRotateNotation.Front_Inverted:
        //            // all back cubes should have y = 0
        //            lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.Y == 0));
        //            // rotate the temp list on the Y axis counter clockwise
        //            Face.RotateYAxis(lstTemp, false);
        //            break;
        //        case FaceRotateNotation.Left:
        //            // all back cubes should have x = 0
        //            lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.X == 0));
        //            // rotate the temp list on the X axis clockwise
        //            Face.RotateXAxis(lstTemp, true);
        //            break;
        //        case FaceRotateNotation.Left_Inverted:
        //            // all back cubes should have x = 0
        //            lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.X == 0));
        //            // rotate the temp list on the X axis counter clockwise
        //            Face.RotateXAxis(lstTemp, false);
        //            break;
        //        case FaceRotateNotation.Right:
        //            // all back cubes should have x = 2
        //            lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.X == 2));
        //            // rotate the temp list on the X axis counter clockwise
        //            Face.RotateXAxis(lstTemp, false);
        //            break;
        //        case FaceRotateNotation.Right_Inverted:
        //            // all back cubes should have x = 2
        //            lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.X == 2));
        //            // rotate the temp list on the X axis clockwise
        //            Face.RotateXAxis(lstTemp, true);
        //            break;
        //        case FaceRotateNotation.Up:
        //            // all back cubes should have z = 2
        //            lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.Z == 2));
        //            // rotate the temp list on the z axis clockwise
        //            Face.RotateZAxis(lstTemp, true);
        //            break;
        //        case FaceRotateNotation.Up_Inverted:
        //            // all back cubes should have z = 2
        //            lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.Z == 2));
        //            // rotate the temp list on the z axis counter clockwise
        //            Face.RotateZAxis(lstTemp, false);
        //            break;
        //    }
        //}

        ///// <summary>
        ///// Legend
        /////          Z = Red
        /////          |
        /////          |  Y = Yellow
        /////          | /
        /////   Blue __|/__ X = Green
        /////         /|
        /////        / |
        ///// white /  |
        /////          Orange
        ///// </summary>
        //public static List<Cubium> GetNewRCube()
        //{
        //    List<Cubium> lstCubium = new List<Cubium>();

        //    #region Top Layer
        //    // (0, 0, 2)
        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(0, 0, 2),
        //        //X = 0,
        //        //Y = 0,
        //        //Z = 2,
        //        Up = CubeColor.Red,
        //        Face = CubeColor.White,
        //        Left = CubeColor.Blue
        //    });
        //    // (0, 1, 2)
        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(0, 1, 2),
        //        //X = 0,
        //        //Y = 1,
        //        //Z = 2,
        //        Up = CubeColor.Red,
        //        Left = CubeColor.Blue
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(0, 2, 2),
        //        //X = 0,
        //        //Y = 2,
        //        //Z = 2,
        //        Up = CubeColor.Red,
        //        Left = CubeColor.Blue,
        //        Back = CubeColor.Yellow,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(1, 0, 2),
        //        //X = 1,
        //        //Y = 0,
        //        //Z = 2,
        //        Up = CubeColor.Red,
        //        Face = CubeColor.White,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(1, 1, 2),
        //        //X = 1,
        //        //Y = 1,
        //        //Z = 2,
        //        Up = CubeColor.Red,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(1, 2, 2),
        //        //X = 1,
        //        //Y = 2,
        //        //Z = 2,
        //        Up = CubeColor.Red,
        //        Back = CubeColor.Yellow,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(2, 0, 2),
        //        //X = 2,
        //        //Y = 0,
        //        //Z = 2,
        //        Up = CubeColor.Red,
        //        Face = CubeColor.White,
        //        Right = CubeColor.Green,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(2, 1, 2),
        //        //X = 2,
        //        //Y = 1,
        //        //Z = 2,
        //        Up = CubeColor.Red,
        //        Right = CubeColor.Green,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(2, 2, 2),
        //        //X = 2,
        //        //Y = 2,
        //        //Z = 2,
        //        Up = CubeColor.Red,
        //        Back = CubeColor.Yellow,
        //        Right = CubeColor.Green,
        //    });
        //    #endregion Top Layer

        //    #region Middle Layer
        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(0, 0, 1),
        //        //X = 0,
        //        //Y = 0,
        //        //Z = 1,
        //        Face = CubeColor.White,
        //        Left = CubeColor.Blue,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(0, 1, 1),
        //        //X = 0,
        //        //Y = 1,
        //        //Z = 1,
        //        Left = CubeColor.Blue
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(0, 2, 1),
        //        //X = 0,
        //        //Y = 2,
        //        //Z = 1,
        //        Back = CubeColor.Yellow,
        //        Left = CubeColor.Blue,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(1, 0, 1),
        //        //X = 1,
        //        //Y = 0,
        //        //Z = 1,
        //        Face = CubeColor.White
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(1, 2, 1),
        //        //X = 1,
        //        //Y = 2,
        //        //Z = 1,
        //        Back = CubeColor.Yellow,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(2, 0, 1),
        //        //X = 2,
        //        //Y = 0,
        //        //Z = 1,
        //        Face = CubeColor.White,
        //        Right = CubeColor.Green,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(2, 1, 1),
        //        //X = 2,
        //        //Y = 1,
        //        //Z = 1,
        //        Right = CubeColor.Green,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(2, 2, 1),
        //        //X = 2,
        //        //Y = 2,
        //        //Z = 1,
        //        Back = CubeColor.Yellow,
        //        Right = CubeColor.Green,
        //    });
        //    #endregion Middle Layer

        //    #region Bottom
        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(0, 0, 0),
        //        //X = 0,
        //        //Y = 0,
        //        //Z = 0,
        //        Face = CubeColor.White,
        //        Left = CubeColor.Blue,
        //        Down = CubeColor.Orange,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(0, 1, 0),
        //        //X = 0,
        //        //Y = 1,
        //        //Z = 0,
        //        Left = CubeColor.Blue,
        //        Down = CubeColor.Orange,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(0, 2, 0),
        //        //X = 0,
        //        //Y = 2,
        //        //Z = 0,
        //        Left = CubeColor.Blue,
        //        Down = CubeColor.Orange,
        //        Back = CubeColor.Yellow,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(1, 0, 0),
        //        //X = 1,
        //        //Y = 0,
        //        //Z = 0,
        //        Face = CubeColor.White,
        //        Down = CubeColor.Orange,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(1, 1, 0),
        //        //X = 1,
        //        //Y = 1,
        //        //Z = 0,
        //        Down = CubeColor.Orange,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(1, 2, 0),
        //        //X = 1,
        //        //Y = 2,
        //        //Z = 0,
        //        Back = CubeColor.Yellow,
        //        Down = CubeColor.Orange,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(2, 0, 0),
        //        //X = 2,
        //        //Y = 0,
        //        //Z = 0,
        //        Face = CubeColor.White,
        //        Down = CubeColor.Orange,
        //        Right = CubeColor.Green,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(2, 1, 0),
        //        //X = 2,
        //        //Y = 1,
        //        //Z = 0,
        //        Right = CubeColor.Green,
        //        Down = CubeColor.Orange,
        //    });

        //    lstCubium.Add(new Cubium()
        //    {
        //        Location = new Point3D(2, 2, 0),
        //        //X = 2,
        //        //Y = 2,
        //        //Z = 0,
        //        Right = CubeColor.Green,
        //        Down = CubeColor.Orange,
        //        Back = CubeColor.Yellow,
        //    });
        //    #endregion Bottom

        //    return lstCubium;
        //}
        #endregion Public Methods

        #region Private Methods
        ///// <summary>
        ///// Legend
        /////          Z = Red
        /////          |
        /////          |  Y = Yellow
        /////          | /
        /////   Blue __|/__ X = Green
        /////         /|
        /////        / |
        ///// white /  |
        /////          Orange
        ///// </summary>
        //private void InitCube()
        //{
        //    // create cube from top to bottom
        //    #region Top Layer
        //    // (0, 0, 2)
        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(0, 0, 2),
        //        //X = 0,
        //        //Y = 0,
        //        //Z = 2,
        //        Up = CubeColor.Red,
        //        Face = CubeColor.White,
        //        Left = CubeColor.Blue
        //    });
        //    // (0, 1, 2)
        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(0, 1, 2),
        //        //X = 0,
        //        //Y = 1,
        //        //Z = 2,
        //        Up = CubeColor.Red,
        //        Left = CubeColor.Blue
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(0, 2, 2),
        //        //X = 0,
        //        //Y = 2,
        //        //Z = 2,
        //        Up = CubeColor.Red,
        //        Left = CubeColor.Blue,
        //        Back = CubeColor.Yellow,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(1, 0, 2),
        //        //X = 1,
        //        //Y = 0,
        //        //Z = 2,
        //        Up = CubeColor.Red,
        //        Face = CubeColor.White,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(1, 1, 2),
        //        //X = 1,
        //        //Y = 1,
        //        //Z = 2,
        //        Up = CubeColor.Red,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(1, 2, 2),
        //        //X = 1,
        //        //Y = 2,
        //        //Z = 2,
        //        Up = CubeColor.Red,
        //        Back = CubeColor.Yellow,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(2, 0, 2),
        //        //X = 2,
        //        //Y = 0,
        //        //Z = 2,
        //        Up = CubeColor.Red,
        //        Face = CubeColor.White,
        //        Right = CubeColor.Green,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(2, 1, 2),
        //        //X = 2,
        //        //Y = 1,
        //        //Z = 2,
        //        Up = CubeColor.Red,
        //        Right = CubeColor.Green,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(2, 2, 2),
        //        //X = 2,
        //        //Y = 2,
        //        //Z = 2,
        //        Up = CubeColor.Red,
        //        Back = CubeColor.Yellow,
        //        Right = CubeColor.Green,
        //    });
        //    #endregion Top Layer

        //    #region Middle Layer
        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(0, 0, 1),
        //        //X = 0,
        //        //Y = 0,
        //        //Z = 1,
        //        Face = CubeColor.White,
        //        Left = CubeColor.Blue,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(0, 1, 1),
        //        //X = 0,
        //        //Y = 1,
        //        //Z = 1,
        //        Left = CubeColor.Blue
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(0, 2, 1),
        //        //X = 0,
        //        //Y = 2,
        //        //Z = 1,
        //        Back = CubeColor.Yellow,
        //        Left = CubeColor.Blue,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(1, 0, 1),
        //        //X = 1,
        //        //Y = 0,
        //        //Z = 1,
        //        Face = CubeColor.White
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(1, 2, 1),
        //        //X = 1,
        //        //Y = 2,
        //        //Z = 1,
        //        Back = CubeColor.Yellow,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(2, 0 ,1),
        //        //X = 2,
        //        //Y = 0,
        //        //Z = 1,
        //        Face = CubeColor.White,
        //        Right = CubeColor.Green,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(2, 1, 1),
        //        //X = 2,
        //        //Y = 1,
        //        //Z = 1,
        //        Right = CubeColor.Green,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(2, 2, 1),
        //        //X = 2,
        //        //Y = 2,
        //        //Z = 1,
        //        Back = CubeColor.Yellow,
        //        Right = CubeColor.Green,
        //    });
        //    #endregion Middle Layer

        //    #region Bottom
        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(0, 0, 0),
        //        //X = 0,
        //        //Y = 0,
        //        //Z = 0,
        //        Face = CubeColor.White,
        //        Left = CubeColor.Blue,
        //        Down = CubeColor.Orange,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(0, 1,0),
        //        //X = 0,
        //        //Y = 1,
        //        //Z = 0,
        //        Left = CubeColor.Blue,
        //        Down = CubeColor.Orange,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(0, 2, 0),
        //        //X = 0,
        //        //Y = 2,
        //        //Z = 0,
        //        Left = CubeColor.Blue,
        //        Down = CubeColor.Orange,
        //        Back = CubeColor.Yellow,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(1, 0, 0),
        //        //X = 1,
        //        //Y = 0,
        //        //Z = 0,
        //        Face = CubeColor.White,
        //        Down = CubeColor.Orange,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(1, 1, 0),
        //        //X = 1,
        //        //Y = 1,
        //        //Z = 0,
        //        Down = CubeColor.Orange,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(1, 2, 0),
        //        //X = 1,
        //        //Y = 2,
        //        //Z = 0,
        //        Back = CubeColor.Yellow,
        //        Down = CubeColor.Orange,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(2, 0,0),
        //        //X = 2,
        //        //Y = 0,
        //        //Z = 0,
        //        Face = CubeColor.White,
        //        Down = CubeColor.Orange,
        //        Right = CubeColor.Green,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(2, 1, 0),
        //        //X = 2,
        //        //Y = 1,
        //        //Z = 0,
        //        Right = CubeColor.Green,
        //        Down = CubeColor.Orange,
        //    });

        //    _lstCubies.Add(new Cubium()
        //    {
        //        Location = new Point3D(2, 2, 0),
        //        //X = 2,
        //        //Y = 2,
        //        //Z = 0,
        //        Right = CubeColor.Green,
        //        Down = CubeColor.Orange,
        //        Back = CubeColor.Yellow,
        //    });
        //    #endregion Bottom
        //}
        #endregion Private Methods
    }


    //public class Point3D
    //{
    //    #region Properties
    //    public double X { get; set; }
    //    public double Y { get; set; }
    //    public double Z { get; set; }

    //    //public string ID { get; set; }
    //    #endregion Properties

    //    #region Constructor
    //    public Point3D(double numX = 0, double numY = 0, double numZ = 0)
    //    {
    //        X = numX;
    //        Y = numY;
    //        Z = numZ;
    //        //ID = string.Format("({0}, {1}, {2})", X, Y, Z);
    //    }
    //    #endregion Constructor

    //    #region Public Methods
    //    public override string ToString()
    //    {
    //        return string.Format("({0}, {1}, {2})", X, Y, Z);
    //    }

    //    public override bool Equals(object obj)
    //    {
    //        return (this.ToString() == obj.ToString());
    //    }

    //    /// <summary>
    //    /// pt2 - pt1
    //    /// </summary>
    //    /// <param name="pt1">Point3D 1</param>
    //    /// <param name="pt2">Point3D 2</param>
    //    /// <returns>Result of the substraction</returns>
    //    public static Point3D Subtract(Point3D pt1, Point3D pt2)
    //    {
    //        Point3D pt3 = new Point3D();

    //        pt3.X = pt2.X - pt1.X;
    //        pt3.Y = pt2.Y - pt1.Y;
    //        pt3.Z = pt2.Z - pt1.Z;

    //        return pt3;
    //    }

    //    /// <summary>
    //    /// pt2 + pt1
    //    /// </summary>
    //    /// <param name="pt1">Point3D 1</param>
    //    /// <param name="pt2">Point3D 2</param>
    //    /// <returns>Result of the addition</returns>
    //    public static Point3D Addition(Point3D pt1, Point3D pt2)
    //    {
    //        Point3D pt3 = new Point3D();

    //        pt3.X = pt2.X + pt1.X;
    //        pt3.Y = pt2.Y + pt1.Y;
    //        pt3.Z = pt2.Z + pt1.Z;

    //        return pt3;
    //    }
    //    #endregion Public Methods
    //}
}
