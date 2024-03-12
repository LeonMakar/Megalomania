using UnityEngine;

public class CitizenSimulatorFactory 
{
    private Navigation _citizenSimulationGameObject;

    public CitizenSimulatorFactory(Navigation navigation)
    {
        _citizenSimulationGameObject = navigation;
    }
    public Navigation Create()
    {
        return GameObject.Instantiate(_citizenSimulationGameObject);
    }
}
