using Nautilus.Json;
using Nautilus.Options.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Extra_Decor_Rusty_Pack
{
    [Menu("Extra Decor - Rusty Pack")]
    public class Config : ConfigFile
    {
        [Toggle("Enable lifepods", Tooltip = "Enables: <color=#ffc600>Lifepod 2</color>, <color=#ffc600>Lifepod 3</color>, <color=#ffc600>Lifepod 4</color>, <color=#ffc600>Lifepod 6</color>, <color=#ffc600>Lifepod 7</color>, <color=#ffc600>Lifepod 12</color>, <color=#ffc600>Lifepod 13</color>, <color=#ffc600>Lifepod 17</color>, <color=#ffc600>Lifepod19</color>. <color=#ff0000>Requires a restart</color>")]
        public bool EnableLifepods = true;

        [Toggle("Enable debris", Tooltip = "Enables: <color=#ffc600>Exploded debris 6</color>, <color=#ffc600>Exploded debris 7</color>, <color=#ffc600>Exploded debris 16</color>, <color=#ffc600>Exploded debris 18</color>, <color=#ffc600>Exploded debris 20</color>. <color=#ff0000>Requires a restart</color>")]
        public bool EnableDebris = true;

        [Toggle("Enable degasi parts", Tooltip = "Enables: <color=#ffc600>Degasi foundation 1</color>, <color=#ffc600>Degasi foundation 2</color>, <color=#ffc600>Degasi foundation 3</color>, <color=#ffc600>Rusted spotlight</color>, <color=#ffc600>Rusted farming tray</color>, <color=#ffc600>Rusted farming pot 2</color>, <color=#ffc600>Rusted planter box</color>. <color=#ff0000>Requires a restart</color>")]
        public bool EnableDegasi = true;

        [Toggle("Enable fragments", Tooltip = "Enables <color=#ffc600>fragments</color>. <color=#ff0000>Requires a restart</color>")]
        public bool EnableFragments = true;

        [Toggle("Enable misc", Tooltip = "Enables: <color=#ffc600>Aurora doorframe medium/thin</color>, <color=#ffc600>Aurora sealed door medium/thin</color>, <color=#ffc600>Aurora blocked door medium/thin</color>, <color=#ffc600>Upgrades console</color>, <color=#ffc600>Upgrades console wide</color>, <color=#ffc600>Reinforce hull</color>. <color=#ff0000>Requires a restart</color>")]
        public bool EnableMisc = true;

    }
}
