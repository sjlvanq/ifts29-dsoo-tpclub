using System;
using System.Collections.Generic;
using System.Text;

namespace Club1.Common
{
    public class FiltroChangedEventArgs : EventArgs
    {
        public string Field { get; }
        public string Text { get; }

        public FiltroChangedEventArgs(string field, string text)
        {
            Field = field;
            Text = text;
        }
    }
}
