using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model;
using System.Web;
using System.Configuration;
using System.Data.OleDb;

namespace DataLibrary
{
    public class DBTools
    {

        #region 文章相关

        /// <summary>
        /// 首页显示的各种文章10条
        /// </summary>
        /// <returns></returns>
        public static List<Model.Article> GetAllArticleList(string language)
        {
            List<Model.Article> result = new List<Article>();
            string sql = "";
            if (language == "en")
            {
                sql = string.Format(@"
                                select * from ( SELECT top 5 * FROM  [article_info] where typeid=1 and [language]='en' order by id desc ) as t1
                                UNION
                                select * from ( SELECT top 5 * FROM  [article_info] where typeid=2 and [language]='en' order by id desc ) as t2
                                UNION
                                select * from ( SELECT top 5 * FROM  [article_info] where typeid=3 and [language]='en' order by id desc ) as t3
                                UNION
                                select * from ( SELECT top 5 * FROM  [article_info] where typeid=4 and [language]='en' order by id desc ) as t4
                                UNION
                                select * from ( SELECT top 5 * FROM  [article_info] where typeid=5 and [language]='en' order by id desc ) as t5
                                UNION
                                select * from ( SELECT top 5 * FROM  [article_info] where typeid=6 and [language]='en' order by id desc ) as t6
                                UNION
                                select * from ( SELECT top 5 * FROM  [article_info] where typeid=7 and [language]='en' order by id desc ) as t7
                                UNION
                                select * from ( SELECT top 5 * FROM  [article_info] where typeid=8 and [language]='en' order by id desc ) as t8
                                UNION
                                select * from ( SELECT top 5 * FROM  [article_info] where typeid=9 and [language]='en' order by id desc ) as t9
                                ");

            }
            else
            {
                sql = string.Format(@"
                                select [id],[typeid],[title] ,[content],[author],[fileURL] ,[language] ,[addDate],[updateDate] from ( SELECT top 5 [id],[typeid],[title] ,[content],[author],[fileURL] ,[language] ,[addDate],[updateDate] FROM  [article_info] where typeid=1 and [language]='cn' order by [id] desc ) as ta
                                UNION
                                select [id],[typeid],[title] ,[content],[author],[fileURL] ,[language] ,[addDate],[updateDate] from ( SELECT top 5 [id],[typeid],[title] ,[content],[author],[fileURL] ,[language] ,[addDate],[updateDate] FROM  [article_info] where typeid=2 and [language]='cn' order by [id] desc ) as tb
                                UNION
                                select [id],[typeid],[title] ,[content],[author],[fileURL] ,[language] ,[addDate],[updateDate] from ( SELECT top 5 [id],[typeid],[title] ,[content],[author],[fileURL] ,[language] ,[addDate],[updateDate] FROM  [article_info] where typeid=3 and [language]='cn' order by [id] desc ) as tc
                                UNION
                                select [id],[typeid],[title] ,[content],[author],[fileURL] ,[language] ,[addDate],[updateDate] from ( SELECT top 5 [id],[typeid],[title] ,[content],[author],[fileURL] ,[language] ,[addDate],[updateDate] FROM  [article_info] where typeid=4 and [language]='cn' order by [id] desc ) as td
                                UNION
                                select [id],[typeid],[title] ,[content],[author],[fileURL] ,[language] ,[addDate],[updateDate] from ( SELECT top 5 [id],[typeid],[title] ,[content],[author],[fileURL] ,[language] ,[addDate],[updateDate] FROM  [article_info] where typeid=5 and [language]='cn' order by [id] desc ) as te
                                UNION
                                select [id],[typeid],[title] ,[content],[author],[fileURL] ,[language] ,[addDate],[updateDate] from ( SELECT top 5 [id],[typeid],[title] ,[content],[author],[fileURL] ,[language] ,[addDate],[updateDate] FROM  [article_info] where typeid=6 and [language]='cn' order by [id] desc ) as tf
                                UNION
                                select [id],[typeid],[title] ,[content],[author],[fileURL] ,[language] ,[addDate],[updateDate] from ( SELECT top 5 [id],[typeid],[title] ,[content],[author],[fileURL] ,[language] ,[addDate],[updateDate] FROM  [article_info] where typeid=7 and [language]='cn' order by [id] desc ) as tg
                                UNION
                                select [id],[typeid],[title] ,[content],[author],[fileURL] ,[language] ,[addDate],[updateDate] from ( SELECT top 5 [id],[typeid],[title] ,[content],[author],[fileURL] ,[language] ,[addDate],[updateDate] FROM  [article_info] where typeid=8 and [language]='cn' order by [id] desc ) as th
                                UNION
                                select [id],[typeid],[title] ,[content],[author],[fileURL] ,[language] ,[addDate],[updateDate] from ( SELECT top 5 [id],[typeid],[title] ,[content],[author],[fileURL] ,[language] ,[addDate],[updateDate] FROM  [article_info] where typeid=9 and [language]='cn' order by [id] desc ) as ti
                                ");

                //  sql = "select * from article_info where [language]='cn'";
            }


            DataSet ds = new DataSet();

            // ds = SqlHelper.ExecuteDataset(ConnString.GetConString, CommandType.Text, sql);

            ds = AccessHelper.ExecuteDataSet(AccessHelper.conn, sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Article art = new Article();
                    art.AddDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["addDate"].ToString());
                    art.Author = ds.Tables[0].Rows[i]["author"].ToString();
                    art.Content = ds.Tables[0].Rows[i]["content"].ToString();
                    art.FileURL = ds.Tables[0].Rows[i]["fileURL"].ToString();
                    art.Id = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    art.Title = ds.Tables[0].Rows[i]["title"].ToString();
                    art.Typeid = int.Parse(ds.Tables[0].Rows[i]["typeid"].ToString());
                    //art.UpdateDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["updateDate"].ToString());
                    art.Language = ds.Tables[0].Rows[i]["language"].ToString();
                    result.Add(art);
                }
            }
            return result;
        }

