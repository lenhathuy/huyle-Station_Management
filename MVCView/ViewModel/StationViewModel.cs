namespace MVCView.ViewModel
{
    public class StationViewModel
    {
        /// <summary>
        /// Group
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Station code
        /// </summary>
        public string StationCode { get; set; }

        /// <summary>
        /// Station name
        /// </summary>
        public string StationName { get; set; }

        /// <summary>
        /// Station location
        /// </summary>
        public string StationLocation { get; set; }

        /// <summary>
        /// Station latitude
        /// </summary>
        public float StationLatitude { get; set; }

        /// <summary>
        /// Station longtitude
        /// </summary>
        public float StationLongtitude { get; set; }

        /// <summary>
        /// Cooordinates
        /// </summary>
        public string Coordinates
        {
            get
            {
                return string.Concat(StationLatitude, ",", StationLongtitude);
            }
        }
    }
}
