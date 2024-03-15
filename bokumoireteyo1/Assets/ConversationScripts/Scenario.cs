using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScenarioData
{
    public int ConversationId;
    public int BgId;
    public int BgmId;
    public List<int> AvatarId;
    public List<Dialogue> Conversation;
    public List<Choice> Choices;
}

[System.Serializable]
public class Dialogue
{
    public int AvatarId;
    public string Text;
}

[System.Serializable]
public class Choice
{
    public string Text;
    public bool Correct;
}

// ����g����
public class Scenario : ScenarioData
{
    private readonly string[] fileNames = {
        "sample",
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "10",
        "11",
        "12",
        "13",
        "14",
        "15",
        "16",
        "17",
        "18",
        "19",
        "20",
        "21",
        "22",
        "23",
        "24",
        "25",
        "26",
        "27",
        "28",
        "29",
        "30",
        "31",
        "32",
        "33",
        "34",
        "35"
    };

    /// <summary>
    /// �V�i���I��JSON�t�@�C������ǂݍ��݁AC#�̌^�ɂ��܂��B
    /// </summary>
    /// <param name="scenarioId">�V�i���I��Id</param>
    public Scenario(int scenarioId)
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Scenario/" + fileNames[scenarioId]);
        if (textAsset == null)
        {
            Debug.LogError("File not found: " + fileNames[scenarioId]);
            return;
        }
        Debug.Log("TextData:" + textAsset.text);

        ScenarioData scenarioData = JsonUtility.FromJson<ScenarioData>(textAsset.text);

        ConversationId = scenarioData.ConversationId;
        BgId = scenarioData.BgId;
        BgmId = scenarioData.BgmId;
        AvatarId = scenarioData.AvatarId;
        Conversation = scenarioData.Conversation;
        Choices = scenarioData.Choices;

        Debug.Log("ConversationId" + ConversationId);
    }
}