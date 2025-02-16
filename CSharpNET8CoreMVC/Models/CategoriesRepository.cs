namespace CSharpNET8CoreMVC.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>
        {
            new Category { Id = 1, Name = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" },
            new Category { Id = 2, Name = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" },
            new Category { Id = 3, Name = "Confections", Description = "Desserts, candies, and sweet breads" },
            new Category { Id = 4, Name = "Dairy Products", Description = "Cheeses" },
            new Category { Id = 5, Name = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" },
            new Category { Id = 6, Name = "Meat/Poultry", Description = "Prepared meats" },
            new Category { Id = 7, Name = "Produce", Description = "Dried fruit and bean curd" },
            new Category { Id = 8, Name = "Seafood", Description = "Seaweed and fish" }
        };

        //public static IEnumerable<Category> Categories => categories;

        public static void AddCategory(Category category)
        {
            var maxId = _categories.Max(c => c.Id);
            category.Id = maxId + 1;
            _categories.Add(category);
        }

        public static List<Category> GetCategories() => _categories;

        public static Category? GetCategoryById(int id)
        {    
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                return new Category
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                };
            }

            return null;
        }

        public static void UpdateCategory(int id, Category category)
        {
            if (id != category.Id) return;

            var categoryToUpdate = _categories.FirstOrDefault(c => c.Id == id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public static void DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}
