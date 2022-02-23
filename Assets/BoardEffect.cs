using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardEffect : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        // pick random color for R, G, B
        Color c = new Color(UnityEngine.Random.Range(0f, 1f),
                            UnityEngine.Random.Range(0f, 1f),
                            UnityEngine.Random.Range(0f, 1f));

        // assign random color to material
        GetComponent<Renderer>().material.color = c;
    }
}
