using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public  static int scoreint; 
    public int scoreint1;
    float score;
    public float score1;
    public Text scoretext;
    private float endPos = -240;
    bool change;
    int k;
    int j = 0;


    private InputManager inputManager;

    // Start is called before the first frame update
    void Awake()
    {
        inputManager = GetComponent<InputManager>();
        score = inputManager.progress;
        score1 = (transform.position.z) / (endPos / 100) / 100;
        scoretext.enabled = false;
        k = 0;
        j = 0;
        //scoreint = 100;
    }



    // Update is called once per frame
    void Update()
    {
        score1 = (transform.position.z) / (endPos / 100) * 100;

        score = ((inputManager.progress * 10000));
        scoreint = Mathf.RoundToInt(score);
        scoreint1 = Mathf.RoundToInt(score1);
        //Debug.Log(score);  


        if (inputManager.Gameover)
        {
            if (j == 0)

            {
                StartCoroutine(ScoreChange());
                j = 1;
            }
            scoretext.enabled = true;
            change = true;

            scoretext.text = "" + k;
            
        }
    }

        

        public void  StrtCor()
        { 
         StartCoroutine(ScoreChange());
        
        }


        IEnumerator ScoreChange()
        { 
        
          yield return new WaitForSeconds(0.0001f);

                scoretext.text = "" + k;
                k += 10;
            if (k <= scoreint)
            {
                Invoke("StrtCor",0f);
            }
        }

    }

