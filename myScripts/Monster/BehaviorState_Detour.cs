using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using myStateMachine;

public class BehaviorState_Detour : myState
{
	private float _fDetourTimer;
	private Vector3 _vDetourDirection;

	public BehaviorState_Detour(GameObject myOwner, StateMachine myStateMachine) 
		: base(myOwner, myStateMachine)
	{

	}

	public override void OnBegin(myState previousState)
	{
		_fDetourTimer = 0.0f;
		var stateChase = previousState as BehaviorState_Chase;
		_vDetourDirection = stateChase._vDetourDirection;
	}

	public override void OnEnd(myState nextState)
	{

	}

	public override bool OnTick()
	{
		if (OnTransition () == true)
			return false;

		// move detour
		moveDetour();

		return true;
	}

	protected override bool OnTransition()
	{
		_fDetourTimer += Time.deltaTime;
		if (_fDetourTimer > 0.3f) 
		{
			_myStateMachine.GotoState ((int)Monster.enBehaviorState.Chase);
			return true;
		}

		return false;
	}

	private void moveDetour()
	{
		CharacterController myController = _myOwner.GetComponent<CharacterController> ();
		if (myController != null)
		{
			myController.Move (_vDetourDirection * Monster.myMonster._fMoveSpeed * Time.deltaTime);
		}
	}
}
