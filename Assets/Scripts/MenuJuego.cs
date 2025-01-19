using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuJuego : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void Salir(){
        StartCoroutine(PlaySoundAndChangeScene("MenuPrincipal"));
    }

    IEnumerator PlaySoundAndChangeScene(string sceneName){
        audioSource.Play();
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
}
