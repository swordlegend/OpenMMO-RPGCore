
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using OpenMMO;

namespace OpenMMO {

	// ===================================================================================
	// CurrencySyncStruct
	// ===================================================================================
	[System.Serializable]
	public partial struct CurrencySyncStruct : ISyncableStruct<CurrencyTemplate>
	{
	
		public int 		hash;
    	public int		slot;
 		public long		timeStamp;
		public long		value;
		
		public long		modifierCapacity;
		public long		modifierProduction;
		public float	modifierDuration;
		
		// -------------------------------------------------------------------------------
		// CurrencySyncStruct (Constructor)
		// -------------------------------------------------------------------------------
		public CurrencySyncStruct(CurrencyTemplate template, int _slot, long _value, long _timeStamp)
		{
			hash 				= (template == null) ? 0 : template.hash;
			slot				= _slot;
			timeStamp			= _timeStamp == 0 ? DateTime.UtcNow.Ticks : Math.Max(0,_timeStamp);
			value 				= Math.Max(0,_value);
			
			modifierCapacity 	= 0;
			modifierProduction 	= 0;
			modifierDuration 	= 0;
			
		}
		
		// -------------------------------------------------------------------------------
		// -------------------------------------------------------------------------------
    	public bool Valid
    	{
    		get { return hash != 0; }
    	}
		
		// -------------------------------------------------------------------------------
		// -------------------------------------------------------------------------------
		public CurrencyTemplate template
		{
			get
			{
				if (hash == 0) return null;
				
				if (!CurrencyTemplate.data.ContainsKey(hash))
					throw new KeyNotFoundException("[Missing] CurrencyTemplate not found in Resources: " + hash);
				return CurrencyTemplate.data[hash];
			}
		}   
    	
    	// -------------------------------------------------------------------------------
		// -------------------------------------------------------------------------------
		public int level
		{
			get {
				return template.level;
			}
		}
    	
    	// -------------------------------------------------------------------------------
    	// Update
    	// Update the currency amount in relation to the time passed since last update
    	// Also takes production power and maximum capacity into account
    	// @Server
    	// -------------------------------------------------------------------------------
    	public void Update(GameObject player)
    	{
    		
    		int _duration 	= GetDuration(player);
    		
    		if (_duration <= 0) return;
    		
    		timeStamp 	= DateTime.UtcNow.Ticks;
    		
    		long _production = GetProduction(player, _duration);
    		
    		if (value + _production > GetCapacity(player))
    			_production = GetCapacity(player) - value;
			
			if (_production <= 0) return;
			
    		value 		+= _production;

#if _STATISTICS
    		player.GetComponent<PlayerStatisticComponent>().TrackStatistic(template.name, _production, Constants.StatProduction);
#endif

    	}
    	
    	// -------------------------------------------------------------------------------
    	// CanAdd
    	//
    	// @Server / @Client
    	// -------------------------------------------------------------------------------
    	public bool CanAdd(long amount=1)
    	{
    		return true;
    	}
    	
    	// -------------------------------------------------------------------------------
    	// Add
    	// Add 'amount' to this currency (separate function for tracking/events later)
    	// @Server
    	// -------------------------------------------------------------------------------
    	public void Add(long amount=1)
    	{
    		value += amount;
    	}
    	
    	// -------------------------------------------------------------------------------
    	// CanRemove
    	// Can we deduct amount 'value' from this currency?
    	// @Server / @Client
    	// -------------------------------------------------------------------------------
		public bool CanRemove(long amount=1)
		{
			
				foreach (FixedCurrencyCost cost in template.sellCost)
				{
					if (cost.Valid && Valid && value > 0)
						return true;
				}
				return false;
			
		}
		
    	// -------------------------------------------------------------------------------
    	// Remove
    	// Deduct amount 'value' from this currency (separate function for tracking/events later)
    	// @Server
    	// -------------------------------------------------------------------------------
		public void Remove(long amount=1)
		{
			value -= amount;
		}
		
    	// -------------------------------------------------------------------------------
    		
	}
	
	public class SyncListCurrencySyncStruct : SyncList<CurrencySyncStruct> { }
	
}

// =======================================================================================