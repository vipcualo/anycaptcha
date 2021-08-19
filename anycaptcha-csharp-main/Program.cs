﻿using System;
using Anycaptcha_example.Api;
using Anycaptcha_example.Helper;
using Newtonsoft.Json.Linq;

namespace Anycaptcha_example
{
    internal class Program
    {
        private const string ClientKey = "input your key here";

        private static void Main()
        {
            ExampleGetBalance();
            ExampleImageToText();
            ExampleRecaptcha2EnterpriseProxyless();
            ExampleRecaptcha2Enterprise();
            ExampleRecaptchaV3EnterpriseProxyless();
            ExampleHCaptchaProxyless();
            ExampleRecaptcha2Proxyless();
            ExampleRecaptcha2();
            ExampleRecaptchaV3Proxyless();
            ExampleFunCaptchaProxyless();
            ExampleGeeTestProxyless();
            Console.ReadKey();
        }

        private static void ExampleGetBalance()
        {
            DebugHelper.VerboseMode = true;

            var api = new ImageToText
            {
                ClientKey = ClientKey
            };

            var balance = api.GetBalance();

            if (balance == null)
                DebugHelper.Out("GetBalance() failed. " + api.ErrorMessage, DebugHelper.Type.Error);
            else
                DebugHelper.Out("Balance: " + balance, DebugHelper.Type.Success);
        }

        private static void ExampleRecaptchaV3EnterpriseProxyless()
        {
            DebugHelper.VerboseMode = true;

            var api = new RecaptchaV3Proxyless
            {
                ClientKey = ClientKey,
                WebsiteUrl = new Uri("https://www.netflix.com/login"),
                WebsiteKey = "6Lf8hrcUAAAAAIpQAFW2VFjtiYnThOjZOA5xvLyR",
                IsEnterprise = true
            };

            if (!api.CreateTask())
                DebugHelper.Out("API v2 send failed. " + api.ErrorMessage, DebugHelper.Type.Error);
            else if (!api.WaitForResult())
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
            else
                DebugHelper.Out("Result: " + api.GetTaskSolution().GRecaptchaResponse, DebugHelper.Type.Success);
        }

        private static void ExampleRecaptchaV3Proxyless()
        {
            DebugHelper.VerboseMode = true;

            var api = new RecaptchaV3Proxyless
            {
                ClientKey = ClientKey,
                WebsiteUrl = new Uri("http://www.supremenewyork.com"),
                WebsiteKey = "6Leva6oUAAAAAMFYqdLAI8kJ5tw7BtkHYpK10RcD",
                PageAction = "testPageAction",
                IsEnterprise = false
            };

            if (!api.CreateTask())
                DebugHelper.Out("API v2 send failed. " + api.ErrorMessage, DebugHelper.Type.Error);
            else if (!api.WaitForResult())
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
            else
                DebugHelper.Out("Result: " + api.GetTaskSolution().GRecaptchaResponse, DebugHelper.Type.Success);
        }

        private static void ExampleGeeTestProxyless()
        {
            DebugHelper.VerboseMode = true;

            // website key ("gt") and "challenge" for testing you can get here: https://auth.geetest.com/api/init_captcha?time=1561554686474
            // you need to get a new "challenge" each time
            var api = new GeeTestProxyless()
            {
                ClientKey = ClientKey,
                WebsiteUrl = new Uri("http://www.supremenewyork.com"),
                WebsiteKey = "b6e21f90a91a3c2d4a31fe84e10d0442",
                WebsiteChallenge = "169acd4a58f2c99770322dfa5270c221"
            };

            if (!api.CreateTask())
                DebugHelper.Out("API v2 send failed. " + api.ErrorMessage, DebugHelper.Type.Error);
            else if (!api.WaitForResult())
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
            else
            {
                DebugHelper.Out("Result CHALLENGE: " + api.GetTaskSolution().Challenge, DebugHelper.Type.Success);
                DebugHelper.Out("Result SECCODE: " + api.GetTaskSolution().Seccode, DebugHelper.Type.Success);
                DebugHelper.Out("Result VALIDATE: " + api.GetTaskSolution().Validate, DebugHelper.Type.Success);
            }
        }

        private static void ExampleImageToText()
        {
            DebugHelper.VerboseMode = true;

            var api = new ImageToText
            {
                ClientKey = ClientKey,
                FilePath = "captcha.jpg"
            };

            if (!api.CreateTask())
                DebugHelper.Out("API v2 send failed. " + api.ErrorMessage, DebugHelper.Type.Error);
            else if (!api.WaitForResult())
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
            else
                DebugHelper.Out("Result: " + api.GetTaskSolution().Text, DebugHelper.Type.Success);
        }

