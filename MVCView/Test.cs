using System;
using System.Data;
using System.Windows.Forms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MVCView
{
    public partial class Test : Form
    {
        private SqlConnection con;
        TreeNode parentNode = null;
        ObservableCollection<GMapMarker> Markers;
        GMarkerGoogle currentMarker = null;
        GMapMarker currentMarkerMap = null;

        float apsuat = 33;
        float luuluong = 2450;
        double Battery = 12.5;

        public Test()
        {
            InitializeComponent();
            connectDB();
        }

        //Connection String
        string cs = ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;

        private void Test_Load(object sender, EventArgs e)
        {
            Markers = new ObservableCollection<GMapMarker>();
            setUpMap();
            loadTreeView(string.Empty);    
        }

        private void setUpMap()
        {
            this.gmap.MapProvider = GoogleMapProvider.Instance;
            Singleton<GMaps>.Instance.Mode = AccessMode.ServerOnly;
            gmap.SetPositionByKeywords("Hue, VietNam");
            this.gmap.ShowCenter = false;
            this.gmap.CanDragMap = true;
            this.ShowTileGridLines = true;
            this.gmap.DragButton = MouseButtons.Left;
        }

        private void loadTreeView(string nameStation)
        {
            try
            {
                tvListTram.Nodes.Clear();

                String sqlSelectKV = " SELECT * FROM KHUVUC ";
                DataTable dt = PDatatable(sqlSelectKV.ToString());

                foreach (DataRow dr in dt.Rows)
                {
                    parentNode = new TreeNode();
                    parentNode.Text = dr.ItemArray[1].ToString();
                    parentNode.Name = dr.ItemArray[0].ToString();
                    parentNode.Tag = dr.ItemArray[2].ToString();

                    tvListTram.Nodes.Add(parentNode);
                    addGroupNode(parentNode, nameStation);

                }

                tvListTram.ExpandAll();
                tvListTram.Update();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        private void addGroupNode(TreeNode parentNode, string nameStation)
        {
            String sqlSelectKV = " SELECT sg.ID, sg.Name FROM Station s left join StationGroup sg on sg.ID = s.StationGroupID WHERE s.KV_ID = '" + parentNode.Name.ToString() + "' group by sg.ID, sg.Name";
            //String sqlSelectKV = " SELECT * FROM DANHSACHTB tb ";
            DataTable dtChild = PDatatable(sqlSelectKV.ToString());

            TreeNode childNode;
            foreach (DataRow dr in dtChild.Rows)
            {
                if (parentNode == null)
                {
                    childNode = tvListTram.Nodes.Add(dr["Name"].ToString());
                }
                else
                {
                    childNode = new TreeNode();
                    childNode.Tag = dr["ID"].ToString();
                    childNode.Name = dr["ID"].ToString();
                    childNode.Text = dr["Name"].ToString();
                    parentNode.Nodes.Add(childNode);
                    addChildNode(childNode, nameStation);
                }

            }
        }


        private void addChildNode(TreeNode parentNode, string nameStation)
        {
            StringBuilder sqlSelectKV = new StringBuilder(" SELECT ID, Name, Lat, Lng FROM Station tb WHERE tb.StationGroupID = '"  + parentNode.Name.ToString() + "'");
            if (!string.IsNullOrEmpty(nameStation)) {
                sqlSelectKV.Append("  AND tb.Name Like @name ");
            }
            //String sqlSelectKV = " SELECT * FROM DANHSACHTB tb ";
            DataTable dtChild = new DataTable();
            SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
            name.Value = "%" + nameStation + "%";

            SqlCommand query = new SqlCommand(sqlSelectKV.ToString());
            query.Parameters.Add(name);
            query.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(query);
            da.Fill(dtChild);
            
            TreeNode childNode;
            foreach (DataRow dr in dtChild.Rows)
            {
                if (parentNode == null)
                {
                    childNode = tvListTram.Nodes.Add(dr["Name"].ToString());
                }
                else {                    
                    childNode = new TreeNode();
                    childNode.Tag = dr["ID"].ToString();
                    childNode.Name = dr["ID"].ToString();
                    childNode.Text = dr["Name"].ToString();
                    parentNode.Nodes.Add(childNode);
                    loadOnMap(dr["ID"].ToString(), dr["Lat"].ToString(), dr["Lng"].ToString());
                    //addChildNode(childNode);
                }
                 
            }
        }

        private void loadOnMap(String id, String lat, String lng)
        {
            apsuat = apsuat + 10;
            luuluong = luuluong + 30;
            Battery = Battery - 0.5;

            GMapOverlay item = new GMapOverlay("markers");

            GMarkerGoogle markerone = new GMarkerGoogle(new PointLatLng(Double.Parse(lat), Double.Parse(lng)), GMarkerGoogleType.green)
            {
                Tag = id,
                ToolTipMode = MarkerTooltipMode.OnMouseOver,      
            };

            MarkerTooltipMode mode = MarkerTooltipMode.Always;
            markerone.ToolTip = new GMapBaloonToolTip(markerone);
            markerone.ToolTipMode = mode;
            //Brush ToolTipBackColor = new SolidBrush(Color.Transparent);
            //markerone.ToolTip.Fill = ToolTipBackColor;

            markerone.ToolTip.Fill = Brushes.Gray;
            markerone.ToolTip.Foreground = Brushes.White;
            markerone.ToolTip.Stroke = Pens.Black;
            markerone.ToolTip.TextPadding = new Size(20, 20);
            markerone.ToolTipText = "Áp suất : " + apsuat + " BAR" + "\r\n Lưu lượng: " + luuluong  + " m3/h" + "\r\n Battery :" + Battery + " VDC";
            markerone.ToolTip.Format.Alignment = StringAlignment.Center;
           
            item.Markers.Add(markerone);
            Markers.Add(markerone);
            this.gmap.Overlays.Add(item);
        }

          public void TreeClick(object sender, TreeNodeMouseClickEventArgs e)
        {

           
            /*DataTable dt = new Provider().Loading("select c.lat , c.lon , co.english , 
						c.city from cities as c " +
                                                  "inner join countries as co " +
                                                  "on c.country_id = co.id " +
                                                    "and c.city = '" + e.Node.Text + "'");
            if (dt.Rows.Count > 0)
            {
                string marker = "marker.png";
                string image = "image.png";
                string path = Application.StartupPath + "\\map.html";
                this.Text = path;
                string filename = Application.StartupPath + "\\mymap.html";
                DataRow r = dt.Rows[0];
                variables.replace(filename, r["lat"].ToString(), r["lon"].ToString(),
                                    r["english"].ToString(), r["city"].ToString(),
                                    marker, image, path);
                this.webBrowser1.Url = new Uri(path);
            }
            */
        }

        private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (currentMarker != null)
            {
                currentMarker.ToolTip.Fill = Brushes.Gray;
            }

            if (currentMarkerMap != null) {
                currentMarkerMap.ToolTip.Fill = Brushes.Gray;
            }

            currentMarkerMap = item;
            item.ToolTip.Fill = Brushes.Brown;
            this.gmap.Position = new PointLatLng(item.Position.Lat, item.Position.Lng);
            //Usage    
            TreeNode itemNode = null;
            foreach (TreeNode node in tvListTram.Nodes)
            {
                itemNode = FromID(item.Tag.ToString(), node);               
                tvListTram.Focus();
                if (itemNode != null) {
                    tvListTram.SelectedNode = itemNode;                    
                }
            }

            //var result = tvListTram.Nodes.OfType<TreeNode>()
            //                .FirstOrDefault(node => node.Tag.Equals(item.Tag));
            //MessageBox.Show(result.Text);
            //DialogResult dialogResult = MessageBox.Show("Ap Suat : 11223 \r\n Luu luong: 1700 \r\n Battery : 12 VDC", "Station Info", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    //do something
            //}
            //else if (dialogResult == DialogResult.No)
            //{
            //    //do something else
            //}
        }

        public TreeNode FromID(string itemId, TreeNode rootNode)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (node.Tag.Equals(itemId)) {
                    return node;
                }           
            }
            return null;
        }


        public void connectDB()
        {
            try
            {
                con = new SqlConnection(cs);
                con.Open();                        
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected DataTable PDatatable(string Select_Statement)
        {
            try
            {
                SqlCommand query = new SqlCommand(Select_Statement);
                query.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(query);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        public bool ShowTileGridLines { get; set; }

        private void tvListTram_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (currentMarker != null)
            {
                currentMarker.ToolTip.Fill = Brushes.Gray;
            }

            if (currentMarkerMap != null)
            {
                currentMarkerMap.ToolTip.Fill = Brushes.Gray;
            }

            var result = Markers.Where(x => x.Tag.Equals(e.Node.Tag)).FirstOrDefault();
            if (result != null) {
                currentMarker = (GMarkerGoogle)result;
                result.ToolTip.Fill = Brushes.Brown;
                this.gmap.Position = new PointLatLng(result.Position.Lat, result.Position.Lng);
            }

            tvListTram.SelectedNode = e.Node;
            tvListTram.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.gmap.Overlays.Clear() ;
            apsuat = 33;
            luuluong = 2450;
            Battery = 12.5;
            loadTreeView(textBox1.Text);  
        }
    }
}
