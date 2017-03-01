using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRootTest : MonoBehaviour {

    public GameObject first;
    public GameObject second;
    public GameObject third;

    void Start()
    {
        first.SetActive(true);
        second.SetActive(false);
        third.SetActive(false);

    }
}
