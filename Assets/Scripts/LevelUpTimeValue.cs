using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GrowthObjectLevelUpValue")]
public class LevelUpTimeValue : ScriptableObject
{
    int _level = 0;
    public int[] LevelUpValue = new int[4];
}
