
using OpenMMO;
using OpenMMO.UI;
using OpenMMO.Network;
using UnityEngine;
using UnityEngine.UI;

namespace OpenMMO.UI
{

	// ===================================================================================
	// UIWindowPlayerCreateAspect
	// ===================================================================================
	public partial class UIWindowPlayerCreateAspect : UIRoot
	{
	
		
		[Header("Prefab")]
		public UIAspectSlot slotPrefab;
		public UIButtonGroup buttonGroup;
		
		[Header("Content")]
		public Transform contentViewport;
		
		protected int index = -1;
		
		// -------------------------------------------------------------------------------
		// ThrottledUpdate
		// -------------------------------------------------------------------------------
		protected override void ThrottledUpdate()
		{
			
			
			
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================