using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RandomNumber : MonoBehaviour
{
    public GameObject numeroPrefab;
    public Marti martiScript;
    public float tiempoEntreNumeros = 1.0f;
    public float gravityScale = 2f;

    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > tiempoEntreNumeros)
        {
            timer = 0;
            GenerarNumero();
        }
    }

    void GenerarNumero()
    {
        float x = Random.Range(martiScript.minX, martiScript.maxX);
        Vector3 posicion = new Vector3(x, 6, 0);
        GameObject numero = Instantiate(numeroPrefab, posicion, Quaternion.identity);
        Rigidbody2D rb = numero.GetComponent<Rigidbody2D>();
        rb.gravityScale = this.gravityScale;
        Text numeroText = numero.GetComponentInChildren<Text>();
        if(Random.Range(0,3) == 1){
            numeroText.text = martiScript.numeroRnd.ToString();
        }else{
            numeroText.text = Random.Range(0, 100).ToString();
        }
    }
}
