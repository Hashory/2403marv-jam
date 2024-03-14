using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioData
{
    public int ConversationId { get; set; }
    public int BgId { get; set; }
    public int BgmId { get; set; }
    public List<int> AvatarId { get; set; }
    public List<Dialogue> Conversation { get; set; }
    public List<Choice> Choices { get; set; }
}

public class Dialogue
{
    public int AvatarId { get; set; }
    public string Text { get; set; }
}

public class Choice
{
    public string Text { get; set; }
    public bool Correct { get; set; }
}

// これ使って
public class Scenario : ScenarioData
{
    private readonly string[] fileNames = {
        "sample.jsonc",
        "1.json",
        "2.json"
    };

    /// <summary>
    /// シナリオをJSONファイルから読み込み、C#の型にします。
    /// </summary>
    /// <param name="scenarioId">シナリオのId</param>
    public Scenario(int scenarioId)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(fileNames[scenarioId]);
        if (textAsset == null)
        {
            Debug.LogError("File not found: " + fileNames[scenarioId]);
            return;
        }

        ScenarioData scenarioData = JsonUtility.FromJson<ScenarioData>(textAsset.text);

        ConversationId = scenarioData.ConversationId;
        BgId = scenarioData.BgId;
        BgmId = scenarioData.BgmId;
        AvatarId = scenarioData.AvatarId;
        Conversation = scenarioData.Conversation;
        Choices = scenarioData.Choices;
    }
}