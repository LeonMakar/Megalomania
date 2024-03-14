using System;

public abstract class BaseState<EState> where EState : Enum
{
    public EState StateKey { get; private set; }
    public event Action<EState> ChangeStateAction;
    protected bool IsTransitionStart = false;

    public BaseState(EState key)
    {
        StateKey = key;
    }
    public abstract void EnterToState();
    public abstract void ExitFromState();
    public abstract void UpdateState();

}
