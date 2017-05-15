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
        private List<Cubium> _lstCubies = new List<Cubium>();
        #endregion Private Members

        #region Constructor
        public RCubeManager()
        {
            _lstCubies = GetNewRCube();
        }
        #endregion Constructor

        #region Properties
        public List<Cubium> RubicsCube
        {
            get { return _lstCubies; }
        }
        #endregion Properties

        #region Public Methods
        public void RotateCube(CubeRotateNotation flgRotate)
        {
            switch (flgRotate)
            {
                case CubeRotateNotation.Up:
                    // rotate all cubes on the x axis clockwise
                    Face.RotateXAxis(_lstCubies, true);
                    break;
                case CubeRotateNotation.Down:
                    // rotate all cubes on the x axis counter clockwise
                    Face.RotateXAxis(_lstCubies, false);
                    break;
                case CubeRotateNotation.Right:
                    // rotate all cubes on the z axis counter clockwise
                    Face.RotateZAxis(_lstCubies, false);
                    break;
                case CubeRotateNotation.Left:
                    // rotate all cubes on the z axis clockwise
                    Face.RotateZAxis(_lstCubies, true);
                    break;
                case CubeRotateNotation.CounterClockWise:
                    // rotate all cubes on the y axis clockwise
                    Face.RotateYAxis(_lstCubies, false);
                    break;
                case CubeRotateNotation.ClockWise:
                    // rotate all cubes on the y axis counter clockwise
                    Face.RotateYAxis(_lstCubies, true);
                    break;
                default:
                    Debug.Assert(false, "[RCubeManager::RotateCube] Unknown cube rotation : " + flgRotate.ToString());
                    break;
            }
        }

        public void RotateFace(FaceRotateNotation flgRotate)
        {
            List<Cubium> lstTemp = new List<Cubium>();
            switch (flgRotate)
            {
                case FaceRotateNotation.Back:
                    // all back cubes should have Y = 2
                    lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.Y == 2));
                    // rotate the temp list on the y axis counter clockwise
                    Face.RotateYAxis(lstTemp, false);
                    break;
                case FaceRotateNotation.Back_Inverted:
                    // all back cubes should have Y = 2
                    lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.Y == 2));
                    // rotate the temp list on the y axis clockwise
                    Face.RotateYAxis(lstTemp, true);
                    break;
                case FaceRotateNotation.Down:
                    // all back cubes should have z = 0
                    lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.Z == 0));
                    // rotate the temp list on the z axis clockwise
                    Face.RotateZAxis(lstTemp, true);
                    break;
                case FaceRotateNotation.Down_Inverted:
                    // all back cubes should have z = 0
                    lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.Z == 0));
                    // rotate the temp list on the z axis counter clockwise
                    Face.RotateZAxis(lstTemp, false);
                    break;
                case FaceRotateNotation.Front:
                    // all back cubes should have y = 0
                    lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.Y == 0));
                    // rotate the temp list on the Y axis clockwise
                    Face.RotateYAxis(lstTemp, true);
                    break;
                case FaceRotateNotation.Front_Inverted:
                    // all back cubes should have y = 0
                    lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.Y == 0));
                    // rotate the temp list on the Y axis counter clockwise
                    Face.RotateYAxis(lstTemp, false);
                    break;
                case FaceRotateNotation.Left:
                    // all back cubes should have x = 0
                    lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.X == 0));
                    // rotate the temp list on the X axis clockwise
                    Face.RotateXAxis(lstTemp, true);
                    break;
                case FaceRotateNotation.Left_Inverted:
                    // all back cubes should have x = 0
                    lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.X == 0));
                    // rotate the temp list on the X axis counter clockwise
                    Face.RotateXAxis(lstTemp, false);
                    break;
                case FaceRotateNotation.Right:
                    // all back cubes should have x = 2
                    lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.X == 2));
                    // rotate the temp list on the X axis counter clockwise
                    Face.RotateXAxis(lstTemp, false);
                    break;
                case FaceRotateNotation.Right_Inverted:
                    // all back cubes should have x = 2
                    lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.X == 2));
                    // rotate the temp list on the X axis clockwise
                    Face.RotateXAxis(lstTemp, true);
                    break;
                case FaceRotateNotation.Up:
                    // all back cubes should have z = 2
                    lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.Z == 2));
                    // rotate the temp list on the z axis clockwise
                    Face.RotateZAxis(lstTemp, true);
                    break;
                case FaceRotateNotation.Up_Inverted:
                    // all back cubes should have z = 2
                    lstTemp.AddRange(_lstCubies.FindAll(cb => cb.Location.Z == 2));
                    // rotate the temp list on the z axis counter clockwise
                    Face.RotateZAxis(lstTemp, false);
                    break;
            }
        }

        /// <summary>
        /// Legend
        ///          Z = Red
        ///          |
        ///          |  Y = Yellow
        ///          | /
        ///   Blue __|/__ X = Green
        ///         /|
        ///        / |
        /// white /  |
        ///          Orange
        /// </summary>
        public static List<Cubium> GetNewRCube()
        {
            List<Cubium> lstCubium = new List<Cubium>();

            #region Top Layer
            // (0, 0, 2)
            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(0, 0, 2),
                //X = 0,
                //Y = 0,
                //Z = 2,
                Up = CubeColor.Red,
                Face = CubeColor.White,
                Left = CubeColor.Blue
            });
            // (0, 1, 2)
            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(0, 1, 2),
                //X = 0,
                //Y = 1,
                //Z = 2,
                Up = CubeColor.Red,
                Left = CubeColor.Blue
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(0, 2, 2),
                //X = 0,
                //Y = 2,
                //Z = 2,
                Up = CubeColor.Red,
                Left = CubeColor.Blue,
                Back = CubeColor.Yellow,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(1, 0, 2),
                //X = 1,
                //Y = 0,
                //Z = 2,
                Up = CubeColor.Red,
                Face = CubeColor.White,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(1, 1, 2),
                //X = 1,
                //Y = 1,
                //Z = 2,
                Up = CubeColor.Red,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(1, 2, 2),
                //X = 1,
                //Y = 2,
                //Z = 2,
                Up = CubeColor.Red,
                Back = CubeColor.Yellow,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(2, 0, 2),
                //X = 2,
                //Y = 0,
                //Z = 2,
                Up = CubeColor.Red,
                Face = CubeColor.White,
                Right = CubeColor.Green,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(2, 1, 2),
                //X = 2,
                //Y = 1,
                //Z = 2,
                Up = CubeColor.Red,
                Right = CubeColor.Green,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(2, 2, 2),
                //X = 2,
                //Y = 2,
                //Z = 2,
                Up = CubeColor.Red,
                Back = CubeColor.Yellow,
                Right = CubeColor.Green,
            });
            #endregion Top Layer

            #region Middle Layer
            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(0, 0, 1),
                //X = 0,
                //Y = 0,
                //Z = 1,
                Face = CubeColor.White,
                Left = CubeColor.Blue,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(0, 1, 1),
                //X = 0,
                //Y = 1,
                //Z = 1,
                Left = CubeColor.Blue
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(0, 2, 1),
                //X = 0,
                //Y = 2,
                //Z = 1,
                Back = CubeColor.Yellow,
                Left = CubeColor.Blue,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(1, 0, 1),
                //X = 1,
                //Y = 0,
                //Z = 1,
                Face = CubeColor.White
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(1, 2, 1),
                //X = 1,
                //Y = 2,
                //Z = 1,
                Back = CubeColor.Yellow,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(2, 0, 1),
                //X = 2,
                //Y = 0,
                //Z = 1,
                Face = CubeColor.White,
                Right = CubeColor.Green,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(2, 1, 1),
                //X = 2,
                //Y = 1,
                //Z = 1,
                Right = CubeColor.Green,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(2, 2, 1),
                //X = 2,
                //Y = 2,
                //Z = 1,
                Back = CubeColor.Yellow,
                Right = CubeColor.Green,
            });
            #endregion Middle Layer

            #region Bottom
            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(0, 0, 0),
                //X = 0,
                //Y = 0,
                //Z = 0,
                Face = CubeColor.White,
                Left = CubeColor.Blue,
                Down = CubeColor.Orange,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(0, 1, 0),
                //X = 0,
                //Y = 1,
                //Z = 0,
                Left = CubeColor.Blue,
                Down = CubeColor.Orange,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(0, 2, 0),
                //X = 0,
                //Y = 2,
                //Z = 0,
                Left = CubeColor.Blue,
                Down = CubeColor.Orange,
                Back = CubeColor.Yellow,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(1, 0, 0),
                //X = 1,
                //Y = 0,
                //Z = 0,
                Face = CubeColor.White,
                Down = CubeColor.Orange,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(1, 1, 0),
                //X = 1,
                //Y = 1,
                //Z = 0,
                Down = CubeColor.Orange,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(1, 2, 0),
                //X = 1,
                //Y = 2,
                //Z = 0,
                Back = CubeColor.Yellow,
                Down = CubeColor.Orange,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(2, 0, 0),
                //X = 2,
                //Y = 0,
                //Z = 0,
                Face = CubeColor.White,
                Down = CubeColor.Orange,
                Right = CubeColor.Green,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(2, 1, 0),
                //X = 2,
                //Y = 1,
                //Z = 0,
                Right = CubeColor.Green,
                Down = CubeColor.Orange,
            });

            lstCubium.Add(new Cubium()
            {
                Location = new Point3D(2, 2, 0),
                //X = 2,
                //Y = 2,
                //Z = 0,
                Right = CubeColor.Green,
                Down = CubeColor.Orange,
                Back = CubeColor.Yellow,
            });
            #endregion Bottom

            return lstCubium;
        }
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

    public class Cubium
    {
        #region Constructor
        public Cubium()
        {
            Up = CubeColor.None;
            Down = CubeColor.None;
            Left = CubeColor.None;
            Right = CubeColor.None;
            Face = CubeColor.None;
            Back = CubeColor.None;
        }
        #endregion Constructor

        #region Properties
        public Point3D Location { get; set; }

        //public int X { get; set; }
        //public int Y { get; set; }
        //public int Z { get; set; }

        /// <summary>
        /// Z
        /// </summary>
        public CubeColor Up { get; set; }
        /// <summary>
        /// -Z
        /// </summary>
        public CubeColor Down { get; set; }
        /// <summary>
        /// -Y
        /// </summary>
        public CubeColor Face { get; set; }
        /// <summary>
        /// Y
        /// </summary>
        public CubeColor Back { get; set; }
        /// <summary>
        /// -X
        /// </summary>
        public CubeColor Left { get; set; }
        /// <summary>
        /// X
        /// </summary>
        public CubeColor Right { get; set; }
        #endregion Properties

        #region Public Methods
        public void Rotate(CubeRotateNotation flgMove)
        {
            switch (flgMove)
            {
                case CubeRotateNotation.Down:
                    {
                        RotateDown();
                        break;
                    }
                case CubeRotateNotation.Up:
                    {
                        RotateUp();
                        break;
                    }
                case CubeRotateNotation.Left:
                    {
                        RotateLeft();
                        break;
                    }
                case CubeRotateNotation.Right:
                    {
                        RotateRight();
                        break;
                    }
                case CubeRotateNotation.ClockWise:
                    {
                        RotateClockWise();
                        break;
                    }
                case CubeRotateNotation.CounterClockWise:
                    {
                        RotateCounterClockWise();
                        break;
                    }
                default:
                    Debug.Assert(false, "[Cubium::Rotate] Unknown Rotation : " + flgMove.ToString());
                    break;
            }
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", Location.X, Location.Y, Location.Z);
        }

        public override bool Equals(object obj)
        {
            // cast the obj to a cubium
            Cubium clsTemp = obj as Cubium;

            // check if cubium is not null
            if (clsTemp != null)
            {
                // check if the co-ordinates matches and check if the faces match
                if (this.ToString() == clsTemp.ToString() &&
                    Up == clsTemp.Up &&
                    Down == clsTemp.Down &&
                    Face == clsTemp.Face &&
                    Back == clsTemp.Back &&
                    Left == clsTemp.Left &&
                    Right == clsTemp.Right)
                {
                    // match return true
                    return true;
                }
            }
            // not equals return false
            return false;
        }
        #endregion Public Methods

        #region Private Methods
        /// <summary>
        /// face -> up -> back -> down -> face
        /// </summary>
        private void RotateUp()
        {
            // save face
            CubeColor flgTemp = Face;

            // down -> face
            Face = Down;
            // back -> down
            Down = Back;
            // up -> back
            Back = Up;
            // face -> up
            Up = flgTemp;
        }

        private void RotateDown()
        {
            // rotate up 3 times
            RotateUp();
            RotateUp();
            RotateUp();
        }

        /// <summary>
        /// face -> right -> back -> left -> face
        /// </summary>
        private void RotateRight()
        {
            // save face
            CubeColor flgTemp = Face;

            // left -> face
            Face = Left;
            // back -> left
            Left = Back;
            // right -> back
            Back = Right;
            // face -> right
            Right = flgTemp;
        }

        private void RotateLeft()
        {
            // rotate right 3 times
            RotateRight();
            RotateRight();
            RotateRight();
        }

        /// <summary>
        /// left -> up -> right -> down -> left
        /// </summary>
        private void RotateClockWise()
        {
            // save left
            CubeColor flgTemp = Left;

            // down -> left
            Left = Down;
            // right -> down
            Down = Right;
            // up -> right
            Right = Up;
            // left -> up
            Up = flgTemp;
        }

        private void RotateCounterClockWise()
        {
            // rotate clockwise 3 times
            RotateClockWise();
            RotateClockWise();
            RotateClockWise();
        }
        #endregion Private Methods
    }

    public class Face
    {
        #region Public Methods
        public static void RotateXAxis(List<Cubium> lstCubes, bool flgClockWise = true)
        {
            //RotateTransform clsRotate = new RotateTransform()
            //RotateTransform3D clsRotate = new RotateTransform3D()
            if (flgClockWise)
            {
                // brute force!!
                foreach (Cubium cubie in lstCubes)
                {
                    // (*, y, z) y and z will be changed.
                    #region rotate clockwise
                    if (cubie.Location.Y == 0)
                    {
                        if (cubie.Location.Z == 0)
                        {
                            // (x, 0, 0) -> (x, 0, 2)
                            cubie.Location.Z = 2;
                        }
                        else if (cubie.Location.Z == 1)
                        {
                            // (x, 0, 1) -> (x, 1, 2)
                            cubie.Location.Y = 1;
                            cubie.Location.Z = 2;
                        }
                        else if (cubie.Location.Z == 2)
                        {
                            // (x, 0, 2) -> (x, 2, 2)
                            cubie.Location.Y = 2;
                        }
                    }
                    else if (cubie.Location.Y == 1)
                    {
                        if (cubie.Location.Z == 0)
                        {
                            // (x, 1, 0) -> (x, 0, 1)
                            cubie.Location.Y = 0;
                            cubie.Location.Z = 1;
                        }
                        else if (cubie.Location.Z == 1)
                        {
                            // (x, 1, 1) -> (x, 1, 1)
                            // do nothing this is the middle
                        }
                        else if (cubie.Location.Z == 2)
                        {
                            // (x, 1, 2) -> (x, 2, 1)
                            cubie.Location.Y = 2;
                            cubie.Location.Z = 1;
                        }
                    }
                    else if (cubie.Location.Y == 2)
                    {
                        if (cubie.Location.Z == 0)
                        {
                            // (x, 2, 0) -> (x, 0, 0)
                            cubie.Location.Y = 0;
                            cubie.Location.Z = 0;
                        }
                        else if (cubie.Location.Z == 1)
                        {
                            // (x, 2, 1) -> (x, 1, 0)
                            cubie.Location.Y = 1;
                            cubie.Location.Z = 0;
                        }
                        else if (cubie.Location.Z == 2)
                        {
                            // (x, 2, 2) -> (x, 2, 0)
                            cubie.Location.Z = 0;
                        }
                    }
                    #endregion rotate clockwise

                    // rotate cubie.Location colors
                    cubie.Rotate(CubeRotateNotation.Up);
                }
            }
            else
            {
                // brute force!!
                foreach (Cubium cubie in lstCubes)
                {
                    // (*, y, z) y and z will be changed.
                    #region rotate clockwise
                    if (cubie.Location.Y == 0)
                    {
                        if (cubie.Location.Z == 0)
                        {
                            // (x, 0, 0) -> (x, 2, 0)
                            cubie.Location.Y = 2;
                        }
                        else if (cubie.Location.Z == 1)
                        {
                            // (x, 0, 1) -> (x, 1, 0)
                            cubie.Location.Y = 1;
                            cubie.Location.Z = 0;
                        }
                        else if (cubie.Location.Z == 2)
                        {
                            // (x, 0, 2) -> (x, 0, 0)
                            cubie.Location.Z = 0;
                        }
                    }
                    else if (cubie.Location.Y == 1)
                    {
                        if (cubie.Location.Z == 0)
                        {
                            // (x, 1, 0) -> (x, 2, 1)
                            cubie.Location.Y = 2;
                            cubie.Location.Z = 1;
                        }
                        else if (cubie.Location.Z == 1)
                        {
                            // (x, 1, 1) -> (x, 1, 1)
                            // do nothing this is the middle
                        }
                        else if (cubie.Location.Z == 2)
                        {
                            // (x, 1, 2) -> (x, 0, 1)
                            cubie.Location.Y = 0;
                            cubie.Location.Z = 1;
                        }
                    }
                    else if (cubie.Location.Y == 2)
                    {
                        if (cubie.Location.Z == 0)
                        {
                            // (x, 2, 0) -> (x, 2, 2)
                            //cubie.Location.Y = 0;
                            cubie.Location.Z = 2;
                        }
                        else if (cubie.Location.Z == 1)
                        {
                            // (x, 2, 1) -> (x, 1, 2)
                            cubie.Location.Y = 1;
                            cubie.Location.Z = 2;
                        }
                        else if (cubie.Location.Z == 2)
                        {
                            // (x, 2, 2) -> (x, 0, 2)
                            cubie.Location.Y = 0;
                        }
                    }
                    #endregion rotate clockwise

                    // rotate cubie colors
                    cubie.Rotate(CubeRotateNotation.Down);
                }
            }
        }

        public static void RotateYAxis(List<Cubium> lstCubes, bool flgClockWise = true)
        {
            if (flgClockWise)
            {
                // brute force!!
                foreach (Cubium cubie in lstCubes)
                {
                    // (x, *, z) x and z will be changed.
                    #region rotate clockwise
                    if (cubie.Location.X == 0)
                    {
                        if (cubie.Location.Z == 0)
                        {
                            // (0, y, 0) -> (0, y, 2)
                            cubie.Location.Z = 2;
                        }
                        else if (cubie.Location.Z == 1)
                        {
                            // (0, y, 1) -> (1, y, 2)
                            cubie.Location.X = 1;
                            cubie.Location.Z = 2;
                        }
                        else if (cubie.Location.Z == 2)
                        {
                            // (0, y, 2) -> (2, y, 2)
                            cubie.Location.X = 2;
                        }
                    }
                    else if (cubie.Location.X == 1)
                    {
                        if (cubie.Location.Z == 0)
                        {
                            // (1, y, 0) -> (0, y, 1)
                            cubie.Location.X = 0;
                            cubie.Location.Z = 1;
                        }
                        else if (cubie.Location.Z == 1)
                        {
                            // (1, y, 1) -> (1, y, 1)
                            // do nothing this is the middle
                        }
                        else if (cubie.Location.Z == 2)
                        {
                            // (1, y, 2) -> (2, y, 1)
                            cubie.Location.X = 2;
                            cubie.Location.Z = 1;
                        }
                    }
                    else if (cubie.Location.X == 2)
                    {
                        if (cubie.Location.Z == 0)
                        {
                            // (2, y, 0) -> (0, y, 0)
                            cubie.Location.X = 0;
                            //cubie.Location.Z = 0;
                        }
                        else if (cubie.Location.Z == 1)
                        {
                            // (2, y, 1) -> (1, y, 0)
                            cubie.Location.X = 1;
                            cubie.Location.Z = 0;
                        }
                        else if (cubie.Location.Z == 2)
                        {
                            // (2, y, 2) -> (2, y, 0)
                            cubie.Location.Z = 0;
                        }
                    }
                    #endregion rotate clockwise

                    // rotate cubie.Location colors
                    cubie.Rotate(CubeRotateNotation.ClockWise);
                }
            }
            else
            {
                // brute force!!
                foreach (Cubium cubie in lstCubes)
                {
                    // (x, *, z) x and z will be changed.
                    #region rotate clockwise
                    if (cubie.Location.X == 0)
                    {
                        if (cubie.Location.Z == 0)
                        {
                            // (0, y, 0) -> (2, y, 0)
                            cubie.Location.X = 2;
                        }
                        else if (cubie.Location.Z == 1)
                        {
                            // (0, y, 1) -> (1, y, 0)
                            cubie.Location.X = 1;
                            cubie.Location.Z = 0;
                        }
                        else if (cubie.Location.Z == 2)
                        {
                            // (0, y, 2) -> (0, y, 0)
                            cubie.Location.Z = 0;
                        }
                    }
                    else if (cubie.Location.X == 1)
                    {
                        if (cubie.Location.Z == 0)
                        {
                            // (1, y, 0) -> (2, y, 1)
                            cubie.Location.X = 2;
                            cubie.Location.Z = 1;
                        }
                        else if (cubie.Location.Z == 1)
                        {
                            // (1, y, 1) -> (1, y, 1)
                            // do nothing this is the middle
                        }
                        else if (cubie.Location.Z == 2)
                        {
                            // (1, y, 2) -> (0, y, 1)
                            cubie.Location.X = 0;
                            cubie.Location.Z = 1;
                        }
                    }
                    else if (cubie.Location.X == 2)
                    {
                        if (cubie.Location.Z == 0)
                        {
                            // (2, y, 0) -> (2, y, 2)
                            //cubie.Location.Y = 0;
                            cubie.Location.Z = 2;
                        }
                        else if (cubie.Location.Z == 1)
                        {
                            // (2, y, 1) -> (1, y, 2)
                            cubie.Location.X = 1;
                            cubie.Location.Z = 2;
                        }
                        else if (cubie.Location.Z == 2)
                        {
                            // (2, y, 2) -> (0, y, 2)
                            cubie.Location.X = 0;
                        }
                    }
                    #endregion rotate clockwise

                    // rotate cubie colors
                    cubie.Rotate(CubeRotateNotation.CounterClockWise);
                }
            }
        }

        public static void RotateZAxis(List<Cubium> lstCubes, bool flgClockWise = true)
        {
            if (flgClockWise)
            {
                // brute force!!
                foreach (Cubium cubie in lstCubes)
                {
                    // (x, y, *) x and y will be changed.
                    #region rotate clockwise
                    if (cubie.Location.X == 0)
                    {
                        if (cubie.Location.Y == 0)
                        {
                            // (0, 0, z) -> (0, 2, z)
                            cubie.Location.Y = 2;
                        }
                        else if (cubie.Location.Y == 1)
                        {
                            // (0, 1, z) -> (1, 2, z)
                            cubie.Location.X = 1;
                            cubie.Location.Y = 2;
                        }
                        else if (cubie.Location.Y == 2)
                        {
                            // (0, 2, z) -> (2, 2, z)
                            cubie.Location.X = 2;
                        }
                    }
                    else if (cubie.Location.X == 1)
                    {
                        if (cubie.Location.Y == 0)
                        {
                            // (1, 0, z) -> (0, 1, z)
                            cubie.Location.X = 0;
                            cubie.Location.Y = 1;
                        }
                        else if (cubie.Location.Y == 1)
                        {
                            // (1, y, 1) -> (1, y, 1)
                            // do nothing this is the middle
                        }
                        else if (cubie.Location.Y == 2)
                        {
                            // (1, 2, z) -> (2, 1, z)
                            cubie.Location.X = 2;
                            cubie.Location.Y = 1;
                        }
                    }
                    else if (cubie.Location.X == 2)
                    {
                        if (cubie.Location.Y == 0)
                        {
                            // (2, 0, z) -> (0, 0, z)
                            cubie.Location.X = 0;
                            //cubie.Location.Z = 0;
                        }
                        else if (cubie.Location.Y == 1)
                        {
                            // (2, 1, z) -> (1, 0, z)
                            cubie.Location.X = 1;
                            cubie.Location.Y = 0;
                        }
                        else if (cubie.Location.Y == 2)
                        {
                            // (2, 2, z) -> (2, 0, Z)
                            cubie.Location.Y = 0;
                        }
                    }
                    #endregion rotate clockwise

                    // rotate cubie colors
                    cubie.Rotate(CubeRotateNotation.Left);
                }
            }
            else
            {
                // brute force!!
                foreach (Cubium cubie in lstCubes)
                {
                    // (x, y, *) x and y will be changed.
                    #region rotate clockwise
                    if (cubie.Location.X == 0)
                    {
                        if (cubie.Location.Y == 0)
                        {
                            // (0, 0, z) -> (2, 0, z)
                            cubie.Location.X = 2;
                        }
                        else if (cubie.Location.Y == 1)
                        {
                            // (0, 1, z) -> (1, 0, z)
                            cubie.Location.X = 1;
                            cubie.Location.Y = 0;
                        }
                        else if (cubie.Location.Y == 2)
                        {
                            // (0, 2, z) -> (0, 0, z)
                            cubie.Location.Y = 0;
                        }
                    }
                    else if (cubie.Location.X == 1)
                    {
                        if (cubie.Location.Y == 0)
                        {
                            // (1, 0, z) -> (2, 1, z)
                            cubie.Location.X = 2;
                            cubie.Location.Y = 1;
                        }
                        else if (cubie.Location.Y == 1)
                        {
                            // (1, y, 1) -> (1, y, 1)
                            // do nothing this is the middle
                        }
                        else if (cubie.Location.Y == 2)
                        {
                            // (1, 2, z) -> (0, 1, z)
                            cubie.Location.X = 0;
                            cubie.Location.Y = 1;
                        }
                    }
                    else if (cubie.Location.X == 2)
                    {
                        if (cubie.Location.Y == 0)
                        {
                            // (2, 0, z) -> (2, 2, z)
                            //cubie.Location.Y = 0;
                            cubie.Location.Y = 2;
                        }
                        else if (cubie.Location.Y == 1)
                        {
                            // (2, 1, z) -> (1, 2, z)
                            cubie.Location.X = 1;
                            cubie.Location.Y = 2;
                        }
                        else if (cubie.Location.Y == 2)
                        {
                            // (2, 2, z) -> (0, 2, y)
                            cubie.Location.X = 0;
                        }
                    }
                    #endregion rotate clockwise

                    // rotate cubie.Location colors
                    cubie.Rotate(CubeRotateNotation.Right);
                }
            }
        }
        #endregion Public Methods
    }

    public class Point3D
    {
        #region Properties
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        //public string ID { get; set; }
        #endregion Properties

        #region Constructor
        public Point3D(double numX = 0, double numY = 0, double numZ = 0)
        {
            X = numX;
            Y = numY;
            Z = numZ;
            //ID = string.Format("({0}, {1}, {2})", X, Y, Z);
        }
        #endregion Constructor

        #region Public Methods
        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }

        public override bool Equals(object obj)
        {
            return (this.ToString() == obj.ToString());
        }

        /// <summary>
        /// pt2 - pt1
        /// </summary>
        /// <param name="pt1">Point3D 1</param>
        /// <param name="pt2">Point3D 2</param>
        /// <returns>Result of the substraction</returns>
        public static Point3D Subtract(Point3D pt1, Point3D pt2)
        {
            Point3D pt3 = new Point3D();

            pt3.X = pt2.X - pt1.X;
            pt3.Y = pt2.Y - pt1.Y;
            pt3.Z = pt2.Z - pt1.Z;

            return pt3;
        }

        /// <summary>
        /// pt2 + pt1
        /// </summary>
        /// <param name="pt1">Point3D 1</param>
        /// <param name="pt2">Point3D 2</param>
        /// <returns>Result of the addition</returns>
        public static Point3D Addition(Point3D pt1, Point3D pt2)
        {
            Point3D pt3 = new Point3D();

            pt3.X = pt2.X + pt1.X;
            pt3.Y = pt2.Y + pt1.Y;
            pt3.Z = pt2.Z + pt1.Z;

            return pt3;
        }
        #endregion Public Methods
    }
}
