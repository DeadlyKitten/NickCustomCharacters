using UnityEditor;
using UnityEngine;

namespace Nick
{
	[ExecuteAlways]
	public class GameAgent : MonoBehaviour
    {
		[SerializeField]
		public string gameUniqueIdentifier;

		[SerializeField]
		private string[] agentTags;

		[SerializeField]
		private int agentSorting;

		[SerializeField]
		private bool isPlayerCharacter;

		[SerializeField]
		private bool isItem;

		public GameAgentBankBank spawnAgents = new GameAgentBankBank();

		[SerializeField]
		private GameAgentStateMachine statemachine;

		[SerializeField]
		private GameAgentBones bones;

		[SerializeField]
		private GameAgentAnimation anim;

		[SerializeField]
		private GameAgentData data;

		[SerializeField]
		private GameAgentControls controls;

		[SerializeField]
		private GameAgentStandardInput standardinput;

		[SerializeField]
		private GameAgentCustomCalls customcalls;

		[SerializeField]
		private GameAgentJumps jumps;

		[SerializeField]
		private GameAgentMovement movement;

		[SerializeField]
		private GameAgentCPU cpu;

		[SerializeField]
		private GameAgentAttack attack;

		[SerializeField]
		private GameAgentHurtset hurtset;

		[SerializeField]
		private GameAgentCombat combat;

		[SerializeField]
		private GameAgentGrabs grabs;

		[SerializeField]
		private GameAgentColors colors;

		[SerializeField]
		private GameAgentFX fx;

		[SerializeField]
		private GameAgentSFX sfx;

		[SerializeField]
		private GameAgentCameraInfo caminfo;

		[SerializeField]
		private GameAgentSkins skins;

		public UpdateMe[] miscUpdate;

		[SerializeField]
		private GameAgentReady[] loadReady;

		[ExecuteAlways]
		private void Awake()
		{
			var tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);

			var layers = tagManager.FindProperty("layers");

			var characterLayer = layers.GetArrayElementAtIndex(12);

			if (characterLayer.stringValue != "character")
			{
				characterLayer.stringValue = "character";
				tagManager.ApplyModifiedProperties();
			}
		}
	}
}
