using System;
using Anycaptcha_example.ApiResponse;
using Anycaptcha_example.Helper;
using Newtonsoft.Json.Linq;

namespace Anycaptcha_example.Api
{
    internal class FunCaptchaProxyless : AnycaptchaBase, IAnycaptchaTaskProtocol
    {
        public Uri WebsiteUrl { protected get; set; }
        public string WebsitePublicKey { protected get; set; }
        public override JObject GetPostData()
        {
            return new JObject
            {
                {"type", "FunCaptchaTaskProxyless"},
                {"websiteURL", WebsiteUrl},
                {"websitePublicKey", WebsitePublicKey},
            };
        }

        public TaskResultResponse.SolutionData GetTaskSolution()
        {
            return TaskInfo.Solution;
        }
    }
}