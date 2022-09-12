using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FailReload : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("MainLevel");
    }
}
