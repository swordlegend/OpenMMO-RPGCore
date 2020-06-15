
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using OpenMMO;

namespace OpenMMO {
	
	// ===================================================================================
	// PlayerAspectComponent
	// ===================================================================================
	[DisallowMultipleComponent]
	[System.Serializable]
	public partial class PlayerAspectComponent : SyncableComponent
	{
		
		[Header("Default Data")]
		[SerializeField]
		protected AspectReward[] defaultAspects;
		
		protected SyncListAspectSyncStruct syncData = new SyncListAspectSyncStruct();
		
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
			
			foreach (AspectReward defaultAspect in defaultAspects)
				AddEntry(defaultAspect.template);
				
		}
		
		// -------------------------------------------------------------------------------
		// AddEntry
		// @Server
		// -------------------------------------------------------------------------------
		[Server]
		public void AddEntry(AspectTemplate _template)
		{
			AspectSyncStruct syncStruct = new AspectSyncStruct(_template);
			syncData.Add(syncStruct);
		}
		
		// -------------------------------------------------------------------------------
		// GetEntries
		// -------------------------------------------------------------------------------
		public List<AspectSyncStruct> GetEntries(bool validOnly=true, SortOrder _sortOrder=SortOrder.None, string _category="")
		{
		
			List<AspectSyncStruct> entryList = new List<AspectSyncStruct>();
			
			foreach (AspectSyncStruct entry in syncData)
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