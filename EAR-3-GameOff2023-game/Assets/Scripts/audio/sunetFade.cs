using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunetFade : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
                audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn() 
    {
        while(audioSource.volume <= 1)
        {
            audioSource.volume += 0.005f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
