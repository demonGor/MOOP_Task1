using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson1_Hometask
{
    public class GameStateModel
    {
        public int LeftBound { get; set; }
        public int RightBound { get; set; }

        public int SpecifiedNumber { get; set; }

        public int DesiredNumber { get; set; }
        public List<GameStateModel> History { get; set; }
    }
}
