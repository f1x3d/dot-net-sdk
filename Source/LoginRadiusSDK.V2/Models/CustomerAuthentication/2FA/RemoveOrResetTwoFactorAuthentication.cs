﻿using LoginRadiusSDK.V2.Util.Serialization;

namespace LoginRadiusSDK.V2.Models.CustomerAuthentication._2FA
{
    public class RemoveOrResetTwoFactorAuthentication : LoginRadiusSerializableObject
    {
        public bool ?otpauthenticator { get; set; }
        public bool ?googleauthenticator { get; set; }
    }
}