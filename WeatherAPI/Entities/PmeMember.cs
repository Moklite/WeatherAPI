using System.ComponentModel.DataAnnotations;

namespace WeatherAPI.Entities
{
    public class PmeMember
    {
        [Key]
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string Stack { get; set; }
    }
}
