namespace RPG_system.Layout
{
	/*
	 * @DOCTOR SOLO
	 * 
	 * This class sets up the entire scenario of the entire game...
	 * 
	 */


	internal static class Menu
	{

		public static void InterfacePlay()
		/*
		 * This Method is more important, it's the skelinton of all scene...
		 * 
		 */
		{
			Layout.Prohibited();

			while(true)
			{
				Layout.HomeMenu();
			}
		}


		
	}
}
