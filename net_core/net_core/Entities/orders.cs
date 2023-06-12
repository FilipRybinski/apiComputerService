namespace net_core.Entities
{
    public class orders
    {
        public int id { get; set; }
        public DateTime accept_date { get; set; }
        public string description { get; set; }
        public bool completed { get; set; }
        public string email { get; set; }
        public int wycena { get; set; }
        public string date_collect { get; set; }
    }
}
