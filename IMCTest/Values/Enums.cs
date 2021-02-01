using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IMCTest.Values
{
	public static class EnumHelper
	{
		public static List<string> GetState2LetterList()
			=> Enum.GetValues(typeof(State2LetterEnum)).Cast<State2LetterEnum>()
				.Select(x => x.ToString()).ToList();
	}

	public enum State2LetterEnum
	{
		AL,
		AK,
		AZ,
		AR,
		CA,
		CO,
		CT,
		DE,
		FL,
		GA,
		HI,
		ID,
		IL,
		IN,
		IA,
		KS,
		KY,
		LA,
		ME,
		MD,
		MA,
		MI,
		MN,
		MS,
		MO,
		MT,
		NE,
		NV,
		NH,
		NJ,
		NM,
		NY,
		NC,
		ND,
		OH,
		OK,
		OR,
		PA,
		RI,
		SC,
		SD,
		TN,
		TX,
		UT,
		VT,
		VA,
		WA,
		WV,
		WI,
		WY,
	}
}
