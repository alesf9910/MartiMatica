using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Marti : MonoBehaviour
{
    public float horizontal;
    private Rigidbody2D rb;
    public float minX, maxX;
    private int cantVida = 5;
    private int estrellasGanadas = 0;
    private int estrellasGanadasMax;
    public Text vida;
    public Text estrella;
    public int numeroRnd;
    public Text formulaText;
    private Text numero;
    private Animator animator;
    private AudioSource []audioSources;
    bool one = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        minX = -screenBounds.x+1.5f;
        maxX = screenBounds.x-7.5f;
        estrellasGanadasMax = PlayerPrefs.GetInt("estrellasGanadasMax", 0);
        vida.text = cantVida.ToString();
        estrella.text = $"{estrellasGanadas}/{estrellasGanadasMax}";
        UpdateFormula();
        animator = GetComponent<Animator>();
        audioSources = GetComponents<AudioSource>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        Vector3 pos = rb.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        rb.position = pos;
        rb.velocity = new Vector2(horizontal, rb.velocity.y) * 10;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Numero"))
        {
            UpdateVidaYEstrella(other.gameObject); 
            Destroy(other.gameObject);
            UpdateFormula();
        }
    }

    void UpdateFormula(){
        int fn = UnityEngine.Random.Range(0, 50);
        int sn = UnityEngine.Random.Range(0, 49);
        numeroRnd = fn + sn;
        formulaText.text = $"{fn}+{sn}";
    }

    void UpdateVidaYEstrella(GameObject gameObject){
        numero = gameObject.GetComponentInChildren<Text>();
        if(numero.text == numeroRnd.ToString()){
            audioSources[0].Play();
            animator.SetBool("IsFood", true);
            estrellasGanadas += 5;
            if(estrellasGanadas > estrellasGanadasMax){
                if(one){
                    audioSources[2].Play();
                    one = false;
                }
                estrellasGanadasMax = estrellasGanadas;
            }
            estrella.text = $"{estrellasGanadas}/{estrellasGanadasMax}";
            PlayerPrefs.SetInt("estrellasGanadasMax", estrellasGanadasMax);        
        }else{
            audioSources[1].Play();
            cantVida--;
            vida.text = cantVida.ToString();
            if(cantVida == 0)SceneManager.LoadScene("GameOver");
        }
    }

    public void OnAnimationEnd()
    {
        animator.SetBool("IsFood", false);
    }
}
