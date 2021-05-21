using HSDRaw.Common;
using HSDRaw.Common.Animation;
using HSDRaw.Melee.Cmd;
using System;
using System.Collections.Generic;
using System.Text;

namespace HSDRaw.Melee
{
    public class SBM_Slp_Chat : HSDAccessor
    {
        public HSD_JOBJDesc chat_select { get => _s.GetReference<HSD_JOBJDesc>(0x00); set => _s.SetReference(0x00, value); }
        public HSD_JOBJDesc chat_msg { get => _s.GetReference<HSD_JOBJDesc>(0x04); set => _s.SetReference(0x04, value); }
        public HSD_MatAnimJoint vs_mode { get => _s.GetReference<HSD_MatAnimJoint>(0x08); set => _s.SetReference(0x08, value); }
        public HSD_JOBJ name_entry_hud { get => _s.GetReference<HSD_JOBJ>(0x0c); set => _s.SetReference(0x0c, value); }
    }
}
