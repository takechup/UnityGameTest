using UnityEngine;
using System;

namespace Take.Save
{
	[Serializable]
	public class Pikachu {

		public void Initialize()
		{
			count = 0;
			name = "PikaChu";
		}

		/// --------------------------------
		public int count;
		public string name;
	}
}
