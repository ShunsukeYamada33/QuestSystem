using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private QuestManager questManager;

    public int count;

    public void OnClick()
    {
        count++;
        questManager.QuestAchieved("OnClick", count);
    }
}
