using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkUtility : MonoBehaviour
{
    // Start is called before the first frame update
    NetworkManager networkmanager;
    void Start()
    {
        networkmanager = GetComponent<NetworkManager>();
    }

    public void CreateGame()
    {
        if (networkmanager != null)
        {
            networkmanager.CreateGame();
        }
    }
    
}
