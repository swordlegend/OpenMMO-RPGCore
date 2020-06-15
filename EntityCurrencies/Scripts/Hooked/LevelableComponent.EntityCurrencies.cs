//by Fhiz
using System;
using System.Text;
using UnityEngine;
using Mirror;
using OpenMMO;

namespace OpenMMO {

	/// <summary>
	/// This partial section of LevelableComponent is responsible for upgrading the component by paying Currencies.
	/// </summary>
	public abstract partial class LevelableComponent : SyncableComponent
	{
	
		public LevelCurrencyCost[] upgradeCost;

		/// <summary>
		/// Checks if the component can be upgraded by checking max-level and cost.
		/// </summary>
		public bool CanUpgradeLevel()
		{
			return (level < maxLevel
					&& GetComponentInParent<PlayerCurrencyComponent>().CanPayCost(upgradeCost, level)
					);
		}
		
		/// <summary>
		/// Command from client to server: Upgrades the component if it can be upgraded.
		/// </summary>
		[Command]
		public void CmdUpgradeLevel()
		{
			if (CanUpgradeLevel())
				UpgradeLevel();
		}
		
		/// <summary>
		/// Server-side, actually upgrades the level of the component itself.
		/// </summary>
		[Server]
		protected virtual void UpgradeLevel()
		{
			GetComponentInParent<PlayerCurrencyComponent>().PayCost(upgradeCost, level);
			level++;
		}
		
	}

}