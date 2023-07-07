using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	public class RotateInOneAxes : ActionTask<Transform>{

        [RequiredField]
        public BBParameter<GameObject> target;
        public BBParameter<float> speed = 2;
        [SliderField(1, 180)]
        public BBParameter<float> angleDifference = 5;
        public bool waitActionFinish;

        protected override void OnUpdate()
        {
            if (Vector3.Angle(new Vector3(target.value.transform.position.x, agent.position.y, target.value.transform.position.z) - agent.position, agent.forward) <= angleDifference.value)
            {
                EndAction();
                return;
            }

            var dir = new Vector3(target.value.transform.position.x, agent.position.y, target.value.transform.position.z) - agent.position;
            agent.rotation = Quaternion.LookRotation(Vector3.RotateTowards(agent.forward, dir, speed.value * Time.deltaTime, 0), Vector3.up);
            if (!waitActionFinish)
            {
                EndAction();
            }
        }
    }
}