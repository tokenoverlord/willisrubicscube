using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillisRubicsCube
{
    public class CubeSolver
    {
        #region Private Members
        // reference rubics cube
        private RCubeManager _clsRCubeManager
            = new RCubeManager();
        #endregion Private Members

        #region Constructor
        public CubeSolver()
        {
            //List<Cubie> lstTemp = RCubeManager.GetNewRCube();

            // use a hash since it will be faster O(n) to check if 
            // they are in the correct position
            //foreach (Cubie cubie in lstTemp)
            //{
            //    // check if cube is already added
            //    if (!_lstReference.ContainsKey(cubie.ToString()))
            //    {
            //        // the cube is not in the hash add it.
            //        _lstReference.Add(cubie.ToString(), cubie);
            //    }
            //}
        }
        #endregion Constructor

        #region Public Methods


        //public int GetPercentSolved(List<Cubie> lstTarget)
        //{
        //    // calculate the percent solved
        //    int numMatch = 0;
        //    foreach (Cubie cubie in lstTarget)
        //    {
        //        // go though all cubes in the reference and check if the cube is in the
        //        // right position
        //        if (_lstReference.ContainsKey(cubie.ToString()))
        //        {
        //            // get the ref cube
        //            Cubie refCube = _lstReference[cubie.ToString()];

        //            // compare the ref cube to the target cube
        //            if (refCube.Equals(cubie))
        //            {
        //                // the cube is in the right position
        //                // keep track of how many are in the right position.
        //                numMatch++;
        //            }
        //        }
        //    }

        //    // get the percentage
        //    return ((int)(numMatch * 100 ) / lstTarget.Count);
        //}
        #endregion Public Methods
    }
}
