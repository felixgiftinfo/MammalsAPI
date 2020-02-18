using System;

namespace AnimalService
{
    public class AnimalModel: NewAnimalModel
    {
        public Guid Id { get; set; }

        public AnimalModel(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }
    }

    public class NewAnimalModel
    {
        public string Name { get; set; }

    }
}
