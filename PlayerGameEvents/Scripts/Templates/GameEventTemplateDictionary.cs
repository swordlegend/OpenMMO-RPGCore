
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;
using OpenMMO;
using OpenMMO.Debugging;

namespace OpenMMO
{

	// ===================================================================================
	// GameEventTemplateDictionary
	// ===================================================================================
	public partial class GameEventTemplateDictionary
	{
		
		public readonly ReadOnlyDictionary<int, GameEventTemplate> data;
		
		// -------------------------------------------------------------------------------
		public GameEventTemplateDictionary(string folderName="")
		{
			List<GameEventTemplate> templates = Resources.LoadAll<GameEventTemplate>(folderName).ToList();
			
			if (templates.HasDuplicates())
				DebugManager.LogWarning("[Warning] Skipped loading due to duplicate(s) in Resources subfolder: " + folderName);
			else
				data = new ReadOnlyDictionary<int, GameEventTemplate>(templates.ToDictionary(x => x.hash, x => x));
		}

		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================
