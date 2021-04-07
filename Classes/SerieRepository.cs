using System;
using System.Collections.Generic;
using series_register.Interfaces;

namespace series_register
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> SeriesList = new List<Serie>();
        public void Delete(int id)
        {
            SeriesList[id].Delete();
        }

        public Serie GetById(int id)
        {
            return SeriesList[id];
        }

        public void Insert(Serie entity)
        {
            SeriesList.Add(entity);
        }

        public List<Serie> List()
        {
            return SeriesList;
        }

        public int NextID()
        {
            return SeriesList.Count;
        }

        public void Update(int id, Serie entity)
        {
            SeriesList[id] = entity;
        }
    }
}