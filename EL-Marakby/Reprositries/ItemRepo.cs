using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using EL_Marakby.Models;

namespace EL_Marakby.Reprositries
{
    public class ItemRepo : IItemRepo
    {
        Context db;
        public ItemRepo(Context _context)
        {
            db = _context;
        }
        public List<Item> GetAll()
        {
            return db.Item.ToList();
        }
        public Item GetItem(int id)
        {
            return db.Item.FirstOrDefault(i => i.ID == id);
        }
        public Item FindById(int id)
        {
            return db.Item.FirstOrDefault(s => s.ID == id);
        }

        public List<Item> FindByDeptId(int itemid)
        {
            return db.Item.Where(s => s.ID == itemid).ToList();
        }

        public int Insert(Item item)
        {
            db.Item.Add(item);
            return db.SaveChanges();
        }
        public int Edit(int id, Item item)
        {
            Item oldItem = FindById(id);
            if (oldItem == null)
            {
                oldItem.Name = item.Name;
                return db.SaveChanges();
            }
            return 0;
        }
        public int Savenew(int id, Item item)
        {
            Item oldItem = FindById(id);
            if (oldItem != null)
            {
                oldItem.Name = item.Name;
                return db.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Item oldItem = FindById(id);
            db.Item.Remove(oldItem);
            return db.SaveChanges();
        }
    }
}
