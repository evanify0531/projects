using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dummy : MonoBehaviour
{
    public GameObject quote1;
    public GameObject quote2;
    public GameObject suntzu;
    public GameObject panel;

    void Start()
    {
        
        quote1.SetActive(false);
        quote2.SetActive(false);
        suntzu.SetActive(false);
        panel.SetActive(true);
        Invoke("Quote1", 1f);
        Invoke("Quote2", 10f);
        Invoke("Suntzu", 17f);
        Invoke("NextScene", 24f);
    }

    private void Quote1()
    {
        quote1.SetActive(true);
    }

    private void Quote2()
    {
        quote2.SetActive(true);
    }

    private void Suntzu()
    {
        suntzu.SetActive(true);
    }

    private void NextScene()
    {
        SceneManager.LoadScene(2);
    }
}
