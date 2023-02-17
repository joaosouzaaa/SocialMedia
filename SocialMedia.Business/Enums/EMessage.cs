using System.ComponentModel;

namespace SocialMedia.Business.Enums
{
    public enum EMessage
    {
        [Description("{0} needs to be filled.")]
        Required,

        [Description("{0} needs to be between {1} chars.")]
        WrongSize
    }
}
