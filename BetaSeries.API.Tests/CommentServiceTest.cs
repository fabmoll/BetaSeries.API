using System.Linq;
using System.Threading.Tasks;
using BetaSeries.API.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace BetaSeries.API.Tests
{
	[TestClass]
	public class CommentServiceTest
	{
		private CommentService _commentService;

		[TestInitialize]
		public void Initialize()
		{
			_commentService = new CommentService
			{
				Token = TestSettings.Token,
				ApiKey = TestSettings.ApiKey,
				UserAgent = TestSettings.UserAgent
			};
		}

		[TestMethod]
		public async Task PostAsync()
		{
			var rootComment = await _commentService.PostAsync(CommentType.Show, 2410, "test");
			
			Assert.IsNotNull(rootComment.Comment.Date);
		}

		[TestMethod]
		public async Task GetAsync()
		{
			var commentList = await _commentService.GetAsync(CommentType.Show, 2410, 20);

			Assert.IsTrue(commentList.Comments.Any());
		}

		[TestMethod]
		public async Task DeleteAsync()
		{
			var rootComment = await _commentService.DeleteAsync(343287);

			Assert.IsNotNull(rootComment);
		}
	}
}