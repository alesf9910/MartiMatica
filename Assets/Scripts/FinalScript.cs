using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScript : MonoBehaviour
{
    public float duration = 3.0f;
    private float timer = 0;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > duration){
            timer = 0;
            SceneManager.LoadScene("MenuPrincipal");
        }
    }
}
