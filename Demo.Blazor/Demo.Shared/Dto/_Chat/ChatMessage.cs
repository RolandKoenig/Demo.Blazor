using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.Shared.Dto
{
    public class ChatMessage
    {
        [Required]
        public string User
        {
            get;
            set;
        } = string.Empty;

        [Required]
        public string Message
        {
            get;
            set;
        } = string.Empty;

        public ChatMessage Clone()
        {
            return (ChatMessage)this.MemberwiseClone();
        }
    }
}
