using System;

namespace HumanService
{
    public class HumanModel: NewHumanModel
    {
        public Guid Id { get; set; }

        public HumanModel(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }
    }

    public class NewHumanModel
    {
        public string Name { get; set; }

    }
}
