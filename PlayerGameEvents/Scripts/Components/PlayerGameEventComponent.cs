
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using OpenMMO;

namespace OpenMMO {
	
	// ===================================================================================
	// PlayerGameEventComponent
	// ===================================================================================
	[DisallowMultipleComponent]
	[System.Serializable]
	public partial class PlayerGameEventComponent : SyncableComponent
	{
	
		protected SyncListEventSyncStruct syncData = new SyncListEventSyncStruct();
		
		// -------------------------------------------------------------------------------
		// Start
		// @Server
		// -------------------------------------------------------------------------------
		[ServerCallback]
		protected override void Start()
		{
			base.Start();
		}
		
		// -------------------------------------------------------------------------------
		// CreateDefaultDataPlayer
		// @Server
		// -------------------------------------------------------------------------------
		[Server]
		public void CreateDefaultDataPlayer()
		{
			syncData.Clear();
			
			foreach (KeyValuePair<int, GameEventTemplate> _entry in GameEventTemplate.data)
    		{
    			AddEntry(_entry.Value);
    		}
			
		}
		
		// -------------------------------------------------------------------------------
		// AddEntry
		// @Server
		// -------------------------------------------------------------------------------
		[Server]
		public void AddEntry(GameEventTemplate _template)
		{
			EventSyncStruct syncStruct = new EventSyncStruct(_template);
			syncData.Add(syncStruct);
		}
		
		// -------------------------------------------------------------------------------
		// GetEntries
		// -------------------------------------------------------------------------------
		public List<EventSyncStruct> GetEntries(bool validOnly=true, SortOrder _sortOrder=SortOrder.None, string _category="")
		{
		
			List<EventSyncStruct> entryList = new List<EventSyncStruct>();
			
			foreach (EventSyncStruct entry in syncData)
			{
				if (entry.Valid)
				{
					
					if (string.IsNullOrWhiteSpace(_category) ||
						entry.template.sortCategory == _category)
						entryList.Add(entry);
										
				}
				else if (!validOnly && !entry.Valid)
					entryList.Add(entry);
			
			}
			
			if (validOnly && _sortOrder == SortOrder.Priority)
				entryList.OrderBy(x => x.template.sortOrder).ToList();
			
			return entryList;
			
		}
		
		// -------------------------------------------------------------------------------
		// UpdateServer
		// @Server
		// -------------------------------------------------------------------------------
		[Server]
		protected override void UpdateServer()
		{
			this.InvokeInstanceDevExtMethods(nameof(UpdateServer));
		}
		
		// -------------------------------------------------------------------------------
		// UpdateClient
		// @Client
		// -------------------------------------------------------------------------------
		[Client]
		protected override void UpdateClient()
		{
			this.InvokeInstanceDevExtMethods(nameof(UpdateClient));
		}
		
		// -------------------------------------------------------------------------------
		// LateUpdateClient
		// @Client
		// -------------------------------------------------------------------------------
		[Client]
		protected override void LateUpdateClient()
		{
			
		}
		
		// -------------------------------------------------------------------------------
		// FixedUpdateClient
		// @Client
		// -------------------------------------------------------------------------------
		[Client]
		protected override void FixedUpdateClient()
		{
			
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================