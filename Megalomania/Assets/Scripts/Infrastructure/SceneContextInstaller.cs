using Cysharp.Threading.Tasks.Triggers;
using TMPro;
using UnityEngine;
using Zenject;

public class SceneContextInstaller : MonoInstaller, IInitializable
{

    [SerializeField] private TextMeshProUGUI _notationText;
    [SerializeField] private GameToken _gameToken;
    [SerializeField] private GameMainData _gameMainData;
    [SerializeField] private CitizenGeneratorData _citizenGeneratorData;
    [SerializeField] private CitizenText _citizenText;
    [SerializeField] private Collider2D _mainBuildingCollider;

    public void Initialize()
    {
        _citizenText.Initialize();
        Container.Resolve<CitizenGenerator>().Initialize();
    }
    public override void InstallBindings()
    {
        BindGameMainData();
        BindCitizenGeneratorData();
        BindNotationText();
        BindCitizensController();
        BindCitizenFactory();
        BindGameToken();
        BindEventBus();
        BindResourcesStorage();
        BindCitizenGenerator();
        BindInstallerInterface();
        BindMainBuildingCollider();

    }

    private void BindMainBuildingCollider()
    {
        Container
            .Bind<Collider2D>()
            .FromInstance(_mainBuildingCollider)
            .AsSingle()
            .Lazy();
    }

    private void BindInstallerInterface()
    {
        Container
            .BindInterfacesTo<SceneContextInstaller>()
            .FromInstance(this)
            .AsSingle()
            .NonLazy();
    }

    private void BindCitizenGeneratorData()
    {
        Container
            .Bind<CitizenGeneratorData>()
            .FromInstance(_citizenGeneratorData)
            .AsSingle()
            .NonLazy();
    }

    private void BindCitizenGenerator()
    {
        Container
            .Bind<CitizenGenerator>()
            .AsSingle()
            .NonLazy();
    }

    private void BindGameMainData()
    {
        Container
            .Bind<GameMainData>()
            .FromInstance(_gameMainData)
            .AsSingle()
            .NonLazy();
    }
    private void BindResourcesStorage()
    {
        Container
            .Bind<ResourcesStorage>()
            .AsSingle()
            .NonLazy();
    }

    private void BindEventBus()
    {
        Container
            .Bind<EventBus>()
            .AsSingle()
            .NonLazy();
    }

    private void BindGameToken()
    {
        Container
            .Bind<GameToken>()
            .FromInstance(_gameToken)
            .AsSingle()
            .NonLazy();
    }

    private void BindCitizenFactory()
    {
        Container
            .BindFactory<Citizen, Citizen.Factory>()
            .AsSingle()
            .Lazy();
    }

    private void BindCitizensController()
    {
        Container
            .Bind<CitizenController>()
            .AsSingle()
            .NonLazy();
    }

    private void BindNotationText()
    {
        Container
            .Bind<TextMeshProUGUI>()
            .FromInstance(_notationText)
            .AsSingle()
            .NonLazy();
    }


}
