using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Building : MonoBehaviour, IPointerClickHandler
{
    [Header("Building Commponents")]
    [SerializeField] private TextMeshProUGUI _woodUpgradeCount;
    [SerializeField] private TextMeshProUGUI _stoneUpgradeCount;
    [SerializeField] private TextMeshProUGUI _citizenUpgradeCount;
    [SerializeField] private Button _upgradeButtone;


    [Space(20), Header("First Upgrade Values")]
    [SerializeField] private int _woodToFirstUpgrade;
    [SerializeField] private int _stoneToFirstUpgrade;
    [SerializeField] private int _citizenToFirstUpgrade;

    [Space(10), Header("Next Upgrades")]
    public List<ConstructionStage> ConstructionStages = new List<ConstructionStage>();

    private int _stageIndex = 0;
    private int _woodToUpgrade;
    private int _stoneToUpgrade;
    private int _citizenToUpgrade;



    private Image _buildingImage;

    private void Start()
    {
        _woodToUpgrade = _woodToFirstUpgrade;
        _stoneToUpgrade = _stoneToFirstUpgrade;
        _citizenToUpgrade = _citizenToFirstUpgrade;
        _woodUpgradeCount.text = _woodToUpgrade.ToString();
        _stoneUpgradeCount.text = _stoneToUpgrade.ToString();
        _citizenUpgradeCount.text = _citizenToUpgrade.ToString();

        _buildingImage = GetComponent<Image>();
        _upgradeButtone.onClick.AddListener(ChangeBuildingStage);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (_upgradeButtone.gameObject.activeSelf)
            SetActiveUpgradeUIPart(false);
        else
            SetActiveUpgradeUIPart(true);
    }

    private void SetActiveUpgradeUIPart(bool boolian)
    {
        _upgradeButtone.gameObject.SetActive(boolian);
        _woodUpgradeCount.gameObject.SetActive(boolian);
        _stoneUpgradeCount.gameObject.SetActive(boolian);
        _citizenUpgradeCount.gameObject.SetActive(boolian);
    }

    private void ChangeBuildingStage()
    {
        if (ConstructionStages.Count > _stageIndex)
        {
            _buildingImage.sprite = ConstructionStages[_stageIndex].ConstructionSprite.sprite;
            _woodToUpgrade = ConstructionStages[_stageIndex].WoodsForBuilding;
            _stoneToUpgrade = ConstructionStages[_stageIndex].StonesForBuilding;
            _citizenToUpgrade = ConstructionStages[_stageIndex].CitizensForBuilding;
            _woodUpgradeCount.text = _woodToUpgrade.ToString();
            _stoneUpgradeCount.text = _stoneToUpgrade.ToString();
            _stageIndex++;
        }
        if (ConstructionStages.Count <= _stageIndex)
        {
            _woodUpgradeCount.text = string.Empty;
            _stoneUpgradeCount.text = string.Empty;
            _citizenUpgradeCount.text = string.Empty;
        }
    }



    [Serializable]
    public struct ConstructionStage
    {
        public Image ConstructionSprite;
        public int WoodsForBuilding;
        public int StonesForBuilding;
        public int CitizensForBuilding;
        public string Description;
    }
}
