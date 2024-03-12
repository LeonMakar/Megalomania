using UnityEngine;

[CreateAssetMenu(fileName ="GameMainData",menuName = "ScriptableObjects/GameMainData")]
public class GameMainData : ScriptableObject
{
    [Header("Resources adding value")]
    [Tooltip("How much wood will be mined at a time")]
    public uint StoneAddingValue;
    [Tooltip("How much stone will be mined at a time")]
    public uint WoodAddingValue;

    [Space(20),Header("Resources mining interval")]

    [Tooltip("How often wood will mine (In milliseconds)")]
    public int WoodAddingInterval;
    [Tooltip("How often stone will mine (In milliseconds)")]
    public int StoneAddingInterval;


}
