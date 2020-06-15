
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using OpenMMO;

namespace OpenMMO {

	// ===================================================================================
	// AspectSyncStruct
	// ===================================================================================
	[System.Serializable]
	public partial struct AspectSyncStruct : ISyncableStruct<AspectTemplate>
	{
	
 		public int hash;
 		
 		// -------------------------------------------------------------------------------
		// -------------------------------------------------------------------------------
		public AspectSyncStruct(AspectTemplate template)
		{
			hash 	= (template == null) ? 0 : template.hash;
		}
		
		// -------------------------------------------------------------------------------
    	public bool Valid
    	{
    		get { return hash != 0; }
    	}
		
		// -------------------------------------------------------------------------------
		// -------------------------------------------------------------------------------
		public AspectTemplate template
		{
			get
			{
				if (hash == 0) return null;
				
				if (!AspectTemplate.data.ContainsKey(hash))
					throw new KeyNotFoundException("[Missing] AspectTemplate not found in Resources: " + hash);
				return AspectTemplate.data[hash];
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
    	
    	}
    	
    	
    	// -------------------------------------------------------------------------------
    	// -------------------------------------------------------------------------------
		public bool CanAdd(long _amount=1)
		{
			return false; // always return false - we can never remove a aspect
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
			return false; // always return false - we can never remove a aspect
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
		}
    	// -------------------------------------------------------------------------------
	}
	
	public class SyncListAspectSyncStruct : SyncList<AspectSyncStruct> { }
	
}

// =======================================================================================