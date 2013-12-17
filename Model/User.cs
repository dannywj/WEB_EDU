using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class User
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int station;

        public int Station
        {
            get { return station; }
            set { station = value; }
        }
        private string interest;

        public string Interest
        {
            get { return interest; }
            set { interest = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string trueName;

        public string TrueName
        {
            get { return trueName; }
            set { trueName = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private DateTime addDate;

        public DateTime AddDate
        {
            get { return addDate; }
            set { addDate = value; }
        }
        //private DateTime updateDate;

        //public DateTime UpdateDate
        //{
        //    get { return updateDate; }
        //    set { updateDate = value; }
        //}

        private string school;

        public string School
        {
            get { return school; }
            set { school = value; }
        }

        private int type;

        public int Type
        {
            get { return type; }
            set { type = value; }
        }



    }

    public class Person
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private string pname;

        public string Pname
        {
            get { return pname; }
            set { pname = value; }
        }
        private string zhicheng;

        public string Zhicheng
        {
            get { return zhicheng; }
            set { zhicheng = value; }
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string lingyu;

        public string Lingyu
        {
            get { return lingyu; }
            set { lingyu = value; }
        }
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private DateTime addDate;

        public DateTime AddDate
        {
            get { return addDate; }
            set { addDate = value; }
        }

        private string fileURL;

        public string FileURL
        {
            get { return fileURL; }
            set { fileURL = value; }
        }

        private string language;

        public string Language
        {
            get { return language; }
            set { language = value; }
        }

        private string teacherURL;

        public string TeacherURL
        {
            get { return teacherURL; }
            set { teacherURL = value; }
        }


    }
}
