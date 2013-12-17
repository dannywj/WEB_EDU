using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Picture
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string fileURL;
        public string FileURL
        {
            get { return fileURL; }
            set { fileURL = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private DateTime addDate;

        public DateTime AddDate
        {
            get { return addDate; }
            set { addDate = value; }
        }


        private int station;
        public int Station
        {
            get { return station; }
            set { station = value; }
        }

    }
}
