using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tekever_Challenge.Models
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }    
        public string JwtId { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime AddedtAt { get; set; }
        public DateTime ExpireAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public User UserToken { get; set; }

    }
}
