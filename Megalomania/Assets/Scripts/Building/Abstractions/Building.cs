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

    [HideInInspector] public int StageIndex = -1;
    [HideInInspector] public int WoodToUpgrade;
    [HideInInspector] public int StoneToUpgrade;
    [HideInInspector] public int CitizenToUpgrade;
    [HideInInspector] public int SoldierToAdd;


    [Space(10), Header("Next Upgrades")]
    public List<ConstructionStage> ConstructionStages = new List<ConstructionStage>();

    [Inject]
    private void Construct(SoldierController soldierController)
    {
        _soldierController = soldierController;
    }
    private void Start()
    {
        BuildingImage = GetComponent<SpriteRenderer>();

        _buildingView = new BuildingView(this);
        UpgradeBuilding();
    }
    public void UpgradeBuilding()
    {
        _buildingView.ChangeBuildingStage();
        TrainSoldierAfterBuilding(SoldierToAdd);
    }

    private void TrainSoldierAfterBuilding(int soldierAmmount) => _soldierController.CreateSoldier(soldierAmmount);
    public void OnPointerClick(PointerEventData eventData)
    {
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
