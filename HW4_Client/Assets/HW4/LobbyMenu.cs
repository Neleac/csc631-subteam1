using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMenu : MonoBehaviour
{
    private int nGames;

    void Start()
    {
        nGames = 0;
    }

    void Update()
    {
        
    }

    public void NewGame()
    {
        nGames++;
        if (nGames == 1)
        {
            transform.Find("Game A").gameObject.SetActive(true);
        }
        else if (nGames == 2)
        {
            transform.Find("Game B").gameObject.SetActive(true);
        }
        else if (nGames == 3)
        {
            transform.Find("Game C").gameObject.SetActive(true);
        }
    }
}
