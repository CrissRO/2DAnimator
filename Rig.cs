using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimationInterpolation
{
    class Rig
    {

        public List<Joint> joints { get; set; }
        public List<Bone> bones { get; set; }
        public List<Tuple<int, int>> boneConnections { get; set; }

        public Vector2 position;

        public Rig(Vector2 position)
        {
            joints = new List<Joint>();
            bones = new List<Bone>();
            boneConnections = new List<Tuple<int, int>>();
            this.position = position;
        }

        public void AddJoint(Joint joint)
        {
            joints.Add(joint);
        }

        public void SetJoint(int index, Vector2 position)
        {
            joints[index].position = position;
            for (int i = 0; i < bones.Count; i++)
            {
                bones[i].start = joints[boneConnections[i].Item1].position;
                bones[i].end = joints[boneConnections[i].Item2].position;
            }
        }

        public void AnimateJointLinear(int jointIndex,Rig startState,Rig endState,int frames,int currentFrame)
        {
            SetJoint(jointIndex, new Vector2(Interpolations.Linear(startState.joints[1].position.X, endState.joints[1].position.X, frames, (int)currentFrame),
                                         Interpolations.Linear(startState.joints[1].position.Y, endState.joints[1].position.Y, frames, (int)currentFrame)));

        }

        public void AddBone(int joint1,int joint2)
        {
            if(joint1 < joints.Count && joint2 < joints.Count)
            {
                boneConnections.Add(new Tuple<int, int>(joint1, joint2));
                bones.Add(new Bone(joints[joint1].position, joints[joint2].position));
            }
                
        }
        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < joints.Count; i++)
                Primitives.DrawEllipse(sb, Vector2.Add(joints[i].position, position), Color.Green);

            for (int i = 0; i < bones.Count; i++)
                Primitives.DrawLine(sb, Vector2.Add(bones[i].start, position), Vector2.Add(bones[i].end, position), Color.Red, 6);
        }
        
    }
}
