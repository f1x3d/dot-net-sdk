﻿// -----------------------------------------------------------------------
// <copyright file="LoginRadiusGetMention.cs" company="LoginRadius Inc.">
// Copyright LoginRadius.com 2013
// This file is part of the LoginRadius SDK package.
// </copyright>
// -----------------------------------------------------------------------


namespace LoginRadiusSDK
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using LoginRadiusDataModal.LoginRadiusDataObject.LoginRadiusDataObject.StatusUpdate;

    /// <summary>
    /// LoginRadius class to get user's mentions in Twitter
    /// </summary>
    public class LoginRadiusGetMention
    {
        string _token;
        string _secret;

        /// <summary>
        /// Raw JSON response for twitter mentions data returned from LoginRadius API
        /// </summary>
        public string Response { get; set; }


        /// <summary>
        /// Connstructor to create environment for LoginRadius API
        /// It validates the GUID format of current user's token and LoginRadius secret. 
        /// </summary>
        /// <param name="token">Token for current user</param>
        /// <param name="secret">API Secret of LoginRadius App</param>
        public LoginRadiusGetMention(string token, string secret)
        {
            if (Utility.IsGuid(token) && Utility.IsGuid(secret))
            {
                this._secret = secret;
                this._token = token;
            }
            else
            {
                throw new Exception("Token or secret not valid guids format!!");
            }
        }


        /// <summary>
        /// GetMention function is use to get User's Mentions with Twitter
        /// LoginRadius Rest API for getting user Mentions list
        /// <![CDATA[
        /// https://www.hub.loginradius.com/status/mentions/{yourapisecret}/{yourtoken}
        /// ]]>
        /// </summary>
        /// <returns>Returns user's Mentions in List Format</returns>
        public List<LoginRadiusStatuses> GetMention()
        {
            List<LoginRadiusStatuses> mention = new List<LoginRadiusStatuses>();

            try
            {

                WebClient wc = new WebClient();

                string validateUrl = string.Format(Requesturl.url + "/status/mentions/{0}/{1}", _secret, _token);
                wc.Encoding = System.Text.Encoding.UTF8;
                Response = wc.DownloadString(validateUrl);
                mention = (List<LoginRadiusStatuses>)Newtonsoft.Json.JsonConvert.DeserializeObject(Response, typeof(List<LoginRadiusStatuses>));
                return mention;
            }
            catch
            {
                return null;
            }
            
        }
       

    }
}
