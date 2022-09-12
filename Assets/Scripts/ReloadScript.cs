using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScript : MonoBehaviour
{
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(sceneName);
    }

    public void setName(string name) { sceneName = name; }

    // Update is called once per frame
    public void Reload()
    {
        Debug.Log("Bulki");
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

}
