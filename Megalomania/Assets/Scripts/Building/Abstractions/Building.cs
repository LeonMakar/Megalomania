using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Building : MonoBehaviour, IPointerClickHandler
{
    [Header("Building Commponents")]
    public TextMeshProUGUI WoodUpgradeCount;
    public TextMeshProUGUI StoneUpgradeCount;
    public TextMeshProUGUI CitizenUpgradeCount;
    public Button UpgradeButtone;
    public SpriteRenderer BuildingImage;

    private BuildingView _buildingView;


    [Space(10), Header("Next Upgrades")]
    public List<ConstructionStage> ConstructionStages = new List<ConstructionStage>();

    private void Start()
    {
        BuildingImage = GetComponent<SpriteRenderer>();

        _buildingView = new BuildingView(this);
    }
    public void Upgrade()
    {
        _buildingView.ChangeBuildingStage();
    }


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
        public string Description;
    }
}
