using System;

namespace DBToExcel
{
	public class TagProperty
	{
		private string myName;

		private string myValue;

		public string Name
		{
			get
			{
				return this.myName;
			}
			set
			{
				this.myName = value;
			}
		}

		public string Value
		{
			get
			{
				return this.myValue;
			}
			set
			{
				this.myValue = value;
			}
		}

		public TagProperty()
		{
			this.myName = "";
			this.myValue = "";
		}

		public TagProperty(string s)
		{
			string[] array = s.Split(new char[]
			{
				':'
			});
			bool flag = array.GetUpperBound(0) == 1;
			if (flag)
			{
				char[] trimChars = new char[]
				{
					'{',
					'}',
					' ',
					'=',
					'\''
				};
				this.myName = array[0].Trim(trimChars);
				this.myValue = array[1].Trim(trimChars);
			}
			else
			{
				this.myName = "";
				this.myValue = "";
			}
		}
	}
}
