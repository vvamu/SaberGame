using Assets.Scripts;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	public class Aim : ActionTask<Enemy>{
        [RequiredField]
        public BBParameter<GameObject> target;

		protected override void OnExecute(){
            var direction = target.value.transform.position - agent.transform.position;
            agent.Weapon.Aim.SetShootPositionAndDirection(agent.transform.position, direction);
            EndAction(true);
		}
	}
}