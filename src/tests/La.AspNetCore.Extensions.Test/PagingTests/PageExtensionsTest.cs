using Xunit;
using La.AspNetCore.Extensions.Paging;
using System.Threading.Tasks;

namespace La.AspNetCore.Extensions.Test.PagingTests
{
    public class PageExtensionsTest
    {
        [Fact]
        public void PageTest()
        {
            // Arrange
            string[] data = TestPageData.Items;

            // Act
            PageModel<string> pagedData = data.Page(1);

            // Assert
            Assert.NotEmpty(pagedData.Items);
            Assert.Equal(PageModel.DefaultPageSize, pagedData.ItemsCount);
            Assert.Equal(PageModel.DefaultPageSize, pagedData.PageSize);
            Assert.Equal(TestPageData.Items.Length, pagedData.TotalItemsCount);
            Assert.False(pagedData.HasPrevious);
            Assert.True(pagedData.HasNext);
            Assert.Equal(
                (TestPageData.Items.Length / PageModel.DefaultPageSize) + (TestPageData.Items.Length % PageModel.DefaultPageSize > 0 ? 1 : 0),
                pagedData.PageCount);
        }
    }
}
