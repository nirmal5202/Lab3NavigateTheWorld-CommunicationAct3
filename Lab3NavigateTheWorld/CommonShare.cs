/* NAME: Nirmal Patel (100767993)
 * Lab 3 | Communication Activity 3
 * Date: Nov 13 2020
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Lab3NavigateTheWorld
{
    /// <summary>
    /// Child class called CommonShare base of share class
    /// </summary>
    class CommonShare : share
    {
        // Constant Declarations
        const int commonPrice = 42;
        const int votingPower = 1;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="date"></param>
        /// <param name="numOfShares"></param>
        /// <param name="shareType"></param>
        /// <param name="votingPower"></param>
        public CommonShare(string name, string date, int numOfShares, string shareType) :
            base(name, date, numOfShares, shareType)
        {
            this.buyerName = base.buyerName;
            this.buyDate = base.buyDate;
            this.numShares = base.numShares;
            this.shareType = base.shareType;
        }
        /// <summary>
        /// GET Methods for Voting Power
        /// </summary>
        public int VotingPower
        {
            get { return votingPower; }
        }

        /// <summary>
        /// GET Methods for Common Share
        /// </summary>
        public int CommonPrice
        {
            get { return commonPrice; }
        }
    }
}
