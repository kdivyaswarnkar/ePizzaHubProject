using ePizzaHub.DAL.Entities;
using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Services.Interfaces;


namespace ePizzaHub.Services.Implementations
{
    public class CatalogService :ICatalogService
    {
        IRepository<Item> _itemRepo;
        IRepository<Category> _categoryRepo;
        IRepository<ItemType> _itemTypeRepo;
        public CatalogService(IRepository<Item> itemRepo, IRepository<Category> categoryRepo, IRepository<ItemType> itemTypeRepo)
        {
            _itemRepo = itemRepo;
            _categoryRepo = categoryRepo;
            _itemTypeRepo = itemTypeRepo;
        }

        public void AddItem(Item item)
        {
            _itemRepo.Add(item);
            _itemRepo.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            _itemRepo.Delete(id);
            _itemRepo.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepo.GetAll();
        }

        public IEnumerable<Item> GetItems()
        {
            return _itemRepo.GetAll();
        }

        public Item GetItem(int id)
        {
            return _itemRepo.Find(id);
        }

        public IEnumerable<ItemType> GetItemtypes()
        {
            return _itemTypeRepo.GetAll();
        }

        public void UpdateItem(Item item)
        {
            _itemRepo.Update(item);
            _itemRepo.SaveChanges();
        }
    }
}