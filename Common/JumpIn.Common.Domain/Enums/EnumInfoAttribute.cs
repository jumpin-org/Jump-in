namespace JumpIn.Common.Domain.Enums
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumInfoAttribute : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public EnumInfoAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
