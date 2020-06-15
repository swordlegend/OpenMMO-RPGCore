
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using OpenMMO;

namespace OpenMMO {
	
	// ===================================================================================
	// AspectTemplate
	// ===================================================================================
	[CreateAssetMenu(fileName = "New Aspect", menuName = "Templates/New Aspect", order = 999)]
	public partial class AspectTemplate : IterateableTemplate
	{

    	[Header("Availability Settings")]
    	public bool hidden;
    	public bool unique;
    	public ArchetypeTemplate[] archetypesOnly;
    	
    	// -------------------------------------------------------------------------------
    	
		public static string _folderName = "";
		
		static AspectTemplateDictionary _data;
		
		// -------------------------------------------------------------------------------
        // data
        // -------------------------------------------------------------------------------
		public static ReadOnlyDictionary<int, AspectTemplate> data
		{
			get {
				AspectTemplate.BuildCache();
				return _data.data;
			}
		}
		
		// -------------------------------------------------------------------------------
        // BuildCache
        // -------------------------------------------------------------------------------
		public static void BuildCache(bool forced=false)
		{
			if (_data == null || forced)
				_data = new AspectTemplateDictionary(AspectTemplate._folderName);
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