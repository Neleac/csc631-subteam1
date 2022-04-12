using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestNewGame : NetworkRequest
{
	public RequestNewGame()
	{
		request_id = Constants.CMSG_NEWGAME;
	}

	public void send(int nGames)
	{
		packet = new GamePacket(request_id);
		packet.addInt32(nGames);
	}
}