using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUSAuction;
using DTOAuction;
using System.Web.UI.MobileControls;
using System.Windows.Forms;
using Google;
using Google.Picasa;
using Google.GData;
using Google.GData.Photos;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.Extensions.Location;


namespace WebDoanHoi_layout.administration.templateLoad.Album
{
    public partial class SPHOTO
    {
        public string title;
        public string _thumbURL;
        public string thumbURL
        {
            get 
            {
                return _thumbURL;
            }
            set
            {
                _thumbURL = value;
            }
        }

    }
    public partial class wucAlbum : System.Web.UI.UserControl
    {
        
        List<AlbumAccessor> listAlbum = new List<AlbumAccessor>();
        //List<PicasaEntry> listPhoto = new List<PicasaEntry>();
        PicasaService service = new PicasaService("webdoantruong");

        AlbumQuery query = new AlbumQuery(PicasaQuery.CreatePicasaUri("doantruong.khtn@gmail.com"));

        PicasaFeed feed;

        AlbumAccessor currentAlbum;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Danh Sách Album";

            service.setUserCredentials("doantruong.khtn@gmail.com", "doantruong");
            feed = service.Query(query);
            foreach (PicasaEntry entry in feed.Entries)
            {
                AlbumAccessor ac = new AlbumAccessor(entry);
                listAlbum.Add(ac);
            }
            if (!IsPostBack)
            {
                int soDong = LoadAlbum();
                FilterSTT(soDong, 0, 10);
            }
            this.GridViewPicasa.HeaderStyle.CssClass = "headerstyle";



            //photos
            
            string maAlbum = null;
            List<SPHOTO> listPhotos = new List<SPHOTO>();
            if(Request.QueryString["id"] != null)
            {
                maAlbum = Request.QueryString["id"].ToString();
            }
            if(maAlbum != null)
            {
                PhotoQuery Pquery = new PhotoQuery(PicasaQuery.CreatePicasaUri("doantruong.khtn@gmail.com",maAlbum));
                feed = service.Query(Pquery);
                foreach (PicasaEntry entry in feed.Entries)
                {
                    SPHOTO temp = new SPHOTO();
                    
                    temp.title = entry.Title.Text;
                    temp.thumbURL = entry.Media.Thumbnails[1].Attributes["url"] as string; 
                    listPhotos.Add(temp);
                    
                    
                }
                ListViewPhotos.DataSource = listPhotos;
                ListViewPhotos.DataBind();
            }
            if (maAlbum != null)
            {
                //lay ma

                //lay thong tin va load len cac textbox
                for (int i = 0; i < listAlbum.Count; i++)
                {
                    if (listAlbum[i].Id == maAlbum)
                    {
                        currentAlbum = listAlbum[i];
                        break;
                    }
                }
                switch (currentAlbum.Access)
                {
                    case "public":
                        DropDownListAccess.SelectedIndex = 0;
                        break;

                    case "private":
                        DropDownListAccess.SelectedIndex = 1;
                        break;
                    case "protected":
                        DropDownListAccess.SelectedIndex = 2;
                        break;

                }
                txtalbumtitle.Text = currentAlbum.AlbumTitle;
                txtmieuta.Text = currentAlbum.AlbumSummary;
            }
        }
        //Do STT
        public void FilterSTT(int TongSoDong, int TrangHienTai, int SoDongTrenTrang)
        {
            int stt = 0;
            for (int i = TrangHienTai * SoDongTrenTrang; i < TongSoDong && i < (TrangHienTai + 1) * SoDongTrenTrang; i++)
            {
                GridViewPicasa.Rows[stt].Cells[0].Text = (i + 1).ToString();
                stt += 1;
            }
        }
        //Load
        public int LoadAlbum()
        {

            if (listAlbum.Count > 0)
            {
                GridViewPicasa.DataSource = listAlbum;
                GridViewPicasa.DataBind();
                PanelDanhSach.Visible = true;
                PanelMessage.Visible = false;
                return listAlbum.Count;
            }
            else
            {
                PanelDanhSach.Visible = false;
                PanelMessage.Visible = true;
                return 0;
            }
        }

