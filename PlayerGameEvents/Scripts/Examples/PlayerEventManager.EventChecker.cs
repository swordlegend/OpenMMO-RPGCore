
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenMMO;

namespace OpenMMO
{

	// ===================================================================================
	// PlayerGameEventManager
	// ===================================================================================
	public partial class PlayerGameEventManager
	{
	
		/*
	
			This is just a example to demonstrate how events work:
		
		*/
	
		// -----------------------------------------------------------------------------------
		// UpdateClient_EventChecker
		// -----------------------------------------------------------------------------------
		[DevExtMethods("UpdateClient")]
		void UpdateClient_EventChecker()
		{
/*
			Debug.Log("----- EVENT CHECKER -----");
		
			List<EventSyncStruct> gameEvents = GetEntries(false, SortOrder.None);
		
			foreach (EventSyncStruct gameEvent in gameEvents)
			{
			
				if (gameEvent.Valid)
					Debug.Log(gameEvent.name + " is currently ACTIVE (based on server time)");
				else
					Debug.Log(gameEvent.name + " is currently INACTIVE (based on server time)");
				
			}
*/
		}
	
		// -----------------------------------------------------------------------------------
	
	}

}