using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Winscore : MonoBehaviour
{
    public TextMeshProUGUI score;
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
