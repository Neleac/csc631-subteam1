using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkybox : MonoBehaviour
{
    private Material defaultSkybox;
    private Material milkywaySkybox;

    // Start is called before the first frame update
    void Start()
    {
        defaultSkybox = RenderSettings.skybox;
        milkywaySkybox = Resources.Load("MilkyWay/Material/MilkyWay", typeof(Material)) as Material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            if(RenderSettings.skybox.name == "Default-Skybox") 
            {
                RenderSettings.skybox = milkywaySkybox;
            }
            else
            {
                RenderSettings.skybox = defaultSkybox;
            }
        }
    }
}
