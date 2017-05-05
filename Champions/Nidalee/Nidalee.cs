//Usings
using System;

namespace HalenAIO.Champions
{
	class Nidalee
	{
		public Nidalee
		{
			private static bool cougarForm;
			
			// private static readonly Spell Javelin = new Spell(SpellSlot.Q, 1500f);
			Javelin = new Spell(SpellSlot.Q, 1500f);
			Bushwack = new Spell(SpellSlot.W, 900f);
			Primalsurge = new Spell(SpellSlot.E, 650f);
			Takedown = new Spell(SpellSlot.Q, 200f);
			Pounce = new Spell(SpellSlow.W, 375f);
			AspectofCougar = new Spell(SpellSlot.R);
			
			private static List<Spell> HumanSpells = new List<Spell>();
			private static List<Spell> CatSpells = new List<Spell>();
			
			private static bool TargetHunted(Obj_AI_base target)
			{
				return target.HasBuff("nidaleepassivehunted", true); //For markings
			}
			
			//Menu
			
			Game.OnUpdate += Game_OnUpdate;
			Drawing.OnDraw += Drawing_OnDraw;

		}
		
		public Game_OnUpdate(EventArgs args)
		{
			cougarForm = Player.Spellbook.GetSpell(SpellSlot.Q).Name != "JavelinToss"; //Determine if in cougar by name of Q spell.
			var t = TargetSelector.GetTarget(1200, TargetSelector.DamageType.Magical);
			
			Autospells(); //KSing
			PrimalSurge(); //Nid heal
		}
		
		private static void Autospells()
		{
			//Typically for KSing code.
		}
		
		private static void PrimalSurge()
		{
			if (!cougarForm && !Primalsurge.IsReady())
				return;
			
			//You should put a menu check for healing here.
			
			if (Player.IsRecalling() || Player.InFountain() || Player.Spellbook.IsChanneling)
				return;
			
			
		}
		
	}
}