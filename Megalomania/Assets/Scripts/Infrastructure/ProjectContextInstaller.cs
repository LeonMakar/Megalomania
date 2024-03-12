using UnityEngine;
using Zenject;
public class ProjectContextInstaller : MonoInstaller
{
    [SerializeField] private Navigation _citizenSimulatorGameObject;
    [SerializeField] private Navigation _soldierSimulatorGameObject;
    [SerializeField] private Navigation _enemySimulatorGameObject;


    private CitizenSimulatorFactory _citizenSimulatorFactory;
    private SoldierSimulatorFactory _soldierSimulatorFactory;
    private EnemySimulatorFactory _enemySimulatorFactory;

    public override void InstallBindings()
    {
        _citizenSimulatorFactory = new CitizenSimulatorFactory(_citizenSimulatorGameObject);
        _soldierSimulatorFactory = new SoldierSimulatorFactory(_soldierSimulatorGameObject);
        _enemySimulatorFactory = new EnemySimulatorFactory(_enemySimulatorGameObject);

        BindCitizenSimulationFactory();
        BindSoldierSimulatorFactory();
        BindEnemySimulatorFactory();
    }

    private void BindEnemySimulatorFactory()
    {
        Container
            .Bind<EnemySimulatorFactory>()
            .FromInstance(_enemySimulatorFactory)
            .AsSingle()
            .Lazy();
    }

    private void BindSoldierSimulatorFactory()
    {
        Container
            .Bind<SoldierSimulatorFactory>()
            .FromInstance(_soldierSimulatorFactory)
            .AsSingle()
            .Lazy();
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
