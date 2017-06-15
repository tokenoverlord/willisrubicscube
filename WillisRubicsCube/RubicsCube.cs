using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;

namespace WillisRubicsCube
{
    public class RubicsCube
    {
        #region Private Members
        private List<Cubie> _lstCubies
            = new List<Cubie>();
        #endregion Private Members

        #region Constructor
        public RubicsCube()
        {
            // reset the cubes
            Reset();

            // init ICommands
            RotateBack = new RotateFaceCommand(RotateFace, 
                FaceRotateNotation.Back, 
                FaceRotateNotation.Back_Inverted);
            InvRotateBack = new RotateFaceCommand(RotateFace,
                FaceRotateNotation.Back_Inverted,
                FaceRotateNotation.Back);

            RotateDown = new RotateFaceCommand(RotateFace,
                FaceRotateNotation.Down,
                FaceRotateNotation.Down_Inverted);
            InvRotateDown = new RotateFaceCommand(RotateFace,
                FaceRotateNotation.Down_Inverted,
                FaceRotateNotation.Down);

            RotateFront = new RotateFaceCommand(RotateFace,
                FaceRotateNotation.Front,
                FaceRotateNotation.Front_Inverted);
            InvRotateFront = new RotateFaceCommand(RotateFace,
                FaceRotateNotation.Front_Inverted,
                FaceRotateNotation.Front);

            RotateLeft = new RotateFaceCommand(RotateFace,
                FaceRotateNotation.Left,
                FaceRotateNotation.Left_Inverted);
            InvRotateLeft = new RotateFaceCommand(RotateFace,
                FaceRotateNotation.Left_Inverted,
                FaceRotateNotation.Left);

            RotateRight = new RotateFaceCommand(RotateFace,
                FaceRotateNotation.Right,
                FaceRotateNotation.Right_Inverted);
            InvRotateRight = new RotateFaceCommand(RotateFace,
                FaceRotateNotation.Right_Inverted,
                FaceRotateNotation.Right);

            RotateUp = new RotateFaceCommand(RotateFace,
                FaceRotateNotation.Up,
                FaceRotateNotation.Up_Inverted);
            InvRotateUp = new RotateFaceCommand(RotateFace,
                FaceRotateNotation.Up_Inverted,
                FaceRotateNotation.Up);

            ResetCommand = new ResetRubicsCubeCommand(Reset);
        }
        #endregion Constructor

        #region Properties
        public List<Cubie> Cubies { get { return _lstCubies; } }

        public ICommand RotateRight { get; private set; }

        public ICommand InvRotateRight { get; private set; }

        public ICommand RotateLeft { get; private set; }

        public ICommand InvRotateLeft { get; private set; }

        public ICommand RotateFront { get; private set; }

        public ICommand InvRotateFront { get; private set; }

        public ICommand RotateBack { get; private set; }

        public ICommand InvRotateBack { get; private set; }

        public ICommand RotateUp { get; private set; }

        public ICommand InvRotateUp { get; private set; }

        public ICommand RotateDown { get; private set; }

        public ICommand InvRotateDown { get; private set; }

        public ICommand ResetCommand { get; private set; }
        #endregion Properties

        #region Public Methods
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
        public void Reset()
        {
            // clear the current cubies
            _lstCubies.Clear();

            #region Top Layer
            // (0, 0, 2)
            _lstCubies.Add(new Cubie()
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
            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(0, 1, 2),
                //X = 0,
                //Y = 1,
                //Z = 2,
                Up = CubeColor.Red,
                Left = CubeColor.Blue
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(0, 2, 2),
                //X = 0,
                //Y = 2,
                //Z = 2,
                Up = CubeColor.Red,
                Left = CubeColor.Blue,
                Back = CubeColor.Yellow,
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(1, 0, 2),
                //X = 1,
                //Y = 0,
                //Z = 2,
                Up = CubeColor.Red,
                Face = CubeColor.White,
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(1, 1, 2),
                //X = 1,
                //Y = 1,
                //Z = 2,
                Up = CubeColor.Red,
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(1, 2, 2),
                //X = 1,
                //Y = 2,
                //Z = 2,
                Up = CubeColor.Red,
                Back = CubeColor.Yellow,
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(2, 0, 2),
                //X = 2,
                //Y = 0,
                //Z = 2,
                Up = CubeColor.Red,
                Face = CubeColor.White,
                Right = CubeColor.Green,
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(2, 1, 2),
                //X = 2,
                //Y = 1,
                //Z = 2,
                Up = CubeColor.Red,
                Right = CubeColor.Green,
            });

