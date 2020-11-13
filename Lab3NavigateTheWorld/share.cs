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
    /// Share Parent Class
    /// </summary>
    class share
    {
        // Data Members
        protected string buyerName;
        protected string buyDate;
        protected int numShares;
        protected string shareType;

        // GET & SET Methods
        
        /// <summary>
        /// Buyer Name GET & SET
        /// </summary>
        public string BuyerName
        {
            get { return this.buyerName; }
            set { this.buyerName = value; }
        }

        /// <summary>
        /// GET & SET methods for Purchased Date
        /// </summary>
        public string BuyDate
        {
            get { return this.buyDate; }
            set { this.buyDate = value; }
        }

        /// <summary>
        /// GET & SET methods for Number of Shares
        /// </summary>
        public int NumShares
        {
            get { return this.numShares; }
            set { this.numShares = value; }
        }
        
        /// <summary>
        /// GET & SET methods for Share Type
        /// </summary>
        public string ShareType
        {
            get { return this.shareType; }
            set { this.shareType = value; }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="date"></param>
        /// <param name="numOfShares"></param>
        /// <param name="shareType"></param>
        public share(string name, string date, int numOfShares, string shareType)
        {
            this.buyerName = name;
            this.buyDate = date;
            this.numShares = numOfShares;
            this.shareType = shareType;
        }
    }
}
