using System;
using UnityEngine;

namespace Nick
{
    class GameAgentBones : AttachedGameAgent
    {
        [SerializeField]
        private Config config;

        public Transform posBone;
        public Transform rotateBone;
        public Transform lookBone;
        public Transform centerBone;
        public Transform rootBone;
        public Vector3 rootBasePosition;
        public Transform syncBone;

        [SerializeField]
        private Shortcut[] bones;

        [SerializeField]
        private AnimObjectActiveAxis[] animobjectactiveaxis;

        [SerializeField]
        private MutexObjectActiveAxis[] mutexobjectanimaxis;

        [SerializeField]
        private ActiveObjectMapping[] mapObjectActive;

        [SerializeField]
        private MirrorHandler mirror = new MirrorHandler();

        [SerializeField]
        private bool allowRollbackPositionLerp = true;

        [Serializable]
        public class Config
        {
            public float rotationAngle;

            public float lookAngle;

            public float tiltAngle;

            public bool mirrorByDirection;

            public Vector2 offset;
        }

        [Serializable]
        public class Shortcut
        {
            public string id;

            public Transform bone;

            public bool defaultState = true;
        }

        [Serializable]
        public struct AnimObjectActiveAxis
        {
            public Transform sample;

            public GameObject objDefault;

            public IndexToObject[] toggleObjects;

            [Serializable]
            public struct IndexToObject
            {
                public IndexSample sample;

                public GameObject obj;
            }

            public enum IndexSample
            {
                posXpositive,
                posYpositive,
                posZpositive,
                rotXpositive,
                rotYpositive,
                rotZpositive,
                scaleX2,
                scaleY2,
                scaleZ2,
                posXnegative,
                posYnegative,
                posZnegative,
                rotXnegative,
                rotYnegative,
                rotZnegative,
                scaleX0,
                scaleY0,
                scaleZ0,
                clampedPosXNegative
            }
        }

        [Serializable]
        public struct MutexObjectActiveAxis
        {
            [Serializable]
            public struct IndexToObject
            {
                public AnimObjectActiveAxis.IndexSample sample;

                public Transform sampleTransform;

                public GameObject obj;
            }

            public IndexToObject[] mutuallyExclusive;
        }

        [Serializable]
        public struct MirroredObjectPair
        {
            public GameObject right;

            public GameObject left;
        }

        [Serializable]
        public struct MirroredTextureIDs
        {
            public string right;

            public string left;
        }

        [Serializable]
        public class MirrorHandler
        {
            public MirroredObjectPair[] mirrorObjs;

            public MirroredTextureIDs[] mirrorSkinTextures;

            private bool lastDir;
        }

        [Serializable]
        public struct ActiveObjectMapping
        {
            public GameObject checkActive;

            public GameObject setActive;
        }
    }
}
