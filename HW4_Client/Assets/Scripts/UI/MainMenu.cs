using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	private GameObject joinButton;
    private GameObject startActionButton;
    private GameObject userNameInput;
    //private GameObject rootMenuPanel;
    //private GameObject hotseatMenuPanel;
    //private GameObject networkMenuPanel;

    //private GameObject messageBox;
    //private TMPro.TextMeshProUGUI messageBoxMsg;

    //private TMPro.TextMeshProUGUI player1Name;
    //private TMPro.TextMeshProUGUI player2Name;
    private GameObject playerInput;
    //private GameObject player1Input;
    //private GameObject player2Input;

    //private TMPro.TextMeshProUGUI playerName;
    //private TMPro.TextMeshProUGUI opponentName;
    //private GameObject playerInput;
    //private GameObject opponentInput;

    private NetworkManager networkManager;
    private MessageQueue msgQueue;
    private PlayerManager playerManager;

    // private string pName = "";
    //private string p1Name = "Player 1";
    //private string p2Name = "Player 2";

    //private bool ready = false;
	//private bool opReady = false;

	// Start is called before the first frame update
	void Start()
	{
        joinButton = GameObject.Find("JoinButton");
        userNameInput = GameObject.Find("NameInput");
        startActionButton = GameObject.Find("StartActionButton");
        //rootMenuPanel = GameObject.Find("Root Menu");
        //hotseatMenuPanel = GameObject.Find("Hotseat Menu");
        //networkMenuPanel = GameObject.Find("Network Menu");

        //messageBox = GameObject.Find("Message Box");
        //messageBoxMsg = messageBox.transform.Find("Message").gameObject.GetComponent<TMPro.TextMeshProUGUI>();

        //playerName = GameObject.Find("PlayerName").GetComponent<TMPro.TextMeshProUGUI>(); //TEST
        //player1Name = GameObject.Find("Player1Name").GetComponent<TMPro.TextMeshProUGUI>();
        //player2Name = GameObject.Find("Player2Name").GetComponent<TMPro.TextMeshProUGUI>();

        // userInput = GameObject.Find("NameInput").GetComponent<TextMeshProUGUI>().text;
        //player1Input = GameObject.Find("NetPlayer1Input");
        //player2Input = GameObject.Find("NetPlayer2Input");

        networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();
        playerManager = GameObject.Find("Player Manager").GetComponent<PlayerManager>();
        
        msgQueue = networkManager.GetComponent<MessageQueue>();

		msgQueue.AddCallback(Constants.SMSG_JOIN, OnResponseJoin);
		msgQueue.AddCallback(Constants.SMSG_LEAVE, OnResponseLeave);
		msgQueue.AddCallback(Constants.SMSG_SETNAME, OnResponseSetName);

        //msgQueue.AddCallback(Constants.SMSG_READY, OnResponseReady);

        joinButton.SetActive(true);
        userNameInput.SetActive(false);
        startActionButton.SetActive(false);
        //messageBox.SetActive(false);
    }


    public void onJoinClick()
    {
		Debug.Log("Send JoinReq");
		bool connected = networkManager.SendJoinRequest();
		if (!connected)
		{
			Debug.Log("Unable to connect to server.");
		} else
        {
            joinButton.SetActive(true);
            userNameInput.SetActive(true);
            startActionButton.SetActive(false);
        }
	}

    //	#region RootMenu
    //	public void OnHotseatClick()
    //	{
    //		rootMenuPanel.SetActive(false);
    //		hotseatMenuPanel.SetActive(true);
    //	}

    //	public void OnNetworkClick()
    //	{
    //		Debug.Log("Send JoinReq");
    //		bool connected = networkManager.SendJoinRequest();
    //		if (!connected)
    //		{
    //			messageBoxMsg.text = "Unable to connect to server.";
    //			messageBox.SetActive(true);
    //		}
    //	}

    //	public void OnExitClick()
    //	{
    //#if UNITY_EDITOR
    //		UnityEditor.EditorApplication.isPlaying = false;
    //#else
    //		Application.Quit();
    //#endif
    //	}
    //	#endregion

    //	#region HotseatMenu
    //	public void OnStartClick()
    //	{
    //		StartHotseatGame();
    //	}

    //	public void OnBackClick()
    //	{
    //		rootMenuPanel.SetActive(true);
    //		hotseatMenuPanel.SetActive(false);
    //		networkMenuPanel.SetActive(false);
    //		messageBox.SetActive(false);
    //	}
    //	#endregion

    //	#region NetworkMenu
    public void OnResponseJoin(ExtendedEventArgs eventArgs)
    {
        ResponseJoinEventArgs args = eventArgs as ResponseJoinEventArgs;
        if (args.status == 0)
        {
            if (args.user_id == 1)
            {
                //playerName = player1Name;
                //opponentName = player2Name;
                //playerInput = player1Input;
                //opponentInput = player2Input;
                Debug.Log("server respond: user 1");
                playerManager.setPlayerNum(1);
            }
            else if (args.user_id == 2)
            {
                //playerName = player2Name;
                //opponentName = player1Name;
                //playerInput = player2Input;
                //opponentInput = player1Input;
                Debug.Log("user 2");
                playerManager.setPlayerNum(2);
            }
            else
            {
                Debug.Log("ERROR: Invalid user_id in ResponseJoin: " + args.user_id);
                //messageBoxMsg.text = "Error joining game. Network returned invalid response.";
                //messageBox.SetActive(true);
                return;
            }
            Constants.USER_ID = args.user_id;
            Constants.OP_ID = 3 - args.user_id;

            if (args.op_id > 0)
            {
                if (args.op_id == Constants.OP_ID)
                {
                    //opponentName.text = args.op_name;
                    //opReady = args.op_ready;
                }
                else
                {
                    Debug.Log("ERROR: Invalid op_id in ResponseJoin: " + args.op_id);
                    //messageBoxMsg.text = "Error joining game. Network returned invalid response.";
                    //messageBox.SetActive(true);
                    return;
                }
            }
            else
            {
                //opponentName.text = "Waiting for opponent";
            }

            //playerInput.SetActive(true);
            //    opponentName.gameObject.SetActive(true);
            //    playerName.gameObject.SetActive(false);
            //    opponentInput.SetActive(false);

            //    rootMenuPanel.SetActive(false);
            //    networkMenuPanel.SetActive(true);
            //}
            //else
            //{
            //    messageBoxMsg.text = "Server is full.";
            //    messageBox.SetActive(true);
            //}
        }
    }
    public void OnLeave()
    {
        Debug.Log("Send LeaveReq");
        networkManager.SendLeaveRequest();
        //rootMenuPanel.SetActive(true);
        //networkMenuPanel.SetActive(false);
        //ready = false;
    }

    public void OnResponseLeave(ExtendedEventArgs eventArgs)
    {
        ResponseLeaveEventArgs args = eventArgs as ResponseLeaveEventArgs;
        if (args.user_id != Constants.USER_ID)
        {
            //opponentName.text = "Waiting for opponent";
            //opReady = false;
        }
    }

    public void OnPlayerNameSet(string name)
    {

        //Debug.Log("Send SetNameReq: " + pname);
        name = GameObject.Find("NameInput").GetComponent<TMP_InputField>().text;
        Debug.Log("Send SetNameReq: " + name);
        networkManager.SendSetNameRequest(name);
        //pName = name;
        Debug.Log("playerName is " + name);
        //if (Constants.USER_ID == 1)
        //{
        //    p1Name = name;
        //}
        //else
        //{
        //    p2Name = name;
        //}
        joinButton.SetActive(true);
        userNameInput.SetActive(true);
        startActionButton.SetActive(true);
    }

    public void OnResponseSetName(ExtendedEventArgs eventArgs)
    {
        ResponseSetNameEventArgs args = eventArgs as ResponseSetNameEventArgs;
        Debug.Log("args.user_id: "+ args.user_id);
        if (args.user_id != Constants.USER_ID)
        {
            //opponentName.text = args.name;
            name = args.name;
            Debug.Log("response playerName is " + name);
            //if (args.user_id == 1)
            //{
            //    p1Name = args.name;
            //}
            //else
            //{
            //    p2Name = args.name;
            //}
        }
    }


    public void onStartGameClick()
    {
        //animationStateControl animationControl = GameObject.Find("ybot@idle").GetComponent<animationStateControl>();
        SceneManager.LoadScene("Server Scene");
        // GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //		if (p1Name.Length == 0)
        //		{
        //			p1Name = "Player 1";
        //		}
        //		if (p2Name.Length == 0)
        //		{
        //			p2Name = "Player 2";
        //		}
        //		Player player1 = new Player(1, p1Name, new Color(0.9f, 0.1f, 0.1f), Constants.USER_ID == 1);
        //		Player player2 = new Player(2, p2Name, new Color(0.2f, 0.2f, 1.0f), Constants.USER_ID == 2);
        //		gameManager.Init(player1, player2);
        //		SceneManager.LoadScene("Game");
    }

    //	public void OnReadyClick()
    //	{
    //		Debug.Log("Send ReadyReq");
    //		networkManager.SendReadyRequest();
    //	}

    //	public void OnResponseReady(ExtendedEventArgs eventArgs)
    //	{
    //		ResponseReadyEventArgs args = eventArgs as ResponseReadyEventArgs;
    //		if (Constants.USER_ID == -1) // Haven't joined, but got ready message
    //		{
    //			opReady = true;
    //		}
    //		else
    //		{
    //			if (args.user_id == Constants.OP_ID)
    //			{
    //				opReady = true;
    //			}
    //			else if (args.user_id == Constants.USER_ID)
    //			{
    //				ready = true;
    //			}
    //			else
    //			{
    //				Debug.Log("ERROR: Invalid user_id in ResponseReady: " + args.user_id);
    //				messageBoxMsg.text = "Error starting game. Network returned invalid response.";
    //				messageBox.SetActive(true);
    //				return;
    //			}
    //		}

    //		if (ready && opReady)
    //		{
    //			StartNetworkGame();
    //		}
    //	}
    //	#endregion

    //	public void OnOKClick()
    //	{
    //		messageBox.SetActive(false);
    //	}

    //	private void StartHotseatGame()
    //	{
    //		GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    //		string p1Name = GameObject.Find("HotPlayer1Name").GetComponent<TMPro.TextMeshProUGUI>().text;
    //		if (p1Name.Length == 1)
    //		{
    //			p1Name = "Player 1";
    //		}
    //		string p2Name = GameObject.Find("HotPlayer2Name").GetComponent<TMPro.TextMeshProUGUI>().text;
    //		if (p2Name.Length == 1)
    //		{
    //			p2Name = "Player 2";
    //		}
    //		Player player1 = new Player(1, p1Name, new Color(0.9f, 0.1f, 0.1f), true);
    //		Player player2 = new Player(2, p2Name, new Color(0.2f, 0.2f, 1.0f), true);
    //		gameManager.Init(player1, player2);
    //		SceneManager.LoadScene("Game");
    //	}

    //	private void StartNetworkGame()
    //	{
    //		GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    //		if (p1Name.Length == 0)
    //		{
    //			p1Name = "Player 1";
    //		}
    //		if (p2Name.Length == 0)
    //		{
    //			p2Name = "Player 2";
    //		}
    //		Player player1 = new Player(1, p1Name, new Color(0.9f, 0.1f, 0.1f), Constants.USER_ID == 1);
    //		Player player2 = new Player(2, p2Name, new Color(0.2f, 0.2f, 1.0f), Constants.USER_ID == 2);
    //		gameManager.Init(player1, player2);
    //		SceneManager.LoadScene("Game");
    //	}
}