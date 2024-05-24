using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mezcla : MonoBehaviour
{
    public AudioClip[] sonidos;
    private AudioSource audioSource;
    bool sonando = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !sonando)
        {
            sonando = true;
            audioSource.PlayOneShot(sonidos[0]);
            Invoke("nota2", 0.5f);
            Invoke("nota3", 1f);
            Invoke("nota4", 1.5f);
            
        }
    }

    void nota2(){
        audioSource.PlayOneShot(sonidos[1]);
    }

    void nota3(){
        audioSource.PlayOneShot(sonidos[2]);
    }

    void nota4(){
        audioSource.PlayOneShot(sonidos[3]);
        Invoke("habilitar", 0.2f);
    }

    void habilitar(){
        sonando = false;
    }



}
