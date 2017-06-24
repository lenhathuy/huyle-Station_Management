namespace MVCView.ViewModel
{
    /// <summary>
    /// Base Station View Model
    /// </summary>
    public class BaseStationViewModel
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

      
    }

    /// <summary>
    /// Station View Model
    /// </summary>
    public class StationViewModel : BaseStationViewModel
    {

        public int StationID { get; set; }

        public int GroupID { get; set; }
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

    /// <summary>
    /// Station value view model
    /// </summary>
    public class StationValueViewModel: BaseStationViewModel
    {
        /// <summary>
        /// The channel
        /// </summary>
        public int Channel { get; set; }

        /// <summary>
        /// The value
        /// </summary>
        public float Value { get; set; }

        /// <summary>
        /// The yype
        /// </summary>
        public int Type { get; set; }

        public int StationID { get; set; }
    }
}
