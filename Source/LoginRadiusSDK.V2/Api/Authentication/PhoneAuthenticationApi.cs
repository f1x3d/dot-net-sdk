//-----------------------------------------------------------------------
// <copyright file="PhoneAuthenticationApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using LoginRadiusSDK.V2.Common;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Models.ResponseModels;
using LoginRadiusSDK.V2.Models.ResponseModels.UserProfile;
using LoginRadiusSDK.V2.Models.RequestModels;
using LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects;

namespace LoginRadiusSDK.V2.Api.Authentication
{
    public class PhoneAuthenticationApi : LoginRadiusResource
    {
        /// <summary>
        /// This API retrieves a copy of the user data based on the Phone
        /// </summary>
        /// <param name="phoneAuthenticationModel">Model Class containing Definition of payload for PhoneAuthenticationModel API</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="loginUrl">Url where the user is logging from</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <returns>Response containing User Profile Data and access token</returns>
        /// 9.2.3

        public ApiResponse<AccessToken<Identity>> LoginByPhone(PhoneAuthenticationModel phoneAuthenticationModel, string fields = "",
        string loginUrl = null, string smsTemplate = null)
        {
            if (phoneAuthenticationModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(phoneAuthenticationModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(loginUrl))
            {
               queryParameters.Add("loginUrl", loginUrl);
            }
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }

            var resourcePath = "identity/v2/auth/login";
            
            return ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(phoneAuthenticationModel));
        }
        /// <summary>
        /// This API is used to send the OTP to reset the account password.
        /// </summary>
        /// <param name="phone">New Phone Number</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <returns>Response Containing Validation Data and SMS Data</returns>
        /// 10.4

        public ApiResponse<UserProfilePostResponse<SMSResponseData>> ForgotPasswordByPhoneOTP(string phone, string smsTemplate = null)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(phone));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }

            var bodyParameters = new BodyParameters
            {
                { "phone", phone }
            };

            var resourcePath = "identity/v2/auth/password/otp";
            
            return ConfigureAndExecute<UserProfilePostResponse<SMSResponseData>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to reset the password
        /// </summary>
        /// <param name="resetPasswordByOTPModel">Model Class containing Definition of payload for ResetPasswordByOTP API</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 10.5

        public ApiResponse<PostResponse> ResetPasswordByPhoneOTP(ResetPasswordByOTPModel resetPasswordByOTPModel)
        {
            if (resetPasswordByOTPModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(resetPasswordByOTPModel));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/password/otp";
            
            return ConfigureAndExecute<PostResponse>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(resetPasswordByOTPModel));
        }
        /// <summary>
        /// This API is used to validate the verification code sent to verify a user's phone number
        /// </summary>
        /// <param name="otp">The Verification Code</param>
        /// <param name="phone">New Phone Number</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <returns>Response containing User Profile Data and access token</returns>
        /// 11.1.1

        public ApiResponse<AccessToken<Identity>> PhoneVerificationByOTP(string otp, string phone,
        string fields = "", string smsTemplate = null)
        {
            if (string.IsNullOrWhiteSpace(otp))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(otp));
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(phone));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "otp", otp }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }

            var bodyParameters = new BodyParameters
            {
                { "phone", phone }
            };

            var resourcePath = "identity/v2/auth/phone/otp";
            
            return ConfigureAndExecute<AccessToken<Identity>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to consume the verification code sent to verify a user's phone number. Use this call for front-end purposes in cases where the user is already logged in by passing the user's access token.
        /// </summary>
        /// <param name="accessToken">Access_Token</param>
        /// <param name="otp">The Verification Code</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <returns>Response containing Definition of Complete Validation data</returns>
        /// 11.1.2

        public ApiResponse<PostResponse> PhoneVerificationOTPByAccessToken(string accessToken, string otp,
        string smsTemplate = null)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(otp))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(otp));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "otp", otp }
            };
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }

            var bodyParameters = new BodyParameters
            {
                { "access_token", accessToken }
            };

            var resourcePath = "identity/v2/auth/phone/otp";
            
            return ConfigureAndExecute<PostResponse>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to resend a verification OTP to verify a user's Phone Number. The user will receive a verification code that they will need to input
        /// </summary>
        /// <param name="phone">New Phone Number</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <returns>Response Containing Validation Data and SMS Data</returns>
        /// 11.2.1

        public ApiResponse<UserProfilePostResponse<SMSResponseData>> PhoneResendVerificationOTP(string phone, string smsTemplate = null)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(phone));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }

            var bodyParameters = new BodyParameters
            {
                { "phone", phone }
            };

            var resourcePath = "identity/v2/auth/phone/otp";
            
            return ConfigureAndExecute<UserProfilePostResponse<SMSResponseData>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to resend a verification OTP to verify a user's Phone Number in cases in which an active token already exists
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="phone">New Phone Number</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <returns>Response Containing Validation Data and SMS Data</returns>
        /// 11.2.2

        public ApiResponse<UserProfilePostResponse<SMSResponseData>> PhoneResendVerificationOTPByToken(string accessToken, string phone,
        string smsTemplate = null)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(phone));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }

            var bodyParameters = new BodyParameters
            {
                { "access_token", accessToken },
                { "phone", phone }
            };

            var resourcePath = "identity/v2/auth/phone/otp";
            
            return ConfigureAndExecute<UserProfilePostResponse<SMSResponseData>>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to update the login Phone Number of users
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="phone">New Phone Number</param>
        /// <param name="smsTemplate">SMS Template name</param>
        /// <returns>Response Containing Validation Data and SMS Data</returns>
        /// 11.5

        public ApiResponse<UserProfilePostResponse<SMSResponseData>> UpdatePhoneNumber(string accessToken, string phone,
        string smsTemplate = null)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(phone));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };
            if (!string.IsNullOrWhiteSpace(smsTemplate))
            {
               queryParameters.Add("smsTemplate", smsTemplate);
            }

            var bodyParameters = new BodyParameters
            {
                { "phone", phone }
            };

            var resourcePath = "identity/v2/auth/phone";
            
            return ConfigureAndExecute<UserProfilePostResponse<SMSResponseData>>(HttpMethod.PUT, resourcePath, queryParameters, ConvertToJson(bodyParameters));
        }
        /// <summary>
        /// This API is used to check the Phone Number exists or not on your site.
        /// </summary>
        /// <param name="phone">LoginRadius API Key</param>
        /// <returns>Response containing Definition Complete ExistResponse data</returns>
        /// 11.6

        public ApiResponse<ExistResponse> CheckPhoneNumberAvailability(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(phone));
            }
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "phone", phone }
            };

            var resourcePath = "identity/v2/auth/phone";
            
            return ConfigureAndExecute<ExistResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API is used to delete the Phone ID on a user's account via the access_token
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response containing Definition of Delete Request</returns>
        /// 11.7

        public ApiResponse<DeleteResponse> RemovePhoneIDByAccessToken(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] }
            };

            var resourcePath = "identity/v2/auth/phone";
            
            return ConfigureAndExecute<DeleteResponse>(HttpMethod.DELETE, resourcePath, queryParameters, null);
        }
    }
}