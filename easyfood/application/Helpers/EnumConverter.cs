using Easyfood.Application.Models;
using System.ComponentModel;

namespace Easyfood.Application.Helpers
{
    public static class EnumConverter<TEnum> where TEnum : Enum
    {
        public static List<EnumDto> ConvertToList()
        {
            List<EnumDto> enumList = new();

            foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
            {
                string description = GetEnumDescription(value);
                enumList.Add(new EnumDto(Convert.ToInt32(value), description));
            }

            return enumList;
        }

        private static string GetEnumDescription(TEnum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo!, typeof(DescriptionAttribute))!;
            return attribute != null ? attribute.Description : value.ToString();
        }
    }
}