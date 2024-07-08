using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestData
{
    public List<Quest> questData;
    
    public QuestData(QuestScriptable[] quests)
    {
        questData = new List<Quest>();
        foreach (var quest in quests)
        {
            questData.Add(new Quest(quest));
        }
    }
    
    [Serializable]
    public class Quest
    {
        public QuestPanel questPanel;
        public string id;
        public int score;
        public string description;
        public bool isAhieved;
        public bool isAcquired;
        
        public Quest(QuestScriptable quest)
        {
            id = quest.id;
            score = quest.score;
            description = quest.description;
            isAhieved = false;
            isAcquired = false;
        } 
    }
}
