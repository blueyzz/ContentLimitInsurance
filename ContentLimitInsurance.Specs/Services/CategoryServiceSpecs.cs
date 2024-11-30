namespace ContentLimitInsurance.Specs.Services;

public class CategoryServiceSpecs
{
    private static Mock<Repository.IRepository> MockRepository;
    private static ICategoryService CategoryService;
    private static List<Category> TestCategories;
    private static ICollection<Category> Result;

    [TestFixture]
    public class Given_Category_Service_When_we_call_get_categories
    {
        [SetUp]
        public void Setup()
        {
            MockRepository = new Mock<Repository.IRepository>();
            CategoryService = new CategoryService(MockRepository.Object);
            TestCategories = CategoryMockData.GetTestCategories();

            MockRepository.Setup(repo => repo.Load<Category>()).Returns(TestCategories.AsQueryable());

            Result = CategoryService.GetCategories();
        }

        [Test]
        public void Then_the_result_should_not_be_empty()
        {
            Result.ShouldNotBeEmpty();
        }

        [Test]
        public void Then_the_result_should_return_categories_ordered_by_name()
        {
            Result.Should().BeEquivalentTo(TestCategories.OrderBy(x => x.Name).ToList(), options => options.WithStrictOrdering());
        }

        [Test]
        public void Then_the_result_contains_Kitchen_category()
        {
            Result.Should().Contain(x => x.Name == "Kitchen");
        }
    }

    public class Given_Category_Service_when_we_call_get_categories_by_category_id
    {
        [SetUp]
        public void Setup()
        {
            MockRepository = new Mock<Repository.IRepository>();
            CategoryService = new CategoryService(MockRepository.Object);
            TestCategories = CategoryMockData.GetTestCategories();

            MockRepository.Setup(repo => repo.Load<Category>()).Returns(TestCategories.AsQueryable());

            Result = CategoryService.GetCategoriesByCategoryID(new List<int> { 1 });
        }

        [Test]
        public void Then_the_result_should_not_be_empty()
        {
            Result.ShouldNotBeEmpty();
        }

        [Test]
        public void Then_the_result_should_contain_only_one_category()
        {
            Result.Count.Should().Be(1);
        }

        [Test]
        public void Then_the_result_should_not_contain_Kitchen()
        {
            Result.Should().NotContain(x => x.Name == "Kitchen");
        }
    }
}
