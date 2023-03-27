﻿//-----------------------------------------------------------------------
// <copyright file="ErrorListResult.cs" company="">
//     Copyright . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TaxiApp.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TaxiApp.Common;

    /// <summary>
    ///  Class ErrorsResult
    /// </summary>
    public class ErrorListResult : AbstractResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorListResult"/> class.
        /// </summary>
        public ErrorListResult()
        {
            this.Error = new Errors();
        }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public Errors Error { get; set; }
    }

    /// <summary>
    /// Class Error
    /// </summary>
    public class Errors
    {
        ///// <summary>
        ///// Gets or sets the code.
        ///// </summary>
        ///// <value>
        ///// The Code.
        ///// </value>
        //// public string Code { get; set; }

        /// <summary>
        /// Gets or sets the Message.
        /// </summary>
        /// <value>
        /// The Message.
        /// </value>
        public IEnumerable<string> Messages { get; set; }
    }
}