            _lstCubies.Add(new Cubie()
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
            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(0, 0, 1),
                //X = 0,
                //Y = 0,
                //Z = 1,
                Face = CubeColor.White,
                Left = CubeColor.Blue,
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(0, 1, 1),
                //X = 0,
                //Y = 1,
                //Z = 1,
                Left = CubeColor.Blue
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(0, 2, 1),
                //X = 0,
                //Y = 2,
                //Z = 1,
                Back = CubeColor.Yellow,
                Left = CubeColor.Blue,
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(1, 0, 1),
                //X = 1,
                //Y = 0,
                //Z = 1,
                Face = CubeColor.White
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(1, 2, 1),
                //X = 1,
                //Y = 2,
                //Z = 1,
                Back = CubeColor.Yellow,
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(2, 0, 1),
                //X = 2,
                //Y = 0,
                //Z = 1,
                Face = CubeColor.White,
                Right = CubeColor.Green,
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(2, 1, 1),
                //X = 2,
                //Y = 1,
                //Z = 1,
                Right = CubeColor.Green,
            });

            _lstCubies.Add(new Cubie()
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
            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(0, 0, 0),
                //X = 0,
                //Y = 0,
                //Z = 0,
                Face = CubeColor.White,
                Left = CubeColor.Blue,
                Down = CubeColor.Orange,
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(0, 1, 0),
                //X = 0,
                //Y = 1,
                //Z = 0,
                Left = CubeColor.Blue,
                Down = CubeColor.Orange,
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(0, 2, 0),
                //X = 0,
                //Y = 2,
                //Z = 0,
                Left = CubeColor.Blue,
                Down = CubeColor.Orange,
                Back = CubeColor.Yellow,
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(1, 0, 0),
                //X = 1,
                //Y = 0,
                //Z = 0,
                Face = CubeColor.White,
                Down = CubeColor.Orange,
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(1, 1, 0),
                //X = 1,
                //Y = 1,
                //Z = 0,
                Down = CubeColor.Orange,
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(1, 2, 0),
                //X = 1,
                //Y = 2,
                //Z = 0,
                Back = CubeColor.Yellow,
                Down = CubeColor.Orange,
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(2, 0, 0),
                //X = 2,
                //Y = 0,
                //Z = 0,
                Face = CubeColor.White,
                Down = CubeColor.Orange,
                Right = CubeColor.Green,
            });

            _lstCubies.Add(new Cubie()
            {
                Location = new Point3D(2, 1, 0),
                //X = 2,
                //Y = 1,
                //Z = 0,
                Right = CubeColor.Green,
                Down = CubeColor.Orange,
            });

            _lstCubies.Add(new Cubie()
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
        }

        public void RotateFace(FaceRotateNotation flgRotate)
        {
            List<Cubie> lstTemp = new List<Cubie>();

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
        #endregion Public Methods
    }

    public class Face
    {
        #region Public Methods
        public static void RotateXAxis(List<Cubie> lstCubes, bool flgClockWise = true)
        {
            //RotateTransform clsRotate = new RotateTransform()
            //RotateTransform3D clsRotate = new RotateTransform3D()
            if (flgClockWise)
            {
                // brute force!!
                foreach (Cubie cubie in lstCubes)
                {
                    // create a temp location
                    Point3D clsTemp = cubie.Location;
                    // (*, y, z) y and z will be changed.
                    #region rotate clockwise
                    if (clsTemp.Y == 0)
                    {
                        if (clsTemp.Z == 0)
                        {
                            // (x, 0, 0) -> (x, 0, 2)
                            clsTemp.Z = 2;
                            //clsTemp.Z = 2;
                        }
                        else if (clsTemp.Z == 1)
                        {
                            // (x, 0, 1) -> (x, 1, 2)
                            clsTemp.Y = 1;
                            clsTemp.Z = 2;
                        }
                        else if (clsTemp.Z == 2)
                        {
                            // (x, 0, 2) -> (x, 2, 2)
                            clsTemp.Y = 2;
                        }
                    }
                    else if (clsTemp.Y == 1)
                    {
                        if (clsTemp.Z == 0)
                        {
                            // (x, 1, 0) -> (x, 0, 1)
                            clsTemp.Y = 0;
                            clsTemp.Z = 1;
                        }
                        else if (clsTemp.Z == 1)
                        {
                            // (x, 1, 1) -> (x, 1, 1)
                            // do nothing this is the middle
                        }
                        else if (clsTemp.Z == 2)
                        {
                            // (x, 1, 2) -> (x, 2, 1)
                            clsTemp.Y = 2;
                            clsTemp.Z = 1;
                        }
                    }
                    else if (clsTemp.Y == 2)
                    {
                        if (clsTemp.Z == 0)
                        {
                            // (x, 2, 0) -> (x, 0, 0)
                            clsTemp.Y = 0;
                            clsTemp.Z = 0;
                        }
                        else if (clsTemp.Z == 1)
                        {
                            // (x, 2, 1) -> (x, 1, 0)
                            clsTemp.Y = 1;
                            clsTemp.Z = 0;
                        }
                        else if (clsTemp.Z == 2)
                        {
                            // (x, 2, 2) -> (x, 2, 0)
                            clsTemp.Z = 0;
                        }
                    }
                    #endregion rotate clockwise

                    // get the new location.
                    cubie.Location = clsTemp;

                    // rotate cubie.Location colors
                    cubie.Rotate(CubeRotateNotation.Up);
                }
            }
            else
            {
                // brute force!!
                foreach (Cubie cubie in lstCubes)
                {
                    // create a temp location
                    Point3D clsTemp = cubie.Location;

                    // (*, y, z) y and z will be changed.
                    #region rotate clockwise
                    if (clsTemp.Y == 0)
                    {
                        if (clsTemp.Z == 0)
                        {
                            // (x, 0, 0) -> (x, 2, 0)
                            clsTemp.Y = 2;
                        }
                        else if (clsTemp.Z == 1)
                        {
                            // (x, 0, 1) -> (x, 1, 0)
                            clsTemp.Y = 1;
                            clsTemp.Z = 0;
                        }
                        else if (clsTemp.Z == 2)
                        {
                            // (x, 0, 2) -> (x, 0, 0)
                            clsTemp.Z = 0;
                        }
                    }
                    else if (clsTemp.Y == 1)
                    {
                        if (clsTemp.Z == 0)
                        {
                            // (x, 1, 0) -> (x, 2, 1)
                            clsTemp.Y = 2;
                            clsTemp.Z = 1;
                        }
                        else if (clsTemp.Z == 1)
                        {
                            // (x, 1, 1) -> (x, 1, 1)
                            // do nothing this is the middle
                        }
                        else if (clsTemp.Z == 2)
                        {
                            // (x, 1, 2) -> (x, 0, 1)
                            clsTemp.Y = 0;
                            clsTemp.Z = 1;
                        }
                    }
                    else if (clsTemp.Y == 2)
                    {
                        if (clsTemp.Z == 0)
                        {
                            // (x, 2, 0) -> (x, 2, 2)
                            //clsTemp.Y = 0;
                            clsTemp.Z = 2;
                        }
                        else if (clsTemp.Z == 1)
                        {
                            // (x, 2, 1) -> (x, 1, 2)
                            clsTemp.Y = 1;
                            clsTemp.Z = 2;
                        }
                        else if (clsTemp.Z == 2)
                        {
                            // (x, 2, 2) -> (x, 0, 2)
                            clsTemp.Y = 0;
                        }
                    }
                    #endregion rotate clockwise

                    // get the new location
                    cubie.Location = clsTemp;

                    // rotate cubie colors
                    cubie.Rotate(CubeRotateNotation.Down);
                }
            }
        }

        public static void RotateYAxis(List<Cubie> lstCubes, bool flgClockWise = true)
        {
            if (flgClockWise)
            {
                // brute force!!
                foreach (Cubie cubie in lstCubes)
                {
                    // create a temp location
                    Point3D clsTemp = cubie.Location;

                    // (x, *, z) x and z will be changed.
                    #region rotate clockwise
                    if (clsTemp.X == 0)
                    {
                        if (clsTemp.Z == 0)
                        {
                            // (0, y, 0) -> (0, y, 2)
                            clsTemp.Z = 2;
                        }
                        else if (clsTemp.Z == 1)
                        {
                            // (0, y, 1) -> (1, y, 2)
                            clsTemp.X = 1;
                            clsTemp.Z = 2;
                        }
                        else if (clsTemp.Z == 2)
                        {
                            // (0, y, 2) -> (2, y, 2)
                            clsTemp.X = 2;
                        }
                    }
                    else if (clsTemp.X == 1)
                    {
                        if (clsTemp.Z == 0)
                        {
                            // (1, y, 0) -> (0, y, 1)
                            clsTemp.X = 0;
                            clsTemp.Z = 1;
                        }
                        else if (clsTemp.Z == 1)
                        {
                            // (1, y, 1) -> (1, y, 1)
                            // do nothing this is the middle
                        }
                        else if (clsTemp.Z == 2)
                        {
                            // (1, y, 2) -> (2, y, 1)
                            clsTemp.X = 2;
                            clsTemp.Z = 1;
                        }
                    }
                    else if (clsTemp.X == 2)
                    {
                        if (clsTemp.Z == 0)
                        {
                            // (2, y, 0) -> (0, y, 0)
                            clsTemp.X = 0;
                            //clsTemp.Z = 0;
                        }
                        else if (clsTemp.Z == 1)
                        {
                            // (2, y, 1) -> (1, y, 0)
                            clsTemp.X = 1;
                            clsTemp.Z = 0;
                        }
                        else if (clsTemp.Z == 2)
                        {
                            // (2, y, 2) -> (2, y, 0)
                            clsTemp.Z = 0;
                        }
                    }
                    #endregion rotate clockwise

                    // get the new location
                    cubie.Location = clsTemp;

                    // rotate cubie.Location colors
                    cubie.Rotate(CubeRotateNotation.ClockWise);
                }
            }
            else
            {
                // brute force!!
                foreach (Cubie cubie in lstCubes)
                {
                    // create a temp location
                    Point3D clsTemp = cubie.Location;

                    // (x, *, z) x and z will be changed.
                    #region rotate clockwise
                    if (clsTemp.X == 0)
                    {
                        if (clsTemp.Z == 0)
                        {
                            // (0, y, 0) -> (2, y, 0)
                            clsTemp.X = 2;
                        }
                        else if (clsTemp.Z == 1)
                        {
                            // (0, y, 1) -> (1, y, 0)
                            clsTemp.X = 1;
                            clsTemp.Z = 0;
                        }
                        else if (clsTemp.Z == 2)
                        {
                            // (0, y, 2) -> (0, y, 0)
                            clsTemp.Z = 0;
                        }
                    }
                    else if (clsTemp.X == 1)
                    {
                        if (clsTemp.Z == 0)
                        {
                            // (1, y, 0) -> (2, y, 1)
                            clsTemp.X = 2;
                            clsTemp.Z = 1;
                        }
                        else if (clsTemp.Z == 1)
                        {
                            // (1, y, 1) -> (1, y, 1)
                            // do nothing this is the middle
                        }
                        else if (clsTemp.Z == 2)
                        {
                            // (1, y, 2) -> (0, y, 1)
                            clsTemp.X = 0;
                            clsTemp.Z = 1;
                        }
                    }
                    else if (clsTemp.X == 2)
                    {
                        if (clsTemp.Z == 0)
                        {
                            // (2, y, 0) -> (2, y, 2)
                            //clsTemp.Y = 0;
                            clsTemp.Z = 2;
                        }
                        else if (clsTemp.Z == 1)
                        {
                            // (2, y, 1) -> (1, y, 2)
                            clsTemp.X = 1;
                            clsTemp.Z = 2;
                        }
                        else if (clsTemp.Z == 2)
                        {
                            // (2, y, 2) -> (0, y, 2)
                            clsTemp.X = 0;
                        }
                    }
                    #endregion rotate clockwise

                    // get the new location
                    cubie.Location = clsTemp;

                    // rotate cubie colors
                    cubie.Rotate(CubeRotateNotation.CounterClockWise);
                }
            }
        }

        public static void RotateZAxis(List<Cubie> lstCubes, bool flgClockWise = true)
        {
            if (flgClockWise)
            {
                // brute force!!
                foreach (Cubie cubie in lstCubes)
                {
                    // create a temp location
                    Point3D clsTemp = cubie.Location;

                    // (x, y, *) x and y will be changed.
                    #region rotate clockwise
                    if (clsTemp.X == 0)
                    {
                        if (clsTemp.Y == 0)
                        {
                            // (0, 0, z) -> (0, 2, z)
                            clsTemp.Y = 2;
                        }
                        else if (clsTemp.Y == 1)
                        {
                            // (0, 1, z) -> (1, 2, z)
                            clsTemp.X = 1;
                            clsTemp.Y = 2;
                        }
                        else if (clsTemp.Y == 2)
                        {
                            // (0, 2, z) -> (2, 2, z)
                            clsTemp.X = 2;
                        }
                    }
                    else if (clsTemp.X == 1)
                    {
                        if (clsTemp.Y == 0)
                        {
                            // (1, 0, z) -> (0, 1, z)
                            clsTemp.X = 0;
                            clsTemp.Y = 1;
                        }
                        else if (clsTemp.Y == 1)
                        {
                            // (1, y, 1) -> (1, y, 1)
                            // do nothing this is the middle
                        }
                        else if (clsTemp.Y == 2)
                        {
                            // (1, 2, z) -> (2, 1, z)
                            clsTemp.X = 2;
                            clsTemp.Y = 1;
                        }
                    }
                    else if (clsTemp.X == 2)
                    {
                        if (clsTemp.Y == 0)
                        {
                            // (2, 0, z) -> (0, 0, z)
                            clsTemp.X = 0;
                            //clsTemp.Z = 0;
                        }
                        else if (clsTemp.Y == 1)
                        {
                            // (2, 1, z) -> (1, 0, z)
                            clsTemp.X = 1;
                            clsTemp.Y = 0;
                        }
                        else if (clsTemp.Y == 2)
                        {
                            // (2, 2, z) -> (2, 0, Z)
                            clsTemp.Y = 0;
                        }
                    }
                    #endregion rotate clockwise

                    // get the new location
                    cubie.Location = clsTemp;

                    // rotate cubie colors
                    cubie.Rotate(CubeRotateNotation.Left);
                }
            }
            else
            {
                // brute force!!
                foreach (Cubie cubie in lstCubes)
                {
                    // create a temp location
                    Point3D clsTemp = cubie.Location;

                    // (x, y, *) x and y will be changed.
                    #region rotate clockwise
                    if (clsTemp.X == 0)
                    {
                        if (clsTemp.Y == 0)
                        {
                            // (0, 0, z) -> (2, 0, z)
                            clsTemp.X = 2;
                        }
                        else if (clsTemp.Y == 1)
                        {
                            // (0, 1, z) -> (1, 0, z)
                            clsTemp.X = 1;
                            clsTemp.Y = 0;
                        }
                        else if (clsTemp.Y == 2)
                        {
                            // (0, 2, z) -> (0, 0, z)
                            clsTemp.Y = 0;
                        }
                    }
                    else if (clsTemp.X == 1)
                    {
                        if (clsTemp.Y == 0)
                        {
                            // (1, 0, z) -> (2, 1, z)
                            clsTemp.X = 2;
                            clsTemp.Y = 1;
                        }
                        else if (clsTemp.Y == 1)
                        {
                            // (1, y, 1) -> (1, y, 1)
                            // do nothing this is the middle
                        }
                        else if (clsTemp.Y == 2)
                        {
                            // (1, 2, z) -> (0, 1, z)
                            clsTemp.X = 0;
                            clsTemp.Y = 1;
                        }
                    }
                    else if (clsTemp.X == 2)
                    {
                        if (clsTemp.Y == 0)
                        {
                            // (2, 0, z) -> (2, 2, z)
                            //clsTemp.Y = 0;
                            clsTemp.Y = 2;
                        }
                        else if (clsTemp.Y == 1)
                        {
                            // (2, 1, z) -> (1, 2, z)
                            clsTemp.X = 1;
                            clsTemp.Y = 2;
                        }
                        else if (clsTemp.Y == 2)
                        {
                            // (2, 2, z) -> (0, 2, y)
                            clsTemp.X = 0;
                        }
                    }
                    #endregion rotate clockwise

                    // get the new location
                    cubie.Location = clsTemp;

                    // rotate cubie.Location colors
                    cubie.Rotate(CubeRotateNotation.Right);
                }
            }
        }
        #endregion Public Methods
    }

    public delegate void RotateFaceDelegate(FaceRotateNotation flgRotateDir);

    public delegate void RubicsCubeDelegate();

    public class ResetRubicsCubeCommand : ICommand
    {
        #region Private Members
        private RubicsCubeDelegate _delResetMethod;
        #endregion Private Members

        #region Constructor
        public ResetRubicsCubeCommand(RubicsCubeDelegate delResetMethod)
        {
            _delResetMethod = delResetMethod;
        }
        #endregion Constructor

        #region Properties
        public bool IsReversable
        {
            get { return false; }
        }
        #endregion Properties

        #region Public Methods
        public void Execute()
        {
            _delResetMethod();
        }

        public void UnExecute()
        {
            //throw new NotImplementedException();
        }
        #endregion Public Methods
    }

    public class RotateFaceCommand : ICommand
    {
        #region Private Members
        // function pointer.
        private RotateFaceDelegate _delRotateCube;

        private FaceRotateNotation _flgRotateDir;
        private FaceRotateNotation _flgReverseDir;
        #endregion Private Members

        #region Constructor
        public RotateFaceCommand(RotateFaceDelegate delRotateCube, 
            FaceRotateNotation flgRotateDir, FaceRotateNotation flgReverseDir)
        {
            _delRotateCube = delRotateCube;
            _flgReverseDir = flgReverseDir;
            _flgRotateDir = flgRotateDir;
        }
        #endregion Constructor

        #region Properties
        public bool IsReversable
        {
            get { return true; }
        }
        #endregion Properties

        #region Public Methods
        public void Execute()
        {
            _delRotateCube(_flgRotateDir);
        }

        public void UnExecute()
        {
            _delRotateCube(_flgReverseDir);
        }
        #endregion Public Methods
    }
}
