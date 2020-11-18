using HSDRaw.Common;
using HSDRaw.Common.Animation;
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
        public HSD_JOBJ Message { get => _s.GetReference<HSD_JOBJ>(0x18); set => _s.SetReference(0x18, value); }
        public HSD_Camera HUDCObjDesc { get => _s.GetReference<HSD_Camera>(0x1C); set => _s.SetReference(0x1C, value); }
        public HSD_JOBJ tip_joint { get => _s.GetReference<HSD_JOBJ>(0x20); set => _s.SetReference(0x20, value); }
        public HSDNullPointerArrayAccessor<HSD_AnimJoint> tip_jointanim { get => _s.GetReference<HSDNullPointerArrayAccessor<HSD_AnimJoint>>(0x24); set => _s.SetReference(0x24, value); }

    }
    public class SBM_TM_LabData : HSDAccessor
    {
        public HSD_JOBJ lstick_joint { get => _s.GetReference<HSD_JOBJ>(0x00); set => _s.SetReference(0x00, value); }
        public HSD_JOBJ rstick_joint { get => _s.GetReference<HSD_JOBJ>(0x04); set => _s.SetReference(0x04, value); }
        public HSDAccessor icon_data { get => _s.GetReference<HSDAccessor>(0x08); set => _s.SetReference(0x08, value); }
        public HSDAccessor banner_data { get => _s.GetReference<HSDAccessor>(0x0C); set => _s.SetReference(0x0C, value); }
        public HSD_JOBJ controller_joint { get => _s.GetReference<HSD_JOBJ>(0x10); set => _s.SetReference(0x10, value); }
        public HSD_JOBJ export_menu { get => _s.GetReference<HSD_JOBJ>(0x14); set => _s.SetReference(0x14, value); }
        public HSD_JOBJ export_popup { get => _s.GetReference<HSD_JOBJ>(0x18); set => _s.SetReference(0x18, value); }

    }

    public class SBM_TM_ImportData : HSDAccessor
    {
        public HSD_JOBJ button_joint { get => _s.GetReference<HSD_JOBJ>(0x00); set => _s.SetReference(0x00, value); }
        public HSD_JOBJ menu_joint { get => _s.GetReference<HSD_JOBJ>(0x04); set => _s.SetReference(0x04, value); }

    }

    public class SBM_TM_LCancelData : HSDAccessor
    {
        public HSD_JOBJ hud_joint { get => _s.GetReference<HSD_JOBJ>(0x00); set => _s.SetReference(0x00, value); }
        public HSDNullPointerArrayAccessor<HSD_MatAnimJoint> hud_matanimjoint { get => _s.GetReference<HSDNullPointerArrayAccessor<HSD_MatAnimJoint>>(0x04); set => _s.SetReference(0x04, value); }
    }

}
