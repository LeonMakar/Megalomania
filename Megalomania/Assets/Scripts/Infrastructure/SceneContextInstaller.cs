using TMPro;
using UnityEngine;
using Zenject;

public class SceneContextInstaller : MonoInstaller
{

    [SerializeField] private TextMeshProUGUI _notationText;
    [SerializeField] private StoneText _stoneText;
    [SerializeField] private WoodText _woodText;
    [SerializeField] private GameToken _gameToken;


    public override void InstallBindings()
    {
        BindNotationText();
        BindCitizensController();
        BindWoodText();
        BindStoneText();
        BindCitizenFactory();
        BindGameToken();
        BindEventBus();
        BindResourcesStorage();

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

    private void BindStoneText()
    {
        Container
            .Bind<StoneText>()
            .FromInstance(_stoneText)
            .AsSingle();
    }

    private void BindWoodText()
    {
        Container
            .Bind<WoodText>()
            .FromInstance(_woodText)
            .AsSingle();
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
