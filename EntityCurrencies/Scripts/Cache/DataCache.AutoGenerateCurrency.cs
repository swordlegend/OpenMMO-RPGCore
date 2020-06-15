
using System;
using System.Collections.Generic;
using UnityEngine;
using OpenMMO;

namespace OpenMMO {
	
	// ===================================================================================
	// DataCache
	// ===================================================================================
	public partial class DataCache
	{
	
		// ==================== AUTO GENERATE CURRENCY - CACHE ===========================
		
		// -------------------------------------------------------------------------------
		// CheckCache_AutoGenerateCurrency
		// -------------------------------------------------------------------------------
		public bool CheckCache_AutoGenerateCurrency(CurrencyTemplate _template)
		{
		
			if (cacheEntries.TryGetValue(_template.hash, out DataCacheEntry entry))
				return (entry.CheckUpdateInterval(cacheUpdateInterval));
			else
				cacheEntries.Add(_template.hash, new DataCacheEntry());
			
			return false;
		}
		
		// ==================== AUTO GENERATE CURRENCY - CAPACITY ========================
		
		// -------------------------------------------------------------------------------
		// GetCache_AutoGenerateCurrency_Capacity
		// -------------------------------------------------------------------------------
		public long GetCache_AutoGenerateCurrency_Capacity(CurrencyTemplate _template)
		{
			
			if (cacheEntries.TryGetValue(_template.hash, out DataCacheEntry entry))
				return entry.autoGenerateCurrencyCapacity;
		
			return 0;	
		}
		
		// -------------------------------------------------------------------------------
		// SetCache_AutoGenerateCurrency_Capacity
		// -------------------------------------------------------------------------------
		public void SetCache_AutoGenerateCurrency_Capacity(CurrencyTemplate _template, long _value)
		{
			if (cacheEntries.TryGetValue(_template.hash, out DataCacheEntry entry))
				entry.autoGenerateCurrencyCapacity = _value;
		}
		
		// =================== AUTO GENERATE CURRENCY - PRODUCTION =======================
		
		// -------------------------------------------------------------------------------
		// GetCache_AutoGenerateCurrency_Production
		// -------------------------------------------------------------------------------
		public long GetCache_AutoGenerateCurrency_Production(CurrencyTemplate _template)
		{
		
			if (cacheEntries.TryGetValue(_template.hash, out DataCacheEntry entry))
				return entry.autoGenerateCurrencyProduction;
			
			return 0;	
		}
		
		// -------------------------------------------------------------------------------
		// SetCache_AutoGenerateCurrency_Production
		// -------------------------------------------------------------------------------
		public void SetCache_AutoGenerateCurrency_Production(CurrencyTemplate _template, long _value)
		{
			if (cacheEntries.TryGetValue(_template.hash, out DataCacheEntry entry))
				entry.autoGenerateCurrencyProduction = _value;
		}
		
		// ================== AUTO CURRENCY PRODUCTION - DURATION ========================
		
		// -------------------------------------------------------------------------------
		// GetCache_AutoGenerateCurrency_Duration
		// -------------------------------------------------------------------------------
		public float GetCache_AutoGenerateCurrency_Duration(CurrencyTemplate _template)
		{
			if (cacheEntries.TryGetValue(_template.hash, out DataCacheEntry entry))
				return entry.autoGenerateCurrencyDuration;

			return 0;	
		}
		
		// -------------------------------------------------------------------------------
		// SetCache_AutoGenerateCurrency_Duration
		// -------------------------------------------------------------------------------
		public void SetCache_AutoGenerateCurrency_Duration(CurrencyTemplate _template, float _value)
		{
			if (cacheEntries.TryGetValue(_template.hash, out DataCacheEntry entry))
				entry.autoGenerateCurrencyDuration = _value;
		}
		
		// -------------------------------------------------------------------------------

	}

}

// =======================================================================================