using Adp.Eai.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Eai.Domain.Models
{
    public class Calculation
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? Operation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Left { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Right { get; set; }
    }
}
