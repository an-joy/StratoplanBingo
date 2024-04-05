using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;

namespace StratoplanBingo.Models
{
    public class BingoCard : ObservableObject
    {
        public string Column { get; set; }
        public int Number { get; set; }
        public string Value { get; set;  }

        bool selected;
        public bool Selected { get => selected; set =>  SetProperty(ref selected, value); }

        public int RowPosition { get; set; }

        public void SetSelected()
        {
            Selected = true;
        }
    }
}
