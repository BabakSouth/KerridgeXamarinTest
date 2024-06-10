using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerridgeTask.Tests
{
    public class TokenTest
    {
        
        [Fact]
        public async void TokenTestExam_Mock()
        {
            var mc = new MockTokenService();
            var token = await  mc.GetAccessTokenAsync();
            Assert.NotNull(token);
            Assert.NotEmpty(token);
        }
    }
}
