
using System;
using Windsor.Commons.DataAnnotations;

namespace Windsor.OpenNode2.RestEndpoint.Models
{
    [Serializable]
    public class BaseAuthenticationParameters
    {
        public BaseAuthenticationParameters()
        {
        }

        public BaseAuthenticationParameters(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public BaseAuthenticationParameters(string token)
        {
            Token = token;
        }

        [MutuallyExclusive("Username", "Password")]
        public string Token
        {
            get;
            set;
        }
        [AllOrNoneAttribute("Password")]
        public string Username
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }

        public bool HasUsernameAndPasswordOrToken
        {
            get
            {
                return HasUsernameAndPassword || HasToken;
            }
        }
        public bool HasUsernameAndPassword
        {
            get
            {
                return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
            }
        }
        public bool HasToken
        {
            get
            {
                return !string.IsNullOrEmpty(Token);
            }
        }
    }
}