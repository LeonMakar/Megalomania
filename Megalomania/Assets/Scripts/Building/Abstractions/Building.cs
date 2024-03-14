using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public abstract class Building : MonoBehaviour, IPointerClickHandler
{
    [Header("Building Commponents")]
    public TextMeshProUGUI WoodUpgradeCount;
    public TextMeshProUGUI StoneUpgradeCount;
    public TextMeshProUGUI CitizenUpgradeCount;
    public Button UpgradeButtone;
    public SpriteRenderer BuildingImage;


    private BuildingView _buildingView;
    private SoldierController _soldierController;
    public CitizenController CitizenController;
    private ResourcesStorage _resourcesStorage;

    public int StageIndex;
    [HideInInspector] public int WoodToUpgrade;
    [HideInInspector] public int StoneToUpgrade;
    [HideInInspector] public int CitizenToUpgrade;
    [HideInInspector] public int SoldierToAdd;

    private bool _isWoodReady = true;
    private bool _isStoneReady = true;
    private bool _isCitizensReady = true;
    private bool _canDeleteUpgradeArrow = true;
    private bool _isParametersAreOn = false;

    [Space(10), Header("Next Upgrades")]
    public List<ConstructionStage> ConstructionStages = new List<ConstructionStage>();

    [Inject]
    private void Construct(SoldierController soldierController, ResourcesStorage storage, CitizenController citizenController)
    {
        _soldierController = soldierController;
        CitizenController = citizenController;
        _resourcesStorage = storage;

        _resourcesStorage.WoodInStorage.OnChange += CheckWood;
        _resourcesStorage.StoneInStorage.OnChange += CheckStone;
        _resourcesStorage.CitizenInStorage.OnChange += CheckCitizens;

    }

    private void CheckCitizens(int citizens)
    {
        if (CitizenToUpgrade != 0)
            if (citizens >= CitizenToUpgrade)
            {
                _isCitizensReady = true;
                ActivateUpgradeArrow();
            }
    }

    private void CheckWood(int wood)
    {
        if (wood >= WoodToUpgrade)
        {
            _isWoodReady = true;
            ActivateUpgradeArrow();
        }
    }
    private void CheckStone(int stone)
    {
        if (stone >= StoneToUpgrade)
        {
            _isStoneReady = true;
            ActivateUpgradeArrow();
        }
    }

    private void ActivateUpgradeArrow()
    {
        if ((_isWoodReady && _isStoneReady) || (_isWoodReady && _isCitizensReady) || (_isStoneReady && _isCitizensReady))
        {
            UpgradeButtone.gameObject.SetActive(true);
            ActivateTransferIcon();
            _canDeleteUpgradeArrow = false;
        }
    }

    private void ActivateTransferIcon()
    {
        BuildingImage.sprite = ConstructionStages[StageIndex].ConstructionProgressSprite;
    }

    private void Start()
    {
        BuildingImage = GetComponent<SpriteRenderer>();
        _buildingView = new BuildingView(this);

        UpgradeBuilding();
    }
    public void UpgradeBuilding()
    {

        if (_buildingView.ChangeBuildingStage())
        {

            TrainSoldierAfterBuilding(SoldierToAdd);
            UpgradeButtone.gameObject.SetActive(false);
            _canDeleteUpgradeArrow = true;
        }
    }
    public bool CheckAllParametersForBuilding()
    {
        Debug.Log($"NeedWood = {WoodToUpgrade} i HaveWood = {_resourcesStorage.WoodInStorage.Value} ");
        if (WoodToUpgrade <= _resourcesStorage.WoodInStorage.Value &&
            StoneToUpgrade <= _resourcesStorage.StoneInStorage.Value &&
            CitizenToUpgrade <= _resourcesStorage.CitizenInStorage.Value)
        {
            _resourcesStorage.WoodInStorage.Value -= WoodToUpgrade;
            _resourcesStorage.StoneInStorage.Value -= StoneToUpgrade;
            return true;
        }
        else
            return false;
    }

    public void RestartAllParameters()
    {
        _isCitizensReady = false;
        _isWoodReady = false;
        _isStoneReady = false;
    }
    private void TrainSoldierAfterBuilding(int soldierAmmount) => _soldierController.CreateSoldier(soldierAmmount);
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_canDeleteUpgradeArrow && !_isParametersAreOn)
        {
            WoodUpgradeCount.gameObject.SetActive(true);
            StoneUpgradeCount.gameObject.SetActive(true);
            CitizenUpgradeCount.gameObject.SetActive(true);
            _isParametersAreOn = true;
            return;
        }
        else if (!_canDeleteUpgradeArrow && _isParametersAreOn)
        {
            WoodUpgradeCount.gameObject.SetActive(false);
            StoneUpgradeCount.gameObject.SetActive(false);
            CitizenUpgradeCount.gameObject.SetActive(false);
            _isParametersAreOn = false;
            return;
        }

        if (UpgradeButtone.gameObject.activeSelf)
            _buildingView.SetActiveUpgradeUIPart(false);
        else
            _buildingView.SetActiveUpgradeUIPart(true);
    }



    [Serializable]
    public struct ConstructionStage
    {
        public Sprite ConstructionFinalSprite;
        public Sprite ConstructionProgressSprite;
        public int WoodsForBuilding;
        public int StonesForBuilding;
        public int CitizensForBuilding;
        public int SoldierToGet;
        public string Description;
    }
}
