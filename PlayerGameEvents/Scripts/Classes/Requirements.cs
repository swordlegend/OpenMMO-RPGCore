
using System;
using System.Text;
using UnityEngine;
using OpenMMO;

namespace OpenMMO {
	
	// -----------------------------------------------------------------------------------
	public partial class Requirements
	{
		public EventRequirement[] 		eventRequirements;
	}
	
	// -----------------------------------------------------------------------------------
	[System.Serializable]
	public partial class EventRequirement
	{
		public GameEventTemplate template;
		public int level;
	}
	
	// -----------------------------------------------------------------------------------
	
}

// =======================================================================================