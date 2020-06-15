
using UnityEngine;
using UnityEngine.UI;
using OpenMMO;
using OpenMMO.UI;
using OpenMMO.Network;

namespace OpenMMO.UI
{

	// ===================================================================================
	// UIPanelCurrencies
	// ===================================================================================
	public partial class UIPanelCurrencies : UIRoot
	{
		
		[Header("Currency Panel")]
		public UICurrencySlotHorizontal slotPrefab;
		[Tooltip("Limit the number of entries shown (0=disable)")]
		[Range(0,99)]public int maxEntries;
		
		protected PlayerCurrencyComponent currencyManager;

		// -------------------------------------------------------------------------------
		// ThrottledUpdate
		// -------------------------------------------------------------------------------
		protected override void ThrottledUpdate()
		{
			
			if (!networkManager || networkManager.state != NetworkState.Game)
				Hide();
			else
				Show();
			
			if (!localPlayer)
				return;
			
			if (currencyManager == null)
				currencyManager = localPlayer.GetComponent<PlayerCurrencyComponent>();
			
			for (int i = 0; i < root.transform.childCount; i++)
            	GameObject.Destroy(root.transform.GetChild(i).gameObject);
			
			int count = 0;
			
			foreach (CurrencySyncStruct _entry in currencyManager.GetEntries(true, SortOrder.Priority))
			{
				
				CurrencySyncStruct entry = _entry;
				
				GameObject go = GameObject.Instantiate(slotPrefab.gameObject);
            	go.transform.SetParent(root.transform, false);

				go.GetComponent<UICurrencySlotHorizontal>().Init(ref entry);
				
				count++;
				
				if (maxEntries > 0 && count > maxEntries)
					break;
				
			}
			
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================