using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace WillisRubicsCube
{
    public partial class CubieControl : UserControl
    {
        #region Private Members
        private Point3D _clsLocation = new Point3D();
        private CubeSurface _flgSurface = CubeSurface.Back;
        #endregion Private Members

        #region Constructor
        public CubieControl()
        {
            InitializeComponent();
        }
        #endregion Constructor

        #region Properties
        public Point3D CubeLocation
        {
            get { return _clsLocation; }
            set { _clsLocation = value; }
        }

        public CubeSurface Surface
        {
            get { return _flgSurface; }
            set { _flgSurface = value; }
        }
        #endregion Properties

        #region Public Methods
        public void LoadCubie(List<Cubie> lstCubies)
        {
            // find the cubie at this location3d
            ChangeColor(lstCubies.Find(x => x.Location == this.CubeLocation));
        }

        public void ChangeColor(Cubie clsCubie)
        {
            if (clsCubie != null)
            {
                // get the color
                Color clsColor = Color.Black;

                // get the color for this surface
                switch (_flgSurface)
                {
                    case CubeSurface.Back:
                        clsColor = GetColor(clsCubie.Back);
                        break;
                    case CubeSurface.Down:
                        clsColor = GetColor(clsCubie.Down);
                        break;
                    case CubeSurface.Face:
                        clsColor = GetColor(clsCubie.Face);
                        break;
                    case CubeSurface.Left:
                        clsColor = GetColor(clsCubie.Left);
                        break;
                    case CubeSurface.Right:
                        clsColor = GetColor(clsCubie.Right);
                        break;
                    case CubeSurface.Up:
                        clsColor = GetColor(clsCubie.Up);
                        break;
                }

                ButtonCubie.BackColor = clsColor;
            }
        }
        #endregion Public Methods

        #region Private Methods
        private Color GetColor(CubeColor flgColor)
        {
            switch (flgColor)
            {
                case CubeColor.Blue:
                    return Color.Blue;
                case CubeColor.Green:
                    return Color.Green;
                case CubeColor.Orange:
                    return Color.Orange;
                case CubeColor.Red:
                    return Color.Red;
                case CubeColor.White:
                    return Color.White;
                case CubeColor.Yellow:
                    return Color.Yellow;
                default:
                    return Color.Black;
            }
        }
        #endregion Private Methods
    }
}
