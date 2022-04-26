using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using TMPro;
public class GameButtonInfo : MonoBehaviour, IPointerClickHandler
{
    public string gameName;
    public TextMeshProUGUI nameText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
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

    // destroy object upon right clicking it
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            DestroyObject();
        }

    }
}
