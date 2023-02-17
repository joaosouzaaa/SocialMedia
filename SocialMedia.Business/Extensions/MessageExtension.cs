using SocialMedia.Business.Enums;
using System.ComponentModel;

namespace SocialMedia.Business.Extensions
{
    public static class MessageExtension
    {
        public static string Description(this EMessage message)
        {
            var type = message.GetType();
            var memberInfo = type.GetMember(message.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}
