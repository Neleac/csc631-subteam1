using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    private int currIdx;
    private int numScenes;
    
    // Start is called before the first frame update
    void Start()
    {
        currIdx = SceneManager.GetActiveScene().buildIndex;
        numScenes = SceneManager.sceneCountInBuildSettings;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            int nextIdx = currIdx + 1;
            if (nextIdx == numScenes) nextIdx = 0;
            SceneManager.LoadScene(nextIdx, LoadSceneMode.Single);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            int nextIdx = currIdx - 1;
            if (nextIdx == -1) nextIdx = numScenes - 1;
            SceneManager.LoadScene(nextIdx, LoadSceneMode.Single);
        }   
    }
}
