using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour {

    private static HighScoreManager instance;

    public Transform HighScorePanel;
    public GameObject OriginalText;

    private List<UnityEngine.UI.Text> highScores;
	// Use this for initialization
	void Start () {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        highScores = new List<UnityEngine.UI.Text>();
        for (int i = 0; i < 10; i++)
        {
            highScores.Add((Instantiate(OriginalText)).GetComponent<UnityEngine.UI.Text>());
            highScores[i].transform.SetParent(HighScorePanel, false);
            highScores[i].text = i + 1 + ": Unknown";

        }

    }
	

    public static void SetHighScores(List<Individual> topIndividuals)
    {
        for(int i = 0; i < 10; i++)
        {
            instance.highScores[i].text = i + 1 + ": " + topIndividuals[i].geneSequence.Substring(0, 10) + " - " + topIndividuals[i].fitnessValue;
        }
    }
}
