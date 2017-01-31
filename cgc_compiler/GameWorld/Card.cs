using System;

namespace cgc_compiler
{
	public enum Card
	{
		Peasant,	// Knight
//		[He is a single-target, melee troop with moderate-high hitpoints and moderate damage.]

		Sharpshooters,	// Archers
//		[It spawns two single-target, medium-ranged Archers with both medium hitpoints and damage.]

		Halfling,	// Bomber
//		[It is an area damage, medium-ranged troop with low hitpoints and moderate damage.]

		Gogs,	// Spear goblins
//		[It spawns three single-target, medium-ranged Goblins with low hitpoints and very low damage.]

		Skeletons,	// Goblins
//		[It spawns three fast, melee Goblins with low hitpoints and medium damage.]

		Elemental,	// Giant
//		[He is a building-targeting, melee troop with high hitpoints and moderate damage.]

		Archer,		// Musketeer
//		[She is a single-target, medium-ranged troop with both moderate hitpoints and damage.]

		Halebardier,	// Pekka
//		[He is a single-target, melee troop with moderate hitpoints and high damage.]

		Crusader	// Valkyrie
//		[She is an area damage, melee troop with high hitpoints and moderate damage.]
	}
}
