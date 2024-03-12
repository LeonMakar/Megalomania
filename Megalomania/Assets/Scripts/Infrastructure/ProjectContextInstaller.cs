using UnityEngine;
using Zenject;
public class ProjectContextInstaller : MonoInstaller
{
    [SerializeField] private Navigation _citizenSimulatorGameObject;
    private CitizenSimulatorFactory _citizenSimulatorFactory;

    public override void InstallBindings()
    {
        _citizenSimulatorFactory = new CitizenSimulatorFactory(_citizenSimulatorGameObject);

        BindCitizenSimulationFactory();
    }

    private void BindCitizenSimulationFactory()
    {
        Container
            .Bind<CitizenSimulatorFactory>()
            .FromInstance(_citizenSimulatorFactory)
            .AsSingle()
            .NonLazy();
    }
}