        private static void ExampleRecaptcha2Proxyless()
        {
            DebugHelper.VerboseMode = true;

            var api = new RecaptchaV2Proxyless
            {
                ClientKey = ClientKey,
                WebsiteUrl = new Uri("http://http.myjino.ru/recaptcha/test-get.php"),
                WebsiteKey = "6Lc_aCMTAAAAABx7u2W0WPXnVbI_v6ZdbM6rYf16"
            };

            if (!api.CreateTask())
                DebugHelper.Out("API v2 send failed. " + api.ErrorMessage, DebugHelper.Type.Error);
            else if (!api.WaitForResult())
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
            else
                DebugHelper.Out("Result: " + api.GetTaskSolution().GRecaptchaResponse, DebugHelper.Type.Success);
        }

        private static void ExampleRecaptcha2EnterpriseProxyless()
        {
            DebugHelper.VerboseMode = true;

            var api = new RecaptchaV2EnterpriseProxyless
            {
                ClientKey = ClientKey,
                WebsiteUrl = new Uri("https://store.steampowered.com/join"),
                WebsiteKey = "6LdIFr0ZAAAAAO3vz0O0OQrtAefzdJcWQM2TMYQH"
            };

            api.EnterprisePayload.Add("test", "qwerty");
            api.EnterprisePayload.Add("secret", "AB_12345");

            if (!api.CreateTask())
                DebugHelper.Out("API v2 send failed. " + api.ErrorMessage, DebugHelper.Type.Error);
            else if (!api.WaitForResult())
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
            else
                DebugHelper.Out("Result: " + api.GetTaskSolution().GRecaptchaResponse, DebugHelper.Type.Success);
        }

        private static void ExampleRecaptcha2Enterprise()
        {
            DebugHelper.VerboseMode = true;

            var api = new RecaptchaV2Enterprise
            {
                ClientKey = ClientKey,
                WebsiteUrl = new Uri("https://store.steampowered.com/join"),
                WebsiteKey = "6LdIFr0ZAAAAAO3vz0O0OQrtAefzdJcWQM2TMYQH",
                UserAgent =
                    "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116",
                // proxy access parameters
                ProxyType = AnycaptchaBase.ProxyTypeOption.Socks5,
                ProxyAddress = "8.8.8.8",
                ProxyPort = 3129,
                ProxyLogin = "amanchik",
                ProxyPassword = "qwerty123"
            };

            api.EnterprisePayload.Add("test", "qwerty");
            api.EnterprisePayload.Add("secret", "AB_12345");

            if (!api.CreateTask())
                DebugHelper.Out("API v2 send failed. " + api.ErrorMessage, DebugHelper.Type.Error);
            else if (!api.WaitForResult())
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
            else
                DebugHelper.Out("Result: " + api.GetTaskSolution().GRecaptchaResponse, DebugHelper.Type.Success);
        }

        private static void ExampleHCaptchaProxyless()
        {
            DebugHelper.VerboseMode = true;

            var api = new HCaptchaProxyless
            {
                ClientKey = ClientKey,
                WebsiteUrl = new Uri("http://democaptcha.com/"),
                WebsiteKey = "51829642-2cda-4b09-896c-594f89d700cc"
            };

            if (!api.CreateTask())
                DebugHelper.Out("API v2 send failed. " + api.ErrorMessage, DebugHelper.Type.Error);
            else if (!api.WaitForResult())
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
            else
                DebugHelper.Out("Result: " + api.GetTaskSolution().GRecaptchaResponse, DebugHelper.Type.Success);
        }

        private static void ExampleRecaptcha2()
        {
            DebugHelper.VerboseMode = true;

            var api = new RecaptchaV2
            {
                ClientKey = ClientKey,
                WebsiteUrl = new Uri("http://http.myjino.ru/recaptcha/test-get.php"),
                WebsiteKey = "6Lc_aCMTAAAAABx7u2W0WPXnVbI_v6ZdbM6rYf16",
                UserAgent =
                    "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116",
                // proxy access parameters
                ProxyType = AnycaptchaBase.ProxyTypeOption.Http,
                ProxyAddress = "xx.xx.xx.xx",
                ProxyPort = 8282,
                ProxyLogin = "123",
                ProxyPassword = "456"
            };

            if (!api.CreateTask())
                DebugHelper.Out("API v2 send failed. " + api.ErrorMessage, DebugHelper.Type.Error);
            else if (!api.WaitForResult())
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
            else
                DebugHelper.Out("Result: " + api.GetTaskSolution().GRecaptchaResponse, DebugHelper.Type.Success);
        }

        private static void ExampleFunCaptchaProxyless()
        {
            DebugHelper.VerboseMode = true;

            var api = new FunCaptchaProxyless
            {
                ClientKey = ClientKey,
                WebsiteUrl = new Uri("https://outlook.live.com"),
                WebsitePublicKey = "B7D8911C-5CC8-A9A3-35B0-554ACEE604DA",
            };

            if (!api.CreateTask())
                DebugHelper.Out("API v2 send failed. " + api.ErrorMessage, DebugHelper.Type.Error);
            else if (!api.WaitForResult())
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
            else
                DebugHelper.Out("Result: " + api.GetTaskSolution().Token, DebugHelper.Type.Success);
        }
    }
}