namespace Adp.Eai.Domain.Models
{
    public class Calculation : GenericModel
    {
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
        /// <summary>
        /// 
        /// </summary>
        public decimal Result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object? PostResult { get; set; }
    }
}