        /// <summary>
        /// 添加新文章
        /// </summary>
        /// <param name="art"></param>
        public static void AddArticle(Article art)
        {
            string sql = string.Format(@"insert into [article_info] (typeid,title,content,author,fileURL,[language])
                values ({0},'{1}','{2}','{3}','{5}','{4}')
                ", art.Typeid, art.Title.Replace("'", "''"), art.Content.Replace("'", "''"), art.Author, art.Language, art.FileURL);
            //object obj = SqlHelper.ExecuteScalar(ConnString.GetConString, CommandType.Text, sql.ToString());
            AccessHelper.ExecuteNonQuery(AccessHelper.conn, sql);
        }

        /// <summary>
        /// 根据类别获取文章数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static List<Article> GetArticleByType(int type, string language)
        {
            List<Model.Article> result = new List<Article>();
            string sql = " SELECT * FROM  [article_info] where typeid=" + type + " and [language]='" + language + "'  order by id desc";

            DataSet ds = new DataSet();
            ds = AccessHelper.ExecuteDataSet(AccessHelper.conn, sql);//SqlHelper.ExecuteDataset(ConnString.GetConString, CommandType.Text, sql);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Article art = new Article();
                    art.AddDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["addDate"].ToString());
                    art.Author = ds.Tables[0].Rows[i]["author"].ToString();
                    art.Content = ds.Tables[0].Rows[i]["content"].ToString();
                    art.FileURL = ds.Tables[0].Rows[i]["fileURL"].ToString();
                    art.Id = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    art.Title = ds.Tables[0].Rows[i]["title"].ToString();
                    art.Typeid = int.Parse(ds.Tables[0].Rows[i]["typeid"].ToString());
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["updateDate"].ToString()))
                    {
                        art.UpdateDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["updateDate"].ToString());
                    }
                    art.Language = ds.Tables[0].Rows[i]["language"].ToString();
                    result.Add(art);
                }
            }
            return result;
        }

        /// <summary>
        /// 获取最新文章内容数据（不包括下载）
        /// </summary>
        /// <param name="type"></param>
        /// <param name="language"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public static List<Article> GetArticleByType(int type, string language, int top)
        {
            List<Model.Article> result = new List<Article>();
            string sql = " SELECT top " + top + " * FROM  [article_info] where typeid=" + type + " and [language]='" + language + "'  order by id desc";
            if (type == 99)
            {
                sql = " SELECT top " + top + " * FROM  [article_info] where [language]='" + language + "' and typeid not in(1,6,8,3,4) order by id desc";
            }
            DataSet ds = new DataSet();
            ds = AccessHelper.ExecuteDataSet(AccessHelper.conn, sql);//SqlHelper.ExecuteDataset(ConnString.GetConString, CommandType.Text, sql);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Article art = new Article();
                    art.AddDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["addDate"].ToString());
                    art.Author = ds.Tables[0].Rows[i]["author"].ToString();
                    art.Content = ds.Tables[0].Rows[i]["content"].ToString();
                    art.FileURL = ds.Tables[0].Rows[i]["fileURL"].ToString();
                    art.Id = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    art.Title = ds.Tables[0].Rows[i]["title"].ToString();
                    art.Typeid = int.Parse(ds.Tables[0].Rows[i]["typeid"].ToString());
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["updateDate"].ToString()))
                    {
                        art.UpdateDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["updateDate"].ToString());
                    }
                    art.Language = ds.Tables[0].Rows[i]["language"].ToString();
                    result.Add(art);
                }
            }
            return result;
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteArticleById(int id)
        {
            string sql = string.Format(@"delete from  [article_info] where id=" + id);
            // object obj = SqlHelper.ExecuteScalar(ConnString.GetConString, CommandType.Text, sql.ToString());
            AccessHelper.ExecuteNonQuery(AccessHelper.conn, sql);
        }

        /// <summary>
        /// 获取一篇文章信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static Article GetArticleById(int id, string language)
        {
            Article art = new Article();
            string sql = " SELECT * FROM  [article_info] where id=" + id + " and [language]='" + language + "' ";

            DataSet ds = new DataSet();
            ds = AccessHelper.ExecuteDataSet(AccessHelper.conn, sql);//SqlHelper.ExecuteDataset(ConnString.GetConString, CommandType.Text, sql);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    art.AddDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["addDate"].ToString());
                    art.Author = ds.Tables[0].Rows[i]["author"].ToString();
                    art.Content = ds.Tables[0].Rows[i]["content"].ToString();
                    art.FileURL = ds.Tables[0].Rows[i]["fileURL"].ToString();
                    art.Id = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    art.Title = ds.Tables[0].Rows[i]["title"].ToString();
                    art.Typeid = int.Parse(ds.Tables[0].Rows[i]["typeid"].ToString());
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["updateDate"].ToString()))
                    {
                        art.UpdateDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["updateDate"].ToString());
                    }
                    art.Language = ds.Tables[0].Rows[i]["language"].ToString();
                }
            }
            return art;
        }

        /// <summary>
        /// 更新文章信息
        /// </summary>
        /// <param name="art"></param>
        public static void UpdateArticle(Article art)
        {
            string sql = "update [article_info] set title='" + art.Title.Replace("'", "''") + "',content='" + art.Content.Replace("'", "''") + "',author='" + art.Author + "',[language]='" + art.Language + "',updateDate=NOW() where id=" + art.Id;

            //object obj = SqlHelper.ExecuteScalar(ConnString.GetConString, CommandType.Text, sql.ToString());
            AccessHelper.ExecuteNonQuery(AccessHelper.conn, sql);
        }

        #endregion

        #region 文件相关
        /// <summary>
        /// 更新文件信息
        /// </summary>
        /// <param name="art"></param>
        public static void UpdateFile(Article art)
        {
            string sql = "";
            if (string.IsNullOrEmpty(art.FileURL))
            {
                sql = string.Format(@"update [article_info] set title='" + art.Title + "',[language]='" + art.Language + "' where id=" + art.Id);
            }
            else
            {
                sql = string.Format(@"update [article_info] set title='" + art.Title + "',[language]='" + art.Language + "', fileURL='" + art.FileURL + "' where id=" + art.Id);
            }
            //object obj = SqlHelper.ExecuteScalar(ConnString.GetConString, CommandType.Text, sql.ToString());
            AccessHelper.ExecuteNonQuery(AccessHelper.conn, sql);
        }

        /// <summary>
        /// 添加一张图片
        /// </summary>
        /// <param name="pic"></param>
        public static void AddPicture(Picture pic)
        {
            string sql = string.Format(@"INSERT INTO  [picture_info]
                       ([title]
                       ,[fileURL]
                        )
                 VALUES
                       ('{0}'
                       ,'{1}')
            ", pic.Title, pic.FileURL);
            //object obj = SqlHelper.ExecuteScalar(ConnString.GetConString, CommandType.Text, sql.ToString());
            AccessHelper.ExecuteNonQuery(AccessHelper.conn, sql);
        }

        /// <summary>
        /// 获取图片列表
        /// </summary>
        /// <returns></returns>
        public static List<Picture> GetAllPicture()
        {
            List<Picture> result = new List<Picture>();
            string sql = " SELECT * FROM  [picture_info] ";

            DataSet ds = new DataSet();
            ds = AccessHelper.ExecuteDataSet(AccessHelper.conn, sql);//SqlHelper.ExecuteDataset(ConnString.GetConString, CommandType.Text, sql);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Picture pic = new Picture();
                    pic.AddDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["addDate"].ToString());

                    pic.FileURL = ds.Tables[0].Rows[i]["fileURL"].ToString().Replace("IndexImages/", "IndexImages/small_");
                    pic.Id = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    pic.Title = ds.Tables[0].Rows[i]["title"].ToString();
                    pic.Station = int.Parse(ds.Tables[0].Rows[i]["station"].ToString());
                    result.Add(pic);
                }
            }
            return result;
        }

        public static Picture GetOnePicture(int id)
        {
            Picture pic = new Picture();
            string sql = " SELECT * FROM  [picture_info] where id=" + id;

            DataSet ds = new DataSet();
            ds = AccessHelper.ExecuteDataSet(AccessHelper.conn, sql);//SqlHelper.ExecuteDataset(ConnString.GetConString, CommandType.Text, sql);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    pic.AddDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["addDate"].ToString());

                    pic.FileURL = ds.Tables[0].Rows[i]["fileURL"].ToString();
                    pic.Id = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    pic.Title = ds.Tables[0].Rows[i]["title"].ToString();
                    pic.Station = int.Parse(ds.Tables[0].Rows[i]["station"].ToString());

                }
            }
            return pic;
        }

        public static void DeletePicture(int picId)
        {
            string sql = string.Format(@"delete from  [picture_info]
                       where id=" + picId);
            //object obj = SqlHelper.ExecuteScalar(ConnString.GetConString, CommandType.Text, sql.ToString());
            AccessHelper.ExecuteNonQuery(AccessHelper.conn, sql);
        }

        public static bool CheckPictureCount()
        {
            string sql = string.Format(@"select count(*) from  [picture_info]");
            object obj = AccessHelper.ExecuteScalar(AccessHelper.conn, sql);//SqlHelper.ExecuteScalar(ConnString.GetConString, CommandType.Text, sql.ToString());
            int count = Convert.ToInt32(obj);
            if (count < int.Parse(System.Configuration.ConfigurationManager.AppSettings["IndexPictureCount"].ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void AddFileInfo(Article art)
        {
            string sql = string.Format(@"insert into [article_info] (typeid,title,content,author,fileURL,[language])
                values ({0},'{1}','{2}','{3}','{5}','{4}')
                ", art.Typeid, art.Title.Replace("'", "''"), art.Content, art.Author, art.Language, art.FileURL);
            //object obj = SqlHelper.ExecuteScalar(ConnString.GetConString, CommandType.Text, sql.ToString());
            AccessHelper.ExecuteNonQuery(AccessHelper.conn, sql);
        }
        #endregion

        #region 用户相关
        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool AddUser(Model.User user)
        {
            string sql = string.Format(@"
                INSERT INTO  [user_info]
                           ([email]
                           ,[password]
                           ,[trueName]
                           ,[school]
                           ,[interest]
                           ,[station]
                           ,[type]
                           )
                     VALUES
                           ('{0}'
                           ,'{1}'
                           ,'{2}'
                           ,'{3}'
                           ,'{4}'
                           ,0
                           ,0
           )", user.Email.Replace("'", "''"), user.Password.Replace("'", "''"), user.TrueName.Replace("'", "''"), user.School.Replace("'", "''"), user.Interest.Replace("'", "''"));


            string checksql = "select count(*) from user_info where email='" + user.Email + "'";
            object count = AccessHelper.ExecuteScalar(AccessHelper.conn, checksql);//SqlHelper.ExecuteScalar(ConnString.GetConString, CommandType.Text, checksql.ToString());
            if (Convert.ToInt32(count) > 0)
            {
                return false;
            }
            else
            {
                object obj = AccessHelper.ExecuteNonQuery(AccessHelper.conn, sql);//SqlHelper.ExecuteScalar(ConnString.GetConString, CommandType.Text, sql.ToString());
                return true;
            }
        }

        /// <summary>
        /// 检查用户登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static User CheckLogin(Model.User user)
        {
            User result = new User();

            string sql = " SELECT * FROM  [user_info] where email='" + user.Email + "' and password='" + user.Password + "' ";

            DataSet ds = new DataSet();
            ds = AccessHelper.ExecuteDataSet(AccessHelper.conn, sql);//SqlHelper.ExecuteDataset(ConnString.GetConString, CommandType.Text, sql);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    result.AddDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["addDate"].ToString());
                    result.Email = ds.Tables[0].Rows[i]["email"].ToString();
                    result.Interest = ds.Tables[0].Rows[i]["interest"].ToString();
                    result.Password = ds.Tables[0].Rows[i]["password"].ToString();
                    result.Id = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    result.School = ds.Tables[0].Rows[i]["school"].ToString();
                    result.TrueName = ds.Tables[0].Rows[i]["trueName"].ToString();
                    result.Type = int.Parse(ds.Tables[0].Rows[i]["type"].ToString());
                    result.Station = int.Parse(ds.Tables[0].Rows[i]["station"].ToString());
                }
                return result;
            }
            return null;
        }

        /// <summary>
        /// 检查用户身份信息
        /// </summary>
        /// <returns></returns>
        public static User CheckUser()
        {
            User user = new User();
            if (HttpContext.Current.Request.Cookies["user_key"] == null)// 没登陆
            {
                return null;
            }
            else
            {
                string key = HttpContext.Current.Request.Cookies["user_key"].Value.ToString();
                if (HttpContext.Current.Session["user_" + key.Split('&')[0].ToString()] == null)
                {
                    return null;
                }
                else
                {
                    if (HttpContext.Current.Session["user_" + key.Split('&')[0].ToString()].ToString() != key)
                    {
                        return null;
                    }
                    else
                    {
                        user = (User)HttpContext.Current.Session["UserModel_" + key.Split('&')[0].ToString()];
                        return user;
                    }
                }
            }
        }

        /// <summary>
        /// 获取全部用户列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.User> GetAllUserList()
        {
            List<Model.User> list = new List<User>();
            string sql = string.Format(@"
                select * from [user_info] order by id desc
                ");

            DataSet ds = new DataSet();
            ds = AccessHelper.ExecuteDataSet(AccessHelper.conn, sql);//SqlHelper.ExecuteDataset(ConnString.GetConString, CommandType.Text, sql);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    User result = new User();

                    result.AddDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["addDate"].ToString());
                    result.Email = ds.Tables[0].Rows[i]["email"].ToString();
                    result.Interest = ds.Tables[0].Rows[i]["interest"].ToString();
                    result.Password = ds.Tables[0].Rows[i]["password"].ToString();
                    result.Id = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    result.School = ds.Tables[0].Rows[i]["school"].ToString();
                    result.TrueName = ds.Tables[0].Rows[i]["trueName"].ToString();
                    result.Type = int.Parse(ds.Tables[0].Rows[i]["type"].ToString());
                    result.Station = int.Parse(ds.Tables[0].Rows[i]["station"].ToString());

                    list.Add(result);
                }
            }
            return list;
        }
        #endregion

        public static void UpdateContact(string language, string info)
        {
            string sql = "update [contact_info] set info='" + info + "' where [language]='" + language + "'";

            //object obj = SqlHelper.ExecuteScalar(ConnString.GetConString, CommandType.Text, sql.ToString());
            AccessHelper.ExecuteNonQuery(AccessHelper.conn, sql);
        }

        public static void UpdateCommittee(string language, string info)
        {
            string sql = "update [other_info] set info='" + info + "' where [language]='" + language + "' and keyname='Committee' ";

            //object obj = SqlHelper.ExecuteScalar(ConnString.GetConString, CommandType.Text, sql.ToString());
            AccessHelper.ExecuteNonQuery(AccessHelper.conn, sql);
        }

        public static DataTable GetContactByLanguage(string lang)
        {
            string sql = "select * from contact_info where [language]='" + lang + "'";

            DataSet ds = new DataSet();
            ds = AccessHelper.ExecuteDataSet(AccessHelper.conn, sql);// SqlHelper.ExecuteDataset(ConnString.GetConString, CommandType.Text, sql.ToString());

            return ds.Tables[0];
        }

        #region 人员相关
        public static void AddPerson(Person p)
        {
            string sql = string.Format("insert into person_info(pname,zhicheng,phone,email,lingyu,type,fileURL,[language],teacherURL) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                p.Pname, p.Zhicheng.Replace("'", "''"), p.Phone, p.Email, p.Lingyu.Replace("'", "''"), p.Type, p.FileURL, p.Language, p.TeacherURL
                );

            //object obj = SqlHelper.ExecuteScalar(ConnString.GetConString, CommandType.Text, sql.ToString());
            AccessHelper.ExecuteNonQuery(AccessHelper.conn, sql);
        }

        public static List<Model.Person> GetAllPersonList(string language)
        {
            List<Model.Person> list = new List<Person>();
            string sql = string.Format(@"
                select * from [person_info] where [language]='" + language + "'  order by id desc");

            DataSet ds = new DataSet();
            ds = AccessHelper.ExecuteDataSet(AccessHelper.conn, sql);//SqlHelper.ExecuteDataset(ConnString.GetConString, CommandType.Text, sql);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Person result = new Person();

                    result.AddDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["addDate"].ToString());
                    result.Email = ds.Tables[0].Rows[i]["email"].ToString();
                    result.FileURL = ds.Tables[0].Rows[i]["fileURL"].ToString();
                    result.Lingyu = ds.Tables[0].Rows[i]["lingyu"].ToString();
                    result.Id = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    result.Phone = ds.Tables[0].Rows[i]["phone"].ToString();
                    result.Pname = ds.Tables[0].Rows[i]["pname"].ToString();
                    result.Type = ds.Tables[0].Rows[i]["type"].ToString();
                    result.Zhicheng = ds.Tables[0].Rows[i]["zhicheng"].ToString();
                    result.Language = ds.Tables[0].Rows[i]["language"].ToString();
                    result.TeacherURL = ds.Tables[0].Rows[i]["teacherURL"].ToString();
                    list.Add(result);
                }
            }
            return list;
        }

        public static List<Model.Person> GetAllPersonList(string language, string personType)
        {
            List<Model.Person> list = new List<Person>();
            string sql = string.Format(@"
                select * from [person_info] where [language]='" + language + "' and type='" + personType + "' order by id asc");

            DataSet ds = new DataSet();
            ds = AccessHelper.ExecuteDataSet(AccessHelper.conn, sql);//SqlHelper.ExecuteDataset(ConnString.GetConString, CommandType.Text, sql);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Person result = new Person();

                    result.AddDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["addDate"].ToString());
                    result.Email = ds.Tables[0].Rows[i]["email"].ToString();
                    result.FileURL = ds.Tables[0].Rows[i]["fileURL"].ToString();
                    result.Lingyu = ds.Tables[0].Rows[i]["lingyu"].ToString();
                    result.Id = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    result.Phone = ds.Tables[0].Rows[i]["phone"].ToString();
                    result.Pname = ds.Tables[0].Rows[i]["pname"].ToString();
                    result.Type = ds.Tables[0].Rows[i]["type"].ToString();
                    result.Zhicheng = ds.Tables[0].Rows[i]["zhicheng"].ToString();
                    result.Language = ds.Tables[0].Rows[i]["language"].ToString();
                    result.TeacherURL = ds.Tables[0].Rows[i]["teacherURL"].ToString();
                    list.Add(result);
                }
            }
            return list;
        }

        public static void DeletePersonById(int id)
        {
            string sql = string.Format("delete from  person_info where id=" + id);

            //object obj = SqlHelper.ExecuteScalar(ConnString.GetConString, CommandType.Text, sql.ToString());
            AccessHelper.ExecuteNonQuery(AccessHelper.conn, sql);
        }

        public static Person GetOnePerson(int id, string lang)
        {
            Person result = new Person();
            string sql = string.Format(@"
                select * from [person_info] where [language]='" + lang + "' and id=" + id);

            DataSet ds = new DataSet();
            ds = AccessHelper.ExecuteDataSet(AccessHelper.conn, sql);//SqlHelper.ExecuteDataset(ConnString.GetConString, CommandType.Text, sql);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    result.AddDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["addDate"].ToString());
                    result.Email = ds.Tables[0].Rows[i]["email"].ToString();
                    result.FileURL = ds.Tables[0].Rows[i]["fileURL"].ToString();
                    result.Lingyu = ds.Tables[0].Rows[i]["lingyu"].ToString();
                    result.Id = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    result.Phone = ds.Tables[0].Rows[i]["phone"].ToString();
                    result.Pname = ds.Tables[0].Rows[i]["pname"].ToString();
                    result.Type = ds.Tables[0].Rows[i]["type"].ToString();
                    result.Zhicheng = ds.Tables[0].Rows[i]["zhicheng"].ToString();
                    result.Language = ds.Tables[0].Rows[i]["language"].ToString();
                    result.TeacherURL = ds.Tables[0].Rows[i]["teacherURL"].ToString();
                }
            }
            return result;
        }

        public static void UpdateOnePerson(Person p)
        {
            string sql = string.Format(@"update person_info set pname='{0}',zhicheng='{1}', phone='{2}', email='{3}' ,lingyu='{4}', type='{5}'
                ,[language]='{6}',teacherURL='{8}'  where id={7}", p.Pname, p.Zhicheng.Replace("'", "''"), p.Phone, p.Email, p.Lingyu.Replace("'", "''"), p.Type, p.Language, p.Id, p.TeacherURL);
            AccessHelper.ExecuteNonQuery(AccessHelper.conn, sql);
        }

        public static DataTable GetCommitteeByLanguage(string language)
        {
            DataTable dt = new DataTable();
            string sql = "select * from other_info where keyname='Committee' and [language]='" + language + "'";
            dt = AccessHelper.ExecuteDataSet(AccessHelper.conn, sql).Tables[0];
            //SqlHelper.ExecuteDataset(ConnString.GetConString, CommandType.Text, sql);
            return dt;
        }
        #endregion


        public static void UpdateSeminars(Article art)
        {
            string sql = "update [article_info] set fileURL='" + art.FileURL + "', title='" + art.Title.Replace("'", "''") + "',content='" + art.Content.Replace("'", "''") + "',author='" + art.Author + "',[language]='" + art.Language + "',updateDate=NOW() where id=" + art.Id;

            //object obj = SqlHelper.ExecuteScalar(ConnString.GetConString, CommandType.Text, sql.ToString());
            AccessHelper.ExecuteNonQuery(AccessHelper.conn, sql);
        }

        #region 其他方法

        /// <summary>  
        /// 图片缩放  
        /// </summary>  
        /// <param name="originalImagePath">原始图片路径，如：c:\\images\\1.gif</param>  
        /// <param name="thumbnailPath">生成缩略图图片路径，如：c:\\images\\2.gif</param>  
        /// <param name="width">宽</param>  
        /// <param name="height">高</param>  
        /// <param name="mode">EQU：指定最大高宽等比例缩放；HW：//指定高宽缩放（可能变形）；W:指定宽，高按比例；H:指定高，宽按比例；Cut：指定高宽裁减（不变形）</param>  
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            if (mode == "EQU")//指定最大高宽，等比例缩放  
            {
                //if(height/oh>width/ow),如果高比例多，按照宽来缩放；如果宽的比例多，按照高来缩放  
                if (height * ow > width * oh)
                {
                    mode = "W";
                }
                else
                {
                    mode = "H";
                }
            }
            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）                     
                    break;
                case "W"://指定宽，高按比例                         
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例     
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）                     
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片     
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板     
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法     
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度     
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充     
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分     
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                new System.Drawing.Rectangle(x, y, ow, oh),
                System.Drawing.GraphicsUnit.Pixel);
            try
            {
                //以jpg格式保存缩略图     
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        #endregion

    }
}
