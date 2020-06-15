
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
	public partial class PlayerCurrencyComponent
	{
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public bool CanPayCost(FixedCurrencyCost[] _cost, long _value)
		{

			bool canPay = false;

			foreach (FixedCurrencyCost cost in _cost)
			{
				foreach (CurrencySyncStruct entry in syncData)
				{
					if (entry.template == cost.template)
						canPay = entry.value >= cost.value * _value;
				}
			}

			return canPay;

		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public bool CanPayCost(LevelCurrencyCost[] _cost, int _level)
		{

			bool canPay = false;
			
			foreach (LevelCurrencyCost cost in _cost)
			{
				foreach (CurrencySyncStruct entry in syncData)
				{
					if (entry.template == cost.template)
						canPay = entry.value >= cost.value.Get(_level);
				}
			}
			
			return canPay;

		}
		
		// -------------------------------------------------------------------------------
		// 
		// @Server
		// -------------------------------------------------------------------------------
		[Server]
		public void PayCost(FixedCurrencyCost[] _cost, long _value)
		{

			foreach (FixedCurrencyCost cost in _cost)
			{
				for (int i = 0; i < syncData.Count; i++)
				{
					if (syncData[i].template == cost.template)
					{
						CurrencySyncStruct entry = syncData[i];
						entry.value -= cost.value * _value;
						syncData[i] = entry;
					}
				}
			}

		}
		
		// -------------------------------------------------------------------------------
		//
		// @Server
		// -------------------------------------------------------------------------------
		[Server]
		public void PayCost(LevelCurrencyCost[] _cost, int _level)
		{

			foreach (LevelCurrencyCost cost in _cost)
			{
				for (int i = 0; i < syncData.Count; i++)
				{
					if (syncData[i].template == cost.template)
					{
						CurrencySyncStruct entry = syncData[i];
						entry.value -= cost.value.Get(_level);
						syncData[i] = entry;
					}
				}
			}

		}
		
		// -------------------------------------------------------------------------------
		//
		// @Server
		// -------------------------------------------------------------------------------
		[Server]
		public void AddCurrency(FixedCurrencyCost[] _cost, long _value)
		{

			foreach (FixedCurrencyCost cost in _cost)
			{
				int index = syncData.FindIndex(x => x.template == cost.template);
				
				if (index != -1)
				{
					CurrencySyncStruct entry = syncData[index];
					entry.value += cost.value * _value;
					syncData[index] = entry;
				}
				else
				{
					index = GetFreeSlot();
					if (index != -1)
						AddEntry(cost.template, index, cost.value * _value, 0);
				}
			}

		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================