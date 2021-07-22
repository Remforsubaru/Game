using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HighscoreTable : MonoBehaviour
{
    [SerializeField] Transform entryContainer;
    [SerializeField] Transform entryTemplate;
    [SerializeField] float templateHeight = 100f;

    private List<Transform> highScoreEntryTransformList;
    private void Awake()
    {
        entryTemplate.gameObject.SetActive(false);

        AddHighScoreEntry(999999, "TESTSCORE");

        // there is the error comes in

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        HightScores hscores = JsonUtility.FromJson<HightScores>(jsonString);



        //sorting algorithm

        for (int i = 0; i < hscores.highscoreEntryListt.Count; i++)
        {
            for (int j = i + 1; j < hscores.highscoreEntryListt.Count; j++)
            {
                if (hscores.highscoreEntryListt[j].score > hscores.highscoreEntryListt[i].score)
                {
                    //Swap
                    HighScoreEntry tmp = hscores.highscoreEntryListt[i];
                    hscores.highscoreEntryListt[i] = hscores.highscoreEntryListt[j];
                    hscores.highscoreEntryListt[j] = tmp;
                }
            }
        }

        highScoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry item in hscores.highscoreEntryListt)
        {
            CreateHScoreEntryTransform(item, entryContainer, highScoreEntryTransformList);
        }
    }
    private void CreateHScoreEntryTransform(HighScoreEntry hscEntry, Transform container, List<Transform> transformList)
    {
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString = rank.ToString() + ".";

        entryTransform.Find("posTXT").GetComponent<Text>().text = rankString;

        int score = hscEntry.score;

        entryTransform.Find("scoreTXT").GetComponent<Text>().text = score.ToString();

        string name = hscEntry.name;

        entryTransform.Find("nameTXT").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }
    private void AddHighScoreEntry(int score_, string name_)
    {
        HighScoreEntry hscoreEntry = new HighScoreEntry { score = score_, name = name_ };
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        HightScores hscores = JsonUtility.FromJson<HightScores>(jsonString);

        hscores.highscoreEntryListt.Add(hscoreEntry);
        string json = JsonUtility.ToJson(hscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
    [System.Serializable]
    private class HightScores
    {
        public List<HighScoreEntry> highscoreEntryListt;
    }
    [System.Serializable]
    private class HighScoreEntry
    {
        public int score;
        public string name;
    }
}