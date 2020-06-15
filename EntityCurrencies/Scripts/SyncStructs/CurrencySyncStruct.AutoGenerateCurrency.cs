
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using OpenMMO;

namespace OpenMMO {

	// ===================================================================================
	// CurrencySyncStruct
	// ===================================================================================
	public partial struct CurrencySyncStruct
	{
		
		// -------------------------------------------------------------------------------
		// GetBaseDuration
		// -------------------------------------------------------------------------------
		public float GetBaseDuration(GameObject player)
		{
    		int _level					= 0;
    		_level 						= player.GetComponent<PlayerComponent>().level;
    		return template.autoProduction.duration.Get(_level);
		}
		
		// -------------------------------------------------------------------------------
		// GetDuration
    	// -------------------------------------------------------------------------------
    	public int GetDuration(GameObject player)
    	{
    		float _baseValue = GetBaseDuration(player);
    		return _baseValue > 0 ? Convert.ToInt32(DateTime.UtcNow.Subtract(new DateTime(timeStamp)).TotalSeconds / ( _baseValue +  modifierDuration)) : 0;
    	}
    	
    	// -------------------------------------------------------------------------------
    	// GetBaseCapacity
		// -------------------------------------------------------------------------------
		public long GetBaseCapacity(GameObject player)
		{
    		int _level					= 0;
    		_level 						= player.GetComponent<PlayerComponent>().level;
    		return template.capacity.Get(_level);
		}
    	
    	// -------------------------------------------------------------------------------
    	// GetCapacity
    	// -------------------------------------------------------------------------------
    	public long GetCapacity(GameObject player)
    	{
    		long _baseValue = GetBaseCapacity(player);    		
    		return _baseValue + modifierCapacity;
    	}
    	
    	// -------------------------------------------------------------------------------
    	// GetBaseProduction
		// -------------------------------------------------------------------------------
		public long GetBaseProduction(GameObject player)
		{
			int _level = 0;
    		_level = player.GetComponent<PlayerComponent>().level;
    		return template.autoProduction.amount.Get(_level);		
		}
    	
    	// -------------------------------------------------------------------------------
    	// GetProduction
    	// -------------------------------------------------------------------------------
    	public long GetProduction(GameObject player, int _intervals=0)
    	{
    		long _baseValue = GetBaseProduction(player);
    		return Convert.ToInt64(_intervals * (_baseValue + modifierProduction) );
    	}
    	
    	// -------------------------------------------------------------------------------
    	
	}
	
}

// =======================================================================================