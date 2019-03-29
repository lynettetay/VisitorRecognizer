using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisitorRecognizer.Models
{
    public class VehicleRegion
    {
        public int y { get; set; }
        public int x { get; set; }
        public int height { get; set; }
        public int width { get; set; }
    }

    public class Candidate
    {
        public int matches_template { get; set; }
        public string plate { get; set; }
        public double confidence { get; set; }
    }

    public class Coordinate
    {
        public int y { get; set; }
        public int x { get; set; }
    }

    public class BestPlate
    {
        public string plate { get; set; }
        public double confidence { get; set; }
        public int region_confidence { get; set; }
        public VehicleRegion vehicle_region { get; set; }
        public string region { get; set; }
        public int plate_index { get; set; }
        public double processing_time_ms { get; set; }
        public IList<Candidate> candidates { get; set; }
        public IList<Coordinate> coordinates { get; set; }
        public int matches_template { get; set; }
        public int requested_topn { get; set; }
    }

    public class Orientation
    {
        public double confidence { get; set; }
        public string name { get; set; }
    }

    public class Color
    {
        public double confidence { get; set; }
        public string name { get; set; }
    }

    public class Make
    {
        public double confidence { get; set; }
        public string name { get; set; }
    }

    public class BodyType
    {
        public double confidence { get; set; }
        public string name { get; set; }
    }

    public class Year
    {
        public double confidence { get; set; }
        public string name { get; set; }
    }

    public class MakeModel
    {
        public double confidence { get; set; }
        public string name { get; set; }
    }

    public class Vehicle
    {
        public IList<Orientation> orientation { get; set; }
        public IList<Color> color { get; set; }
        public IList<Make> make { get; set; }
        public IList<BodyType> body_type { get; set; }
        public IList<Year> year { get; set; }
        public IList<MakeModel> make_model { get; set; }
    }

    public class WebServerConfig
    {
        public string agent_label { get; set; }
        public string camera_label { get; set; }
    }

    public class cData
    {
        public long epoch_start { get; set; }
        public int camera_id { get; set; }
        public int frame_start { get; set; }
        public string agent_uid { get; set; }
        public double best_confidence { get; set; }
        public string company_id { get; set; }
        public int version { get; set; }
        public string agent_type { get; set; }
        public BestPlate best_plate { get; set; }
        public Vehicle vehicle { get; set; }
        public string best_uuid { get; set; }
        public long epoch_end { get; set; }
        public int best_image_width { get; set; }
        public string data_type { get; set; }
        public int best_image_height { get; set; }
        public int frame_end { get; set; }
        public bool is_parked { get; set; }
        public WebServerConfig web_server_config { get; set; }
        public string best_region { get; set; }
        public IList<string> uuids { get; set; }
        public IList<int> plate_indexes { get; set; }
        public double travel_direction { get; set; }
        public string country { get; set; }
        public string best_plate_number { get; set; }
        public double best_region_confidence { get; set; }
        public string agent_version { get; set; }
        public IList<Candidate> candidates { get; set; }
    }
}