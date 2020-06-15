
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using OpenMMO;

namespace OpenMMO {
	
	public partial struct EventSyncStruct
	{
	
		// -------------------------------------------------------------------------------
		public string name
		{
			get { return (template == null) ? "" : template.name; }
		}
		
	}
	
}

// =======================================================================================
