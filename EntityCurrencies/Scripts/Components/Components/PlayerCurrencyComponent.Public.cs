
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using OpenMMO;

namespace OpenMMO {
	
	// ===================================================================================
	// PlayerCurrencyComponent
	// ===================================================================================
	public partial class PlayerCurrencyComponent
	{
		
		// -------------------------------------------------------------------------------
		//
		// -------------------------------------------------------------------------------
		[Command]
		public void CmdSellEntry(int _slot, long _amount)
		{
			int index = GetIndexBySlot(_slot);
			if (syncData[index].CanRemove(_amount))
				SellEntry(index, _amount);
		}
		
		// -------------------------------------------------------------------------------
		//
		// -------------------------------------------------------------------------------
		[Server]
		protected void SellEntry(int _index, long _amount)
		{
			CurrencySyncStruct entry = syncData[_index];
			entry.Remove(_amount);
			syncData[_index] = entry;
			
			AddCurrency(entry.template.sellCost, _amount);
		}

		/*
		public bool CanBuyEntry()
		{
		}

		[Command]
		public void CmdBuyEntry()
		{
		}
		
		[Server]
		protected void BuyEntry()
		{
		}
		*/
		
	}

}

// =======================================================================================