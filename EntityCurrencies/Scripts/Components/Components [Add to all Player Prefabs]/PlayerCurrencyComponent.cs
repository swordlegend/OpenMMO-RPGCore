
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using OpenMMO;

namespace OpenMMO {
	
	// ===================================================================================
	// PlayerCurrencyComponent
	// ===================================================================================
	[DisallowMultipleComponent]
	[System.Serializable]
	public partial class PlayerCurrencyComponent : UpgradableComponent
	{
		
		[Header("Default Data")]
		[SerializeField]
		protected CurrencyReward[] defaultCurrencies;
		
		protected SyncListCurrencySyncStruct syncData = new SyncListCurrencySyncStruct();
				
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
			
			int length = (defaultCurrencies == null || defaultCurrencies.Length == 0) ? 0 : defaultCurrencies.Length;
			
			for (int i = 0; i < defaultCurrencies.Length; i++)
	   			AddEntry(defaultCurrencies[i].template, i, defaultCurrencies[i].GetAmount, defaultCurrencies[i].timer);
	   		
	   		InsertDummyData(length, GetCapacity-1);
	   		
		}
		
		// -------------------------------------------------------------------------------
		// AddEntry
		// @Server
		// -------------------------------------------------------------------------------
		[Server]
		public void AddEntry(CurrencyTemplate _template, int _slot, long _amount, long _timeStamp)
		{
			CurrencySyncStruct syncStruct = new CurrencySyncStruct(_template, _slot, _amount, _timeStamp);
			syncData.Add(syncStruct);
		}
		
		// -------------------------------------------------------------------------------
		// GetEntries
		// -------------------------------------------------------------------------------
		public List<CurrencySyncStruct> GetEntries(bool validOnly=true, SortOrder _sortOrder=SortOrder.None, string _category="")
		{
			
			List<CurrencySyncStruct> entryList = new List<CurrencySyncStruct>();
			
			foreach (CurrencySyncStruct entry in syncData)
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
		// InsertDummyData
		// @Server
		// -------------------------------------------------------------------------------
		[Server]
		public void InsertDummyData(int startIndex, int endIndex)
		{
			for (int i = startIndex; i < endIndex; i++)
				AddEntry(null, i, 0, 0);
		}
		
		// -------------------------------------------------------------------------------
		// GetFreeSlot
		// -------------------------------------------------------------------------------
		protected int GetFreeSlot()
		{
			for (int i = 0; i < syncData.Count; i++)
				if (!syncData[i].Valid)
					return syncData[i].slot;
			return -1;
		}
		
		// -------------------------------------------------------------------------------
		// GetIndexBySlot
		// -------------------------------------------------------------------------------
		protected int GetIndexBySlot(int _slot)
		{
			for (int i = 0; i < syncData.Count; i++)
				if (syncData[i].slot == _slot)
					return i;
			return -1;
		}
		
		// -------------------------------------------------------------------------------
		// UpgradeLevel
		// @Server
		// -------------------------------------------------------------------------------
		[Server]
		protected override void UpgradeLevel()
		{
			int startIndex = GetCapacity-1;
			base.UpgradeLevel();
			InsertDummyData(startIndex, GetCapacity-1);
		}
		
		// -------------------------------------------------------------------------------
		// UpdateServer
		// @Server
		// -------------------------------------------------------------------------------
		[Server]
		protected override void UpdateServer()
		{
			for (int i = 0; i < syncData.Count; i++)
			{
				if (!syncData[i].Valid) continue;
				CurrencySyncStruct entry = syncData[i];

				entry.modifierCapacity 		= GetCapacity_AutoGenerateCurrency<CurrencySyncStruct>(GetEntries(), entry.template, entry.GetBaseCapacity(this.gameObject), level);
				entry.modifierProduction 	= GetProduction_AutoGenerateCurrency<CurrencySyncStruct>(GetEntries(), entry.template, entry.GetBaseProduction(this.gameObject), level);
				entry.modifierDuration 		= GetDuration_AutoGenerateCurrency<CurrencySyncStruct>(GetEntries(), entry.template, entry.GetBaseDuration(this.gameObject), level);

				entry.Update(this.gameObject);
				syncData[i] = entry;
			}
		}
		
		// -------------------------------------------------------------------------------
		// UpdateClient
		// @Client
		// -------------------------------------------------------------------------------
		[Client]
		protected override void UpdateClient() {}
		
		
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