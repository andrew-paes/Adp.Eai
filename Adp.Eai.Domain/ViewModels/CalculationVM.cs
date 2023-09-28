using Newtonsoft.Json;

namespace Adp.Eai.Domain.ViewModels
{
    public class CalculationVM
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("result")]
        public decimal Result { get; set; }
    }
}