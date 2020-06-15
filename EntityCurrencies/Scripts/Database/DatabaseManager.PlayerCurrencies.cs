
using UnityEngine;
using Mirror;
using System;
using System.IO;
using System.Collections.Generic;
using SQLite;
using UnityEngine.AI;
using OpenMMO;
using OpenMMO.Database;
using OpenMMO.Debugging;

namespace OpenMMO.Database
{

	// ===================================================================================
	// DatabaseManager
	// ===================================================================================
	public partial class DatabaseManager
	{
	
		// -------------------------------------------------------------------------------
		// Init_Currency
		// -------------------------------------------------------------------------------
		[DevExtMethods("Init")]
		void Init_Currency()
		{
	   		CreateTable<TablePlayerCurrencies>();
        	CreateIndex(nameof(TablePlayerCurrencies), new []{"owner", "name"});
		}
		
		// -------------------------------------------------------------------------------
		// CreateDefaultDataPlayer_Currency
		// -------------------------------------------------------------------------------
		[DevExtMethods("CreateDefaultDataPlayer")]
		void CreateDefaultDataPlayer_Currency(GameObject player)
		{
	   		PlayerCurrencyComponent manager = player.GetComponent<PlayerCurrencyComponent>();
	   		manager.CreateDefaultDataPlayer();
		}
		
		// -------------------------------------------------------------------------------
		// LoadDataPlayer_Currency
		// -------------------------------------------------------------------------------
		[DevExtMethods("LoadDataPlayer")]
		void LoadDataPlayer_Currency(GameObject player)
		{
	   		PlayerCurrencyComponent manager = player.GetComponent<PlayerCurrencyComponent>();

			foreach (TablePlayerCurrencies row in Query<TablePlayerCurrencies>("SELECT * FROM "+nameof(TablePlayerCurrencies)+" WHERE owner=?", player.name))
			{
				if (row.slot < manager.GetCapacity)
				{
					if (String.IsNullOrWhiteSpace(row.name))
					{
						manager.AddEntry(null, row.slot, 0, 0);
					}
					else if (CurrencyTemplate.data.TryGetValue(row.name.GetDeterministicHashCode(), out CurrencyTemplate template))
                	{
						manager.AddEntry(template, row.slot, row.value, row.timeStamp);
					}
					else debug.LogWarning("[LoadData] Skipped currency " + row.name + " for " + player.name + " as it was not found in Resources.");
				}
            	else debug.LogWarning("[LoadData] Skipped currency slot " + row.slot + " for " + player.name + " because it exceeds capacity " + manager.GetCapacity);
			}
		}
		
	   	// -------------------------------------------------------------------------------
	   	// SaveDataPlayer_Currency
		// -------------------------------------------------------------------------------
		[DevExtMethods("SaveDataPlayer")]
		void SaveDataPlayer_Currency(GameObject player, bool isOnline)
		{

			// you should delete all data of this player first, to prevent duplicates
	   		DeleteDataPlayer_Currency(player.name);
	   		
	   		PlayerCurrencyComponent manager = player.GetComponent<PlayerCurrencyComponent>();
	   		
	   		List<CurrencySyncStruct> list = manager.GetEntries(false);
	   		
	   		for (int i = 0; i < list.Count; i++)
	   		{
	   			
	   			CurrencySyncStruct entry = list[i];
	   			
	   			InsertOrReplace(new TablePlayerCurrencies{
                	owner 			= player.name,
                	name 			= entry.name,
                	slot			= entry.slot,
                	value 			= entry.value,
                	timeStamp 		= entry.timeStamp
            	});
	   		}
		}
		
		// -------------------------------------------------------------------------------
	   	// DeleteDataPlayer_Currency
	   	// -------------------------------------------------------------------------------
	   	[DevExtMethods("DeleteDataPlayer")]
	   	void DeleteDataPlayer_Currency(string _name)
	   	{
	   		Execute("DELETE FROM "+nameof(TablePlayerCurrencies)+" WHERE owner=?", _name);
	   	}
		
		// -------------------------------------------------------------------------------

	}

}

// =======================================================================================