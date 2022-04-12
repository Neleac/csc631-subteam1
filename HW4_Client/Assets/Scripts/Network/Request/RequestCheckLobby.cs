using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestCheckLobby : NetworkRequest
{
	public RequestCheckLobby()
	{
		request_id = Constants.CMSG_CHECKLOBBY;
	}
	
	public void send()
	{
		packet = new GamePacket(request_id);
	}
}
