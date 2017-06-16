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
        }
        #endregion Constructor

        #region Properties
        public List<Cubie> Cubies { get { return _lstCubies; } }
        #endregion Properties
    }
}
