
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using OpenMMO;

namespace OpenMMO {

	// ===================================================================================
	// EventSyncStruct
	// ===================================================================================
	[System.Serializable]
	public partial struct EventSyncStruct : ISyncableStruct<GameEventTemplate>
	{
	
 		public int 		hash;
 		public bool		active;
 		
 		// -------------------------------------------------------------------------------
		// -------------------------------------------------------------------------------
		public EventSyncStruct(GameEventTemplate template)
		{
			hash 	= (template == null) ? 0 : template.hash;
			active 	= false;
		}
		
		// -------------------------------------------------------------------------------
    	public bool Valid
    	{
    		get { return hash != 0 && active; }
    	}
		
		// -------------------------------------------------------------------------------
		// -------------------------------------------------------------------------------
		public GameEventTemplate template
		{
			get
			{
				if (hash == 0) return null;
				
				if (!GameEventTemplate.data.ContainsKey(hash))
					throw new KeyNotFoundException("[Missing] GameEventTemplate not found in Resources: " + hash);
				return GameEventTemplate.data[hash];
			}
		}   
		
		// -------------------------------------------------------------------------------
		// -------------------------------------------------------------------------------
		public int level
		{
			get { return template.level; }
		}
		
		// -------------------------------------------------------------------------------
    	// -------------------------------------------------------------------------------
    	public void Update(GameObject player)
    	{
    		active = 
    				DateTime.Compare(DateTime.UtcNow, template.startDate) >= 0 &&
    				DateTime.Compare(DateTime.UtcNow, template.endDate) <= 0;
    	
    	}
    	// -------------------------------------------------------------------------------
    	// -------------------------------------------------------------------------------
		public bool CanAdd(long _amount=1)
		{
			return false; // always return false - we can never remove a event
		}
		
		// -------------------------------------------------------------------------------
		// -------------------------------------------------------------------------------
		public void Add(long _amount=1)
		{
			// do nothing - we can never sell a event
		}
    	// -------------------------------------------------------------------------------
    	// -------------------------------------------------------------------------------
		public bool CanRemove(long _amount=1)
		{
			return false; // always return false - we can never remove a event
		}
		
		// -------------------------------------------------------------------------------
		// -------------------------------------------------------------------------------
		public void Remove(long _amount=1)
		{
			// do nothing - we can never sell a event
		}
    	// -------------------------------------------------------------------------------
    	// -------------------------------------------------------------------------------
		public void Reset()
		{
			hash = 0;
			active = false;
		}
    	// -------------------------------------------------------------------------------
	}
	
	public class SyncListEventSyncStruct : SyncList<EventSyncStruct> { }
	
}

// =======================================================================================