using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FailReload : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(reloadScene());
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("MainLevel");
    }
}
