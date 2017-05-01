using System;

namespace SwissTransportPortableLibrary.Models
{
    public class Location
    {
		public String Id { get; private set; }

		public string Name { get; private set; }

		public Location(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
