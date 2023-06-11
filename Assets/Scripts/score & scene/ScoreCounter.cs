using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour {
    public static int scoreint;
    float score;
    public TextMeshProUGUI scoretext;
    int k;
    int j;


    private InputManager inputManager;

    // Start is called before the first frame update
    void Awake() {
        inputManager = GetComponent<InputManager>();
        score = inputManager.progress;
        scoretext.enabled = false;
        k = 0;
        j = 0;
        //scoreint = 100;
    }

    void Update() {
        //Debug.Log(score);  


        if(inputManager.Gameover == 1) {

            if(j == 0) {
                score = inputManager.getTransformValue() * 10 * ScoreMultiplicator.GetInstance().GetMultiplicator();
                scoreint = Mathf.RoundToInt(score);
                LocalDB.Instance.db.data.money += scoreint;

                StartCoroutine(ScoreChange());
                j = 1;
            }
            scoretext.enabled = true;

            scoretext.text = $"{scoreint}";

        }
    }

    IEnumerator ScoreChange() {

        yield return null;
        scoretext.text = $"{k}";
        k += 25;
        if(k <= scoreint) {
            StartCoroutine(ScoreChange());
        }
    }

}

