//Usings

namespace HalenAIO
{
	Class Program
	{
		//Supported champions
		public static string[] ChampList = { "Ezreal" };
		public static Spell Q, W, E, R;
		private static string DevLog = "(WIP)";
		
		public static Menu Config;
		
		public static Obj_AI_Hero Player = ObjectManager.Player;
		public static Orbwalking.Orbwalker Orbwalker;
		
		public static bool LaneClear = false;
		public static bool Harass = false;
		public static bool Combo = false;
		
		Game.OnUpdate += Game_OnGameUpdate;
		Drawing.OnDraw += Drawing_OnDraw;
		
		private static void Game_OnGameLoad(EventArgs args)
		{
			Config = new Menu("HalenAIO", "HalenAIO", true);
			
			//Determine champion
			switch (Player.ChampionName)
			{
				case "Ezreal":
				new Champions.Ezreal();
				break;
			}
			
			//Use SDK prediction here.
			
		}
		
	}
}