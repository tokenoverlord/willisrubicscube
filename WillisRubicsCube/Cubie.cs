using System.Diagnostics;
using System.Windows.Media.Media3D;

namespace WillisRubicsCube
{
    public class Cubie
    {
        #region Constructor
        public Cubie()
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
            Cubie clsTemp = obj as Cubie;

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

        public override int GetHashCode()
        {
            return base.GetHashCode();
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
}
