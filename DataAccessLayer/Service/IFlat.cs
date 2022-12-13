using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.DataAccessLayer.Service
{
    public interface IFlat
    {
        List<Flat> GetAll(); //Get all the list


        void Add(Flat flat);

        void Delete(int idx);


        void Update(int idx, Flat flat);


        Flat DetailFlat(string id);
       
    }
}
