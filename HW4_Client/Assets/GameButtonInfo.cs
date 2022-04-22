using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameButtonInfo : MonoBehaviour
{
    public string gameName;
    public TextMeshProUGUI nameText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetGameName( string lobbyName) {
        gameName = lobbyName;
        name = lobbyName;
        nameText.text = lobbyName + " 1/2";
    }
    public void SetGame()
    {
        FindObjectOfType<LobbyMenu>().JoinGame(gameName);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
