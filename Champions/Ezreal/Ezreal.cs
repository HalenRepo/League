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
			
			//Menu items for customisation here, such as min mana for harass etc.
			
			Game.OnUpdate += Game_OnUpdate;
			Drawing.OnDraw += Drawing_OnDraw;
		}
		
		public Game_OnUpdate(EventArgs args)
		{
			if (Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.Combo)
			{
				Combo();
			}
			
			if (Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.Mixed)
			{
				Harass();
			}
			
			if (Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.LaneClear)
			{
				LaneClear();
			}
		}
		
		public static void Combo()
		{
			if (Q.IsReady()) //if spell is ready
			{
				var target = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Physical); //Get target via SDK.
				
				if (t.IsValidTarget())
				{
					Q.Cast(t); //Cast at target.
				}
			}
		}
	}
}