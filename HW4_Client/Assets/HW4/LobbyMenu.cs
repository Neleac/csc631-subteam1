using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMenu : MonoBehaviour
{
    private int nGames;

    private NetworkManager networkManager;

    void Awake()
    {
        networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();

        MessageQueue msgQueue = networkManager.GetComponent<MessageQueue>();
        msgQueue.AddCallback(Constants.SMSG_NEWGAME, OnResponseNewGame);
        msgQueue.AddCallback(Constants.SMSG_JOINGAME, OnResponseJoinGame);
    }

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
        networkManager.SendNewGameRequest(nGames);
    }

    public void JoinGame(string name)
    {
        networkManager.SendJoinGameRequest(name);
    }

    public void OnResponseNewGame(ExtendedEventArgs eventArgs)
    {       
        ResponseNewGameEventArgs args = eventArgs as ResponseNewGameEventArgs;
        nGames = args.nGames;

        if (nGames == 1)
        {
            transform.Find("Game A").gameObject.SetActive(true);
            transform.Find("Game A").Find("closed").gameObject.SetActive(false);
        }
        else if (nGames == 2)
        {
            transform.Find("Game B").gameObject.SetActive(true);
            transform.Find("Game B").Find("closed").gameObject.SetActive(false);
        }
        else if (nGames == 3)
        {
            transform.Find("Game C").gameObject.SetActive(true);
            transform.Find("Game C").Find("closed").gameObject.SetActive(false);
        }
    }

    public void OnResponseJoinGame(ExtendedEventArgs eventArgs)
    {       
        ResponseJoinGameEventArgs args = eventArgs as ResponseJoinGameEventArgs;
        name = args.name;

        transform.Find(name).Find("open").gameObject.SetActive(false);
        transform.Find(name).Find("open").gameObject.SetActive(false);

        transform.Find(name).Find("closed").gameObject.SetActive(true);
        transform.Find(name).Find("closed").gameObject.SetActive(true);
    }
}
