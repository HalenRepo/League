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
			
			private static bool TargetHunted(Obj_AI_Base target)
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
			
			if (Player.HasBuff("Takedown"))
			{
				if (target.IsValidTarget(Takedown.Range))
				{
					if (Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.Combo && CougarForm)
					{
						//Me.IssueOrder(GameObjectOrder.AttackUnit, _target);
						//Attack unit
					}
				}
			}
			
			/*if (_mainMenu.Item("usecombo").GetValue<KeyBind>().Active)
                UseCombo(_target);
			*/
			
			//This may or may not be the same. The above Kurisu uses looks for a keypress rather than the orbwalker mode.
			if (Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.Combo)
			{
				UseCombo(target);
			}
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
		
		private static void UseCombo((Obj_AI_Base target)
		{
			//Cougar combo
			if (cougarForm && target.IsValidTarget(Javelin.Range)) //So you don't check the combos on ALL enemies, only those within spear range
			{
				//use inventory items..? maybe not necessary
				
				//Check if takedown is ready on unit
				
				#region Takedown (Cougar Q)
				//might be necessary to add a menu check here if you want full customization. Does user want to use cougar q?
				if (Takedown.IsReady() && target.Distance(Player.ServerPosition, true) <= Takedown.RangeSqr + 150*150)
				{
					Takedown.CastOnUnit(Player); //this looks new... SDK?
					//The below to probably send an auto attack to enemy, because this is cougar q.
					  if (Orbwalker.ActiveMode == Orbwalker.OrbwalkingMode.Combo)
                        Player.IssueOrder(GameObjectOrder.AttackUnit, target);
				}
				#endregion
				
				#region Pounce (Cougar W)
				//Check if pounce ready
				//Maybe add a menu check here. User customization - does user want to use pounce in cougar combo?
				if (Pounce.IsReady() && (target.Distance(Player.ServerPosition, true) > 200*200 || CougarDamage(target) >= target.Health)) //CougarDamage is another method to be created.
				{
					//Check to see if the unit Nidalee is pouncing on is "hunted"/marked, then use takedown if possible! 
					//Single ampersand '&' BITWISE operator!
					if (TargetHunted(target) & target.Distance(Player.ServerPosition, true) <= 750*750)
					{
						if (Takedown.IsReady())
						{
							//Then use takedown then pounce for best combo
							Takedown.CastOnUnit(Player);
							
						}
							Pounce.Cast(target.ServerPosition);
					} else if (target.Distance(Player.ServerPosition, true) <= 400*400)
						{
							if (Takedown.IsReady())
							{
								Takedown.CastOnUnit(Player);
							}
							Pounce.Cast(target.ServerPosition);
						}
				}
				#endregion
				
				#region Swipe (Cougar E)
				//Check if swipe is ready (no prediction)
				//Maybe check for menu. Does user want to use cougar e?
				if (Swipe.IsReady())
                {
                    if (target.Distance(Player.ServerPosition, true) <= Swipe.RangeSqr)
                    {
                        if (!Pounce.IsReady() || NotLearned(Pounce)) //NotLearned is another method we need to make. You'd assume IsReady() would account for this...
                            Swipe.Cast(target.ServerPosition);
                    }
                }
				#endregion
				
				#region COUGAR to HUMAN checks
				//force transform if q ready and no collision 
				//Maybe add a check here to see if user wants to auto transform?
				//Check if can change forms...
				if (!AspectofCougar.IsReady())
				{
					return;
				}
				
				//OR Don't transform and stay cougar if target killable with combo
				if (target.Health <= CougarDamage(target) && target.Distance(Player.ServerPosition, true) <= Pounce.RangeSqr)
				{
					return;
				}
				
				//If spear is likely to hit via prediction, then switch forms!
				var prediction = Javelin.GetPrediction(target);
                if (prediction.Hitchance >= HitChance.Medium && !Pounce.IsReady())
				{
					Aspectofcougar.Cast();
				}
				#endregion
				
				#region COUGAR to HUMAN if AA Killable and COUGAR skills on CD
				//Switch to human form if killable with aa and cougar skills not available
				if (!Pounce.IsReady() && !Swipe.IsReady() && !Takedown.IsReady())
                {
                    if (target.Distance(Player.ServerPosition, true) > Takedown.RangeSqr && CanKillAA(target)) //CanKillAA() method
                    {
						//Maybe also add a check for menu. Does user want auto transform?
                        if (target.Distance(Player.ServerPosition, true) <= Math.Pow(Me.AttackRange + 50, 2))
                        {
                            if (Aspectofcougar.IsReady())
                                Aspectofcougar.Cast();
                        }
                    }
                }
				#endregion
				
				#region SPEAR (Human Q)
				//Human Q
				if (!CougarForm && target.IsValidTarget(Javelin.Range)
				{
					var qTarget = TargetSelector.GetTargetNoCollision(Javelin);
					if (qTarget != null && Javelin.IsReady()) //if there is actually a target you can hit a spear on with no collision
					{
						Javelin.Cast(qTarget); //Kurisu added a hitchance slider and checked to see if the chance was enough to make it worth casting
					}
				}
				
				#endregion
				
				//Human combo
				if (!CougarForm && target.IsValidTarget(Javelin.Range))
				{
					//Switch to COUGAR if target hunted or can kill target
					
				}
			}
		}
		
	}
}