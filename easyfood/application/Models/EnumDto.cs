namespace Easyfood.Application.Models
{
    public class EnumDto
    {
        public int Value { get; set; }

        public string Label { get; set; }

        public EnumDto(int value, string description)
        {
            Value = value;
            Label = description;
        }
    }
}