using System;

namespace Application.Models.SampleModels
{
    public class Sample
    {
        public Guid Id { get; set; }
        public int numbering { get; set; }
        public string lettering { get; set; }

        public Sample(int numbering)
        {
            Random random = new Random();
            Id = Guid.NewGuid();
            this.numbering = numbering;
            this.lettering = random.Next().ToString();
        }
    }
}
