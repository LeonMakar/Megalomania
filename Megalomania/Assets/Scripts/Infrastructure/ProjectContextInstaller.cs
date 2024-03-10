using UnityEngine;
using Zenject;
public class ProjectContextInstaller : MonoInstaller
{
    [SerializeField] private GameMainData _gameMainData;
    public override void InstallBindings()
    {
        BindGameMainData();
    }

    private void BindGameMainData()
    {
        Container
            .Bind<GameMainData>()
            .FromInstance(_gameMainData)
            .AsSingle()
            .NonLazy();
    }
}
