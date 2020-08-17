using HSDRaw.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HSDRaw.Melee
{
    public class SBM_EventMenu : HSDAccessor
    {
        public HSD_JOBJ MainMenu { get => _s.GetReference<HSD_JOBJ>(0x00); set => _s.SetReference(0x00, value); }
        public HSD_JOBJ SubMenu { get => _s.GetReference<HSD_JOBJ>(0x04); set => _s.SetReference(0x04, value); }
        public HSD_JOBJ ScrollBar { get => _s.GetReference<HSD_JOBJ>(0x08); set => _s.SetReference(0x08, value); }
        public HSD_JOBJ CheckBox { get => _s.GetReference<HSD_JOBJ>(0x0C); set => _s.SetReference(0x0C, value); }
        public HSD_JOBJ Arrow { get => _s.GetReference<HSD_JOBJ>(0x10); set => _s.SetReference(0x10, value); }
        public HSD_JOBJ Playback { get => _s.GetReference<HSD_JOBJ>(0x14); set => _s.SetReference(0x14, value); }
    }
}
