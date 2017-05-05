//Usings
using System;

namespace HalenAIO.Champions
{
	class Nidalee
	{
		public Nidalee
		{
			// private static readonly Spell Javelin = new Spell(SpellSlot.Q, 1500f);
			Javelin = new Spell(SpellSlot.Q, 1500f);
			Bushwack = new Spell(SpellSlot.W, 900f);
			PrimalSurge = new Spell(SpellSlot.E, 650f);
			Takedown = new Spell(SpellSlot.Q, 200f);
			Pounce = new Spell(SpellSlow.W, 375f);
			AspectofCougar = new Spell(SpellSlot.R);
			
			private static List<Spell> HumanSpells = new List<Spell>();
			private static List<Spell> CatSpells = new List<Spell>();
			
			private static bool TargetHunted(Obj_AI_base target)
			{
				return target.HasBuff("nidaleepassivehunted", true);
			}

		}
	}
}