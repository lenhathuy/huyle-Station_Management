using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using GMap.NET.WindowsForms.ToolTips;

namespace MVCView
{
    public partial class Test : Form
    {
        private SqlConnection con;
        TreeNode parentNode = null;

        public Test()
        {
            InitializeComponent();
            connectDB();
        }

        //Connection String
        string cs = ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;

        private void Test_Load(object sender, EventArgs e)
        {
            loadTreeView();            
        }

        private void loadTreeView()
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
            tvListTram.NodeMouseClick += new TreeNodeMouseClickEventHandler(TreeClick);
            tvListTram.Update();
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
                    childNode.Name = dr["ID"].ToString();
                    childNode.Text = dr["TENTB"].ToString();
                    parentNode.Nodes.Add(childNode);
                    loadOnMap(dr["Latitude"].ToString(), dr["Longitude"].ToString());
                    //addChildNode(childNode);
                }
                 
            }
        }

        private void loadOnMap(String lat, String lng)
        {
            this.gmap.MapProvider = BingMapProvider.Instance;
            Singleton<GMaps>.Instance.Mode = AccessMode.ServerOnly;
            this.gmap.Position = new PointLatLng(16.481909, 107.590226);
            this.gmap.ShowCenter = false;
            this.gmap.CanDragMap = true;
            this.gmap.DragButton = MouseButtons.Left;
            GMapOverlay item = new GMapOverlay("markers");


            GMarkerGoogle markerone = new GMarkerGoogle(new PointLatLng(Double.Parse(lat), Double.Parse(lng)), GMarkerGoogleType.green)
            {
                Tag = "",
                ToolTipMode = MarkerTooltipMode.OnMouseOver,      
            };

            /*MarkerTooltipMode mode = MarkerTooltipMode.Always;
            markerone.ToolTip = new GMapBaloonToolTip(markerone);
            markerone.ToolTipMode = mode;
            Brush ToolTipBackColor = new SolidBrush(Color.Transparent);
            markerone.ToolTip.Fill = ToolTipBackColor ;
            markerone.ToolTipText = "Huy Tests";
             */
            item.Markers.Add(markerone);
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
            //MessageBox.Show(item.Tag.ToString());
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
    }
}
