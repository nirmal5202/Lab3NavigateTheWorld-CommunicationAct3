/* NAME: Nirmal Patel (100767993)
 * Lab 3 | Communication Activity 3
 * Date: Nov 13 2020
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3NavigateTheWorld
{
    /// <summary>
    /// Child class called PreferredShare base of share class
    /// </summary>
    class PreferredShare : share
    {
        // Constant Declarations
        const int preferredPrice = 100;
        const int votingPower = 10;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="date"></param>
        /// <param name="numOfShares"></param>
        /// <param name="shareType"></param>
        public PreferredShare(string name, string date, int numOfShares, string shareType) :
            base(name, date, numOfShares, shareType)
        {
            this.buyerName = base.buyerName;
            this.buyDate = base.buyDate;
            this.numShares = base.numShares;
            this.shareType = base.shareType;
        }

        /// <summary>
        /// GET Methods for PreferredPrice
        /// </summary>
        public int PreferredPrice
        {
            get { return preferredPrice; }

        }

        /// <summary>
        /// GET Methods for Voting Power
        /// </summary>
        public int VotingPower
        {
            get { return votingPower; }

        }
    }
}
