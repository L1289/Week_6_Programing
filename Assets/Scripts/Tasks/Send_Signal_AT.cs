using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class Send_Signal_AT : ActionTask {

		public BBParameter<bool> signal;
		public int framedelay;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			signal.value = false;
			StartCoroutine(FrameDelay());
		}

		IEnumerator FrameDelay()
		{
			for(int i = 0; i < framedelay; i++)
			{
				yield return new WaitForEndOfFrame();
			}
			signal.value = false;
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}