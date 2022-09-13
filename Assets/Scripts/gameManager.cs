using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    public GameObject square;
    public GameObject gameOverText;
    public GameObject balloon;

    public Text timeText;
    float elapsedTime = 0.0f;

    public Animator animator;

    public static gameManager I;

    private void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeSquare", 0.0f, 0.5f);
    }

    void makeSquare()
    {
        Instantiate(square);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        timeText.text = elapsedTime.ToString("N2");
    }

    public void GameOver()
    { 
        animator.SetBool("isDie", true);
        gameOverText.SetActive(true);
        Invoke("Dead", 0.5f);
       
    }

    void Dead()
    {
        Time.timeScale = 0.0f;
        Destroy(balloon);
        
    }
}
