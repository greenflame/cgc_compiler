﻿using System;
using System.Linq;

namespace cgc_compiler
{
	public class Skeleton : Troop
	{
		private const int xp = 80;
		private const float speed = 2;
		private const float deployTime = 1;

		// Sword - melee single
		private const float damage = 50;
		private const float cooldown = 1.1f;
		private const float range = 0.8f;

		public Skeleton(GameWorld world, Player owner, float position)
			: base(world, owner, position, xp, speed, deployTime)
		{
		}

		public override Weapon MakeWeapon()
		{
			return new SingleTargetMeleeWeapon(this, damage, cooldown, range);
		}

		public override GameObject FindTarget()
		{
			return TargetSelectors.ClosestDamagableDeployedEnemy(this);
		}
	}
}