using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();
    protected BaseState<EState> CurrentState;
    private bool _isTransitioningProccesWay = false;

    protected void StartStateMachine(EState startState)
    {
        if (CurrentState != null)
            CurrentState.ChangeStateAction -= TransitionToNextState;
        CurrentState = States[startState];
        CurrentState.ChangeStateAction += TransitionToNextState;
        CurrentState.EnterToState();
    }

    private void Update()
    {
        if (!_isTransitioningProccesWay)
            CurrentState.UpdateState();
    }

    protected void TransitionToNextState(EState nextStateKey)
    {
        _isTransitioningProccesWay = true;
        CurrentState.ExitFromState();
        CurrentState.ChangeStateAction -= TransitionToNextState;
        CurrentState = States[nextStateKey];
        CurrentState.ChangeStateAction += TransitionToNextState;
        CurrentState.EnterToState();
        _isTransitioningProccesWay = false;
    }

}
