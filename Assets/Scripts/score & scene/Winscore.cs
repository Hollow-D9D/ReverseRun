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
    void Start()
    { points = ScoreCounter.scoreint;
      score.text = "" + points;
        StartCoroutine(reloadScene());
    }

    

    IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("MainLevel");
    }
}
