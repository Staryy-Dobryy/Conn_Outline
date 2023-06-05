using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.BuisnessLogic.Models
{
    public class GetMessageModel
    {
        [Required]
        [MaxLength(2048, ErrorMessage = "Слишком длинное сообщение")]
        public string MessageText { get; set; }
        [Required]
        public string ChatId  { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
