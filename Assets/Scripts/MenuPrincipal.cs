using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void NuevoJuego(){
        StartCoroutine(PlaySoundAndChangeScene("Juego"));
    }

    public void Ayuda(){
        StartCoroutine(PlaySoundAndChangeScene("Instrucciones"));
    }

    public void Salir(){
        Application.Quit();
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
