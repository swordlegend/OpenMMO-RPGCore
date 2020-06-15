
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Mirror;
using OpenMMO;

namespace OpenMMO {
	
	// ===================================================================================
	// SyncableComponent
	// ===================================================================================
	public partial class SyncableComponent
	{

		// -------------------------------------------------------------------------------
		// GetCapacity_AutoGenerateCurrency
		// -------------------------------------------------------------------------------
		public virtual long GetCapacity_AutoGenerateCurrency<T>(List<T> syncData, CurrencyTemplate _template, long _baseValue, int _level=0)
		{
		
			// -- check cache
			if (cacheData.CheckCache_AutoGenerateCurrency(_template))
				return cacheData.GetCache_AutoGenerateCurrency_Capacity(_template);
			
			// -- recalculate everything if cache is out of date
			long value = 0;
			
			foreach (ISyncableStruct<T> data in syncData.OfType<ISyncableStruct<T>>())
			{
				if (!data.Valid) continue;
				
				IterateableTemplate template = data as IterateableTemplate;
				
				foreach (GenerateCurrencyModifier modifier in template.autoGenerateCurrencyModifier)
					value += modifier.GetCapacityModifier(_template, (_level == 0) ? data.level : _level, _baseValue);

			}
			
			// -- update cache
			cacheData.SetCache_AutoGenerateCurrency_Capacity(_template, value);
			
			return value;
		}
		
		// -------------------------------------------------------------------------------
		// GetProduction_AutoGenerateCurrency
		// -------------------------------------------------------------------------------
		public virtual long GetProduction_AutoGenerateCurrency<T>(List<T> syncData, CurrencyTemplate _template, long _baseValue, int _level=0)
		{
		
			// -- check cache
			if (cacheData.CheckCache_AutoGenerateCurrency(_template))
				return cacheData.GetCache_AutoGenerateCurrency_Production(_template);
			
			// -- recalculate everything if cache is out of date
			long value = 0;
			
			foreach (ISyncableStruct<T> data in syncData.OfType<ISyncableStruct<T>>())
			{
				if (!data.Valid) continue;
				
				IterateableTemplate template = data as IterateableTemplate;
				
				foreach (GenerateCurrencyModifier modifier in template.autoGenerateCurrencyModifier)
					value += modifier.GetProductionModifier(_template, (_level == 0) ? data.level : _level, _baseValue);

			}
			
			return value;
		}
		
		// -------------------------------------------------------------------------------
		// GetDuration_AutoGenerateCurrency
		// -------------------------------------------------------------------------------
		public virtual float GetDuration_AutoGenerateCurrency<T>(List<T> syncData, CurrencyTemplate _template, float _baseValue, int _level=0)
		{
			
			// -- check cache
			if (cacheData.CheckCache_AutoGenerateCurrency(_template))
				return cacheData.GetCache_AutoGenerateCurrency_Duration(_template);
			
			// -- recalculate everything if cache is out of date
			float value = 0;
			
			foreach (ISyncableStruct<T> data in syncData.OfType<ISyncableStruct<T>>())
			{
				if (!data.Valid) continue;
				
				IterateableTemplate template = data as IterateableTemplate;
				
				foreach (GenerateCurrencyModifier modifier in template.autoGenerateCurrencyModifier)
					value += modifier.GetDurationModifier(_template, (_level == 0) ? data.level : _level, _baseValue);

			}
			
			return value;
		}
		
		// -------------------------------------------------------------------------------

	}

}

// =======================================================================================