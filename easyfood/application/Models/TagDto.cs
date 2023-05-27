namespace Easyfood.Application.Models
{
    public class TagDto
    {
        public Guid Value { get; set; }

        public string Label { get; set; }

        public TagDto(Guid value, string name)
        {
            Value = value;
            Label = name;
        }
    }
}