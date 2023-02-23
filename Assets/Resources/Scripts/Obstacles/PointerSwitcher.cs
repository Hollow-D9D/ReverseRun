using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerSwitcher : MonoBehaviour
{
    Image Active;
    Image Passive;
    
    Transform Player;
    public Transform ball = null;
    bool startedCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        Active = transform.GetChild(0).Find("Active").GetComponent<Image>();
        Passive = transform.GetChild(0).Find("Image").GetComponent<Image>();

        startedCoroutine = false;
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance;
        if (ball != null && !startedCoroutine)
        {
            distance = Vector3.Distance(ball.transform.position, Player.position);
//            Debug.Log(distance);
            StartCoroutine(switchSprite(distance));
        }
        

    }

    private IEnumerator switchSprite(float distance)
    {
        yield return new WaitForSeconds(100 / distance);
        startedCoroutine = true;
        Active.enabled = true;
        Passive.enabled = false;
        yield return new WaitForSeconds(100 / distance);
        Active.enabled = false;
        Passive.enabled = true;
        startedCoroutine = false;
    }
}
