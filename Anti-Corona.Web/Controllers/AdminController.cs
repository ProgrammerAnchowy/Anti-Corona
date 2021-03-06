﻿using Anti_Corona.Business.Abstract;
using Anti_Corona.Entity;
using Anti_Corona.Web.Identity;
using Anti_Corona.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anti_Corona.Web.Controllers
{
    [Authorize(Roles = "admin")]

    public class AdminController : Controller
    {
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IProductService _productService;
        private IOrderService _orderService;
        private ICategoryService _categoryService;
        private IBrandService _brandService;
        public AdminController(UserManager<User> userManager,
                               RoleManager<IdentityRole> roleManager,
                               IProductService productService,
                               IOrderService orderService,
                               ICategoryService categoryService,
                               IBrandService brandService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _productService = productService;
            _orderService = orderService;
            _categoryService = categoryService;
            _brandService = brandService;
        }
        public IActionResult Index()
        {
            var deneme = _orderService.GetLastSalersProduct();
            return View(new AdminDashboardViewModel()
            {
                ProductCount = _productService.GetProductCount(),
                UserCount = _userManager.Users.Count(),
                Revenue = _orderService.GetTotalGain(),
                lastSalersProduct = _orderService.GetLastSalersProduct().Select(i => new OrderItemModel()
                {
                    Title = i.Product.Title,
                    Price = (double)i.Product.Price * i.Quantity,
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            });
        }
        public IActionResult UserList()
        {
            return View(_userManager.Users);
        }
        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);
                var roles = _roleManager.Roles.Select(i => i.Name);

                ViewBag.Roles = roles;
                return View(new UserDetailModel()
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    EmailComfirmed = user.EmailConfirmed,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                    SelectedRoles = selectedRoles
                });
            }
            return Redirect("/admin/UserList");
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserDetailModel model, string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.Address = model.Address;
                    user.PhoneNumber = model.PhoneNumber;
                    user.EmailConfirmed = model.EmailComfirmed;

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        selectedRoles = selectedRoles ?? new string[] { };
                        await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles).ToArray<string>());

                        return Redirect("/admin/UserList");
                    }
                }
                return Redirect("/admin/UserList");
            }
            return View(model);
        }
        public async Task<IActionResult> UserDelete(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.DeleteAsync(user);
            return Redirect("/admin/UserList");
        }
        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        public async Task<IActionResult> RoleEdit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var members = new List<User>();
            var nonmembers = new List<User>();

            foreach (var user in _userManager.Users.ToList())
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name)
                                ? members : nonmembers;
                list.Add(user);
            }
            var model = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

                foreach (var userId in model.IdsToDelete ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
            }
            return Redirect("/admin/role/" + model.RoleId);
        }
        public async Task<IActionResult> RoleDelete(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }
            return Redirect("/admin/RoleList");
        }
        public IActionResult ProductList()
        {
            return View(_productService.GetAllProducts(""));
        }
        [HttpGet]
        public IActionResult ProductEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _productService.GetProductDetails((int)id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new ProductEditModel()
            {
                ProductId = product.ProductId,
                categoryId = Convert.ToString(product.CategoryId),
                Description = product.Description,
                isHomePage = product.IsHomePage,
                isOnSale = product.IsOnSale,
                Price = (double)product.Price,
                Stock = product.Stock,
                Title = product.Title,
                imageUrl = product.Images[0].ImageUrl
            };
            ViewBag.Categories = _categoryService.GetAllCategories();
            return View(model);
        }
        [HttpPost]
        public IActionResult ProductEdit(ProductEditModel editProduct)
        {
            if (!ModelState.IsValid)
            {
                var tempProduct = _productService.GetProductDetails(editProduct.ProductId);
                editProduct.imageUrl = tempProduct.Images[0].ImageUrl;
                ViewBag.Categories = _categoryService.GetAllCategories();
                return View(editProduct);
            }
            var product = _productService.GetById(editProduct.ProductId);
            if (product == null)
            {
                return NotFound();
            }
            product.Description = editProduct.Description;
            product.CategoryId = Convert.ToInt32(editProduct.categoryId);
            product.IsHomePage = editProduct.isHomePage;
            product.IsOnSale = editProduct.isOnSale;
            product.Stock = editProduct.Stock;
            product.Price = editProduct.Price;
            product.Title = editProduct.Title;
            _productService.Update(product);
            return Redirect("/admin/ProductList");

        }
        public IActionResult ProductDelete(int productId)
        {
            var product = _productService.GetById(productId);
            if (product != null)
            {
                _productService.Delete(product);
            }
            return Redirect("/admin/ProductList");

        }

        public IActionResult BrandList()
        {
            return View(_brandService.GetBrands());

        }
        [HttpGet]
        public IActionResult BrandCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BrandCreate(BrandModel brand)
        {
            var entity = new Brand()
            {
                Name = brand.Name,
            };
            _brandService.Create(entity);
            return Redirect("/admin/BrandList");
        }
        [HttpGet]
        public IActionResult BrandEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var brand = _brandService.GetByIdWithProducts((int)id);
            if (brand == null)
            {
                return NotFound();
            }
            var model = new BrandModel()
            {
                BrandId = brand.Id,
                Name = brand.Name,
                products = brand.Products.ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult BrandEdit(BrandModel brandmodel)
        {
            var brand = _brandService.GetById(brandmodel.BrandId);
            if (brand == null)
            {
                return NotFound();
            }
            brand.Name = brandmodel.Name;
            _brandService.Update(brand);

            return Redirect("/admin/BrandList");
        }
        public IActionResult BrandDelete(int BrandId)
        {
            var brand = _brandService.GetById(BrandId);
            if (brand != null)
            {
                _brandService.Delete(brand);
            }
            return Redirect("/admin/BrandList");
        }
        //category

        public IActionResult CategoryList()
        {
            return View(_categoryService.GetAllCategories());

        }
        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryCreate(CategoryModel category)
        {
            var entity = new Category()
            {
                Name = category.Name,
            };
            _categoryService.Create(entity);
            return Redirect("/admin/CategoryList");
        }
        [HttpGet]
        public IActionResult CategoryEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = _categoryService.GetByIdWithProducts((int)id);
            if (category == null)
            {
                return NotFound();
            }
            var model = new CategoryModel()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                products = category.Products.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CategoryEdit(CategoryModel categorymodel)
        {
            var category = _categoryService.GetById(categorymodel.CategoryId);
            if (category == null)
            {
                return NotFound();
            }
            category.Name = categorymodel.Name;
            _categoryService.Update(category);

            return Redirect("/admin/BrandList");
        }
        public IActionResult CategoryDelete(int CategoryId)
        {
            var category = _categoryService.GetById(CategoryId);
            if (category != null)
            {
                _categoryService.Delete(category);
            }
            return Redirect("/admin/CategoryList");
        }

    }
}
