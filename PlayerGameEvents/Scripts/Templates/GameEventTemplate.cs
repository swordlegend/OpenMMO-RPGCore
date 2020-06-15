
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using OpenMMO;
using OpenMMO.Debugging;

namespace OpenMMO {

	// ===================================================================================
	// GameEventTemplate
	// ===================================================================================
	[CreateAssetMenu(fileName = "New GameEvent", menuName = "Templates/New GameEvent", order = 999)]
	public partial class GameEventTemplate : IterateableTemplate
	{
	
		[Header("Active Timespan")]
		[Tooltip("MM/DD/YYYY HH:MM")]
		public UDateTime startDate;
		[Tooltip("MM/DD/YYYY HH:MM")]
		public UDateTime endDate;
		
		// -------------------------------------------------------------------------------
    	
		public static string _folderName = "";
    	
		static GameEventTemplateDictionary _data;
		
		// -------------------------------------------------------------------------------
        // data
        // -------------------------------------------------------------------------------
		public static ReadOnlyDictionary<int, GameEventTemplate> data
		{
			get {
				GameEventTemplate.BuildCache();
				return _data.data;
			}
		}
		
		// -------------------------------------------------------------------------------
        // BuildCache
        // -------------------------------------------------------------------------------
		public static void BuildCache(bool forced=false)
		{
			if (_data == null || forced)
				_data = new GameEventTemplateDictionary(GameEventTemplate._folderName);
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