using System;
using System.Collections.Generic;
using System.Text;

namespace AppPrism.Shared.Models
{
    public class CorpUser : TableData
    {
        #region Relacionamento

        public string AppUserId { get; set; }

        //[ForeignKey("AppUserId")]
        //public AppUser AppUser { get; set; }

        #endregion

        public string Name { get; set; }

        public string Email { get; set; }

        public string CorpName { get; set; }

        public bool InUse { get; set; }
    }
}
