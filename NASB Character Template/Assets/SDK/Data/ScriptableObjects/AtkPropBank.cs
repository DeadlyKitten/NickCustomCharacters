using System;
using UnityEngine;

namespace Nick
{
    [CreateAssetMenu(fileName = "AtkPropBank", menuName = "ScriptableObjects/AtkPropBank", order = 1)]
    public class AtkPropBank : ScriptableObject
    {
		[Serializable]
		public class IdProp
		{
			public string id;

			public AtkProp prop;
		}

		[SerializeField]
		public IdProp[] props;
	}
}