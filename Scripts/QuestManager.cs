using System;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private MasterDataScriptable masterData;
    [SerializeField] private QuestPanel questPanelPrefab;
    public QuestData questData;
    private ScrollRect _scrollRect;

    private void Awake()
    {
        _scrollRect = GetComponent<ScrollRect>();
    }

    public void Start()
    {
        questData = LoadQuestData();
        if (questData == null || questData.questData.Count == 0)
        {
            questData = new QuestData(masterData.quests);
        }

        foreach (var quest in questData.questData)
        {
            var questPanel = Instantiate(questPanelPrefab, _scrollRect.content);
            quest.questPanel = questPanel;
            questPanel.descriptionText.text = quest.description;
            questPanel.achievedButton.interactable = quest.isAhieved && !quest.isAcquired;
            questPanel.achievedText.text = quest.isAcquired ? "Acquired" : quest.isAhieved ? "Achieved" : "Not Achieved";
            
            questPanel.achievedButton.onClick.AddListener(() =>
            {
                quest.isAcquired = true;
                questPanel.achievedButton.interactable = false;
                questPanel.achievedText.text = "Acquired";
                SaveQuestData();
            });
        }
    }

    public void QuestAchieved(string id, int score)
    {
        foreach (var quest in questData.questData)
        {
            if(quest.id != id) continue;
            if(quest.isAhieved) continue;
            if(quest.score > score) continue;
            quest.isAhieved = true;
            quest.questPanel.achievedButton.interactable = true;
            quest.questPanel.achievedText.text = "Achieved";
            SaveQuestData();
        }
    }

    private static QuestData LoadQuestData()
    {
        var saveData = new SaveFile();
        var data = saveData.Load("Quest");
        return JsonUtility.FromJson<QuestData>(data);
    }

    private void SaveQuestData()
    {
        var saveData = new SaveFile();
        var data = JsonUtility.ToJson(questData);
        saveData.Save("Quest", data);
    }
}
