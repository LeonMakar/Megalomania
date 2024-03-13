using UnityEngine;

public abstract class SimulatorFactory
{
    private Navigation _simulationGameObject;

    public SimulatorFactory(Navigation navigation)
    {
        _simulationGameObject = navigation;
    }
    public virtual Navigation Create()
    {
        return GameObject.Instantiate(_simulationGameObject);
    }
}
