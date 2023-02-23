using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Winscore : MonoBehaviour
{
    public Text score;
    public int points;
    // Start is called before the first frame update
    IEnumerator Start()
    { 
        points = ScoreCounter.scoreint;
        score.text = "" + points;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainLevel");
    }

}
