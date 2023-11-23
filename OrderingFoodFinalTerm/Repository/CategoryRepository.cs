﻿using Microsoft.EntityFrameworkCore;
using OrderingFoodFinalTerm.Interface;
using OrderingFoodFinalTerm.DTO;
using System.Net.WebSockets;

namespace OrderingFoodFinalTerm.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MainDbContext _context;

        public CategoryRepository(MainDbContext context)
        {
            _context = context;
        }

        //Add
        public CategoryDTO Add(CategoryDTO category)
        {
            var _category = new CategoryDTO
            {
                CategoryName = category.CategoryName
            };
            _context.Add(_category);
            _context.SaveChanges();
            return _category;
        }

        // Delete
        public void Delete(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (category != null)
            {
                _context.Remove(category);
                _context.SaveChanges();
            }
        }

        // Get all
        public ICollection<CategoryDTO> GetAll()
        {
            var categories = _context.Categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                CategoryName = c.CategoryName
            });
            return categories.ToList();
        }

        //Get by id
        public CategoryDTO GetById(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (category != null)
            {
                return new CategoryDTO
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                };
            }
            return null;
        }

        // Update
        public void Update(CategoryDTO category)
        {
            var _category = _context.Categories.SingleOrDefault(c => c.Id == category.Id);
            _category.CategoryName = category.CategoryName;

            _context.SaveChanges();
        }
    }
}