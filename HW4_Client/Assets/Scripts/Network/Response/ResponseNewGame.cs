using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseNewGameEventArgs : ExtendedEventArgs
{
	public int user_id { get; set; }
	public int nGames { get; set; }

	public ResponseNewGameEventArgs()
	{
		event_id = Constants.SMSG_NEWGAME;
	}
}

public class ResponseNewGame : NetworkResponse
{
	private int user_id;
	private int nGames;

	public ResponseNewGame()
	{
	}

	public override void parse()
	{
		user_id = DataReader.ReadInt(dataStream);
		nGames = DataReader.ReadInt(dataStream);
	}

	public override ExtendedEventArgs process()
	{
		ResponseNewGameEventArgs args = new ResponseNewGameEventArgs
		{
			user_id = user_id,
			nGames = nGames
		};

		return args;
	}
}