
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using OpenMMO;

namespace OpenMMO {
	
	// ===================================================================================
	// CurrencyTemplate
	// ===================================================================================
	[CreateAssetMenu(fileName = "New Currency", menuName = "Templates/New Currency", order = 999)]
	public partial class CurrencyTemplate : IterateableTemplate
	{
    
    	[Header("Costs")]
		public FixedCurrencyCost[] buyCost;
		public FixedCurrencyCost[] sellCost;
		
		[Header("Maximum Storage Capacity")]
    	public LinearGrowthInt capacity;
		
		[Header("Automatic Production")]
		public AutoGenerateCurrency autoProduction;

    	// -------------------------------------------------------------------------------
    	
		public static string _folderName = "";
		
		static CurrencyTemplateDictionary _data;
		
		// -------------------------------------------------------------------------------
        // data
        // -------------------------------------------------------------------------------
		public static ReadOnlyDictionary<int, CurrencyTemplate> data
		{
			get {
				CurrencyTemplate.BuildCache();
				return _data.data;
			}
		}
		
		// -------------------------------------------------------------------------------
        // BuildCache
        // -------------------------------------------------------------------------------
		public static void BuildCache(bool forced=false)
		{
			if (_data == null || forced)
				_data = new CurrencyTemplateDictionary(CurrencyTemplate._folderName);
		}
		
		// -------------------------------------------------------------------------------
        // OnEnable
        // -------------------------------------------------------------------------------
		public void OnEnable()
		{
			if (_folderName != folderName)
				_folderName = folderName;
			
			_data = null;
			
		}
		
		// -------------------------------------------------------------------------------
        // OnValidate
        // You can add custom validation checks here
        // -------------------------------------------------------------------------------
		public override void OnValidate()
		{
			base.OnValidate();
		}
		
		// -------------------------------------------------------------------------------

	}

}

// =======================================================================================