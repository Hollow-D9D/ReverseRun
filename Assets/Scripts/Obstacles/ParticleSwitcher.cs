using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSwitcher : MonoBehaviour
{
    private float seconds = 1f;
    private ParticleSystem particle;
    // Start is called before the first frame update
    void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        particle.Stop();
    }

    public void StartTimer()
    {
        particle.Play();
        StartCoroutine(disableParticle());
    }

    private IEnumerator disableParticle()
    {
        yield return new WaitForSeconds(seconds);
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
