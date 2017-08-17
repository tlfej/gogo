﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using myStateMachine;

public class BehaviorState_Attack : myState 
{
	public BehaviorState_Attack(GameObject myOwner, StateMachine myStateMachine) 
		: base(myOwner, myStateMachine)
	{

	}

	public override void OnBegin(myState previousState)
	{

	}

	public override void OnEnd(myState nextState)
	{

	}

	public override bool OnTick()
	{
		if (OnTransition () == true)
			return false;

		return true;
	}

	protected override bool OnTransition()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) 
		{
			float fDistance = Vector3.Distance (player.transform.position, _myOwner.transform.position);
			// chase
			if (fDistance > 3.0f)
			{
				_myStateMachine.GotoState ((int)Monster.enBehaviorState.Chase);
				return true;
			}
		}

		return false;
	}
}
