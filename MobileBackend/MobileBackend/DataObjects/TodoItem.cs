using Microsoft.Azure.Mobile.Server;

namespace MobileBackend.DataObjects
{
    public class TodoItem : EntityData
    {
        /// <summary>
        /// Exclusive User Security Identifier generate for each App User absed in your authentication.
        /// </summary>
        public string UserSId { get; set; }

        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}