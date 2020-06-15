
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using OpenMMO;

namespace OpenMMO {

	// ===================================================================================
	// CurrencySyncStruct
	// ===================================================================================
	public partial struct CurrencySyncStruct
	{
	
		// -------------------------------------------------------------------------------
		public string name
		{
			get
			{
				return (template == null) ? "" : template.name;
			}
		}
		
		// -------------------------------------------------------------------------------
		public string Amount
		{
			get {
				return value.KiloFormat();
			}
		}
		
	}
	
}

// =======================================================================================