using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PongPlayers
{
	public List<PongPlayer> list;

	public PongPlayers(List<PongPlayer> list)
	{
		this.list = list;
	}

	public PongPlayer NextPlayer(PongPlayer pp)
	{
		var c = this.list.Count;
		var i = this.list.IndexOf(pp) + 1;
		
		if(i < c) return this.list[i];
		if(c > 0) return this.list[0];
		return null;
	}

	public void RemoveDeadPlayers()
	{
		this.list.Where(pp => pp.hearts <= 0).ToList().ForEach(pp => pp.paddle.GetComponent<PongPaddle>().Kill());
		this.list = this.list.Where(pp => pp.hearts > 0).ToList();
	}
}
