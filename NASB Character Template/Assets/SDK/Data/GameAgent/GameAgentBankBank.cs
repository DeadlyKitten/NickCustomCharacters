using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nick
{
    [Serializable]
    public class GameAgentBankBank
    {
		[Serializable]
		public class IdBank
		{
			public string id;

			public GameAgentBank bank;
		}

		public IdBank[] banks;
	}
}
