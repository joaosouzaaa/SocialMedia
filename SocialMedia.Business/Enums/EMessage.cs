using System.ComponentModel;

namespace SocialMedia.Business.Enums
{
    public enum EMessage
    {
        [Description("{0} needs to be filled.")]
        Required,

        [Description("{0} needs to be between {1} chars.")]
        WrongSize,

        [Description("{0} is in the wrong format.")]
        WrongFormat,

        [Description("{0} not found.")]
        NotFound,

        [Description("{0} already exists.")]
        Exists
    }
}
