using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
    public static int scoreint;
    float score;
    public Text scoretext;
    int k;
    int j = 0;


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
        score = inputManager.progress * 10000 * ScoreMultiplicator.GetInstance().GetMultiplicator();
        scoreint = Mathf.RoundToInt(score);
        //Debug.Log(score);  


        if(inputManager.Gameover == 1) {
            if(j == 0) {
                StartCoroutine(ScoreChange());
                j = 1;
            }
            scoretext.enabled = true;

            scoretext.text = "" + k;

        }
    }



    public void StrtCor() {
        StartCoroutine(ScoreChange());

    }


    IEnumerator ScoreChange() {

        yield return new WaitForSeconds(0.0001f);

        scoretext.text = "" + k;
        k += 10;
        if(k <= scoreint) {
            Invoke("StrtCor",0f);
        }
    }

}

