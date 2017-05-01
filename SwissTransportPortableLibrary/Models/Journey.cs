using System;

namespace SwissTransportPortableLibrary.Models
{
    public class Journey
    {
		internal String Name { get; set; }
		internal String To { get; set; }

		internal Journey(String name, String to)
		{
			Name = name;
			To = to;
		}
    }
}
