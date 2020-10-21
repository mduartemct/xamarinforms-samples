using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileBackend.DataObjects
{
    public class CorpUser : EntityData
    {

        #region Relacionamento

        public string AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }

        #endregion

        public string Name { get; set; }

        public string Email { get; set; }

        public string CorpName { get; set; }

        public bool InUse { get; set; }



    }
}