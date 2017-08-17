using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using myStateMachine;

public class BehaviorState_Chase : myState
{
	public Vector3 _vDetourDirection;

	private bool _IsDetourTimeFlag;
	private float _fDetourTimeElapsed;

	public BehaviorState_Chase(GameObject myOwner, StateMachine myStateMachine) 
		: base(myOwner, myStateMachine)
	{

	}

	public override void OnBegin(myState previousState)
	{
		_vDetourDirection = Vector3.zero;

		if (previousState._myKey == (int)Monster.enBehaviorState.Detour) 
		{
			_IsDetourTimeFlag = true;
			_fDetourTimeElapsed = 1.0f; 
		} 
		else 
		{
			_IsDetourTimeFlag = false;
			_fDetourTimeElapsed = 0.0f; 
		}
	}

	public override void OnEnd(myState nextState)
	{
	}

	public override bool OnTick()
	{
		if (OnTransition () == true)
			return false;


		// chase
		moveChase();

		return true;
	}

	protected override bool OnTransition()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) 
		{
			float fDistance = Vector3.Distance (player.transform.position, _myOwner.transform.position);
			// attack
			if (fDistance <= 2.0f)
			{
				_myStateMachine.GotoState ((int)Monster.enBehaviorState.Attack);
				return true;
			}
			// idle
			if (fDistance > 20.0f)
			{
				_myStateMachine.GotoState ((int)Monster.enBehaviorState.Idle);
				return true;
			}
		}

		// detour
		if (OnTransitionDetour () == true)
			return true;

		return false;
	}

	private bool OnTransitionDetour()
	{
		// 이전 state가 detour이면 어느 정도 시간이 지났을때 처리
		if (_IsDetourTimeFlag == true) 
		{
			_fDetourTimeElapsed -= Time.deltaTime;
			if (_fDetourTimeElapsed > 0.0f)
				return false;
		}


		float fMyPDistance;

		// 일정 범위에서만 detour 처리
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) 
		{
			fMyPDistance = Vector3.Distance (player.transform.position, _myOwner.transform.position);
			// attack
			if (fMyPDistance > 3.0f) 
			{
				GameObject[] monsterArray = GameObject.FindGameObjectsWithTag ("Monster");
				if (monsterArray.Length > 0) 
				{
					for (int i = 0; i < monsterArray.Length; ++i) 
					{
						if (_myOwner == monsterArray [i])
							continue;

						float fMyMDistance = Vector3.Distance (monsterArray [i].transform.position, _myOwner.transform.position);
						float fMPDistance = Vector3.Distance (monsterArray [i].transform.position, player.transform.position);
						if (fMyMDistance < 2.0f && fMyPDistance > fMPDistance)
						{
							Vector3 vLookAt = player.transform.position - _myOwner.transform.position;
							vLookAt.x = vLookAt.y;
							vLookAt.y = -vLookAt.x;
							_vDetourDirection = vLookAt;
							_vDetourDirection.Normalize ();

							_myStateMachine.GotoState ((int)Monster.enBehaviorState.Detour);
							return true;
						}
					}
				}
			}
		}

		return false;
	}

	private void moveChase()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) 
		{
			Vector3 vDesiredDirection = player.transform.position - _myOwner.transform.position;
			vDesiredDirection.Normalize ();
			CharacterController myController = _myOwner.GetComponent<CharacterController> ();
			if (myController != null)
			{
				myController.Move (vDesiredDirection * Monster.myMonster._fMoveSpeed * Time.deltaTime);
			}
		}
	}
}
