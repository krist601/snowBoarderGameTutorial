using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashAudioClip;
    [SerializeField] float delayTime = 2f;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){
            crashEffect.Play();
            if(FindObjectOfType<PlayerController>().canMove)
                GetComponent<AudioSource>().PlayOneShot(crashAudioClip);
            FindObjectOfType<PlayerController>().disableControls();
            Invoke("loadNewScene", delayTime);
        }
    }
}
