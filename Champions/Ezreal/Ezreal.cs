//Usings

namespace HalenAIO.Champions
{
	class Ezreal
	{
		public Ezreal()
		{
			Q = new Spell(SpellSlot.Q, 1170);
			W = new Spell(SpellSlot.W, 950);
			E = new Spell(SpellSlot.E, 475);
			R = new Spell(SpellSlot.R, 3000f);
			
			Q.SetSkillshot(0.25f, 60f, 2000f, true, SkillshotType.SkillshotLine);
            W.SetSkillshot(0.25f, 80f, 1600f, false, SkillshotType.SkillshotLine);
			R.SetSkillshot(1.1f, 160f, 2000f, false, SkillshotType.SkillshotLine);
			
			//Menu items for customisation here.
			
			Game.OnUpdate += Game_OnUpdate;
			Drawing.OnDraw += Drawing_OnDraw;
		}
	}
}