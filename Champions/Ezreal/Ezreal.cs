//Usings
using System;

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
			Config.SubMenu(Player.ChampionName).addItem(new MenuItem("stackTear", "Auto stack tear", true).SetValue(true));
			Config.SubMenu(Player.ChampionName).addItem(new MenuItem("autoW", "Auto W push", true).SetValue(true));
			Config.SubMenu(Player.ChampionName).addItem(new MenuItem("smartE", "Smart E", true).SetValue(true));
			
			
			Game.OnUpdate += Game_OnUpdate;
			Drawing.OnDraw += Drawing_OnDraw;
		}
		
		public Game_OnUpdate(EventArgs args)
		{
			if (Q.IsReady())
			{
				CheckQ();
			}
			
			if (W.IsReady() && Config.Item("autoW", true).GetValue<bool>())
			{
				CheckW();
			}
			
			if (E.IsReady())
			{
				CheckE();
			}
		}
		
		public void CheckQ()
		{
			if (Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.Combo) //You should add a mana check here according to menu.
			{
				var t = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Physical);
				if (t.IsValidTarget())
				{
					Q.Cast(t); //Either use SDK inbuilt prediction or custom prediction here.
					
					//Possible KS code here as well.
					
				}
			} else if (Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.Harass) //You should add a mana check here, as well as a target check (whether you want to harass a champion or not which is useful for bot) here.
			{
				Q.Cast(t); //Either use SDK inbuilt prediction or custom prediction here.
			} else if (Config.Item("stackTear", true).GetValue<bool>() && Utils.TickCount - Q.LastCastAttemptT > 4000 && !Player.hasBuff("Recall") && Player.Mana > Player.MaxMana * 0.95 && Orbwalker.ActiveMode == None && (Items.HasItem(3070) || Items.HasItem(3004)))
			{
				//Tear stacking. Check - if menu item is checked, if we can stack the tear (cooldown), if player's current mana is more than 95% of max, if they are not orbwalking and if they have a tear/manamune.
				Q.Cast(Player.Position.Extend(Game.CursorPos, 500)); //Cast to mousepos
			}
			
		}
		
		public void CheckW()
		{
			//Code for harassW can be here, but to me that's just dumb.
			
			
		}
		
		public void CheckE()
		{
			var t = TargetSelector.GetTarget(1300, TargetSelectorDamageType.Physical);
			
			if (Config.Item("smartE", true).GetValue<bool>())
			{
				//The below code needs to be used with the inbuilt SDK prediction or custom prediction.
				/*if (HeroManager.Enemies.Any(target => target.IsValidTarget(1000) && target.IsMelee && Player.Distance(Prediction.GetPrediction(target, 0.2f).CastPosition) < 250))
				{
					//Safe dash logic code here
					
				}
					*/
			}
		}
	}
}