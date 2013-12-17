using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLibrary;
using Model;

public partial class User_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetData();
    }

    public void GetData()
    {
        //获取所有数据列表
        List<Model.Article> allList = DBTools.GetAllArticleList("en");
        if (allList.Count > 0)
        {
            // 绑定通知公告
            List<Model.Article> noticeList = allList.FindAll(f => f.Typeid == 1).OrderByDescending(t => t.Id).ToList();
            try
            {
                noticeList.RemoveRange(5, 5);
            }
            catch (Exception)
            {

            }
            Rpt_gonggao.DataSource = noticeList;
            Rpt_gonggao.DataBind();

            // 绑定中心概况  中心动态
            List<Model.Article> gaikuangList = allList.FindAll(f => f.Typeid == 7).OrderByDescending(t => t.Id).ToList();
            Rpt_gaikuang.DataSource = gaikuangList;
            Rpt_gaikuang.DataBind();

            // 绑定学术讲座
            List<Model.Article> jiangzuoList = allList.FindAll(f => f.Typeid == 4).OrderByDescending(t => t.Id).ToList();
            Rpt_jiangzuo.DataSource = jiangzuoList;
            Rpt_jiangzuo.DataBind();

            // 绑定研究成果
            List<Model.Article> chengguoList = allList.FindAll(f => f.Typeid == 5).OrderByDescending(t => t.Id).ToList();
            Rpt_chengguo.DataSource = chengguoList;
            Rpt_chengguo.DataBind();

            // 绑定资料下载  科研项目
            List<Model.Article> downList = allList.FindAll(f => f.Typeid == 9).OrderByDescending(t => t.Id).ToList();
            Rpt_down.DataSource = downList;
            Rpt_down.DataBind();

            // 绑定中心人员 合作机构
            List<Model.Article> personList = allList.FindAll(f => f.Typeid == 8).OrderByDescending(t => t.Id).ToList();
            Rpt_renyuan.DataSource = personList;
            Rpt_renyuan.DataBind();
        }

        //绑定首页图片
        List<Picture> pList = DBTools.GetAllPicture();
        Rpt_PictureList.DataSource = pList;
        Rpt_PictureList.DataBind();
    }
}