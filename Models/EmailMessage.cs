using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;


namespace HelpDeskWebSite.Models
{
    public class EmailMessage
    {
        [Key]
        public int Id { get; set; }
        [ModelBinder(Name = "recipient")]
        public string Recipient { get; set; }

        [ModelBinder(Name = "sender")]
        public string Sender { get; set; }

        [ModelBinder(Name = "from")]
        public string From { get; set; }

        [ModelBinder(Name = "subject")]
        public string Subject { get; set; }

        [ModelBinder(Name ="body-plain")]
        public string BodyPlain { get; set; }

        [ModelBinder(Name = "stripped-text")]
        public string StrippedText { get; set; }

        [ModelBinder(Name ="stripped-signature")]
        public string StrippedSignature { get; set; }

        [ModelBinder(Name = "body-html")]
        public string BodyHtml { get; set; }

        [ModelBinder(Name = "stripped-html")]
        public string StrippedHtml { get; set; }

        [ModelBinder(Name = "attachment-count")]
        public int AttachmentCount { get; set; }

        [ModelBinder(Name = "timestamp")]
        public int Timestamp { get; set; }

        [ModelBinder(Name = "token")]
        public string Token { get; set; }

        [ModelBinder(Name = "signature")]
        public string Signature { get; set; }

        [ModelBinder(Name = "message-headers")]
        public string MessageHeaders { get; set; }

        [ModelBinder(Name = "content-id-map")]
        public string ContentIdMap { get; set; }

    }

}
