
using OpenMMO;
using OpenMMO.Database;
using System;
using SQLite;

namespace OpenMMO.Database
{

	// -------------------------------------------------------------------------------
	// TablePlayerAspects
	// -------------------------------------------------------------------------------
	partial class TablePlayerAspects
	{
		[PrimaryKey]
		public string 	player 	{ get; set; }
		public string 	name 	{ get; set; }
	}
	
	// -----------------------------------------------------------------------------------
	
}

// =======================================================================================