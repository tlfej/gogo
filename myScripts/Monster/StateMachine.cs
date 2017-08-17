using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace myStateMachine
{
	public class StateMachine
	{
		myState _currentState;

		Dictionary<int, myState> _stateTable;

		public StateMachine()
		{
			_stateTable = new Dictionary<int, myState> ();
		}

		public void AddState(int iKey, myState addState)
		{
			_stateTable.Add (iKey, addState);
			// set key
			addState.SetKey (iKey);
		}

		public void GotoState(int iKey)
		{
			if (_stateTable.ContainsKey (iKey) == true)
			{
				if (_currentState != null) 
				{
					// call end
					_currentState.OnEnd (_stateTable[iKey]);
				}

				myState previousState = _currentState;

				_currentState = _stateTable[iKey];
				// call begin
				_currentState.OnBegin (previousState);
			}
		}

		public void OnTick()
		{
			if (_currentState != null) 
			{
				_currentState.OnTick ();
			}
		}
	}

	public abstract class myState
	{
		protected GameObject _myOwner;
		protected StateMachine _myStateMachine;
		public int _myKey;

		public myState(GameObject myOwner, StateMachine myStateMachine)
		{
			_myOwner = myOwner;
			_myStateMachine = myStateMachine;
		}

		public void SetKey(int iKey)
		{
			_myKey = iKey;
		}

		public abstract void OnBegin(myState previousState);
		public abstract void OnEnd(myState nextState);
		public abstract bool OnTick ();

		protected abstract bool OnTransition();
	}
}

