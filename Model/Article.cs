using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Article
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int typeid;

        public int Typeid
        {
            get { return typeid; }
            set { typeid = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        private string fileURL;

        public string FileURL
        {
            get { return fileURL; }
            set { fileURL = value; }
        }
        private DateTime addDate;

        public DateTime AddDate
        {
            get { return addDate; }
            set { addDate = value; }
        }
        private DateTime updateDate;

        public DateTime UpdateDate
        {
            get { return updateDate; }
            set { updateDate = value; }
        }

        private string language;

        public string Language
        {
            get { return language; }
            set { language = value; }
        }
       
    }
}
