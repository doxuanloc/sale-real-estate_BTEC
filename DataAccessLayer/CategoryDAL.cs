using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project1.DataAccessLayer.Service;
using Project1.Model;

namespace Project1.DataAccessLayer
{
    //Communicate with Database to Create, Read, Update,Delete the data
    public class CategoryDAL : ICategory
    {
        //Get all list
        public List<Category> GetAll()
        {
            List<Category> list = new List<Category>(); //init new list

            if (File.Exists(Category.PATH)) //check exists file
            {
                StreamReader reader = new StreamReader(Category.PATH); //read file
                string line;
                while ((line = reader.ReadLine()) != null) //read file
                {
                    //split string
                    string[] arr = line.Split("#");
                    // save the information's object
                    Category category = new Category(arr[0], arr[1]);
                    list.Add(category);
                }

                reader.Close();
            }

            return list;
        }

        public void Add(Category category) //Add category
        {
            //Get list
            List<Category> list = GetAll();
            // add to list
            list.Add(category);
            using (StreamWriter writer = new StreamWriter(Category.PATH)) //open to writed file
            {
                foreach (Category ctx in list)
                {
                    writer.WriteLine(ctx.ToString()); 
                }
            }
        }

        public void Delete(int idx)
        {
            List<Category> list = GetAll(); //lấy về ds
            list.RemoveAt(idx); //xóa đối tượng theo vị trí
            using (StreamWriter writer = new StreamWriter(Category.PATH)) //mở luồng ghi file
            {
                foreach (Category ctx in list) //duyệt danh sácch
                {
                    writer.WriteLine(ctx.ToString()); //ghi file
                }
            }
        }

        public void Update(int idx, Category category)
        {
            List<Category> list = GetAll();//lấy về danh sách

            list[idx] = category;//cập nhật thông tin theo vị trí
            using (StreamWriter writer = new StreamWriter(Category.PATH))//mở luồng ghì file
            {
                foreach (Category ctx in list)//duyệt danh sách
                {
                    writer.WriteLine(ctx.ToString());//ghi filee
                }
            }
        }

        public Category DetailCategory(string id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}