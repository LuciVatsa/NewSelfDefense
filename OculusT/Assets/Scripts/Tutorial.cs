using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject orient;
    public GameObject leftpoke;
    public GameObject rightpoke;

    private bool input = false;
    void Start()
    {

    }

    void Update()
    {
        leftpoke.SetActive(false);
        rightpoke.SetActive(false);
    }
}
