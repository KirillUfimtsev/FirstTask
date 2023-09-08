using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Device.Location;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task1.Data;
using Task1.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Task1
{
    public partial class Form1 : Form
    {
        private MarkerRepository markerRepo = new MarkerRepository();

        List<Marker> markers= new List<Marker>();
        
        private bool isLeftButtonDown = false;

        private Marker currentMarker;
        private GMapMarker currentGMapMarker;

        GMapOverlay markersOverlay = new GMap.NET.WindowsForms.GMapOverlay();
        public Form1()
        {
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = ArcGIS_World_Street_MapProvider.Instance;

            gMapControl1.CanDragMap= true;
            gMapControl1.MarkersEnabled = true;
            gMapControl1.DragButton = MouseButtons.Right;
            gMapControl1.MouseWheelZoomEnabled= true;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.Position = new GMap.NET.PointLatLng(55, 83);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 10;
            gMapControl1.Bearing = 0;

            gMapControl1.MouseClick += new MouseEventHandler(mapControl_MouseClick);
            gMapControl1.MouseDown += new MouseEventHandler(mapControl_MouseDown);
            gMapControl1.MouseUp += new MouseEventHandler(mapControl_MouseUp);
            gMapControl1.MouseMove += new MouseEventHandler(mapControl_MouseMove);
            gMapControl1.OnMarkerEnter += new MarkerEnter(mapControl_OnMarkerEnter);

            fiilMap();
        }
        private void fiilMap()
        {
            markers = markerRepo.getAllMarkers().ToList();

            foreach (Marker marker in markers)
            {
                GMap.NET.WindowsForms.Markers.GMarkerGoogle markerG =
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                new GMap.NET.PointLatLng(marker.Latitude, marker.Longitude), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot);
                markerG.ToolTip =
                new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(markerG);

                markerG.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(markerG);

                markerG.ToolTipMode = GMap.NET.WindowsForms.MarkerTooltipMode.Always;

                markersOverlay.Markers.Add(markerG);
            }
            gMapControl1.Overlays.Clear();
            gMapControl1.Overlays.Add(markersOverlay);
        }
        
        private void gMapControl1_OnMarkerDoubleClick(GMap.NET.WindowsForms.GMapMarker item, MouseEventArgs e)
        {
            gMapControl1.Position = new GMap.NET.PointLatLng(item.Position.Lat, item.Position.Lng);
            gMapControl1.Zoom = 17;
            gMapControl1.Refresh();
        }

        void mapControl_MouseMove(object sender, MouseEventArgs e)
        {
            //Проверка, что нажата ЛКМ
            if (e.Button == MouseButtons.Left && isLeftButtonDown)
            {
                if (currentMarker != null)
                {
                    currentGMapMarker.Position = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                    currentMarker.Latitude = currentGMapMarker.Position.Lat;  
                    currentMarker.Longitude = currentGMapMarker.Position.Lng;  
                }
            }
        }

        void mapControl_MouseUp(object sender, MouseEventArgs e)
        {
            {
                if(currentMarker != null)
                {
                    var point = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                    var lat = point.Lat;
                    var lng = point.Lng;
                    markerRepo.updateMarker(currentMarker.ID, lat, lng);
                }
                isLeftButtonDown = false;
                currentMarker = null;
                currentGMapMarker= null;
            }         
        }

        void mapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isLeftButtonDown = true;
        }

        void mapControl_OnMarkerEnter(GMapMarker item)
        {
            
            if (item is GMapMarker && !isLeftButtonDown)
            {
                currentGMapMarker= item;
                currentMarker = new Marker(new PointLatLng(item.Position.Lat,item.Position.Lng));

                if (currentMarker != null)
                {
                    var lat = currentMarker.Position.Lat;
                    var lng = currentMarker.Position.Lng;
                    try
                    {
                        currentMarker.ID = markers.Where(p => p.Latitude == lat && p.Longitude == lng).First().ID;
                    }
                    catch { } 
                }

            }
        }

        void mapControl_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void btnAddMarker_Click(object sender, EventArgs e)
        {
            GMap.NET.WindowsForms.Markers.GMarkerGoogle markerG =
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                new GMap.NET.PointLatLng(gMapControl1.Position.Lat, gMapControl1.Position.Lng), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot);
            markerG.ToolTip =
            new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(markerG);

            markerG.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(markerG);

            markerG.ToolTipMode = GMap.NET.WindowsForms.MarkerTooltipMode.Always;

            markersOverlay.Markers.Add(markerG);
            gMapControl1.Overlays.Add(markersOverlay);

            markerRepo.addMarker(gMapControl1.Position.Lat.ToString(), gMapControl1.Position.Lng.ToString());
        }

        private void gMapControl1_OnMarkerLeave(GMapMarker item)
        {

            currentGMapMarker= null;
            currentMarker = null;
        }
    }
}
