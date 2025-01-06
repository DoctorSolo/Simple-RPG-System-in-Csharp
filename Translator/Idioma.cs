namespace RPG_system.Translator
{
	/*
	 * @DOCTOR SOLO
	 * 
	 * 
	 * Here there is all text of all
	 * 
	 */
	internal static class Idioma
	{
		// Here for the user choose the language
		public static string ChoiseYourLanguage;
		public static string[] ChoiseIndioma;

		// Here is Menu
		public static string NameHomeMenu;
		public static string[] Menus;

		// This is all atributes name on RPG
		public static string[] _atributesName;

		// Here are layout name of atributes values
		public static string[] _infoAtributes;


		// Layout
		public static string[] _indiomaLayout;
		public static string[] _indChoiseRace;


		public static void SetLanguage(byte LanguageNumber=0)
		{
			switch(LanguageNumber)
			{
				default:
					ChoiseYourLanguage	= "Choise your language: ";
					ChoiseIndioma		= ["English", "Portuguese"];
					NameHomeMenu		= "RPG System in C#";
					Menus				= ["Play", "Language", "Exit"];

					_atributesName = [ "Level", "Weight", "Life", "Histamine", "Mana", "Inventor", "Phisical Defense", "Phisical Damage", 
						"Magical Damage", "Magical Defense", "Att Speed", "Strenght", "Critical Chance", "Critical Damage", "Mov Speed", 
						"Magic Proficience", "Magical Att"];
					_infoAtributes = ["Total Value", "Bonus", "Base Value", "For Level?"];

					_indiomaLayout = ["Enter your name: ", "WELCOME to the game ", "\nPRESS 'Z' TO CONTINUE", "Choise your race: "];
					_indChoiseRace = ["Human", "Ogro", "Spectral Knight"];
					break;

				case 1:
					ChoiseYourLanguage	= "Escolha a sua lingua: ";
					ChoiseIndioma		= ["Inglês", "Portugues"];
					NameHomeMenu		= "Sistema de RPG em C#";
					Menus				= ["Jogar", "Idioma", "Sair"];

					_atributesName = [ "Level", "Peso", "Vida", "Histamina", "Mana", "Inventor", "Defesa Fisica", "Dano Fisico", "Dano Magico",
						"Defesa Fisica", "Vel Ataque", "Força", "Chance de Critico", "Dano Critico", "Vel de Movimento", "Proficiencia Magica", 
						"Ataque Mágico"];
					_infoAtributes = ["Valor Total", "Bonus", "Valor Raiz", "Por Level?"];

					_indiomaLayout = ["Digite seu nome: ", "BEM VINDO AO GAME ", "\nPRESSIONE 'Z' PARA CONTINUAR", "Escolha sua raça: "];
					_indChoiseRace = ["Humano", "Ogro", "Cavaleiro Espectral"];
					break;
			}
		}

		// All variables used in atributes
		public static string _nameLevel				= _atributesName[0];
		public static string _nameWeight			= _atributesName[1];
		public static string _nameLife				= _atributesName[2];
		public static string _nameHistamine			= _atributesName[3];
		public static string _nameMana				= _atributesName[4];
		public static string _nameInventor			= _atributesName[5];
		public static string _namePhisicalDe		= _atributesName[6];
		public static string _namePhisicalDa		= _atributesName[7];
		public static string _nameMagicalDa			= _atributesName[8];
		public static string _nameMagicalDe			= _atributesName[9];
		public static string _nameAttSpeed			= _atributesName[10];
		public static string _nameStrenght			= _atributesName[11];
		public static string _nameCriticalChance	= _atributesName[12];
		public static string _nameCriticalDa		= _atributesName[13];
		public static string _nameMovSpeed			= _atributesName[14];
		public static string _nameMagicP			= _atributesName[15];
		public static string _nameMagicalAtt		= _atributesName[16];

		// All variables used in layout in atributes
		public static string _InfoNameTotalValue	= _infoAtributes[0];
		public static string _InfoNameBonus			= _infoAtributes[1];
		public static string _infoNameBaseValue		= _infoAtributes[2];
		public static string _InfoNameForLevel		= _infoAtributes[3];


		// Layout
		public static string _indYourName		= _indiomaLayout[0];
		public static string _welcomeMessage	= _indiomaLayout[1];
		public static string _pressZText		= _indiomaLayout[2];
		public static string _choiseYourRaceT	= _indiomaLayout[3];
	}
}
