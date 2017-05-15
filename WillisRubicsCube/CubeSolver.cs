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
        //private List<Cubium> _lstReference;
        private Dictionary<string, Cubium> _lstReference
            = new Dictionary<string, Cubium>();

        private Dictionary<string, ICommand> _lstMoves
            = new Dictionary<string, ICommand>();
        #endregion Private Members

        #region Constructor
        public CubeSolver()
        {
            // create the reference list
            List<Cubium> lstTemp = RCubeManager.GetNewRCube();
            foreach (Cubium cubie in lstTemp)
            {
                _lstReference.Add(cubie.ToString(), cubie);
            }
        }
        #endregion Constructor

        #region Public Methods
        public int GetPercentSolved(List<Cubium> lstTarget)
        {
            // calculate the percent solved
            int numMatch = 0;
            foreach (Cubium cubie in lstTarget)
            {
                if (_lstReference.ContainsKey(cubie.ToString()))
                {
                    if (_lstReference[cubie.ToString()].Equals(cubie))
                    {
                        numMatch++;
                    }
                }
            }

            // get the percentage
            // int numPercent = ((int)(numMatch / lstTarget.Count) * 100);

            return ((int)(numMatch * 100 ) / lstTarget.Count);
        }
        #endregion Public Methods

        #region Class Helpers
        #endregion Class Helpers
    }
}
