﻿using ShoesSalePage.Data;
using ShoesSalePage.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ShoesSalePage.Controllers
{
    public class CartController : Controller
    {
        private readonly ShoesDbContext db = new ShoesDbContext();
        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Add(int id)
        {
            if (Session["Cart"] == null)
            {
                List<Cart> list = new List<Cart>();
                list.Add(new Cart { Shoes = db.Shoes.Find(id), Quantity = 1, CreatedDate = DateTime.Now });
                Session["Cart"] = list;     // Store shoes list to a session
                Session["Count"] = 1;
            }
            else
            {
                List<Cart> list = (List<Cart>)Session["Cart"];
                int index = CheckExist(id);
                if (index != -1)
                {
                    list[index].Quantity++;
                }
                else
                    list.Add(new Cart { Shoes = db.Shoes.Find(id), Quantity = 1, CreatedDate = DateTime.Now });
                Session["Cart"] = list;
                Session["Count"] = Convert.ToInt32(Session["Count"]) + 1;
            }
            return RedirectToAction("Shop", "Shoes");
        }
        public ActionResult Remove(int id)
        {
            List<Cart> list = (List<Cart>)Session["Cart"];
            int index = CheckExist(id);
            list.RemoveAt(index + 1);
            Session["Cart"] = list;
            Session["Count"] = Convert.ToInt32(Session["Count"]) - 1;
            return RedirectToAction("Cart");
        }
        private int CheckExist(int id)
        {
            List<Cart> list = (List<Cart>)Session["Cart"];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Shoes.Id == id)
                    return i - 1;
            }
            return -1;
        }
    }
}