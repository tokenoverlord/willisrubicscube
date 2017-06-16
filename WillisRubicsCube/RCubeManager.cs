using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media.Media3D;

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
        #region Constructor
        public RCubeManager()
        {
            // TheRubicsCube = clsRubicsCube;
            TheRubicsCube = new RubicsCube();

            // init rotate face commands
            RotateILeftCommand =
                new RotateFaceCommand(TheRubicsCube, 
                    FaceRotateNotation.Left_Inverted, 
                    FaceRotateNotation.Left);
            RotateLeftCommand = 
                new RotateFaceCommand(TheRubicsCube, 
                    FaceRotateNotation.Left, 
                    FaceRotateNotation.Left_Inverted);

            RotateRightCommand =
                new RotateFaceCommand(TheRubicsCube,
                    FaceRotateNotation.Right,
                    FaceRotateNotation.Right_Inverted);
            RotateIRightCommand =
                new RotateFaceCommand(TheRubicsCube,
                    FaceRotateNotation.Right_Inverted,
                    FaceRotateNotation.Right);

            RotateBackCommand =
                new RotateFaceCommand(TheRubicsCube,
                    FaceRotateNotation.Back,
                    FaceRotateNotation.Back_Inverted);
            RotateIBackCommand =
                new RotateFaceCommand(TheRubicsCube,
                    FaceRotateNotation.Back_Inverted,
                    FaceRotateNotation.Back);

            RotateUpCommand =
                new RotateFaceCommand(TheRubicsCube,
                    FaceRotateNotation.Up,
                    FaceRotateNotation.Up_Inverted);
            RotateIUpCommand =
                new RotateFaceCommand(TheRubicsCube,
                    FaceRotateNotation.Up_Inverted,
                    FaceRotateNotation.Up);

            RotateDownCommand =
                new RotateFaceCommand(TheRubicsCube,
                    FaceRotateNotation.Down,
                    FaceRotateNotation.Down_Inverted);
            RotateIDownCommand =
                new RotateFaceCommand(TheRubicsCube,
                    FaceRotateNotation.Down_Inverted,
                    FaceRotateNotation.Down);

            RotateFrontCommand =
                new RotateFaceCommand(TheRubicsCube,
                    FaceRotateNotation.Front,
                    FaceRotateNotation.Front_Inverted);
            RotateIFrontCommand =
                new RotateFaceCommand(TheRubicsCube,
                    FaceRotateNotation.Front_Inverted,
                    FaceRotateNotation.Front);

            RestCommand =
                new ResetRubicsCubeCommand(TheRubicsCube);
        }
        #endregion Constructor

        #region Properties
        public RubicsCube TheRubicsCube { get; private set; }

        // Rotate Left ICommand
        public RotateFaceCommand RotateLeftCommand { get; private set; }
        public RotateFaceCommand RotateILeftCommand { get; private set; }

        // Rotate Right ICommand
        public RotateFaceCommand RotateRightCommand { get; private set; }
        public RotateFaceCommand RotateIRightCommand { get; private set; }

        // Rotate Back ICommand
        public RotateFaceCommand RotateBackCommand { get; private set; }
        public RotateFaceCommand RotateIBackCommand { get; private set; }

        // Rotate Up ICommand
        public RotateFaceCommand RotateUpCommand { get; private set; }
        public RotateFaceCommand RotateIUpCommand { get; private set; }

        // Rotate Down ICommand
        public RotateFaceCommand RotateDownCommand { get; private set; }
        public RotateFaceCommand RotateIDownCommand { get; private set; }

        // Rotate Front ICommand
        public RotateFaceCommand RotateFrontCommand { get; private set; }
        public RotateFaceCommand RotateIFrontCommand { get; private set; }

        // Rest ICommand
        public ResetRubicsCubeCommand RestCommand { get; private set; }
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
        public static void Reset(RubicsCube clsRubicsCube)
        {
            // clear the current cubies
            clsRubicsCube.Cubies.Clear();

            #region Top Layer
            // (0, 0, 2)
            clsRubicsCube.Cubies.Add(new Cubie()
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
            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(0, 1, 2),
                //X = 0,
                //Y = 1,
                //Z = 2,
                Up = CubeColor.Red,
                Left = CubeColor.Blue
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(0, 2, 2),
                //X = 0,
                //Y = 2,
                //Z = 2,
                Up = CubeColor.Red,
                Left = CubeColor.Blue,
                Back = CubeColor.Yellow,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(1, 0, 2),
                //X = 1,
                //Y = 0,
                //Z = 2,
                Up = CubeColor.Red,
                Face = CubeColor.White,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(1, 1, 2),
                //X = 1,
                //Y = 1,
                //Z = 2,
                Up = CubeColor.Red,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(1, 2, 2),
                //X = 1,
                //Y = 2,
                //Z = 2,
                Up = CubeColor.Red,
                Back = CubeColor.Yellow,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(2, 0, 2),
                //X = 2,
                //Y = 0,
                //Z = 2,
                Up = CubeColor.Red,
                Face = CubeColor.White,
                Right = CubeColor.Green,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(2, 1, 2),
                //X = 2,
                //Y = 1,
                //Z = 2,
                Up = CubeColor.Red,
                Right = CubeColor.Green,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
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
            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(0, 0, 1),
                //X = 0,
                //Y = 0,
                //Z = 1,
                Face = CubeColor.White,
                Left = CubeColor.Blue,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(0, 1, 1),
                //X = 0,
                //Y = 1,
                //Z = 1,
                Left = CubeColor.Blue
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(0, 2, 1),
                //X = 0,
                //Y = 2,
                //Z = 1,
                Back = CubeColor.Yellow,
                Left = CubeColor.Blue,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(1, 0, 1),
                //X = 1,
                //Y = 0,
                //Z = 1,
                Face = CubeColor.White
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(1, 2, 1),
                //X = 1,
                //Y = 2,
                //Z = 1,
                Back = CubeColor.Yellow,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(2, 0, 1),
                //X = 2,
                //Y = 0,
                //Z = 1,
                Face = CubeColor.White,
                Right = CubeColor.Green,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(2, 1, 1),
                //X = 2,
                //Y = 1,
                //Z = 1,
                Right = CubeColor.Green,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
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
            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(0, 0, 0),
                //X = 0,
                //Y = 0,
                //Z = 0,
                Face = CubeColor.White,
                Left = CubeColor.Blue,
                Down = CubeColor.Orange,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(0, 1, 0),
                //X = 0,
                //Y = 1,
                //Z = 0,
                Left = CubeColor.Blue,
                Down = CubeColor.Orange,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(0, 2, 0),
                //X = 0,
                //Y = 2,
                //Z = 0,
                Left = CubeColor.Blue,
                Down = CubeColor.Orange,
                Back = CubeColor.Yellow,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(1, 0, 0),
                //X = 1,
                //Y = 0,
                //Z = 0,
                Face = CubeColor.White,
                Down = CubeColor.Orange,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(1, 1, 0),
                //X = 1,
                //Y = 1,
                //Z = 0,
                Down = CubeColor.Orange,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(1, 2, 0),
                //X = 1,
                //Y = 2,
                //Z = 0,
                Back = CubeColor.Yellow,
                Down = CubeColor.Orange,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(2, 0, 0),
                //X = 2,
                //Y = 0,
                //Z = 0,
                Face = CubeColor.White,
                Down = CubeColor.Orange,
                Right = CubeColor.Green,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
            {
                Location = new Point3D(2, 1, 0),
                //X = 2,
                //Y = 1,
                //Z = 0,
                Right = CubeColor.Green,
                Down = CubeColor.Orange,
            });

            clsRubicsCube.Cubies.Add(new Cubie()
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

        public static void RotateFace(RubicsCube clsRubicsCube, FaceRotateNotation flgRotate)
        {
            List<Cubie> lstTemp = new List<Cubie>();

            switch (flgRotate)
            {
                case FaceRotateNotation.Back:
                    // all back cubes should have Y = 2
                    lstTemp.AddRange(clsRubicsCube.Cubies.FindAll(cb => cb.Location.Y == 2));
                    // rotate the temp list on the y axis counter clockwise
                    RotateYAxis(lstTemp, false);
                    break;
                case FaceRotateNotation.Back_Inverted:
                    // all back cubes should have Y = 2
                    lstTemp.AddRange(clsRubicsCube.Cubies.FindAll(cb => cb.Location.Y == 2));
                    // rotate the temp list on the y axis clockwise
                    RotateYAxis(lstTemp, true);
                    break;
                case FaceRotateNotation.Down:
                    // all back cubes should have z = 0
                    lstTemp.AddRange(clsRubicsCube.Cubies.FindAll(cb => cb.Location.Z == 0));
                    // rotate the temp list on the z axis clockwise
                    RotateZAxis(lstTemp, true);
                    break;
                case FaceRotateNotation.Down_Inverted:
                    // all back cubes should have z = 0
                    lstTemp.AddRange(clsRubicsCube.Cubies.FindAll(cb => cb.Location.Z == 0));
                    // rotate the temp list on the z axis counter clockwise
                    RotateZAxis(lstTemp, false);
                    break;
                case FaceRotateNotation.Front:
                    // all back cubes should have y = 0
                    lstTemp.AddRange(clsRubicsCube.Cubies.FindAll(cb => cb.Location.Y == 0));
                    // rotate the temp list on the Y axis clockwise
                    RotateYAxis(lstTemp, true);
                    break;
                case FaceRotateNotation.Front_Inverted:
                    // all back cubes should have y = 0
                    lstTemp.AddRange(clsRubicsCube.Cubies.FindAll(cb => cb.Location.Y == 0));
                    // rotate the temp list on the Y axis counter clockwise
                    RotateYAxis(lstTemp, false);
                    break;
                case FaceRotateNotation.Left:
                    // all back cubes should have x = 0
                    lstTemp.AddRange(clsRubicsCube.Cubies.FindAll(cb => cb.Location.X == 0));
                    // rotate the temp list on the X axis clockwise
                    RotateXAxis(lstTemp, true);
                    break;
                case FaceRotateNotation.Left_Inverted:
                    // all back cubes should have x = 0
                    lstTemp.AddRange(clsRubicsCube.Cubies.FindAll(cb => cb.Location.X == 0));
                    // rotate the temp list on the X axis counter clockwise
                    RotateXAxis(lstTemp, false);
                    break;
                case FaceRotateNotation.Right:
                    // all back cubes should have x = 2
                    lstTemp.AddRange(clsRubicsCube.Cubies.FindAll(cb => cb.Location.X == 2));
                    // rotate the temp list on the X axis counter clockwise
                    RotateXAxis(lstTemp, false);
                    break;
                case FaceRotateNotation.Right_Inverted:
                    // all back cubes should have x = 2
                    lstTemp.AddRange(clsRubicsCube.Cubies.FindAll(cb => cb.Location.X == 2));
                    // rotate the temp list on the X axis clockwise
                    RotateXAxis(lstTemp, true);
                    break;
                case FaceRotateNotation.Up:
                    // all back cubes should have z = 2
                    lstTemp.AddRange(clsRubicsCube.Cubies.FindAll(cb => cb.Location.Z == 2));
                    // rotate the temp list on the z axis clockwise
                    RotateZAxis(lstTemp, true);
                    break;
                case FaceRotateNotation.Up_Inverted:
                    // all back cubes should have z = 2
                    lstTemp.AddRange(clsRubicsCube.Cubies.FindAll(cb => cb.Location.Z == 2));
                    // rotate the temp list on the z axis counter clockwise
                    RotateZAxis(lstTemp, false);
                    break;
            }
        }

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

    public class RotateFaceCommand : ICommand
    {
        #region Private Members
        private RubicsCube _clsRubicsCube;
        private FaceRotateNotation _flgRotateDir;
        private FaceRotateNotation _flgReverseDir;
        #endregion Private Members

        #region Constructor
        public RotateFaceCommand(
            RubicsCube clsRubicsCube,
            FaceRotateNotation flgRotateDir, 
            FaceRotateNotation flgReverseDir)
        {
            _clsRubicsCube = clsRubicsCube;
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
        public void LoadRubicsCube(RubicsCube clsRubicsCube)
        {
            if (clsRubicsCube != null)
            {
                _clsRubicsCube = clsRubicsCube;
            }
        }

        public void Execute()
        {
            RCubeManager.RotateFace(_clsRubicsCube, _flgRotateDir);
        }

        public void UnExecute()
        {
            RCubeManager.RotateFace(_clsRubicsCube, _flgReverseDir);
        }

        public override string ToString()
        {
            return "Rotate Cube " + _flgRotateDir.ToString();
        }
        #endregion Public Methods
    }

    public class ResetRubicsCubeCommand : ICommand
    {
        #region Private Members
        private RubicsCube _clsRubicsCube;
        #endregion Private Members

        #region Constructor
        public ResetRubicsCubeCommand(RubicsCube clsRubicsCube)
        {
            _clsRubicsCube = clsRubicsCube;
        }
        #endregion Constructor

        #region Properties
        public bool IsReversable
        {
            get { return false; }
        }
        #endregion Properties

        #region Public Methods
        public void LoadRubicsCube(RubicsCube clsRubicsCube)
        {
            _clsRubicsCube = clsRubicsCube;
        }

        public void Execute()
        {
            RCubeManager.Reset(_clsRubicsCube);
        }

        public void UnExecute()
        {
            //throw new NotImplementedException();
        }
        #endregion Public Methods
    }
}
