using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataBank
{
    public class EstudianteEntity
    {
        public string _id;
        public string _cedula;
        public string _nivelBasica;
        public string _gender;
        public string _born;

        public EstudianteEntity()
        {

        }


        public EstudianteEntity(string id, String cedula, string nivelBasica, string gender, string born)
        {
            _id = id;
            _cedula = cedula;
            _nivelBasica = nivelBasica;
            _gender = gender;
            _born = born;
        }


    }
}