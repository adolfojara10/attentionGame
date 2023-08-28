using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataBank
{
    public class EstudianteEntity
    {
        public string _id;
        public string _name;
        public string _lastName;
        public string _born;


        public EstudianteEntity(string id, String name, string lastName, string born)
        {
            _id = id;
            _name = name;
            _lastName = lastName;
            _born = born;
        }


    }
}