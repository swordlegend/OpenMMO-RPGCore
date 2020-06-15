
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using OpenMMO;

namespace OpenMMO {
	
	// ===================================================================================
	// PlayerAspectComponent
	// ===================================================================================
	public partial class PlayerAspectComponent
	{
	
		// -------------------------------------------------------------------------------
		// ValidateAspect
		
		// Note: static allows this function to be used without a active player
		// (e.g. during character creation)
		// -------------------------------------------------------------------------------
		public static bool ValidateAspect(AspectTemplate template, List<AspectSyncStruct> list)
		{
			return true;
		}
		
		// -------------------------------------------------------------------------------
		// ValidateAspects
		
		// Note: static allows this function to be used without a active player
		// (e.g. during character creation)
		// -------------------------------------------------------------------------------
		public static bool ValidateAspects(List<AspectSyncStruct> list)
		{
			return true;
		}
		
		
		// -------------------------------------------------------------------------------
		public static List<AspectSyncStruct> AddToList(List<AspectSyncStruct> list, List<AspectTemplate> addList)
		{
		
			foreach (AspectTemplate template in addList)
			{
				if (!list.Any(x => x.hash == template.hash))
					list.Add(new AspectSyncStruct(template));
			}
			
			return list;
		}
		
		// -------------------------------------------------------------------------------
		public static List<AspectSyncStruct> RemoveFromList(List<AspectSyncStruct> list, List<AspectTemplate> removeList)
		{
			
			for (int i = 0; i < list.Count; i++)
			{
				if (removeList.Any(x => x.hash == list[i].hash))
					list.RemoveAt(i);
			}
		
			return list;
		}
		
		// -------------------------------------------------------------------------------
	
	}
}

// =======================================================================================