        //Chon Phan Trang Theo y nguoi dung: 5, 10, 15, 20,..
        protected void DropDownListPaging_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridViewPicasa.PageSize = int.Parse(DropDownListPaging.SelectedValue);
            int SoDong = LoadAlbum();
            FilterSTT(SoDong, GridViewPicasa.PageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }
        //Chon trang NEXT
        protected void GridViewPicasa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPicasa.PageIndex = e.NewPageIndex;
            int SoDong = LoadAlbum();
            FilterSTT(SoDong, e.NewPageIndex, int.Parse(DropDownListPaging.SelectedValue));
        }

        protected void GridViewPicasa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "XoaAlbum")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                foreach (PicasaEntry entry in feed.Entries)
                {
                    AlbumAccessor ac = new AlbumAccessor(entry);
                    if(listAlbum[index].Id == ac.Id)
                        XoaAlbum(entry);
                }
            }

        }
        protected void XoaAlbum(PicasaEntry entry)
        {
            try
            {
                //xac nhan truoc khi xoa
                AlbumAccessor album = new AlbumAccessor(entry);
                DialogResult rs = MessageBox.Show("Bạn có chắc là muốn xoá Album <" + album.AlbumTitle + "> không?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    //Goi ham xoa
                    entry.Delete();
                    //Thong bao
                    DialogResult rs1 = MessageBox.Show("Xoá Album thành công", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Response.Redirect("Album.aspx");

                }
                else
                {
                    Response.Redirect("Album.aspx");
                }
            }

            catch
            {
            }
        
        }
        protected void lbtnThemAlbum_Click(object sender, EventArgs e)
        {
            AlbumEntry newEntry = new AlbumEntry();

            currentAlbum = new AlbumAccessor(newEntry);
            switch (DropDownListAccess.SelectedIndex)
            {
                case 0:
                    currentAlbum.Access = "public";
                    break;
                case 1:
                    currentAlbum.Access = "private";
                    break;
                case 2:
                    currentAlbum.Access = "protected";
                    break;
            }
            newEntry.Title.Text = txtalbumtitle.Text;
            newEntry.Summary.Text = txtmieuta.Text;
            currentAlbum.AlbumAuthor = listAlbum[0].AlbumAuthor;
            currentAlbum.AlbumAuthorNickname = listAlbum[0].AlbumAuthorNickname;

            Uri feedUri = new Uri(PicasaQuery.CreatePicasaUri("doantruong.khtn@gmail.com"));
            PicasaEntry createdEntry = (PicasaEntry)service.Insert(feedUri, newEntry);

            Response.Redirect("Album.aspx");
        }


        protected void lbtnCapNhatAlbum_Click(object sender, EventArgs e)
        {
            string maAlbum = Convert.ToString(Request.QueryString["id"]);
            for (int i = 0; i < listAlbum.Count; i++)
            {
                if (listAlbum[i].Id == maAlbum)
                {
                    currentAlbum = listAlbum[i];
                    break;
                }
            }
            foreach (PicasaEntry entry in feed.Entries)
            {
                if (entry.Id.ToString() == maAlbum)
                {
                    entry.Title.Text = txtalbumtitle.Text;
                    entry.Summary.Text = txtmieuta.Text;
                    currentAlbum = new AlbumAccessor(entry);
                    switch (DropDownListAccess.SelectedIndex)
                    {
                        case 0:
                            currentAlbum.Access = "public";
                            break;
                        case 1:
                            currentAlbum.Access = "private";
                            break;
                        case 2:
                            currentAlbum.Access = "protected";
                            break;
                    }
                    entry.Update();
                    break;
                }
            }

            Response.Redirect("Album.aspx");
        }


    }
}