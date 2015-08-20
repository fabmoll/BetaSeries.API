using System.Threading.Tasks;
using BetaSeries.API.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace BetaSeries.API.Tests
{
	[TestClass]
	public class FriendsServiceTest
	{
		private FriendsService _friendsService;

		[TestInitialize]
		public void Initialize()
		{
			_friendsService = new FriendsService
			{
				Token = TestSettings.Token,
				ApiKey = TestSettings.ApiKey,
				UserAgent = TestSettings.UserAgent
			};
		}

		[TestMethod]
		public async Task ListASync()
		{
			var friends = await _friendsService.ListASync();

			Assert.IsNotNull(friends);
		}
	}
}