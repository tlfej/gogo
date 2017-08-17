using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using myStateMachine;

namespace Monster
{
	enum enBehaviorState
	{
		Idle,
		Chase,
		Attack,
		Detour,
		Max,
	}

	public class myMonster : MonoBehaviour 
	{
		private StateMachine _myBehaviorStateMachine;

		public static float _fMoveSpeed = 5.0f;

		// Use this for initialization
		void Start () {
			StartBehaviorStateMachine ();
		}

		// Update is called once per frame
		void Update () {
			UpdateBehaviorStateMachine ();
		}

		private void StartBehaviorStateMachine()
		{
			_myBehaviorStateMachine = new StateMachine ();

			// idle
			_myBehaviorStateMachine.AddState((int)enBehaviorState.Idle, new BehaviorState_Idle(gameObject, _myBehaviorStateMachine));
			// chase
			_myBehaviorStateMachine.AddState((int)enBehaviorState.Chase, new BehaviorState_Chase(gameObject, _myBehaviorStateMachine));
			// attack
			_myBehaviorStateMachine.AddState((int)enBehaviorState.Attack, new BehaviorState_Attack(gameObject, _myBehaviorStateMachine));
			// detour
			_myBehaviorStateMachine.AddState((int)enBehaviorState.Detour, new BehaviorState_Detour(gameObject, _myBehaviorStateMachine));

			// first state
			_myBehaviorStateMachine.GotoState((int)enBehaviorState.Idle);
		}

		private void UpdateBehaviorStateMachine()
		{
			_myBehaviorStateMachine.OnTick ();
		}
	}
}

