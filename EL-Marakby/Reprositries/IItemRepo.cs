using EL_Marakby.Models;
using System.Collections.Generic;

namespace EL_Marakby.Reprositries
{
    public interface IItemRepo
    {
        int Delete(int id);
        int Edit(int id, Item item);
        List<Item> FindByDeptId(int itemid);
        Item FindById(int id);
        List<Item> GetAll();
        Item GetItem(int id);
        int Insert(Item item);
        int Savenew(int id, Item item);
    }
}