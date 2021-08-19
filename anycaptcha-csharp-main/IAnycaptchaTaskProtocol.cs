using Anycaptcha_example.ApiResponse;
using Newtonsoft.Json.Linq;

namespace Anycaptcha_example
{
    public interface IAnycaptchaTaskProtocol
    {
        JObject GetPostData();
        TaskResultResponse.SolutionData GetTaskSolution();
    }
}