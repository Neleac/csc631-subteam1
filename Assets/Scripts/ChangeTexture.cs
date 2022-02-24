using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTexture : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;

    [SerializeField]
    private Texture[] textures;

    private Renderer cubeRenderer;

    private int textureIndex = 0;
 

    // Start is called before the first frame update
    void Start()
    {
        cubeRenderer = cube.GetComponent<Renderer>();
        // assign to textureIndex which is 0
        cubeRenderer.material.mainTexture = textures[textureIndex];
        gameObject.GetComponent<Button>().onClick.AddListener(ChangeCubeTexture);
    }

    // Update is called once per frame
    private void ChangeCubeTexture()
    {
        textureIndex++;
        
        if (textureIndex >= textures.Length)
        {
            textureIndex = 0; // reset the index
        }
        cubeRenderer.material.mainTexture = textures[textureIndex];
    }
}
