using System;
using System.Security.Cryptography;
using System.Text;

namespace Windsor.Commons.Core
{

    /// <summary>
    /// Generates random strings.  Derived from the PasswordGenerator Codeplex project at: http://www.codeproject.com/KB/cs/pwdgen.aspx
    /// </summary>
    public class RandomStringGenerator
    {
        public RandomStringGenerator() 
		{
			Minimum               = DefaultMinimum;
			Maximum               = DefaultMaximum;
			ConsecutiveCharacters = true;
			RepeatCharacters      = true;
			ExcludeSymbols        = false;

            // Default exclusions.  See for reasons why, see http://www.crockford.com/wrmg/base32.html
            // In addition to crockford's list, we'll add '#' to avoid issues with ajax calls
            // In addition adding <, > to avoid "A potentially dangerous Request.QueryString value was detected from the client"
            // In addition adding & and + as + turned into a space and & cut off itself and everything after it.
			Exclusions            = "ILOU10l#<>&+";
		}		
		
		protected int GetCryptographicRandomNumber(int lowerBound, int upperBound)
		{   
			// Assumes lBound >= 0 && lBound < uBound

			// returns an int >= lBound and < uBound

			uint urndnum;   
			byte[] rndnum = new Byte[4];
            // test for degenerate case where only lBound can be returned
            if (lowerBound == upperBound - 1)  
				return lowerBound;
															  
			uint xcludeRndBase = (uint.MaxValue -
				(uint.MaxValue%(uint)(upperBound-lowerBound)));   
			
			do 
			{      
				rng.GetBytes(rndnum);      
				urndnum = System.BitConverter.ToUInt32(rndnum,0);       
			} while (urndnum >= xcludeRndBase);   
			
			return (int)(urndnum % (upperBound-lowerBound)) + lowerBound;
		}

		protected char GenerateCharacter()
		{            
			int upperBound = pwdCharArray.GetUpperBound(0);

			if ( ExcludeSymbols )
				upperBound = UBoundDigit;

			int randomCharPosition = GetCryptographicRandomNumber(
				pwdCharArray.GetLowerBound(0), upperBound);

			char randomChar = pwdCharArray[randomCharPosition];

			return randomChar;
		}
		
        /// <summary>
        /// Generates a random string
        /// </summary>
        /// <returns>Random string</returns>
		public string Generate()
		{
			// Pick random length between minimum and maximum   

			int pwdLength = GetCryptographicRandomNumber(this.Minimum,
				this.Maximum);

			StringBuilder pwdBuffer = new StringBuilder();
			pwdBuffer.Capacity = this.Maximum;

			// Generate random characters

			char lastCharacter, nextCharacter;

			// Initial dummy character flag

			lastCharacter = nextCharacter = '\n';

			for ( int i = 0; i < pwdLength; i++ )
			{
                nextCharacter = GenerateCharacter(pwdBuffer, lastCharacter, nextCharacter);
				pwdBuffer.Append(nextCharacter);
				lastCharacter = nextCharacter;
			}

            return pwdBuffer != null ? pwdBuffer.ToString() : string.Empty;
		}

        private char GenerateCharacter(StringBuilder pwdBuffer, char lastCharacter, char nextCharacter)
        {
            // Get a candidate character
            nextCharacter = GenerateCharacter();

            if (!ConsecutiveCharacters)
                while (lastCharacter == nextCharacter)
                    nextCharacter = GenerateCharacter();

            if (!RepeatCharacters) {
                string temp = pwdBuffer.ToString();
                int duplicateIndex = temp.IndexOf(nextCharacter);
                while (duplicateIndex != -1) {
                    nextCharacter = GenerateCharacter();
                    duplicateIndex = temp.IndexOf(nextCharacter);
                }
            }

            if (Exclusions != null)
                while (Exclusions.IndexOf(nextCharacter) != -1)
                    nextCharacter = GenerateCharacter();

            return nextCharacter;
        }

        public string Exclusions { get; set; }

        /// <summary>
        /// Minimum number of characters in the generated string.  
        /// For passwords, please read http://en.wikipedia.org/wiki/Password_strength#Guidelines_for_strong_passwords
        /// prior to chaning this value.  The default minimum is set to 8, which is relatively weak (somewhere around
        /// entropy of 40 bits), but a 20 character default password would be too much for most humans)
        /// </summary>
		public int Minimum
		{
			get { return this.minSize; }
			set	
			{ 
				minSize = DefaultMinimum > this.minSize ? DefaultMinimum : value;
			}
		}

        /// <summary>
        /// Maximum number of characters in the generated string.  
        /// For passwords, please read http://en.wikipedia.org/wiki/Password_strength#Guidelines_for_strong_passwords
        /// prior to chaning this value.  The default maximum is set to 10, which is relatively weak (somewhere just below
        /// entropy of 64 bits), but a 20 character default password would be too much for most humans)
        /// </summary>
        public int Maximum
		{
			get { return maxSize; }
			set	
			{ 
				maxSize = minSize >= maxSize ? DefaultMaximum : value;
			}
		}

        /// <summary>
        /// Specifies whether symbols should be excluded.  For passwords, this should be left as the default (false)
        /// </summary>
		public bool ExcludeSymbols {get;set;}

        /// <summary>
        /// Specifies whether characters should be allowed to repeat (anywhere in the string).  For passwords, this should be left as the default (true).
        /// Setting this to true for passwords actually reduces entropy and makes generated passwords easier to guess.
        /// </summary>
		public bool RepeatCharacters {get;set;}

        /// <summary>
        /// Specifies whether characters should be allowed to repeat next to each other.  For passwords, this should be left as the default (true).
        /// Setting this to true for passwords actually reduces entropy and makes generated passwords easier to guess.
        /// </summary>
        public bool ConsecutiveCharacters { get; set; }

		private const int DefaultMinimum = 8;
		private const int DefaultMaximum = 10;

        /// <summary>
        /// Index into pwdCharArray where symbols start.  Used if ExcludeSymbols is set to true
        /// </summary>
		private const int UBoundDigit    = 61;

		private RNGCryptoServiceProvider    rng = new RNGCryptoServiceProvider();
		private int 			minSize;
		private int 			maxSize;
		private char[] pwdCharArray = ("abcdefghijklmnopqrstuvwxyzABCDEFG" +
			"HIJKLMNOPQRSTUVWXYZ0123456789`~!@#$%^&*()-_=+[]{}\\|;:'\",<" + 
			".>/?").ToCharArray();                                        
    }
}
