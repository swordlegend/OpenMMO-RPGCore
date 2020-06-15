
using OpenMMO;
using OpenMMO.Database;
using System;
using SQLite;

namespace OpenMMO.Database
{

	// -------------------------------------------------------------------------------
	// TablePlayerCurrencies
	// -------------------------------------------------------------------------------
	partial class TablePlayerCurrencies
	{
		public string 	owner 		{ get; set; }
		public string 	name 		{ get; set; }
		public int		slot		{ get; set; }
		public long 	value 		{ get; set; }
		public long 	timeStamp 	{ get; set; }
	}

	// -----------------------------------------------------------------------------------
	
}

// =======================================================================================