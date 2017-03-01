using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRootTest2 : MonoBehaviour {

    public GameObject first;
    public GameObject second;

    void Awake()
    {
        

    }

    void Start()
    {
        first.SetActive(true);
        second.SetActive(false);
    }
}
