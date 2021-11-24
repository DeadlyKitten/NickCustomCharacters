using System;
using UnityEngine;

namespace Nick
{
    class GameAgentStandardInput : AttachedGameAgent
    {
        [Serializable]
        public class Config
        {
            public bool checkTriggers = true;
        }

        [Serializable]
        public class StandardInputTrigger
        {
            public class Config
            {
                public enum CheckMoves
                {
                    Special = 0,
                    SpecialMid = 1,
                    SpecialUp = 2,
                    SpecialDown = 3,
                    Attack = 4,
                    AttackMid = 5,
                    AttackUp = 6,
                    AttackDown = 7,
                    Strong = 8,
                    StrongMid = 9,
                    StrongUp = 10,
                    StrongDown = 11,
                    AirAtk = 12,
                    AirAtkMid = 13,
                    AirAtkUp = 14,
                    AirAtkDown = 0xF,
                    AirStr = 0x10,
                    AirStrMid = 17,
                    AirStrUp = 18,
                    AirStrDown = 19,
                    Jump = 20,
                    AirJump = 21,
                    Block = 22,
                    AirDash = 23,
                    Grab = 24,
                    AirGrab = 25,
                    NONE = 10000
                }

                public const int _enumLength = 26;

                public const int CFGBYTES = 4;

                public byte[] dontcheckbytes = new byte[4];

                private const byte AirStrMask = 15;

                private bool show;

            }

            [SerializeField]
            private string SpecialMid;

            [SerializeField]
            private string SpecialUp;

            [SerializeField]
            private string SpecialDown;

            [SerializeField]
            private string AttackMid;

            [SerializeField]
            private string AttackUp;

            [SerializeField]
            private string AttackDown;

            [SerializeField]
            private string StrongMid;

            [SerializeField]
            private string StrongUp;

            [SerializeField]
            private string StrongDown;

            [SerializeField]
            private string AirAtkMid;

            [SerializeField]
            private string AirAtkUp;

            [SerializeField]
            private string AirAtkDown;

            [SerializeField]
            private string AirStrMid;

            [SerializeField]
            private string AirStrUp;

            [SerializeField]
            private string AirStrDown;

            [SerializeField]
            private string Jump;

            [SerializeField]
            private string AirJump;

            [SerializeField]
            private float coyoteFrames;

            [SerializeField]
            private string Block;

            [SerializeField]
            private string AirDash;

            [SerializeField]
            private string Grab;

            [SerializeField]
            private string AirGrab;
        }

        public StandardInputTrigger standardInputTrigger;

        [SerializeField]
        private Config config;
    }
}