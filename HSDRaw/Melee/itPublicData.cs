using HSDRaw.Melee.Pl;

namespace HSDRaw.Melee
{
    public class itPublicData : HSDAccessor
    {
        public SBM_ArticlePointer Items { get => _s.GetReference<SBM_ArticlePointer>(0x04); set => _s.SetReference(0x04, value); }
        public SBM_ArticlePointer Zako { get => _s.GetReference<SBM_ArticlePointer>(0x08); set => _s.SetReference(0x08, value); }

        public SBM_ArticlePointer Pokemon { get => _s.GetReference<SBM_ArticlePointer>(0x0C); set => _s.SetReference(0x0C, value); }
    }
}
