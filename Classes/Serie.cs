using System;

namespace series_register
{
    public class Serie : BaseEntity
    {
        
        private Gender Gender { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        public Serie(int id, Gender gender, string title, string description, int year)
        {
            this.Id = id;
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string stringReturn = "";
            stringReturn += "Gênero: " + this.Gender + Environment.NewLine;
            stringReturn += "Título: " + this.Title + Environment.NewLine;
            stringReturn += "Descrição: " + this.Description + Environment.NewLine;
            stringReturn += "Ano de início: " + this.Year + Environment.NewLine;
            return stringReturn;
        }

        public string GetTitle()
        {
            return this.Title;
        }

        public int GetId()
        {
            return this.Id;
        }

        public void Delete()
        {
            this.Deleted = true;
        }
    }
    
}