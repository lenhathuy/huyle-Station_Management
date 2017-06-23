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

namespace MVCView
{
    public partial class Test : Form
    {
        private SqlConnection con;
        TreeNode parentNode = null;
        ObservableCollection<GMapMarker> Markers;
        GMarkerGoogle currentMarker = null;
        GMapMarker currentMarkerMap = null;

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
            loadTreeView();    
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

        private void loadTreeView()
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
                    addChildNode(parentNode);

                }

                tvListTram.ExpandAll();
                tvListTram.Update();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        private void addChildNode(TreeNode parentNode)
        {
            String sqlSelectKV = " SELECT ID, TENTB, Latitude, Longitude FROM DANHSACHTB tb WHERE tb.MAKV = '"  + parentNode.Name.ToString() + "'";
            //String sqlSelectKV = " SELECT * FROM DANHSACHTB tb ";
            DataTable dtChild = PDatatable(sqlSelectKV.ToString()); 
            
            TreeNode childNode;
            foreach (DataRow dr in dtChild.Rows)
            {
                if (parentNode == null)
                {
                    childNode = tvListTram.Nodes.Add(dr["TENTB"].ToString());
                }
                else {                    
                    childNode = new TreeNode();
                    childNode.Tag = dr["ID"].ToString();
                    childNode.Name = dr["ID"].ToString();
                    childNode.Text = dr["TENTB"].ToString();
                    parentNode.Nodes.Add(childNode);
                    loadOnMap(dr["ID"].ToString(), dr["Latitude"].ToString(), dr["Longitude"].ToString());
                    //addChildNode(childNode);
                }
                 
            }
        }

        private void loadOnMap(String id, String lat, String lng)
        {         
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
            markerone.ToolTipText = "Ap Suat : 11223 \r\n Luu luong: 1700 \r\n Battery : 12 VDC";
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

            var result = Markers.Where(x => x.Tag == e.Node.Tag).FirstOrDefault();
            if (result != null) {
                currentMarker = (GMarkerGoogle)result;
                result.ToolTip.Fill = Brushes.Brown;
                this.gmap.Position = new PointLatLng(result.Position.Lat, result.Position.Lng);
            }
        }
    }
}
