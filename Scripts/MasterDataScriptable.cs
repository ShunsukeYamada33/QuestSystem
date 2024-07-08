using UnityEngine;

[CreateAssetMenu(fileName = "MasterData", menuName = "QuestSystem/MasterData")]
public class MasterDataScriptable : ScriptableObject
{
    public QuestScriptable[] quests;
}
