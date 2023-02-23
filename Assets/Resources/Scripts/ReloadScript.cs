using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScript : MonoBehaviour
{
    string sceneName;

    public void setName(string name) { sceneName = name; }

    public void Reload()
    {
        Debug.Log("Skipping");
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

}
