using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeStretchEffect : MonoBehaviour
{
    public InputManager inputManager;
    public Transform startPoint;
    [SerializeField] private GameObject particle;

    float showTime = .6f;
    float appearFrequency = .6f;
    bool startTheShow;


    // Start is called before the first frame update
    void Start()
    {
        startTheShow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startTheShow)
            if (inputManager.getProgress() > showTime)
            {
                startTheShow = true;
                StartCoroutine(Show());
            }
    }

    private IEnumerator Show()
    {
        Vector3 difference = transform.position - startPoint.position ;
        Vector3 desiredPoint = transform.position - difference.normalized * 5f;
        GameObject pf = Instantiate(particle, desiredPoint, transform.rotation);
        yield return new WaitForSeconds(appearFrequency);
        Destroy(pf);
        StartCoroutine(Show());
    }
}
