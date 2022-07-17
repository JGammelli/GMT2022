using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSideTag : MonoBehaviour
{
    public int Number;
    // Start is called before the first frame update
    void Start()
    {
        tag = Number.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
