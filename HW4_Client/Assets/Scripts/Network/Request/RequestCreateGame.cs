using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestCreateGame : NetworkRequest
{
	public RequestCreateGame()
	{
		request_id = Constants.CMSG_CREATEGAME;
	}

	public void send()
	{
		packet = new GamePacket(request_id);
	}
}
