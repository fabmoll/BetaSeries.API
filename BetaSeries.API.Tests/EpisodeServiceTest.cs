using System.Threading.Tasks;
using BetaSeries.API.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace BetaSeries.API.Tests
{
	public class EpisodeServiceTest
	{
		private EpisodeService _episodeService;

		[TestInitialize]
		public void Initialize()
		{
			_episodeService = new EpisodeService
			{
				Token = TestSettings.Token,
				ApiKey = TestSettings.ApiKey,
				UserAgent = TestSettings.UserAgent
			};
		}

		[TestMethod]
		public async Task GetASync()
		{
			var episode = await _episodeService.GetASync(263278, true);

			Assert.IsNotNull(episode);
		}

		[TestMethod]
		public async Task FindEpisodesToWatchASync()
		{
			var shows = await _episodeService.FindEpisodesToWatchASync(0, 0, Language.All);

			Assert.IsNotNull(shows);
		}

		[TestMethod]
		public async Task NoteASync()
		{
			var episode = await _episodeService.NoteASync(263278, 3);

			Assert.IsNotNull(episode);
		}

		[TestMethod]
		public async Task RemoveNoteASync()
		{
			var episode = await _episodeService.RemoveNoteASync(263278);

			Assert.IsNotNull(episode);
		}

		[TestMethod]
		public async Task MarkAsWatchedASync()
		{
			var episode = await _episodeService.MarkAsWatchedASync(263278, true);

			Assert.IsNotNull(episode);
		}

		[TestMethod]
		public async void MarkAsUnwatchedASync()
		{
			var episode = await _episodeService.MarkAsUnwatchedASync(263278);

			Assert.IsNotNull(episode);
		}

	}
}