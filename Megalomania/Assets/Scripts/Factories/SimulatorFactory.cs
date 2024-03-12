using UnityEngine;

public abstract class SimulatorFactory
{
    private Navigation _simulationGameObject;

    public SimulatorFactory(Navigation navigation)
    {
        _simulationGameObject = navigation;
    }
    public Navigation Create()
    {
        return GameObject.Instantiate(_simulationGameObject);
    }
}
