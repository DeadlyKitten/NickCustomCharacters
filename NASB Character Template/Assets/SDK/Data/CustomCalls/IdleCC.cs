using System;
using System.Collections.Generic;
using System.Text;

namespace Nick
{
    class IdleCC : CustomCallMB
    {
        public string animTimerId;

        public IdleSet[] normalIdles;

        public IdleSet[] funIdles;

        [Serializable]
        public struct IdleSet
        {
            public string anim;

            public string sfxtl;

            public float lengthFrames;
        }
    }
}
