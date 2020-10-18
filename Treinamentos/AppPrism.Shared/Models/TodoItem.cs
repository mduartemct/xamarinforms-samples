using System;
using System.Collections.Generic;
using System.Text;

namespace AppPrism.Shared.Models
{
    public class TodoItem : TableData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}
