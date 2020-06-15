
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using OpenMMO;
using OpenMMO.UI;

namespace OpenMMO.UI
{
	
	// ===================================================================================
	// UIAspectSlot
	// ===================================================================================
	public partial class UIAspectSlot : UIButton
	{
		
		[Header("UI Elements")]
		public Image image;
		public Image imageSelected;
		
		[Header("Used Images")]
		public Sprite unselectedImage;
		public Sprite selectedImage;
		
		protected AspectSyncStruct entry;
		protected bool selected;
		
		// -------------------------------------------------------------------------------
		// Init
		// -------------------------------------------------------------------------------
		public void Init(UIButtonGroup _buttonGroup, ref AspectSyncStruct _entry, bool _selected = false)
		{
			
			selected = _selected;
			
			entry = _entry;
			
			base.Init(_buttonGroup);
			
		}
		
		// -------------------------------------------------------------------------------
		// OnPressed
		// -------------------------------------------------------------------------------
		public override void OnPressed(bool deselect=false)
		{
		
			if (selected)
			{
				selected = false;
				imageSelected.sprite = unselectedImage;
				
			}
			else if (!deselect)
			{
				selected = true;
				imageSelected.sprite = selectedImage;
			}
			
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================