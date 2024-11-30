namespace ContentLimitInsurance.Specs.Services;

public class ItemServiceSpecs
{
    private static Mock<Repository.IRepository> MockRepository;
    private static Mock<IMapper> MockMapper;
    private static IItemService ItemService;

    [TestFixture]
    public class Given_Item_Service_When_we_call_get_items
    {
        private static List<Item> TestItems;
        private static ICollection<Item> Result;

        [SetUp]
        public void Setup()
        {
            MockRepository = new Mock<Repository.IRepository>();
            MockMapper = new Mock<IMapper>();
            ItemService = new ItemService(MockRepository.Object, MockMapper.Object);
            
            TestItems = ItemMockData.GetTestItems();
            MockRepository.Setup(repo => repo.Load<Item>()).Returns(TestItems.AsQueryable());

            Result = ItemService.GetItems();
        }

        [Test]
        public void Then_the_result_should_not_be_empty()
        {
            Result.ShouldNotBeEmpty();
        }

        [Test]
        public void Then_the_result_should_return_items_ordered_by_name()
        {
            Result.Should().BeEquivalentTo(TestItems.OrderBy(x => x.Name).ToList(), options => options.WithStrictOrdering());
        }

        [Test]
        public void Then_the_result_contains_Spoon_category()
        {
            Result.Should().Contain(x => x.Name == "Spoon");
        }
    }

    public class Given_Item_Service_When_we_call_Add
    {
        private static AddItemVM AddItemVM;
        private static Item AddItem;
        private static bool Result;

        [SetUp]
        public void Setup()
        {
            MockRepository = new Mock<Repository.IRepository>();
            MockMapper = new Mock<IMapper>();
            ItemService = new ItemService(MockRepository.Object, MockMapper.Object);
            AddItemVM = ItemMockData.GetAddItemVM();
            AddItem = ItemMockData.GetAddItem();

            MockMapper.Setup(x => x.Map<Item>(AddItemVM)).Returns(AddItem);
            MockRepository.Setup(x => x.Add(AddItem));
            Result = ItemService.Add(AddItemVM);
        }

        [Test]
        public void Then_the_result_should_return_true()
        {
            Result.Should().BeTrue();
        }
    }

    public class Given_Item_Service_When_we_call_Delete
    {
        private static bool Result;

        [SetUp]
        public void Setup()
        {
            MockRepository = new Mock<Repository.IRepository>();
            MockMapper = new Mock<IMapper>();
            ItemService = new ItemService(MockRepository.Object, MockMapper.Object);
            MockRepository.Setup(x => x.Delete<Item>(1, default));
            Result = ItemService.Delete(1);
        }

        [Test]
        public void Then_the_result_should_return_true()
        {
            Result.Should().BeTrue();
        }
    }
}
