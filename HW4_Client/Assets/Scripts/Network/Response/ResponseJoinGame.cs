using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseJoinGameEventArgs : ExtendedEventArgs
{
	public int user_id { get; set; }
	public string name { get; set; }

	public ResponseJoinGameEventArgs()
	{
		event_id = Constants.SMSG_JOINGAME;
	}
}

public class ResponseJoinGame : NetworkResponse
{
	private int user_id;
	private string name;

	public ResponseJoinGame()
	{
	}

	public override void parse()
	{
		user_id = DataReader.ReadInt(dataStream);
		name = DataReader.ReadString(dataStream);
	}

	public override ExtendedEventArgs process()
	{
		ResponseJoinGameEventArgs args = new ResponseJoinGameEventArgs
		{
			user_id = user_id,
			name = name
		};

		return args;
	}
}