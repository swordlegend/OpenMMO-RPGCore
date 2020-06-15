// =======================================================================================
// UICurrencySlotHorizontal
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;
using OpenMMO;
using OpenMMO.UI;

namespace OpenMMO.UI
{
	
	// ===================================================================================
	// 
	// ===================================================================================
	public partial class UICurrencySlotHorizontal : UISlot<CurrencySyncStruct>
	{
		
		protected PlayerCurrencyComponent currencyManager;
		
		// -------------------------------------------------------------------------------
		// Init
		// -------------------------------------------------------------------------------
		public override void Init(ref CurrencySyncStruct _entry)
		{
			
			base.Init(ref _entry);
			
			currencyManager 		= localPlayer.GetComponent<PlayerCurrencyComponent>();
			
			if (entry.Valid)
			{
			
				if (backgroundImage)
					backgroundImage.sprite 	= entry.template.backgroundIcon;
			
				if (borderImage)
					borderImage.sprite 		= entry.template.rarity.borderImage;
			
			
				image.sprite 	= entry.template.smallIcon;
				
				textValue.text	= entry.value + "/" + entry.GetCapacity(localPlayer);
			
			}
			
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================