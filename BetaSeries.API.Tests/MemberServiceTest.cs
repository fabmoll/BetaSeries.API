using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace BetaSeries.API.Tests
{
	[TestClass]
	public class MemberServiceTest
	{
		private MemberService _memberService;

		[TestInitialize]
		public void Initialize()
		{
			_memberService = new MemberService
			{
				Token = TestSettings.Token,
				ApiKey = TestSettings.ApiKey,
				UserAgent = TestSettings.UserAgent
			};
		}

		[TestMethod]
		public async Task AuthASync()
		{
			var rootAuth = await _memberService.AuthASync("dev029", "developer");

			Assert.IsTrue(!string.IsNullOrEmpty(rootAuth.Token));
		}

		[TestMethod]
		public async Task DisconnectASync()
		{
			var rootAuth = await _memberService.AuthASync("dev029", "developer");

			Assert.IsTrue(!string.IsNullOrEmpty(rootAuth.Token));

			var result = await _memberService.DisconnectASync(rootAuth.Token);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public async Task InfosASync()
		{
			var result = await _memberService.InfosASync();

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public async Task FindBadgesASync()
		{
			var result = await _memberService.FindBadgesASync(86198);

			Assert.IsNotNull(result);
		}
	}
}