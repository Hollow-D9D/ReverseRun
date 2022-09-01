using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ParticleSwitcher : MonoBehaviour
{
    private float seconds = 1f;
    private ParticleSystem particle;
    [SerializeField] CinemachineVirtualCamera main;
    [SerializeField] CinemachineVirtualCamera speedy;

    // Start is called before the first frame update
    void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        particle.Stop();
    }

    public void StartTimer()
    {
        speedy.Priority = main.Priority + 1;
        particle.Play();
        StartCoroutine(disableParticle());
    }

    private IEnumerator disableParticle()
    {
        yield return new WaitForSeconds(seconds);
        speedy.Priority = main.Priority - 1;
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
