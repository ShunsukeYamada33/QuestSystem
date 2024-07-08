using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "QuestSystem/Quest")]
public class QuestScriptable : ScriptableObject
{
    public string id;
    public int score = 1;
    public string description;
}
