using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data_Access_Layer;
namespace Bussiness_Layer
{
    static public class clsCategory
    {

        static public bool AddCategory(string CategoryName)
        {
            return clsCategoryDataAccess.InsertCategory(CategoryName) !=-1;
        }

        static private int _GetCategoryID(string CategoryName)
        {
            
            return clsCategoryDataAccess.GetCategoryIDByName(CategoryName);

        }

        static public bool RemoveCategory(string CategoryName)
        {
            return clsCategoryDataAccess.DeleteCategory(_GetCategoryID(CategoryName));
        }

        static public bool UpdateCategory(string OldCategoryName , string NewCategoryName)
        {
            return clsCategoryDataAccess.ModifyCategory(_GetCategoryID(OldCategoryName), NewCategoryName);

        }

        static public bool IsCategoryExists(string CategoryName)
        {
            return clsCategoryDataAccess.IsCategoryExists(CategoryName);
        }

        static public bool IsCategoryExists(int CategoryID)
        {
            return clsCategoryDataAccess.IsCategoryExists(CategoryID);
        }

        static public DataTable ListCategories()
        {
            return clsCategoryDataAccess.ListCategories();
        }


    }
}
