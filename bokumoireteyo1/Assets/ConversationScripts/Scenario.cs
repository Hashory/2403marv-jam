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

// これ使って
public class Scenario : ScenarioData
{
    private readonly string[] fileNames = {
        "sample",
        "1",
        "2"
    };

    /// <summary>
    /// シナリオをJSONファイルから読み込み、C#の型にします。
    /// </summary>
    /// <param name="scenarioId">シナリオのId</param>
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