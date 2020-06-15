
using System;
using System.Text;
using UnityEngine;
using OpenMMO;

namespace OpenMMO {

	// -----------------------------------------------------------------------------------
	// LevelCurrencyCost
	// currency cost that scales with level
	// -----------------------------------------------------------------------------------
	[System.Serializable]
	public partial class LevelCurrencyCost : CurrencyCost
	{
		public LinearGrowthLong value;
		
		public override bool Valid
		{
			get { return (template != null && value.Get(1) != 0); }
		}
		
	}
	
	// -----------------------------------------------------------------------------------
	// FixedCurrencyCost
	// fixed value currency cost
	// -----------------------------------------------------------------------------------
	[System.Serializable]
	public partial class FixedCurrencyCost : CurrencyCost
	{
		public long value;
		
		public override bool Valid
		{
			get { return (template != null && value != 0); }
		}
		
	}
	
	// -----------------------------------------------------------------------------------
	// VirtualCurrencyCost
	// Basic currency cost tied to a currency template
	// -----------------------------------------------------------------------------------
	[System.Serializable]
	public partial class CurrencyCost
	{
		public CurrencyTemplate template;
		
		public virtual bool Valid
		{
			get { return (template != null); }
		}
		
	}
	
	// -----------------------------------------------------------------------------------
	
}