
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
	// AspectTemplateDictionary
	// ===================================================================================
	public partial class AspectTemplateDictionary
	{
		
		public readonly ReadOnlyDictionary<int, AspectTemplate> data;
		
		// -------------------------------------------------------------------------------
		public AspectTemplateDictionary(string folderName="")
		{
			List<AspectTemplate> templates = Resources.LoadAll<AspectTemplate>(folderName).ToList();
			
			if (templates.HasDuplicates())
				DebugManager.LogWarning("[Warning] Skipped loading due to duplicate(s) in Resources subfolder: " + folderName);
			else
				data = new ReadOnlyDictionary<int, AspectTemplate>(templates.ToDictionary(x => x.hash, x => x));
		}

		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================
