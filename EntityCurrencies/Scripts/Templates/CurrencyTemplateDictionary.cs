
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
	// CurrencyTemplateDictionary
	// ===================================================================================
	public partial class CurrencyTemplateDictionary
	{
		
		public readonly ReadOnlyDictionary<int, CurrencyTemplate> data;
		
		// -------------------------------------------------------------------------------
		public CurrencyTemplateDictionary(string folderName="")
		{
			List<CurrencyTemplate> templates = Resources.LoadAll<CurrencyTemplate>(folderName).ToList();
			
			if (templates.HasDuplicates())
				DebugManager.LogWarning("[Warning] Skipped loading due to duplicate(s) in Resources subfolder: " + folderName);
			else
				data = new ReadOnlyDictionary<int, CurrencyTemplate>(templates.ToDictionary(x => x.hash, x => x));
		}

		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================
