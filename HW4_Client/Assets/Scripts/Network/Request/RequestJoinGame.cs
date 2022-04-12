using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestJoinGame : NetworkRequest
{
	public RequestJoinGame()
	{
		request_id = Constants.CMSG_JOINGAME;
	}

	public void send(string name)
	{
		packet = new GamePacket(request_id);
		packet.addString(name);
	}
}