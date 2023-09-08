using GMap.NET.MapProviders;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.gMapControl1.MapProvider = OpenStreet4UMapProvider.Instance; // Устанавливаем источник карты
            GMaps.Instance.Mode = AccessMode.ServerAndCache; // Режим работы GMap
            //this.gMapControl1.SetPositionByKeywords("Moscow"); // положение центра карты

            // Используйте широту и долготу, чтобы установить центр карты
            this.gMapControl1.Position = new GMap.NET.PointLatLng(39.923518, 116.539009);

        }
    }
}
