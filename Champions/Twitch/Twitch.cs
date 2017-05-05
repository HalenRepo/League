//Usings
using System;

namespace HalenAIO.Champions
{
	class Twitch
	{
		private int count = 0, countE = 0;
		private float grabTime = Game.Time;
		
		public Twitch
		{
			Q = new Spell(SpellSlot.Q, 0);
			W = new Spell(SpellSlot.W, 950);
			E = new Spell(SpellSlot.E, 1200);
			R = new Spell(SpellSlot.R, 975);
			
			W.SetSkillshot(0.25f, 100f, 1410f, false, SkillshotType.SkillshotCircle);
			
			Game.OnUpdate += Game_OnUpdate;
			Drawing.OnDraw += Drawing_OnDraw;
			
			Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
			Spellbook.OnCastSpell += Spellbook_OnCastSpell;
		}
	}
}